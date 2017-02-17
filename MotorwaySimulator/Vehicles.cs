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
        public bool InSight;
        public bool InEffect;
        public TimeSpan TimeAppearance;
        public TimeSpan TimeDisappearance;

        public int VehicleId;
        public double VehicleHeightMetres;
        public int VehicleWidthPixels;
        public int VehicleHeightPixels;
        public VehicleTypes VehicleType;

        public double LifetimeMilliseconds;

        public int MaximumLane;

        public double DesiredSpeedMetresHour;
        public double DesiredSpeedPixelsHour;
        public double ActualSpeedMetresHour;
        public double ActualSpeedPixelsHour;
        public double AverageSpeedMetresHour;

        public bool IsTravellingAtDesiredSpeed
        {
            get
            {
                return DesiredSpeedMetresHour == ActualSpeedMetresHour;
            }
        }

        public bool SuccessfulSpawn
        {
            get
            {
                return ParentLane != null;
            }
        }

        public CongestionStates Congestion
        {
            get
            {
                if (this.DesiredSpeedMetresHour - this.AverageSpeedMetresHour > this.MainForm.SevereCongestionTriggerMetresHour)
                {
                    return CongestionStates.Severe;
                }
                else if (this.DesiredSpeedMetresHour - this.AverageSpeedMetresHour > this.MainForm.MildCongestionTriggerMetresHour)
                {
                    return CongestionStates.Mild;
                }
                else
                {
                    return CongestionStates.None;
                }
            }
        }

        public double ExactProgressPixels;
        public int ProgressPixels;
        public double ExactProgressMetres;

        public double OriginalDistanceOffsetMetres;

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

                int backOfNextVehicle = nextVehicle.ProgressPixels - nextVehicle.VehicleHeightPixels;
                int projectedDesiredStopppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(this.DesiredSpeedMetresHour)), 0);
                if (this.ProgressPixels + projectedDesiredStopppingDistancePixels >= backOfNextVehicle)
                {
                    // desired safety distance is overlapping
                    if (nextVehicle.ActualSpeedMetresHour < this.ActualSpeedMetresHour)
                    {
                        //  next vehicle slower than this vehicle
                        int stoppingDistanceChangeByChangingSpeedsPixels = projectedDesiredStopppingDistancePixels - (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(nextVehicle.ActualSpeedMetresHour)));

                        if ((this.ProgressPixels + projectedDesiredStopppingDistancePixels) >= (backOfNextVehicle + stoppingDistanceChangeByChangingSpeedsPixels))
                        {
                            // Stopping distance overlaps at (back of next vehicle - margin)
                            // Adjust speed to match that of vehicle ahead
                            this.ActualSpeedMetresHour = nextVehicle.ActualSpeedMetresHour;
                            this.ActualSpeedPixelsHour = nextVehicle.ActualSpeedPixelsHour;
                        }
                    }
                }
                else if (this.ProgressPixels + projectedDesiredStopppingDistancePixels < backOfNextVehicle - (projectedDesiredStopppingDistancePixels * 0.1)) // add 10% margin fix pixeling flashing bug
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
            if (this.ParentLane.LaneId != this.MainForm.ActiveLaneCount-1 && !this.IsTravellingAtDesiredSpeed && this.ParentLane.LaneId+1 < this.MaximumLane)
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
                double scaledElapsedTime = elapsedTime * this.MainForm.TimeScale;
                this.LifetimeMilliseconds += scaledElapsedTime;

                //  Try to get into lane n-1 [will need to make sure vehicle does not instantly move back into n after moving into n+1]
                //  If going slower than desired
                //      If going slower caused by vehicle ahead
                //          Try to get into lane n+1
                //      Else
                //          Change speed

                #region Move Forward
                double metresMoved = MainForm.PerHourToPerTick(ActualSpeedMetresHour, scaledElapsedTime);
                ExactProgressMetres += metresMoved;
                ExactProgressPixels += MainForm.MetresToPixels(metresMoved);
                ProgressPixels = (int)Math.Round(ExactProgressPixels,0);
                #endregion

                this.AverageSpeedMetresHour = (this.ExactProgressMetres + this.OriginalDistanceOffsetMetres) / (LifetimeMilliseconds / 1000 / 60 / 60);
            }
            if (ExactProgressMetres >= MainForm.ActiveRoadLengthMetres + this.VehicleHeightMetres)
            {
                InSight = false;
            }
        }

        public void GenerateSize(VehicleTypes vehicleType)
        {
            double lengthVariation = (MainForm.Random.NextDouble() * MainForm.VehicleParameters[vehicleType].LengthVariation * 2) - MainForm.VehicleParameters[vehicleType].LengthVariation;
            double length = MainForm.VehicleParameters[vehicleType].Length + lengthVariation;
            
            this.VehicleHeightMetres = length;
            this.VehicleWidthPixels = MainForm.VehicleWidthPixels;
            this.VehicleHeightPixels = (int)Math.Round(MainForm.MetresToPixels(length), 0);
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
            this.InSight = true;
            this.InEffect = true;

            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.VehicleType = VehicleTypes.Car;
            this.ParentLane = null;
            this.MaximumLane = mainForm.VehicleParameters[VehicleTypes.Car].MaximumLane;

            GenerateDesiredSpeed(VehicleTypes.Car);
            GenerateSize(VehicleTypes.Car);

            double safetyDistanceLength = mainForm.StoppingDistance(this.DesiredSpeedMetresHour);
            this.ExactProgressMetres = -safetyDistanceLength;
            this.ExactProgressPixels = MainForm.MetresToPixels(this.ExactProgressMetres);
            this.ProgressPixels = (int)Math.Round(this.ExactProgressPixels, 0);
            this.OriginalDistanceOffsetMetres = safetyDistanceLength;
        }
    }

    public class LGV : Vehicle
    {
        public LGV (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            this.InSight = true;
            this.InEffect = true;

            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.VehicleType = VehicleTypes.LGV;
            this.ParentLane = null;
            this.MaximumLane = mainForm.VehicleParameters[VehicleTypes.LGV].MaximumLane;

            GenerateDesiredSpeed(VehicleTypes.LGV);
            GenerateSize(VehicleTypes.LGV);

            double safetyDistanceLength = mainForm.StoppingDistance(this.DesiredSpeedMetresHour);
            this.ExactProgressMetres = -safetyDistanceLength;
            this.ExactProgressPixels = MainForm.MetresToPixels(this.ExactProgressMetres);
            this.ProgressPixels = (int)Math.Round(this.ExactProgressPixels, 0);
            this.OriginalDistanceOffsetMetres = safetyDistanceLength;
        }
    }

    public class HGV : Vehicle
    {
        public HGV (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            this.InSight = true;
            this.InEffect = true;

            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.VehicleType = VehicleTypes.HGV;
            this.ParentLane = null;
            this.MaximumLane = mainForm.VehicleParameters[VehicleTypes.HGV].MaximumLane;

            GenerateDesiredSpeed(VehicleTypes.HGV);
            GenerateSize(VehicleTypes.HGV);

            double safetyDistanceLength = mainForm.StoppingDistance(this.DesiredSpeedMetresHour);
            this.ExactProgressMetres = -safetyDistanceLength;
            this.ExactProgressPixels = MainForm.MetresToPixels(this.ExactProgressMetres);
            this.ProgressPixels = (int)Math.Round(this.ExactProgressPixels, 0);
            this.OriginalDistanceOffsetMetres = safetyDistanceLength;
        }
    }

    public class Bus : Vehicle
    {
        public Bus (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            this.InSight = true;
            this.InEffect = true;

            this.MainForm = mainForm;
            this.VehicleId = vehicleId;
            this.LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            this.VehicleType = VehicleTypes.Bus;
            this.ParentLane = null;
            this.MaximumLane = mainForm.VehicleParameters[VehicleTypes.Bus].MaximumLane;

            GenerateDesiredSpeed(VehicleTypes.Bus);
            GenerateSize(VehicleTypes.Bus);

            double safetyDistanceLength = mainForm.StoppingDistance(this.DesiredSpeedMetresHour);
            this.ExactProgressMetres = -safetyDistanceLength;
            this.ExactProgressPixels = MainForm.MetresToPixels(this.ExactProgressMetres);
            this.ProgressPixels = (int)Math.Round(this.ExactProgressPixels, 0);
            this.OriginalDistanceOffsetMetres = safetyDistanceLength;
        }
    }
}
