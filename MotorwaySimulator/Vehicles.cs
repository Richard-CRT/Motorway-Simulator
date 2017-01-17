using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorwaySimulator
{
    public class Vehicle
    {

        public bool InSight = true;
        public int VehicleId;

        public int VehicleWidth;
        public int VehicleHeight;
        public Size VehicleSize;

        public double DesiredSpeedMetresHour;
        public double DesiredSpeedPixelsHour;
        public double ActualSpeedMetresHour;
        public double ActualSpeedPixelsHour;

        public double ExactLocationY;
        public int LocationY;

        public long LastTimerValue;

        public string Type;

        public MotorwaySimulator MainForm;
        public LaneControl ParentLane;

        public void LaneTick()
        {
            //  Try to get into lane n-1 [will need to make sure vehicle does not instantly move back into n after moving into n+1]
            //  If going slower than desired
            //      If going slower caused by vehicle ahead
            //          Try to get into lane n+1
            //      Else
            //          Change speed

            #region Change Lane n-1
            if (this.ParentLane.LaneId != 0)
            {
                // Not in Lane 1
                LaneControl leftLane = this.MainForm.Lanes[this.ParentLane.LaneId - 1];
                bool spaceInLane = leftLane.SpaceInLane(this);
                if (spaceInLane)
                {
                    leftLane.Vehicles.Add(this);
                    this.ParentLane.Vehicles.Remove(this);
                    this.ParentLane = leftLane;
                }
            }
            #endregion

            #region Change Speed
            Vehicle nextVehicle = ParentLane.NextVehicle(this);

            if (nextVehicle != null)
            {
                // vehicle in front

                int backOfNextVehicle = nextVehicle.LocationY + nextVehicle.VehicleHeight;
                int projectedDesiredStopppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(ParentLane.StoppingDistance(this.DesiredSpeedMetresHour)), 0);
                if (this.LocationY - projectedDesiredStopppingDistancePixels <= backOfNextVehicle)
                {
                    // desired safety distance is overlapping
                    if (nextVehicle.ActualSpeedMetresHour < this.ActualSpeedMetresHour)
                    {
                        //  next vehicle slower than this vehicle
                        int stoppingDistanceChangeByChangingSpeedsPixels = projectedDesiredStopppingDistancePixels - (int)Math.Round(MainForm.MetresToPixels(ParentLane.StoppingDistance(nextVehicle.ActualSpeedMetresHour)));

                        if ((this.LocationY - projectedDesiredStopppingDistancePixels) <= (backOfNextVehicle - stoppingDistanceChangeByChangingSpeedsPixels))
                        {
                            // Stopping distance overlaps at (back of next vehicle - margin)
                            // Adjust speed to match that of vehicle ahead
                            this.ActualSpeedMetresHour = nextVehicle.ActualSpeedMetresHour;
                            this.ActualSpeedPixelsHour = nextVehicle.ActualSpeedPixelsHour;
                        }
                    }
                }
                else if (this.LocationY - projectedDesiredStopppingDistancePixels > backOfNextVehicle + (projectedDesiredStopppingDistancePixels*0.1)) // add 10% margin 1) for realism (haha) 2) fix pixeling flashing bug
                {
                    // stopping distance does not overlap

                    this.ActualSpeedMetresHour = this.DesiredSpeedMetresHour;
                    this.ActualSpeedPixelsHour = this.DesiredSpeedPixelsHour;
                }
            }
            else
            {
                // road clear ahead

                this.ActualSpeedMetresHour = this.DesiredSpeedMetresHour;
                this.ActualSpeedPixelsHour = this.DesiredSpeedPixelsHour;
            }
            #endregion
        }

        public void MovementTick()
        {
            if (this.InSight)
            {
                long tempTime = MainForm.Timer.ElapsedMilliseconds;
                long elapsedTime = tempTime - LastTimerValue;
                LastTimerValue = tempTime;
                double scaledElapsedTime = elapsedTime * MainForm.TimeScale;

                //  Try to get into lane n-1 [will need to make sure vehicle does not instantly move back into n after moving into n+1]
                //  If going slower than desired
                //      If going slower caused by vehicle ahead
                //          Try to get into lane n+1
                //      Else
                //          Change speed

                #region Move Forward
                double pixelsMoved = MainForm.PixelHoursToPixelTicks(ActualSpeedPixelsHour, scaledElapsedTime);
                ExactLocationY -= pixelsMoved;
                LocationY = (int)Math.Round(ExactLocationY,0);
                #endregion
            }
            if (ExactLocationY <= -VehicleHeight)
            {
                InSight = false;
            }
        }

        public void GenerateSize(string vehicleType)
        {
            double lengthVariation = (MainForm.Random.NextDouble() * MainForm.VehicleParameters[vehicleType].LengthVariation * 2) - MainForm.VehicleParameters[vehicleType].LengthVariation;

            this.VehicleWidth = MainForm.VehicleWidth;
            this.VehicleHeight = (int)Math.Round(MainForm.MetresToPixels(MainForm.VehicleParameters[vehicleType].Length + lengthVariation), 0);
            this.VehicleSize = new Size(this.VehicleWidth, this.VehicleHeight);
        }

        public void GenerateDesiredSpeed(string vehicleType)
        {
            double speedVariation = (MainForm.Random.NextDouble() * MainForm.VehicleParameters[vehicleType].DesiredSpeedVariation * 2) - MainForm.VehicleParameters[vehicleType].DesiredSpeedVariation;

            int speedMetresHour = (int) Math.Round(MainForm.VehicleParameters[vehicleType].DesiredSpeed + speedVariation,0);
            this.DesiredSpeedMetresHour = speedMetresHour;
            this.ActualSpeedMetresHour = speedMetresHour;

            double speedPixelsHour = MainForm.MetresToPixels(speedMetresHour);
            this.DesiredSpeedPixelsHour = speedPixelsHour;
            this.ActualSpeedPixelsHour = speedPixelsHour;
        }
    }

    // ##############################################################################################

    public class Car : Vehicle
    {
        public Car (MotorwaySimulator mainForm, int vehicleId)
        {
            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.Type = "Car";
            this.ParentLane = null;

            GenerateDesiredSpeed("Car");
            GenerateSize("Car");

            this.ExactLocationY = mainForm.RoadLength;
            this.LocationY = mainForm.RoadLength;
        }
    }

    public class LGV : Vehicle
    {
        public LGV (MotorwaySimulator mainForm, int vehicleId)
        {
            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.Type = "LGV";
            this.ParentLane = null;

            GenerateDesiredSpeed("LGV");
            GenerateSize("LGV");

            this.ExactLocationY = mainForm.RoadLength;
            this.LocationY = mainForm.RoadLength;
        }
    }

    public class HGV : Vehicle
    {
        public HGV (MotorwaySimulator mainForm, int vehicleId)
        {
            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.Type = "HGV";
            this.ParentLane = null;

            GenerateDesiredSpeed("HGV");
            GenerateSize("HGV");

            this.ExactLocationY = mainForm.RoadLength;
            this.LocationY = mainForm.RoadLength;
        }
    }

    public class Bus : Vehicle
    {
        public Bus (MotorwaySimulator mainForm, int vehicleId)
        {
            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.Type = "Bus";
            this.ParentLane = null;

            GenerateDesiredSpeed("Bus");
            GenerateSize("Bus");

            this.ExactLocationY = mainForm.RoadLength;
            this.LocationY = mainForm.RoadLength;
        }
    }
}
