/* Included System Namespaces/Libraries */
using System;

/* My Custom Control Namespace/Library */
using CustomControls;

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
        public long LastTimerValue;


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
        /// The congestion state of the vehicle (see the CongestionStates enumerator of MotorwaySimulator.cs)
        /// </summary>
        public CongestionStates Congestion
        {
            get
            {
                if (DesiredSpeedMetresHour - AverageSpeedMetresHour > MainForm.ActiveSevereCongestionTriggerMetresHour)
                {
                    return CongestionStates.Severe;
                }
                else if (DesiredSpeedMetresHour - AverageSpeedMetresHour > MainForm.ActiveMildCongestionTriggerMetresHour)
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
        protected double OriginalDistanceOffsetMetres;


        /* Parent Objects */

        /// <summary>
        /// The object representing the parent lane which allows access to the lane's methods, properties and controls
        /// </summary>
        public LaneControl ParentLane;
        /// <summary>
        /// The main form object which allows access to the main form's methods, properties and controls
        /// </summary>
        protected MotorwaySimulatorForm MainForm;

        #endregion

        #region Methods

        /// <summary>
        /// The method that is called every tick that controls the vehicle's speed and lane
        /// </summary>
        public void LaneTick()
        {

            #region Change Speed

            // Get the vehicle ahead of this vehicle on the lane
            Vehicle nextVehicle = ParentLane.NextVehicle(this);

            if (nextVehicle != null)
            {
                // There is a vehicle ahead of this vehicle

                // Calculate the stopping distance of this vehicle at desired speed
                int projectedDesiredStopppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(DesiredSpeedMetresHour)), 0);

                // Calculate the back of the vehicle ahead of this vehicle
                int backOfNextVehicle = nextVehicle.ProgressPixels - nextVehicle.VehicleLengthPixels;

                if (ProgressPixels + projectedDesiredStopppingDistancePixels >= backOfNextVehicle)
                {
                    // The stopping distance of this vehicle at desired speed overlaps the back of the next vehicle
                    
                    if (nextVehicle.ActualSpeedMetresHour < ActualSpeedMetresHour)
                    {
                        // The vehicle ahead of this vehicle is travelling slower than this vehicle
                        // Therefore this vehicle can slow down, meaning the stopping distance can overlap

                        // Calculate the overlap allowed in pixels
                        int stoppingDistanceChangeByChangingSpeedsPixels = projectedDesiredStopppingDistancePixels - (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(nextVehicle.ActualSpeedMetresHour)));

                        if (ProgressPixels + projectedDesiredStopppingDistancePixels >= backOfNextVehicle + stoppingDistanceChangeByChangingSpeedsPixels)
                        {
                            // Stopping distance overlaps too far past the allowed overlap

                            // Match the speed of the vehicle ahead of this vehicle
                            ActualSpeedMetresHour = nextVehicle.ActualSpeedMetresHour;
                        }
                    }
                }
                else if (ProgressPixels + (projectedDesiredStopppingDistancePixels * 1.1) < backOfNextVehicle) // add 10% margin fix pixeling flashing bug
                {
                    // The stopping distance (plus an extra 10% to avoid quick switching between states) of this vehicle at desired speed does not overlap the back of the next vehicle

                    // Go to full desired speed
                    ActualSpeedMetresHour = DesiredSpeedMetresHour;
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

            if (ParentLane.LaneId != MainForm.ActiveLaneCount-1 && !IsTravellingAtDesiredSpeed && ParentLane.LaneId+1 < MaximumLane)
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

        /// <summary>
        /// The method that is called every tick that controls the vehicle's movement
        /// </summary>
        public void MovementTick()
        {
            if (InEffect)
            {
                // This vehicle does not have a vehicle behind it in the lane to the left, in the lane it is in or in the lane to right which is within the visible bounds of the road

                // Calculate the delta time since the last check then scale it
                long tempTime = MainForm.Timer.ElapsedMilliseconds;
                long elapsedTime = tempTime - LastTimerValue;
                LastTimerValue = tempTime;
                double scaledElapsedTime = elapsedTime * MainForm.TimeScale;

                // Incrememnt the lifetime by the scaled elapsed time
                LifetimeMilliseconds += scaledElapsedTime;

                #region Move Forward

                // Calculate the metres moved since the last tick
                double metresMoved = MainForm.PerHourToPerTick(ActualSpeedMetresHour, scaledElapsedTime);
                
                // Move the vehicle by the metres that is has moved since the last tick
                ExactProgressMetres += metresMoved;
                ProgressPixels += (int)Math.Round(MainForm.MetresToPixels(metresMoved), 0);

                #endregion

                // Update the average speed from the new lifetime and progress along the road
                AverageSpeedMetresHour = (ExactProgressMetres + OriginalDistanceOffsetMetres) / (LifetimeMilliseconds / 1000 / 60 / 60);
            }

            if (ExactProgressMetres >= MainForm.ActiveRoadLengthMetres + VehicleLengthMetres)
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
        public void GenerateSize(VehicleTypes vehicleType)
        {
            // Generate the plus or minus speed variation for this vehicle
            double lengthVariation = (MainForm.RandomGenerator.NextDouble() * MainForm.VehicleParameters[vehicleType].LengthVariation * 2) - MainForm.VehicleParameters[vehicleType].LengthVariation;

            // Calculate the length of this vehicle
            double length = MainForm.VehicleParameters[vehicleType].Length + lengthVariation;
            
            // Assign the length and width of this vehicle
            VehicleLengthMetres = length;
            VehicleWidthPixels = MainForm.VehicleWidthPixels;
            VehicleLengthPixels = (int)Math.Round(MainForm.MetresToPixels(length), 0);
        }

        /// <summary>
        /// he method that generates the desired speed of the vehicle at creation time given the vehicle type
        /// </summary>
        /// <param name="vehicleType">The enum type of the vehicle that is being generated</param>
        public void GenerateDesiredSpeed(VehicleTypes vehicleType)
        {
            // Generate the plus or minus speed variation for this vehicle
            double speedVariation = (MainForm.RandomGenerator.NextDouble() * MainForm.VehicleParameters[vehicleType].DesiredSpeedVariation * 2) - MainForm.VehicleParameters[vehicleType].DesiredSpeedVariation;

            // Calculate the desired speed of this vehicle 
            int speedMetresHour = (int) Math.Round(MainForm.VehicleParameters[vehicleType].DesiredSpeed + speedVariation,0);

            // Assign the desired speed and actual speed of this vehicle
            DesiredSpeedMetresHour = speedMetresHour;
            ActualSpeedMetresHour = speedMetresHour;
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
        /// It intialises some variables.
        /// It generates the size of the vehicle.
        /// It generates the desired speed of the vehicle.
        /// Finally, it offsets the vehicle so the end of its stopping distance is at the beginning of the road
        /// </summary>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="vehicleId">The ID of the vehicle to construct</param>
        public Car (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            // Instantiate the variables from the parameters and those that need initial values
            MainForm = mainForm;
            VehicleId = vehicleId;
            InSight = true;
            InEffect = true;
            VehicleType = VehicleTypes.Car;
            MaximumLane = mainForm.VehicleParameters[VehicleTypes.Car].MaximumLane;
            LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            ParentLane = null;

            // Generate the size of the vehicle
            GenerateSize(VehicleTypes.Car);

            // Generate the desired speed of the vehicle
            GenerateDesiredSpeed(VehicleTypes.Car);

            // Offset the vehicle so the end of the stopping distance is at the beginning of the road
            double stoppingDistanceLength = mainForm.StoppingDistance(DesiredSpeedMetresHour);
            ExactProgressMetres = -stoppingDistanceLength;
            ProgressPixels += (int)Math.Round(MainForm.MetresToPixels(ExactProgressMetres), 0);
            OriginalDistanceOffsetMetres = stoppingDistanceLength;
        }
    }

    /// <summary>
    /// This class inherits from vehicle and allows me to instantiate a "LGV" instead of instatiating a "Vehicle" while passing in the LGV type.
    /// </summary>
    public class LGV : Vehicle
    {
        /// <summary>
        /// This is the constructor for the Car class.
        /// It intialises some variables.
        /// It generates the size of the vehicle.
        /// It generates the desired speed of the vehicle.
        /// Finally, it offsets the vehicle so the end of its stopping distance is at the beginning of the road
        /// </summary>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="vehicleId">The ID of the vehicle to construct</param>
        public LGV (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            // Instantiate the variables from the parameters and those that need initial values
            MainForm = mainForm;
            VehicleId = vehicleId;
            InSight = true;
            InEffect = true;
            VehicleType = VehicleTypes.LGV;
            MaximumLane = mainForm.VehicleParameters[VehicleTypes.LGV].MaximumLane;
            LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            ParentLane = null;

            // Generate the size of the vehicle
            GenerateSize(VehicleTypes.LGV);

            // Generate the desired speed of the vehicle
            GenerateDesiredSpeed(VehicleTypes.LGV);

            // Offset the vehicle so the end of the stopping distance is at the beginning of the road
            double stoppingDistanceLength = mainForm.StoppingDistance(DesiredSpeedMetresHour);
            ExactProgressMetres = -stoppingDistanceLength;
            ProgressPixels += (int)Math.Round(MainForm.MetresToPixels(ExactProgressMetres), 0);
            OriginalDistanceOffsetMetres = stoppingDistanceLength;
        }
    }

    /// <summary>
    /// This class inherits from vehicle and allows me to instantiate a "HGV" instead of instatiating a "Vehicle" while passing in the HGV type.
    /// </summary>
    public class HGV : Vehicle
    {
        /// <summary>
        /// This is the constructor for the Car class.
        /// It intialises some variables.
        /// It generates the size of the vehicle.
        /// It generates the desired speed of the vehicle.
        /// Finally, it offsets the vehicle so the end of its stopping distance is at the beginning of the road
        /// </summary>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="vehicleId">The ID of the vehicle to construct</param>
        public HGV (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            // Instantiate the variables from the parameters and those that need initial values
            MainForm = mainForm;
            VehicleId = vehicleId;
            InSight = true;
            InEffect = true;
            VehicleType = VehicleTypes.HGV;
            MaximumLane = mainForm.VehicleParameters[VehicleTypes.HGV].MaximumLane;
            LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            ParentLane = null;

            // Generate the size of the vehicle
            GenerateSize(VehicleTypes.HGV);

            // Generate the desired speed of the vehicle
            GenerateDesiredSpeed(VehicleTypes.HGV);

            // Offset the vehicle so the end of the stopping distance is at the beginning of the road
            double stoppingDistanceLength = mainForm.StoppingDistance(DesiredSpeedMetresHour);
            ExactProgressMetres = -stoppingDistanceLength;
            ProgressPixels += (int)Math.Round(MainForm.MetresToPixels(ExactProgressMetres), 0);
            OriginalDistanceOffsetMetres = stoppingDistanceLength;
        }
    }

    /// <summary>
    /// This class inherits from vehicle and allows me to instantiate a "Bus" instead of instatiating a "Vehicle" while passing in the Bus type.
    /// </summary>
    public class Bus : Vehicle
    {
        /// <summary>
        /// This is the constructor for the Car class.
        /// It intialises some variables.
        /// It generates the size of the vehicle.
        /// It generates the desired speed of the vehicle.
        /// Finally, it offsets the vehicle so the end of its stopping distance is at the beginning of the road
        /// </summary>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="vehicleId">The ID of the vehicle to construct</param>
        public Bus (MotorwaySimulatorForm mainForm, int vehicleId)
        {
            // Instantiate the variables from the parameters and those that need initial values
            MainForm = mainForm;
            VehicleId = vehicleId;
            InSight = true;
            InEffect = true;
            VehicleType = VehicleTypes.Bus;
            MaximumLane = mainForm.VehicleParameters[VehicleTypes.Bus].MaximumLane;
            LastTimerValue = mainForm.Timer.ElapsedMilliseconds;
            ParentLane = null;

            // Generate the size of the vehicle
            GenerateSize(VehicleTypes.Bus);

            // Generate the desired speed of the vehicle
            GenerateDesiredSpeed(VehicleTypes.Bus);

            // Offset the vehicle so the end of the stopping distance is at the beginning of the road
            double stoppingDistanceLength = mainForm.StoppingDistance(DesiredSpeedMetresHour);
            ExactProgressMetres = -stoppingDistanceLength;
            ProgressPixels += (int)Math.Round(MainForm.MetresToPixels(ExactProgressMetres), 0);
            OriginalDistanceOffsetMetres = stoppingDistanceLength;
        }
    }
}
