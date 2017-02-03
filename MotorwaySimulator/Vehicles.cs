using CustomControls;
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
        public bool InEffect = true;

        public int VehicleId;
        public int VehicleWidth;
        public int VehicleHeight;
        public VehicleTypes VehicleType;

        public double DesiredSpeedMetresHour;
        public double DesiredSpeedPixelsHour;
        public double ActualSpeedMetresHour;
        public int ActualSpeedKilometresHour
        {
            get
            {
                return (int)Math.Round(DesiredSpeedMetresHour / 1000,0);
            }
        }
        public double ActualSpeedPixelsHour;

        public bool IsTravellingAtDesiredSpeed
        {
            get
            {
                return DesiredSpeedMetresHour == ActualSpeedMetresHour;
            }
        }

        public double ExactProgress;
        public int Progress;

        public long LastTimerValue;

        public MotorwaySimulatorForm MainForm;
        public LaneControl ParentLane;

        public void LaneTick()
        {
            //  Try to get into lane n-1 [will need to make sure vehicle does not instantly move back into n after moving into n+1]
            //  If going slower than desired
            //      If going slower caused by vehicle ahead
            //          Try to get into lane n+1
            //      Else
            //          Change speed

            #region Change Speed
            Vehicle nextVehicle = ParentLane.NextVehicle(this);

            if (nextVehicle != null)
            {
                // vehicle in front

                int backOfNextVehicle = nextVehicle.Progress - nextVehicle.VehicleHeight;
                int projectedDesiredStopppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(this.DesiredSpeedMetresHour)), 0);
                if (this.Progress + projectedDesiredStopppingDistancePixels >= backOfNextVehicle)
                {
                    // desired safety distance is overlapping
                    if (nextVehicle.ActualSpeedMetresHour < this.ActualSpeedMetresHour)
                    {
                        //  next vehicle slower than this vehicle
                        int stoppingDistanceChangeByChangingSpeedsPixels = projectedDesiredStopppingDistancePixels - (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(nextVehicle.ActualSpeedMetresHour)));

                        if ((this.Progress + projectedDesiredStopppingDistancePixels) >= (backOfNextVehicle + stoppingDistanceChangeByChangingSpeedsPixels))
                        {
                            // Stopping distance overlaps at (back of next vehicle - margin)
                            // Adjust speed to match that of vehicle ahead
                            this.ActualSpeedMetresHour = nextVehicle.ActualSpeedMetresHour;
                            this.ActualSpeedPixelsHour = nextVehicle.ActualSpeedPixelsHour;
                        }
                    }
                }
                else if (this.Progress + projectedDesiredStopppingDistancePixels < backOfNextVehicle - (projectedDesiredStopppingDistancePixels * 0.1)) // add 10% margin fix pixeling flashing bug
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

            #region Change Lane n+1
            if (this.ParentLane.LaneId != this.MainForm.LaneCount-1 && !this.IsTravellingAtDesiredSpeed)
            {
                // Not in Lane n
                LaneControl rightLane = this.MainForm.Lanes[this.ParentLane.LaneId + 1];
                bool spaceInLane = rightLane.SpaceInLane(this);
                if (spaceInLane)
                {
                    rightLane.Vehicles.Add(this);
                    this.ParentLane.Vehicles.Remove(this);
                    this.ParentLane = rightLane;
                }
            }
            #endregion
        }

        public void MovementTick()
        {
            if (this.InEffect)
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
                ExactProgress += pixelsMoved;
                Progress = (int)Math.Round(ExactProgress,0);
                #endregion
            }
            if (ExactProgress >= MainForm.RoadLengthPixels + this.VehicleHeight)
            {
                InSight = false;
            }
        }

        public void GenerateSize(VehicleTypes vehicleType)
        {
            double lengthVariation = (MainForm.Random.NextDouble() * MainForm.VehicleParameters[vehicleType].LengthVariation * 2) - MainForm.VehicleParameters[vehicleType].LengthVariation;

            this.VehicleWidth = MainForm.VehicleWidthPixels;
            this.VehicleHeight = (int)Math.Round(MainForm.MetresToPixels(MainForm.VehicleParameters[vehicleType].Length + lengthVariation), 0);
        }

        public void GenerateDesiredSpeed(VehicleTypes vehicleType)
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
        public Car (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.VehicleType = VehicleTypes.Car;
            this.ParentLane = null;

            GenerateDesiredSpeed(VehicleTypes.Car);
            GenerateSize(VehicleTypes.Car);

            double safetyDistanceLength = MainForm.MetresToPixels(mainForm.StoppingDistance(this.DesiredSpeedMetresHour));
            this.ExactProgress = -safetyDistanceLength;
            this.Progress = (int)Math.Round(-safetyDistanceLength, 0);
        }
    }

    public class LGV : Vehicle
    {
        public LGV (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.VehicleType = VehicleTypes.LGV;
            this.ParentLane = null;

            GenerateDesiredSpeed(VehicleTypes.LGV);
            GenerateSize(VehicleTypes.LGV);

            double safetyDistanceLength = MainForm.MetresToPixels(MainForm.StoppingDistance(this.DesiredSpeedMetresHour));
            this.ExactProgress = -safetyDistanceLength;
            this.Progress = (int)Math.Round(-safetyDistanceLength, 0);
        }
    }

    public class HGV : Vehicle
    {
        public HGV (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.VehicleType = VehicleTypes.HGV;
            this.ParentLane = null;

            GenerateDesiredSpeed(VehicleTypes.HGV);
            GenerateSize(VehicleTypes.HGV);

            double safetyDistanceLength = MainForm.MetresToPixels(MainForm.StoppingDistance(this.DesiredSpeedMetresHour));
            this.ExactProgress = -safetyDistanceLength;
            this.Progress = (int)Math.Round(-safetyDistanceLength, 0);
        }
    }

    public class Bus : Vehicle
    {
        public Bus (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.VehicleType = VehicleTypes.HGV;
            this.ParentLane = null;

            GenerateDesiredSpeed(VehicleTypes.HGV);
            GenerateSize(VehicleTypes.HGV);

            double safetyDistanceLength = MainForm.MetresToPixels(MainForm.StoppingDistance(this.DesiredSpeedMetresHour));
            this.ExactProgress = -safetyDistanceLength;
            this.Progress = (int)Math.Round(-safetyDistanceLength,0);
        }
    }
}
