/* Included System Namespaces/Libraries */
using System;

// My namespace
namespace MotorwaySimulator
{
    /// <summary>
    /// Each instance of this class represents a vehicle
    /// </summary>
    public class Vehicle
    {

        #region Variable Declarations

        /* Vehicle Details */

        /// <summary>
        /// The ID of the vehicle
        /// </summary>
        public int VehicleId;
        /// <summary>
        /// The enum type of the vehicle (see the VehicleTypes enumerator of MotorwaySimulator.cs)
        /// </summary>
        public VehicleTypes VehicleType;
        /// <summary>
        /// The maximum lane that the vehicle can be in
        /// </summary>
        public int MaximumLane;


        /* State */

        /// <summary>
        /// Describes whether the vehicle is within the visible bounds of the road
        /// </summary>
        public bool InSight;
        /// <summary>
        /// Describes whether this vehicle has a vehicle behind it in the lane to the left, in the lane it is in or in the lane to right which is within the visible bounds of the road
        /// </summary>
        public bool InEffect;
        /// <summary>
        /// Describes whether this vehicle has crashed and will not be able to move anymore
        /// </summary>
        public bool Crashed;


        /* Spawning */

        /// <summary>
        /// Describes whether the vehicle successfully spawned
        /// </summary>
        public bool SuccessfulSpawn
        {
            get
            {
                return ParentLane != null;
            }
        }
        /// <summary>
        /// The scaled time of attempted appearance of the vehicle in milliseconds
        /// </summary>
        public double TimeAppearance;
        /// <summary>
        /// The scaled time of disappearance of the vehicle in miliseconds
        /// </summary>
        public double TimeDisappearance;


        /* Time */

        /// <summary>
        /// The lifetime of the vehicle in miliseconds
        /// </summary>
        public double LifetimeMilliseconds;
        /// <summary>
        /// The last timer value in milliseconds used to calculate delta-time for the movement algorithm
        /// </summary>
        public double LastStopwatchTimerValue;


        /* Dimensions */

        /// <summary>
        /// The length of the vehicle in metres
        /// </summary>
        public double VehicleLengthMetres;
        /// <summary>
        /// The length of the vehicle in pixels
        /// </summary>
        public int VehicleLengthPixels;
        /// <summary>
        /// The width of the vehicle in pixels
        /// </summary>
        public int VehicleWidthPixels;


        /* Speeds */

        /// <summary>
        /// The desired speed of the vehicle in metres per hour
        /// </summary>
        public double DesiredSpeedMetresHour;
        /// <summary>
        /// The actual speed of the vehicle in metres per hour
        /// </summary>
        public double ActualSpeedMetresHour;
        /// <summary>
        /// The average speed of the vehicle in metres per hour
        /// </summary>
        public double AverageSpeedMetresHour;
        /// <summary>
        /// Describes whether the vehicle is travelling at its desired speed
        /// </summary>
        public bool IsTravellingAtDesiredSpeed
        {
            get
            {
                return DesiredSpeedMetresHour == ActualSpeedMetresHour;
            }
        }
        /// <summary>
        /// The congestion state of the vehicle (see the CongestionStates enumerator of MotorwaySimulator.cs).
        /// Calculates the congestion each time it is accessed using a get function.
        /// </summary>
        public CongestionStates Congestion
        {
            get
            {
                if (DesiredSpeedMetresHour - ActualSpeedMetresHour >= MainForm.ActiveSevereCongestionTriggerMetresHour)
                {
                    return CongestionStates.Severe;
                }
                else if (DesiredSpeedMetresHour - ActualSpeedMetresHour >= MainForm.ActiveMildCongestionTriggerMetresHour)
                {
                    return CongestionStates.Mild;
                }
                else
                {
                    return CongestionStates.None;
                }
            }
        }


        /* Progress */

        /// <summary>
        /// The exact progress along the road in metres
        /// </summary>
        public double ExactProgressMetres;
        /// <summary>
        /// The approximate (rounded) progress along the road in pixels
        /// </summary>
        public int ProgressPixels;
        /// <summary>
        /// The starting offset so that the vehicle stopping distance starts at the beginning of the road in metres
        /// </summary>
        private double OriginalDistanceOffsetMetres;
        /// <summary>
        /// Describes whether this vehicle will crash
        /// </summary>
        public double CrashLocationMetres;


        /* Parent Objects */

        /// <summary>
        /// The object representing the parent lane which allows access to the lane's methods, properties and controls
        /// </summary>
        public LaneControl ParentLane;
        /// <summary>
        /// The main form object which allows access to the main form's methods, properties and controls
        /// </summary>
        private MotorwaySimulatorForm MainForm;

        #endregion

        #region Methods

        /// <summary>
        /// The method that is called every tick that controls the vehicle's speed and lane
        /// </summary>
        public void LaneTick()
        {
            if (!Crashed)
            {
                #region Change Speed

                // Get the vehicle ahead of this vehicle on the lane
                Vehicle nextVehicle = ParentLane.NextVehicle(this);

                if (nextVehicle != null)
                {
                    // There is a vehicle ahead of this vehicle

                    // Calculate the stopping distance of this vehicle at its actual speed
                    int projectedActualStoppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(ActualSpeedMetresHour)), 0);

                    // Calculate the back of the vehicle ahead of this vehicle
                    int backOfNextVehicle = nextVehicle.ProgressPixels - nextVehicle.VehicleLengthPixels;


                    if (ProgressPixels + projectedActualStoppingDistancePixels >= backOfNextVehicle)
                    {
                        // The stopping distance of this vehicle at its current speed overlaps the back of the next vehicle

                        if (nextVehicle.ActualSpeedMetresHour < ActualSpeedMetresHour)
                        {
                            // The vehicle ahead of this vehicle is travelling slower than this vehicle
                            // Therefore this vehicle can slow down, meaning the stopping distance can overlap

                            int stoppingDistanceNextVehiclePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(nextVehicle.ActualSpeedMetresHour)));

                            // Calculate the overlap allowed in pixels
                            int stoppingDistanceChangeByChangingSpeedsPixels = projectedActualStoppingDistancePixels - stoppingDistanceNextVehiclePixels;

                            if (ProgressPixels + projectedActualStoppingDistancePixels >= backOfNextVehicle + stoppingDistanceChangeByChangingSpeedsPixels)
                            {
                                // Stopping distance overlaps too far past the allowed overlap

                                // Match the speed of the vehicle ahead of this vehicle
                                ActualSpeedMetresHour = nextVehicle.ActualSpeedMetresHour;
                            }
                        }
                        else
                        {
                            // The vehicle ahead of this vehicle is travelling either at the same speed or faster than this vehicle
                            // Therefore this vehicle needs to stop to wait for the next vehicle to get far enough away

                            ActualSpeedMetresHour = 0;
                        }
                    }
                    else
                    {
                        // The stopping distance of this vehicle at its current speed does not overlap the back of the next vehicle

                        // Calculate the stopping distance of this vehicle at desired speed
                        int projectedDesiredStoppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(DesiredSpeedMetresHour)), 0);

                        if (ProgressPixels + (projectedDesiredStoppingDistancePixels * 1.1) < backOfNextVehicle)
                        {
                            // The stopping distance (plus an extra 10% margin to avoid quick switching between states) of this vehicle at desired speed does not overlap the back of the next vehicle

                            // Go to full desired speed
                            ActualSpeedMetresHour = DesiredSpeedMetresHour;
                        }
                    }
                }
                else
                {
                    // There is no vehicle ahead of this vehicle

                    // Go to full desired speed
                    ActualSpeedMetresHour = DesiredSpeedMetresHour;
                }

                #endregion

                #region Change Lane n-1

                if (ParentLane.LaneId != 0)
                {
                    // This vehicle is not in the left most lane

                    // Get the object of the lane to the left of the lane this vehicle is in
                    LaneControl leftLane = MainForm.Lanes[ParentLane.LaneId - 1];

                    // Calculate if there is space in the lane to the left
                    bool spaceInLane = leftLane.SpaceInLane(this);
                    if (spaceInLane)
                    {
                        // There is space in the lane to the left

                        // Switch lane to the left
                        leftLane.Vehicles.Add(this);
                        ParentLane.Vehicles.Remove(this);
                        ParentLane = leftLane;
                    }
                }

                #endregion

                #region Change Lane n+1

                if (ParentLane.LaneId != MainForm.ActiveLaneCount - 1 && !IsTravellingAtDesiredSpeed && ParentLane.LaneId + 1 < MaximumLane)
                {
                    // This vehicle is not in the right most lane, is not in its own maximum lane and is not travelling at its desired speed

                    // Get the object of the lane to the right of the lane this vehicle is in
                    LaneControl rightLane = MainForm.Lanes[ParentLane.LaneId + 1];

                    // Calculate if there is space in the lane to the right
                    bool spaceInLane = rightLane.SpaceInLane(this);
                    if (spaceInLane)
                    {
                        // There is space in the lane to the right

                        // Switch lane to the right
                        rightLane.Vehicles.Add(this);
                        ParentLane.Vehicles.Remove(this);
                        ParentLane = rightLane;
                    }
                }

                #endregion
            }
        }

        /// <summary>
        /// The method that is called every tick that controls the vehicle's movement
        /// </summary>
        public void MovementTick()
        {
            // Calculate the delta simulation time since the last tick
            double tempTime = MainForm.ScaledTimePassed;
            double scaledElapsedTime = tempTime - LastStopwatchTimerValue;
            LastStopwatchTimerValue = tempTime;

            // Increment the lifetime of this vehicle by the scaled elapsed time
            LifetimeMilliseconds += scaledElapsedTime;

            if (!Crashed)
            {
                #region Move Forward

                // Calculate the exact metres moved since the last tick
                double metresMoved = MainForm.PerHourToPerTick(ActualSpeedMetresHour, scaledElapsedTime);

                // Move the vehicle by the exact metres that it has moved since the last tick
                ExactProgressMetres += metresMoved;
                ProgressPixels = (int)Math.Round(MainForm.MetresToPixels(ExactProgressMetres), 0);

                #endregion
            }

            // Update the average speed from the new lifetime and progress along the road
            AverageSpeedMetresHour = (ExactProgressMetres + OriginalDistanceOffsetMetres) / (LifetimeMilliseconds / 1000 / 60 / 60);

            if (CrashLocationMetres != -1 && ExactProgressMetres > CrashLocationMetres)
            {
                ActualSpeedMetresHour = 0;
                Crashed = true;
            }

            if (ExactProgressMetres > MainForm.ActiveRoadLengthMetres + VehicleLengthMetres)
            {
                // The vehicle is not within the visible bounds of the road

                // Update the InSight variable
                InSight = false;
            }
        }

        /// <summary>
        /// The method that generates the size of the vehicle at creation time given the vehicle type
        /// </summary>
        /// <param name="vehicleType">The enum type of the vehicle that is being generated</param>
        public double GenerateSize(VehicleTypes vehicleType)
        {
            // Generate the plus or minus speed variation for this vehicle
            double lengthVariation = (MainForm.RandomGenerator.NextDouble() * MainForm.VehicleParameters[vehicleType].LengthVariation * 2) - MainForm.VehicleParameters[vehicleType].LengthVariation;

            // Calculate the length of this vehicle
            double length = MainForm.VehicleParameters[vehicleType].Length + lengthVariation;

            return length;
        }

        /// <summary>
        /// The method that generates the desired speed of the vehicle at creation time given the vehicle type
        /// </summary>
        /// <param name="vehicleType">The enum type of the vehicle that is being generated</param>
        public int GenerateDesiredSpeed(VehicleTypes vehicleType)
        {
            // Generate the plus or minus speed variation for this vehicle
            double speedVariation = (MainForm.RandomGenerator.NextDouble() * MainForm.VehicleParameters[vehicleType].DesiredSpeedVariation * 2) - MainForm.VehicleParameters[vehicleType].DesiredSpeedVariation;

            // Calculate the desired speed of this vehicle 
            int speedMetresHour = (int) Math.Round(MainForm.VehicleParameters[vehicleType].DesiredSpeed + speedVariation,0);

            return speedMetresHour;
        }

        /// <summary>
        /// Initialises the variables (default values, generates the size and desired speed) of the vehicle given the vehicle type
        /// Finally, it offsets the vehicle so the end of its stopping distance is at the beginning of the road
        /// </summary>
        /// <param name="type">The enum type of the vehicle that is being generated</param>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="vehicleId">The ID of the vehicle to construct</param>
        /// <param name="predeterminedVehicleLength">The (optional) predetermined vehicle length, used for debug mode</param>
        /// <param name="predeterminedDesiredSpeedMetresHour">The (optional) predetermined vehicle desired speed in metres per hour, used for debug mode</param>
        public void GenerateVehicle(VehicleTypes type, MotorwaySimulatorForm mainForm, int vehicleId, double predeterminedVehicleLength, double predeterminedDesiredSpeedMetresHour, double predeterminedCrashLocation)
        {
            // Instantiate the variables from the parameters and those that need initial values
            MainForm = mainForm;
            VehicleId = vehicleId;
            InSight = true;
            InEffect = true;
            VehicleType = type;
            MaximumLane = mainForm.VehicleParameters[type].MaximumLane;
            LastStopwatchTimerValue = mainForm.ScaledTimePassed;
            ParentLane = null;
            CrashLocationMetres = predeterminedCrashLocation;

            // Record the time of appearance
            TimeAppearance = mainForm.ScaledTimePassed;

            double length;
            if (predeterminedVehicleLength == 0)
            {
                // Generate the size of the vehicle
                length = GenerateSize(type);
            }
            else
            {
                length = predeterminedVehicleLength;
            }
            
            double rand = MainForm.RandomGenerator.NextDouble();
            
            if (rand < MainForm.VehicleParameters[type].CrashProbability)
            {
                rand = MainForm.RandomGenerator.NextDouble();
                // It will crash
                CrashLocationMetres = rand * MainForm.ActiveRoadLengthMetres;
            }

            // Assign the length and width of this vehicle
            VehicleLengthMetres = length;
            VehicleWidthPixels = MainForm.VehicleWidthPixels;
            VehicleLengthPixels = (int)Math.Round(MainForm.MetresToPixels(length), 0);

            double speedMetresHour;
            if (predeterminedDesiredSpeedMetresHour == 0)
            {
                // Generate the desired speed of the vehicle
                speedMetresHour = GenerateDesiredSpeed(type);
            }
            else
            {
                speedMetresHour = predeterminedDesiredSpeedMetresHour;
            }

            // Assign the desired speed and actual speed of this vehicle
            DesiredSpeedMetresHour = speedMetresHour;
            ActualSpeedMetresHour = speedMetresHour;

            // Offset the vehicle so the end of the stopping distance is at the beginning of the road
            double stoppingDistanceLength = mainForm.StoppingDistance(DesiredSpeedMetresHour);
            ExactProgressMetres = -stoppingDistanceLength;
            ProgressPixels += (int)Math.Round(MainForm.MetresToPixels(ExactProgressMetres), 0);
            OriginalDistanceOffsetMetres = stoppingDistanceLength;
        }

        #endregion

    }

    /// <summary>
    /// This class inherits from vehicle and allows me to instantiate a "Car" instead of instatiating a "Vehicle" while passing in the Car type.
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// This is the constructor for the Car class.
        /// It generates a vehicle using the Car enum type.
        /// </summary>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="vehicleId">The ID of the vehicle to construct</param>
        /// <param name="predeterminedVehicleLength">The (optional) predetermined vehicle length, used for debug mode</param>
        /// <param name="predeterminedDesiredSpeedMetresHour">The (optional) predetermined vehicle desired speed in metres per hour, used for debug mode</param>
        public Car (MotorwaySimulatorForm mainForm, int vehicleId, double predeterminedVehicleLength = 0, double predeterminedDesiredSpeedMetresHour = 0, double predeterminedCrashLocation = -1)
        {
            GenerateVehicle(VehicleTypes.Car, mainForm, vehicleId, predeterminedVehicleLength, predeterminedDesiredSpeedMetresHour, predeterminedCrashLocation);
        }
    }

    /// <summary>
    /// This class inherits from vehicle and allows me to instantiate a "LGV" instead of instatiating a "Vehicle" while passing in the LGV type.
    /// </summary>
    public class LGV : Vehicle
    {
        /// <summary>
        /// This is the constructor for the LGV class.
        /// It generates a vehicle using the LGV enum type.
        /// </summary>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="vehicleId">The ID of the vehicle to construct</param>
        public LGV (MotorwaySimulatorForm mainForm, int vehicleId, double predeterminedVehicleLength = 0, double predeterminedDesiredSpeedMetresHour = 0, double predeterminedCrashLocation = -1)
        {
            GenerateVehicle(VehicleTypes.LGV, mainForm, vehicleId, predeterminedVehicleLength, predeterminedDesiredSpeedMetresHour, predeterminedCrashLocation);
        }
    }

    /// <summary>
    /// This class inherits from vehicle and allows me to instantiate a "HGV" instead of instatiating a "Vehicle" while passing in the HGV type.
    /// </summary>
    public class HGV : Vehicle
    {
        /// <summary>
        /// This is the constructor for the HGV class.
        /// It generates a vehicle using the HGV type.
        /// </summary>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="vehicleId">The ID of the vehicle to construct</param>
        public HGV (MotorwaySimulatorForm mainForm, int vehicleId, double predeterminedVehicleLength = 0, double predeterminedDesiredSpeedMetresHour = 0, double predeterminedCrashLocation = -1)
        {
            GenerateVehicle(VehicleTypes.HGV, mainForm, vehicleId, predeterminedVehicleLength, predeterminedDesiredSpeedMetresHour, predeterminedCrashLocation);
        }
    }

    /// <summary>
    /// This class inherits from vehicle and allows me to instantiate a "Bus" instead of instatiating a "Vehicle" while passing in the Bus type.
    /// </summary>
    public class Bus : Vehicle
    {
        /// <summary>
        /// This is the constructor for the Bus class.
        /// It generates a vehicle using the Bus type.
        /// </summary>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="vehicleId">The ID of the vehicle to construct</param>
        public Bus (MotorwaySimulatorForm mainForm, int vehicleId, double predeterminedVehicleLength = 0, double predeterminedDesiredSpeedMetresHour = 0, double predeterminedCrashLocation = -1)
        {
            GenerateVehicle(VehicleTypes.Bus, mainForm, vehicleId, predeterminedVehicleLength, predeterminedDesiredSpeedMetresHour, predeterminedCrashLocation);
        }
    }
}
