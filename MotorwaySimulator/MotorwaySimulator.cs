/* Included System Namespaces/Libraries */
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// My namespace
namespace MotorwaySimulator
{
    /// <summary>
    /// Defines the 4 possible vehicle types in an enumerator
    /// </summary>
    public enum VehicleTypes
    {
        Car,
        LGV,
        HGV,
        Bus
    }

    /// <summary>
    /// Defines the 3 possible congestion states in an enumerator
    /// </summary>
    public enum CongestionStates
    {
        None,
        Mild,
        Severe
    }

    /// <summary>
    /// Defines the 3 possible simulation states in an enumerator
    /// </summary>
    public enum SimulationStates
    {
        Started,
        Stopped,
        Paused
    }

    /// <summary>
    /// The primary object MotorwaySimulatorForm, also the form that the user interacts with
    /// </summary>
    public partial class MotorwaySimulatorForm : Form
    {
        #region Variable Declarations

        /* Constants */

        /// <summary>
        /// The margin between the white line and the side of each vehicle in metres
        /// </summary>
        private const double LaneMarginMetres = 0.8;


        /* Calculated Constants */

        /// <summary>
        /// The margin between the white line and the side of each vehicle in pixels calculated at runtime 
        /// </summary>
        public int LaneMarginPixels;
        /// <summary>
        /// Width of each vehicle in pixels calculated at runtime
        /// </summary>
        public int VehicleWidthPixels;


        /* Setup Parameters */

        private bool FirstLaunch;

        /// <summary>
        /// The Road Length in metres being used by the simulation
        /// </summary>
        public int ActiveRoadLengthMetres;
        /// <summary>
        /// The Lane count being used by the simulation
        /// </summary>
        public int ActiveLaneCount;
        /// <summary>
        /// The Interarrival time being used by the simulation
        /// </summary>
        public int ActiveInterArrivalTime;
        /// <summary>
        /// The Interarrival time variation being used by the simulation
        /// </summary>
        public double ActiveInterArrivalTimeVariationPercentage;
        /// <summary>
        /// The stopping time (i.e. time taken for vehicle to stop for safety reasons) being used by the simulation
        /// </summary>
        public double ActiveStoppingTime;
        /// <summary>
        /// The margin that the average speed of a vehicle must be below it's desired spped to be mildly congested
        /// </summary>
        public int ActiveMildCongestionTriggerMetresHour;
        /// <summary>
        /// The margin that the average speed of a vehicle must be below it's desired spped to be severely congested
        /// </summary>
        public int ActiveSevereCongestionTriggerMetresHour;
        /// <summary>
        /// Max crash count
        /// </summary>
        public int ActiveMaxCrashCount;
        /// <summary>
        /// Scaling factor from Metres To Pixels
        /// </summary>
        private int ActiveMetresToPixelsScalingFactor;
        /// <summary>
        /// Width of each vehicle in metres
        /// </summary>
        private double ActiveVehicleWidthMetres;
        /// <summary>
        /// Simulation run time enabled?
        /// </summary>
        private bool ActiveRunDurationEnabled;
        /// <summary>
        /// Duration of the simulation
        /// </summary>
        private DateTime ActiveRunDuration;
        /// <summary>
        /// Duration of the simulation in Milliseconds
        /// </summary>
        private int ActiveRunDurationMilliseconds;
        /// <summary>
        /// Time at start of simulation
        /// </summary>
        private DateTime ActiveRunStartTime;
        /// <summary>
        /// The dictionary containing all the vehicle simulation parameters being used by the simulation (dictionary is a is a system class not created by me but VehicleTypes and VehicleTemplate are data structures made by me)
        /// </summary>
        public Dictionary<VehicleTypes, VehicleTemplate> VehicleParameters;

        //

        /// <summary>
        /// The Road Length set by the TrackBar input
        /// </summary>
        private int RoadLengthMetres;
        /// <summary>
        /// The Lane Count set by the TrackBar input
        /// </summary>
        private int LaneCount;
        /// <summary>
        /// The Interarrival time set by the TrackBar input
        /// </summary>
        private int InterArrivalTime;
        /// <summary>
        /// The Interarrival time variation set by the TrackBar input
        /// </summary>
        private double InterArrivalTimeVariationPercentage;
        /// <summary>
        /// The stopping time (i.e. time taken for vehicle to stop for safety reasons) set by the TrackBar input
        /// </summary>
        private double StoppingTime;


        /* Interarrival Variables */

        /// <summary>
        /// The last timer value in milliseconds used to calculate delta-time for the vehicle arrival algorithm
        /// </summary>
        private double LastArrivalTimerValue;
        /// <summary>
        /// The chosen variation for the next vehicle spawn
        /// </summary>
        private double ChosenInterArrivalVariationPercentage;


        /* Time */

        /// <summary>
        /// Provides the realtime time measuring capability (stopwatch is a system class not created by me)
        /// </summary>
        public Stopwatch StopwatchTimer;
        /// <summary>
        /// The amount of simulation time that passes between each tick
        /// </summary>
        public double TickTime;
        /// <summary>
        /// The scaled time passed since the beginning of the simulation
        /// </summary>
        public double TimePassed;
        /// <summary>
        /// The last timer value in milliseconds used to calculate the ticks per second
        /// </summary>
        private long LastTickMeasurementTimerValue;
        /// <summary>
        /// The number of ticks since the last tick measurement
        /// </summary>
        private long TickMeasurementTickCount;


        /* Random */

        /// <summary>
        /// The random number generator used for all elements of randomness in the simulation (random is a system class not created by me)
        /// </summary>
        public Random RandomGenerator;


        /* Lanes and Vehicles */

        /// <summary>
        /// Dynamic list of the lane objects in the simulation (list is a system class not created by me, but LaneControl is a class made by me)
        /// </summary>
        public List<LaneControl> Lanes;
        /// <summary>
        /// List of all vehicle objects (including failed and finished) (list is a system class not created by me, but Vehicle is a class made by me)
        /// </summary>
        public List<Vehicle> AllVehicles;


        /* State */

        /// <summary>
        /// Contains the state of the simulation Started, Stopped or Paused
        /// </summary>
        private SimulationStates SimulationState;
        /// <summary>
        /// The specific vehicle object that has been selected for data output
        /// </summary>
        public Vehicle SelectedVehicle;


        /* Debug */

        /// <summary>
        /// Contains the individual spawn instructions for vehicles while in debug mode (list is a system class not created by me, but DebugVehicleSpawnInstruction is a class made by me)
        /// </summary>
        public List<DebugVehicleSpawnInstruction> DebugModeInstructions;
        /// <summary>
        /// Defines whether the simulation is running off hardcoded spawn data (for debugging and testing)
        /// </summary>
        private bool DebugMode;

        #endregion

        /// <summary>
        /// This is the constructor for the main form and the primary class.
        /// It initialises the auto-generated form controls, and all variables that need an initial value.
        /// It also updates the labels of the form that are paired to track bars so the value can be seen.
        /// Finally, it calculates the LaneMargin and VehicleWidth in pixels from the constants.
        /// </summary>
        public MotorwaySimulatorForm()
        {
            // (Auto-generated) Intialises all the form controls in the form (see MotorwaySimulator.Designer.cs)
            InitializeComponent();

            FirstLaunch = true;

            // Initialise variables
            DebugMode = false;
            StopwatchTimer = new Stopwatch();
            RandomGenerator = new Random();
            SimulationState = SimulationStates.Stopped;
            Lanes = new List<LaneControl>();
            AllVehicles = new List<Vehicle>();
            SelectedVehicle = null;
            DebugModeInstructions = new List<DebugVehicleSpawnInstruction>();

            // Update labels
            UpdateRoadLength(null, null);
            UpdateInterArrivalTime(null, null);
            UpdateInterArrivalVariation(null, null);
            UpdateLaneCount(null, null);
            UpdateStoppingTime(null, null);
            UpdateTickTime(null, null);
            ValidateProbabilityChange(null, null);

            // Make window fill screen
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }

        #region Form Event Handlers

        /// <summary>
        /// Updates LabelRoadLength and the RoadLengthMetres variable to the new value whenever TrackBarRoadLength changes value.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void UpdateRoadLength(object sender, EventArgs e)
        {
            // The TrackBar stores increments of 10 metres, so divide by 100 to get kilometres or multiple by 10 to get metres
            // The (double) is required to avoid integer division
            LabelRoadLength.Text = Math.Round(TrackBarRoadLength.Value / (double)10, 2) + " km";
            RoadLengthMetres = TrackBarRoadLength.Value * 100;
        }

        /// <summary>
        /// Updates LabelInterArrivalTime and the InterArrivalTime variable to the new value whenever TrackBarInterArrivalTime changes value.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void UpdateInterArrivalTime(object sender, EventArgs e)
        {
            // The TrackBar stores increments of 100 milliseconds, so divide by 10 to get seconds or multiple by 100 to get milliseconds
            // The (double) is required to avoid integer division
            LabelInterArrivalTime.Text = Math.Round(TrackBarInterArrivalTime.Value / (double)10, 1) + "s";
            InterArrivalTime = TrackBarInterArrivalTime.Value * 100;
        }

        /// <summary>
        /// Updates LabelInterArrivalVariation and the InterArrivalTimeVariationPercentage variable to the new value whenever TrackBarInterArrivalVariation changes value.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void UpdateInterArrivalVariation(object sender, EventArgs e)
        {
            // The TrackBar stores increments of 1%, so divide by 100 to get decimal %
            // The (double) is required to avoid integer division
            LabelInterArrivalVariation.Text = TrackBarInterArrivalVariation.Value + "%";
            InterArrivalTimeVariationPercentage = TrackBarInterArrivalVariation.Value / (double)100;
        }

        /// <summary>
        /// Updates LabelLaneCount and the LaneCount variable to the new value whenever TrackBarLaneCount changes value.
        /// Also updates the maximum of value of each of the 'maximum lane' fields to the new lane count.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void UpdateLaneCount(object sender, EventArgs e)
        {
            // The TrackBar stores increments of 1 lane, so no manipulation is required to retrieve the lane count
            LabelLaneCount.Text = TrackBarLaneCount.Value + " lane(s)";
            LaneCount = TrackBarLaneCount.Value;
            NumericCarMaximumLane.Maximum = LaneCount;
            NumericLGVMaximumLane.Maximum = LaneCount;
            NumericHGVMaximumLane.Maximum = LaneCount;
            NumericBusMaximumLane.Maximum = LaneCount;
        }

        /// <summary>
        /// Updates LabelStoppingTime and the StoppingTime variable to the new value whenever TrackBarStoppingTime changes value.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void UpdateStoppingTime(object sender, EventArgs e)
        {
            // The TrackBar stores increments of 0.1s, so divide by 10 to get seconds
            // The (double) is required to avoid integer division
            LabelStoppingTime.Text = Math.Round(TrackBarStoppingTime.Value / (double)10, 1) + "s";
            StoppingTime = TrackBarStoppingTime.Value / (double)10;
        }

        /// <summary>
        /// Updates LabelTickTime and the TickTime variable to the new value whenever TrackBarTickTime changes value.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void UpdateTickTime(object sender, EventArgs e)
        {
            // The TrackBar stores increments of 1
            TickTime = TrackBarTickTime.Value;
            LabelTickTime.Text = TrackBarTickTime.Value + "ms";
        }

        /// <summary>
        /// Updates the maximum value of the length variation Numerical Up Down controls when the length Numerical Up Down controls change.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void UpdateLengthVariation(object sender, EventArgs e)
        {
            NumericCarLengthVar.Maximum = NumericCarLength.Value;
            NumericLGVLengthVar.Maximum = NumericLGVLength.Value;
            NumericHGVLengthVar.Maximum = NumericHGVLength.Value;
            NumericBusLengthVar.Maximum = NumericBusLength.Value;
        }

        /// <summary>
        /// Updates the maximum value of the speed variation Numerical Up Down controls when the speed Numerical Up Down controls change.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void UpdateSpeedVariation(object sender, EventArgs e)
        {
            NumericCarDesiredSpeedVar.Maximum = NumericCarDesiredSpeed.Value;
            NumericLGVDesiredSpeedVar.Maximum = NumericLGVDesiredSpeed.Value;
            NumericHGVDesiredSpeedVar.Maximum = NumericHGVDesiredSpeed.Value;
            NumericBusDesiredSpeedVar.Maximum = NumericBusDesiredSpeed.Value;
        }

        /// <summary>
        /// This method simply updates the panel control which contains the 'control panel' location to be on screen whenever the form is scrolled.
        /// </summary>
        private void UpdateControlPanelLocation(object sender, ScrollEventArgs e)
        {
            PanelSettings.Location = new Point(12, 12);
            int scrollPosition = this.HorizontalScroll.Value;
            double visibleMetres1 = PixelsToMetres(scrollPosition + TrackBarRoadStartPoint.Value);
            double visibleMetres2 = PixelsToMetres(scrollPosition + Width + TrackBarRoadStartPoint.Value);
            if (visibleMetres1 < 0)
            {
                visibleMetres1 = 0;
            }
            if (visibleMetres2 > ActiveRoadLengthMetres)
            {
                visibleMetres2 = ActiveRoadLengthMetres;
            }
            LabelVisibleRoadInterval.Text = visibleMetres1 + "m - " + visibleMetres2 + "m";
            double metres1 = PixelsToMetres(TrackBarRoadStartPoint.Value);
            double metres2 = PixelsToMetres(TrackBarRoadStartPoint.Value + 65535);
            if (metres1 < 0)
            {
                metres1 = 0;
            }
            if (metres2 > ActiveRoadLengthMetres)
            {
                metres2 = ActiveRoadLengthMetres;
            }
            LabelRoadInterval.Text = metres1 + "m - " + metres2 + "m";
        }

        /// <summary>
        /// This method simply updates the panel control which contains the 'control panel' location to be on screen whenever the form is scrolled.
        /// </summary>
        private void UpdateStartPoint(object sender, EventArgs e)
        {
            UpdateControlPanelLocation(null, null);
        }

        /// <summary>
        /// This method simply updates the panel control which contains the 'control panel' location to be on screen whenever the form is scrolled.
        /// </summary>
        private void UpdateResize(object sender, EventArgs e)
        {
            UpdateControlPanelLocation(null, null);
        }

        /// <summary>
        /// Validates the probabilities and updates LabelSpawnProbabilityUnassigned to the % unassigned to any particular vehicle type.
        /// The validation will ensure that at no point does the sum of the percentages exceed 100%.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void ValidateProbabilityChange(object sender, EventArgs e)
        {
            // Get the total sum of the percentages as a result of the change just made
            int totalPercentage = GetTotalSpawnProbability();
            // Calculate the difference between the total percentage and 100%
            int margin = totalPercentage - 100;
            if (margin > 0)
            {
                // The margin is positive, indicating that the total percentage exceeds 100%

                // Reduce the bus spawn probability
                if (NumericBusSpawnProbability.Value >= margin)
                {
                    NumericBusSpawnProbability.Value -= margin;
                }
                else
                {
                    margin -= (int)NumericBusSpawnProbability.Value;
                    NumericBusSpawnProbability.Value = 0;

                    // Reduce the HGV spawn probability if the margin is still positive
                    if (NumericHGVSpawnProbability.Value >= margin)
                    {
                        NumericHGVSpawnProbability.Value -= margin;
                    }
                    else
                    {
                        margin -= (int)NumericHGVSpawnProbability.Value;
                        NumericHGVSpawnProbability.Value = 0;

                        // Reduce the LGV spawn probability if the margin is still positive
                        if (NumericLGVSpawnProbability.Value >= margin)
                        {
                            NumericLGVSpawnProbability.Value -= margin;
                        }
                        else
                        {
                            margin -= (int)NumericLGVSpawnProbability.Value;
                            NumericLGVSpawnProbability.Value = 0;

                            // Reduce the Car spawn probability if the margin is still positive
                            if (NumericCarSpawnProbability.Value >= margin)
                            {
                                NumericCarSpawnProbability.Value -= margin;
                            }
                            else
                            {
                                margin -= (int)NumericCarSpawnProbability.Value;
                                NumericCarSpawnProbability.Value = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                // The margin is <= 0, so update the label
                // The programmatic changes to the spawn probability values also trigger this function, and as those changes seek to set the margin to 0
                // this condition will be satisfied at least once everytime a change is made by the user
                LabelSpawnProbabilityUnassigned.Text = (margin * -1) + "% unassigned";
            }
        }

        /// <summary>
        /// Whenever a vehicle is selected in either the vehicles TreeView or the finished vehicles TreeView this method is called so that it can update the SelectedVehicle object.
        /// It then updates the output data so that even if the simulation is paused or stopped the specific vehicle data will still update
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void TreeNodeVehicleSelected(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Node is selected
            Vehicle selectedVehicle = (Vehicle)e.Node.Tag;
            if (selectedVehicle != null)
            {
                SelectedVehicle = selectedVehicle;
                ButtonFindVehicle.Enabled = true;
                UpdateData();
            }
        }

        /// <summary>
        /// Depending on the simulation state, either start a new simulation (if it was stopped) or resume the current one (if it was paused) when the play button is clicked.
        /// It will only allow a new simulation to be started if all 100% have been assigned to spawn probabilities of the vehicles. If not, it will flash the LabelSpawnProbabilityTitle and LabelSpawnProbabilityUnassigned red.
        /// This method is async as it uses an asynchronous await method for the delays involved in flashing a control a different colour.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            switch (SimulationState)
            {
                case SimulationStates.Stopped:
                    // The simulation is stopped
                    if (GetTotalSpawnProbability() == 100)
                    {
                        // All 100% have been assigned to spawn probabilities
                        NewSimulation();
                        UpdateControlPanelLocation(null, null);
                    }
                    else
                    {
                        // No all 100% have been assigned to spawn probabilities so change tab and flash the labels red
                        TabControlControlPanel.SelectedIndex = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            LabelSpawnProbabilityTitle.ForeColor = Color.Red;
                            LabelSpawnProbabilityUnassigned.ForeColor = Color.Red;
                            await FlashSpawnProbabilityDelay();
                            LabelSpawnProbabilityTitle.ForeColor = Color.Black;
                            LabelSpawnProbabilityUnassigned.ForeColor = Color.Black;
                            await FlashSpawnProbabilityDelay();
                        }
                    }
                    break;
                case SimulationStates.Paused:
                    // The simulation is paused
                    ResumeSimulation();
                    break;
            }
        }

        /// <summary>
        /// Pause the simulation when the pause button is clicked
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void ButtonPause_Click(object sender, EventArgs e)
        {
            // Pause the stopwatch
            StopwatchTimer.Stop();
            // Pause the form ticks
            FormTick.Enabled = false;

            // Update the simulation state
            SimulationState = SimulationStates.Paused;

            // Update the enabled state of the Play, Pause and Stop buttons
            ButtonStop.Enabled = true;
            ButtonPause.Enabled = false;
            ButtonStart.Enabled = true;
            CheckBoxRunForDuration.Enabled = true;
            DateTimeRunDuration.Enabled = true;
        }

        /// <summary>
        /// Stop the simulation when the stop button is clicked
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            // Pause the stopwatch
            StopwatchTimer.Stop();
            // Pause the form ticks
            FormTick.Enabled = false;

            // Update the simulation state
            SimulationState = SimulationStates.Stopped;

            // Update the enabled state of the Play, Pause and Stop buttons
            ButtonStop.Enabled = false;
            ButtonPause.Enabled = false;
            ButtonStart.Enabled = true;
            CheckBoxRunForDuration.Enabled = true;
            DateTimeRunDuration.Enabled = true;

            if (CheckBoxSaveOnStop.Checked)
            {
                SaveData();
            }
        }

        /// <summary>
        /// Scroll the form so that the selected vehicle is in view when the find vehicle button is clicked
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void ButtonFindVehicle_Click(object sender, EventArgs e)
        {
            if (SelectedVehicle != null)
            {
                // There is actually a selected vehicle

                // Calculate the new scroll position from the vehicles progress in pixels and the width of the form
                int newScrollPosition = SelectedVehicle.ProgressPixels - TrackBarRoadStartPoint.Value;
                if (newScrollPosition < 0)
                {
                    newScrollPosition = 0;
                    if (SelectedVehicle.ProgressPixels > TrackBarRoadStartPoint.Maximum)
                    {
                        TrackBarRoadStartPoint.Value = TrackBarRoadStartPoint.Maximum;
                    }
                    else if (SelectedVehicle.ProgressPixels < TrackBarRoadStartPoint.Minimum)
                    {
                        TrackBarRoadStartPoint.Value = TrackBarRoadStartPoint.Minimum;
                    }
                    else
                    {
                        TrackBarRoadStartPoint.Value = SelectedVehicle.ProgressPixels;
                    }
                }
                if (newScrollPosition > HorizontalScroll.Maximum)
                {
                    if (SelectedVehicle.ProgressPixels > TrackBarRoadStartPoint.Maximum)
                    {
                        TrackBarRoadStartPoint.Value = TrackBarRoadStartPoint.Maximum;
                    }
                    else if (SelectedVehicle.ProgressPixels < TrackBarRoadStartPoint.Minimum)
                    {
                        TrackBarRoadStartPoint.Value = TrackBarRoadStartPoint.Minimum;
                    }
                    else
                    {
                        TrackBarRoadStartPoint.Value = SelectedVehicle.ProgressPixels;
                    }
                    newScrollPosition = SelectedVehicle.ProgressPixels - TrackBarRoadStartPoint.Value;
                    if (newScrollPosition > HorizontalScroll.Maximum)
                    {
                        newScrollPosition = HorizontalScroll.Maximum;
                    }
                }
                // Scroll the form to the right place
                HorizontalScroll.Value = newScrollPosition;
                // Update the location of the control panel so it is still in view
                UpdateControlPanelLocation(null, null);
            }
        }

        /// <summary>
        /// Save the data for the current simulation to a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveData_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// This is the underlying update structure of the simulation. Everytime the FormTick form control 'ticks' (every 15ms) this function is called.
        /// Firstly it checks to see if a new vehicle should be spawned.
        /// Secondly, it increments the scaled time passed by the scaled elapsed miliseconds since the last tick
        /// Thirdly, it individually ticks each vehicle's lane and speed handling method in order of progress along the road.
        /// Then, it individually ticks each vehicle's movement handling method in order of progress along the road.
        /// Then, it individually checks if each vehicle is having an effect on any other visible vehicles on the road in order of progress along the road
        /// If the vehicles behind in the lane to the left, right and the same as the current vehicle are out of sight, the vehicle is deemed to be no longer affecting any vehicles and removed from the road and vehicles TreeView.
        ///     A new entry is also created for the vehicle in the finished vehicle TreeView.
        /// Penultimately, the method marks each lane for repainting on the form as the vehicle's positions have changed.
        /// Finally, the method updates the output data shown on the data tab.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void FormTick_Tick(object sender, EventArgs e)
        {
            TickMeasurementTickCount++;

            // Check if a new vehicle should be spawned
            CheckVehicle();

            // Increment the scaled time passed by the scaled elapsed time
            long tempTime = StopwatchTimer.ElapsedMilliseconds;
            double elapsedTime = TrackBarTickTime.Value;

            TimePassed += elapsedTime;

            long elapsedTickMeasurementTime = tempTime - LastTickMeasurementTimerValue;
            if (elapsedTickMeasurementTime > 1000)
            {
                LastTickMeasurementTimerValue = tempTime;
                LabelTicksPerSecond.Text = (TickMeasurementTickCount*1).ToString();
                TickMeasurementTickCount = 0;
            }

            if (ActiveRunDurationEnabled && TimePassed >= ActiveRunDurationMilliseconds)
            {
                ButtonStop_Click(null, null);
            }

            Vehicle[] OrderedVehicles = AllActiveVehiclesOrderByLocation();

            // Tick the lane handling method of each vehicle by location
            foreach (Vehicle vehicle in OrderedVehicles)
            {
                vehicle.LaneTick();
            }

            // Tick the movement handling method of each vehicle by location
            foreach (Vehicle vehicle in OrderedVehicles)
            {
                vehicle.MovementTick();
            }

            foreach (Vehicle vehicle in OrderedVehicles)
            {
                if (!vehicle.InSight)
                {
                    // The vehicle is not in sight

                    // Get the object of the vehicle behind the current vehicle in the same lane
                    Vehicle previousVehicle = vehicle.ParentLane.PreviousVehicle(vehicle);
                    Vehicle previousVehicleLeftLane = null;
                    if (vehicle.ParentLane.LaneId != 0)
                    {
                        // Not in the leftmost lane

                        // Get the object of the vehicle behind the current vehicle in the lane to the left
                        previousVehicleLeftLane = Lanes[vehicle.ParentLane.LaneId - 1].PreviousVehicle(vehicle);
                    }

                    Vehicle previousVehicleRightLane = null;
                    if (vehicle.ParentLane.LaneId != ActiveLaneCount - 1)
                    {
                        // Not in the rightmost lane

                        // Get the object of the vehicle behind the current vehicle in the lane to the right
                        previousVehicleRightLane = Lanes[vehicle.ParentLane.LaneId + 1].PreviousVehicle(vehicle);
                    }

                    if (previousVehicle == null && previousVehicleRightLane == null && previousVehicleLeftLane == null)
                    {
                        // There are no vehicles behind the current vehicle in the current lane, lane to the left or lane to the right

                        // The vehicle is therefore not affecting any vehicles
                        vehicle.InEffect = false;
                    }
                    else if (previousVehicle == null && previousVehicleLeftLane == null)
                    {
                        // There are no vehicles behind the current vehicle in the current lane or lane to the left

                        if (!previousVehicleRightLane.InSight)
                        {
                            // The vehicle the current vehicle is affecting is out of sight

                            // The vehicle is therefore not affecting any visible vehicles
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicle == null && previousVehicleRightLane == null)
                    {
                        // There are no vehicles behind the current vehicle in the current lane or lane to the right

                        if (!previousVehicleLeftLane.InSight)
                        {
                            // The vehicle the current vehicle is affecting is out of sight

                            // The vehicle is therefore not affecting any visible vehicles
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicleLeftLane == null && previousVehicleRightLane == null)
                    {
                        // There are no vehicles behind the current vehicle in the lane to the left or lane to the right

                        if (!previousVehicle.InSight)
                        {
                            // The vehicle the current vehicle is affecting is out of sight

                            // The vehicle is therefore not affecting any visible vehicles
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicle == null)
                    {
                        // There are no vehicles behind the current vehicle in the current lane

                        if (!previousVehicleLeftLane.InSight && !previousVehicleRightLane.InSight)
                        {
                            // The vehicles the current vehicle is affecting are out of sight

                            // The vehicle is therefore not affecting any visible vehicles
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicleLeftLane == null)
                    {
                        // There are no vehicles behind the current vehicle in the lane to the left

                        if (!previousVehicle.InSight && !previousVehicleRightLane.InSight)
                        {
                            // The vehicles the current vehicle is affecting are out of sight

                            // The vehicle is therefore not affecting any visible vehicles
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicleRightLane == null)
                    {
                        // There are no vehicles behind the current vehicle in the lane to the right

                        if (!previousVehicle.InSight && !previousVehicleLeftLane.InSight)
                        {
                            // The vehicles the current vehicle is affecting are out of sight

                            // The vehicle is therefore not affecting any visible vehicles
                            vehicle.InEffect = false;
                        }
                    }
                    else
                    {
                        // There are vehicles behind the current vehicle in the current lane, lane to the left and lane to the right

                        if (!previousVehicle.InSight && !previousVehicleLeftLane.InSight && !previousVehicleRightLane.InSight)
                        {
                            // The vehicles the current vehicle is affecting are out of sight

                            // The vehicle is therefore not affecting any visible vehicles
                            vehicle.InEffect = false;
                        }
                    }
                }

                if (!vehicle.InEffect)
                {
                    // This vehicle does not have a vehicle behind it in the lane to the left, in the lane it is in or in the lane to right which is within the visible bounds of the road

                    // Remove the vehicle from the road
                    vehicle.ParentLane.Vehicles.Remove(vehicle);

                    // Record the time of disappearance
                    vehicle.TimeDisappearance = TimePassed;

                    // Construct a TreeNode for the finished vehicle TreeView
                    TreeNode finishedVehicleNode = new TreeNode("#" + (vehicle.VehicleId + 1) + " - " + vehicle.VehicleType + " - " + Math.Round(vehicle.ActualSpeedMetresHour / 1000, 0) + " kph");
                    finishedVehicleNode.Tag = vehicle;

                    // Add the TreeNode to the right lane of the finished vehicle TreeView
                    TreeNode LaneNode = TreeViewFinishedVehicles.Nodes[vehicle.ParentLane.LaneId + 1];
                    for (int laneVehicleNodeIndex = 0; laneVehicleNodeIndex < LaneNode.Nodes.Count; laneVehicleNodeIndex++)
                    {
                        TreeNode laneVehicleNode = LaneNode.Nodes[laneVehicleNodeIndex];
                        if (vehicle.VehicleId < ((Vehicle)laneVehicleNode.Tag).VehicleId)
                        {
                            LaneNode.Nodes.Insert(laneVehicleNodeIndex, finishedVehicleNode);
                            break;
                        }
                    }
                    if (LaneNode.Nodes.Count == 0 || vehicle.VehicleId > ((Vehicle)LaneNode.Nodes[LaneNode.Nodes.Count - 1].Tag).VehicleId)
                    {
                        LaneNode.Nodes.Add(finishedVehicleNode);
                    }
                }
            }

            // Mark each lane for repainting
            foreach (LaneControl lane in Lanes)
            {
                lane.Invalidate(); // Repaint the lane
            }

            if (SelectedVehicle != null && CheckBoxAutoFindVehicle.Checked)
            {
                if (SelectedVehicle.ProgressPixels - TrackBarRoadStartPoint.Value < this.HorizontalScroll.Value || SelectedVehicle.ProgressPixels - TrackBarRoadStartPoint.Value > this.HorizontalScroll.Value + this.Width)
                {
                    ButtonFindVehicle_Click(null, null);
                }
            }

            // Update the output data of the data tab
            UpdateData();
        }

        private void CheckBoxRunForDuration_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CheckBoxRunForDuration = sender as CheckBox;
            if (CheckBoxRunForDuration != null && SimulationState == SimulationStates.Stopped)
            {
                if (CheckBoxRunForDuration.Checked)
                {
                    DateTimeRunDuration.Enabled = true;
                }
                else
                {
                    DateTimeRunDuration.Enabled = false;
                }
            }
        }

        #endregion

        #region Supportive Methods

        /// <summary>
        /// Given a value of units per hour and time elapsed in milliseconds this method will calculate the units for the tick
        /// </summary>
        /// <param name="unitsHour">The units per hour to be converted to per tick</param>
        /// <param name="tickLength">The lenght of the tick in milliseconds</param>
        /// <returns>Returns the units per tick</returns>
        public double PerHourToPerTick(double unitsHour, double tickLength)
        {
            if (tickLength > 0)
            {
                // The conversion 60 * 60 * 1000 represents hours -> minutes -> seconds -> milliseconds
                return (unitsHour * tickLength) / (60 * 60 * 1000);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// This method converts from metres to pixels using the MetresToPixelsScalingFactor constant
        /// </summary>
        /// <param name="metres">The number of metres to be converted to pixels</param>
        /// <returns>The number of pixels for each metre</returns>
        public double MetresToPixels(double metres)
        {
            return metres * ActiveMetresToPixelsScalingFactor;
        }

        /// <summary>
        /// This method converts from pixels to metres using the MetresToPixelsScalingFactor constant
        /// </summary>
        /// <param name="pixels">The number of pixels to be converted metres pixels</param>
        /// <returns>The number of metres for each pixel</returns>
        public double PixelsToMetres(int pixels)
        {
            if (ActiveMetresToPixelsScalingFactor == 0)
            {
                return 0;
            }
            else
            {
                return pixels / ActiveMetresToPixelsScalingFactor;
            }
        }

        /// <summary>
        /// This method calculates the stopping distance in metres given a speed in metres per hour (using a time period of 1s to stop in) using the StoppingTime constant
        /// </summary>
        /// <param name="metresHour">The number of metres per hour to be used in the calculation</param>
        /// <returns>The stopping distance in metres</returns>
        public double StoppingDistance(double metresHour)
        {
            double distance = (metresHour * ActiveStoppingTime) / (60 * 60);

            if (distance < 3)
            {
                distance = 3;
            }

            return distance;
        }

        /// <summary>
        /// Sums together the spawn probabilities from the form inputs
        /// </summary>
        /// <returns>The sum of the spawn probabilities from the form inputs</returns>
        private int GetTotalSpawnProbability()
        {
            return (int)(NumericCarSpawnProbability.Value + NumericLGVSpawnProbability.Value + NumericHGVSpawnProbability.Value + NumericBusSpawnProbability.Value);
        }

        /// <summary>
        /// Asynchronously delays by 100ms without interrupting the UI thread
        /// </summary>
        /// <returns>The asynchronous delay task</returns>
        private async Task FlashSpawnProbabilityDelay()
        {
            await Task.Delay(100);
        }

        /// <summary>
        /// Firstly  this method clears all data from previous simulations.
        /// It then reassigns variables to the input setup values of the form before calculating the size of the road.
        /// It then populates the TreeViews with the lane nodes, creates the lane objects.
        /// It then adds any debug spawn instructions that might be put here.
        /// Finally, it starts the simulation.
        /// </summary>
        private void NewSimulation()
        {

            // Clear previous data/simulation
            Lanes.Clear();
            AllVehicles.Clear();
            Road.Controls.Clear();
            TreeViewVehicles.Nodes.Clear();
            TreeViewFinishedVehicles.Nodes.Clear();
            Road.Size = new Size(10, 10);
            SelectedVehicle = null;
            CheckBoxAutoFindVehicle.Checked = false;

            ActiveRunStartTime = DateTime.UtcNow;

            ActiveRunDurationEnabled = CheckBoxRunForDuration.Checked;
            if (ActiveRunDurationEnabled)
            {
                ActiveRunDuration = DateTimeRunDuration.Value;
                ActiveRunDurationMilliseconds = 1000 * ((ActiveRunDuration.Hour * 3600) + (ActiveRunDuration.Minute * 60) + ActiveRunDuration.Second);
            }

            ActiveMetresToPixelsScalingFactor = (int)NumericMetreToPixelScalingFactor.Value;
            ActiveVehicleWidthMetres = (int)NumericVehicleWidth.Value;

            // Calculate values in pixels from metre constants
            LaneMarginPixels = (int)Math.Round(MetresToPixels(MotorwaySimulatorForm.LaneMarginMetres), 0);
            VehicleWidthPixels = (int)Math.Round(MetresToPixels(ActiveVehicleWidthMetres), 0);


            // Assign the parameters for use in the simulation from the form inputs
            VehicleParameters = new Dictionary<VehicleTypes, VehicleTemplate>()
            {
                // Length (metres), Length Variation (+-) (metres), Desired Speed (meters/hour), Desired Speed Variation (+-) (meters/hour), Maximum Lane, Camper Probability, Crash Probability, Spawn Probability

                { VehicleTypes.Car, new VehicleTemplate((double)NumericCarLength.Value, (double)NumericCarLengthVar.Value,  (int)(NumericCarDesiredSpeed.Value*1000),  (double)(NumericCarDesiredSpeedVar.Value*1000), (int)(NumericCarMaximumLane.Value),  (double)(NumericCarCamperProbability.Value/(decimal)100),  (double)(NumericCarCrashProbability.Value/(decimal)100),  (double)(NumericCarSpawnProbability.Value/(decimal)100)) },
                { VehicleTypes.LGV, new VehicleTemplate((double)NumericLGVLength.Value, (double)NumericLGVLengthVar.Value,  (int)(NumericLGVDesiredSpeed.Value*1000),  (double)(NumericLGVDesiredSpeedVar.Value*1000), (int)(NumericLGVMaximumLane.Value),  (double)(NumericLGVCamperProbability.Value/(decimal)100),  (double)(NumericLGVCrashProbability.Value/(decimal)100),  (double)(NumericLGVSpawnProbability.Value/(decimal)100)) },
                { VehicleTypes.HGV, new VehicleTemplate((double)NumericHGVLength.Value, (double)NumericHGVLengthVar.Value,  (int)(NumericHGVDesiredSpeed.Value*1000),  (double)(NumericHGVDesiredSpeedVar.Value*1000), (int)(NumericHGVMaximumLane.Value),  (double)(NumericHGVCamperProbability.Value/(decimal)100),  (double)(NumericHGVCrashProbability.Value/(decimal)100),  (double)(NumericHGVSpawnProbability.Value/(decimal)100)) },
                { VehicleTypes.Bus, new VehicleTemplate((double)NumericBusLength.Value, (double)NumericBusLengthVar.Value,  (int)(NumericBusDesiredSpeed.Value*1000),  (double)(NumericBusDesiredSpeedVar.Value*1000), (int)(NumericBusMaximumLane.Value),  (double)(NumericBusCamperProbability.Value/(decimal)100),  (double)(NumericBusCrashProbability.Value/(decimal)100),  (double)(NumericBusSpawnProbability.Value/(decimal)100)) }
            };

            ActiveLaneCount = LaneCount;

            ActiveRoadLengthMetres = RoadLengthMetres;
            int activeRoadLengthPixels = (int)Math.Round(MetresToPixels(ActiveRoadLengthMetres), 0);
            int overFlow = activeRoadLengthPixels - 65535;
            if (overFlow < 0)
            {
                overFlow = 0;
            }
            TrackBarRoadStartPoint.Maximum = overFlow;
            TrackBarRoadStartPoint.SmallChange = ActiveMetresToPixelsScalingFactor;
            TrackBarRoadStartPoint.LargeChange = ActiveMetresToPixelsScalingFactor*10;

            ActiveMaxCrashCount = (int)NumericMaxCrashCount.Value;

            ActiveMildCongestionTriggerMetresHour = (int)NumericMildCongestion.Value * 1000;
            ActiveSevereCongestionTriggerMetresHour = (int)NumericSevereCongestion.Value * 1000;

            ActiveInterArrivalTime = InterArrivalTime;
            ActiveInterArrivalTimeVariationPercentage = InterArrivalTimeVariationPercentage;
            ChosenInterArrivalVariationPercentage = -1;

            ActiveStoppingTime = StoppingTime;

            int laneWidth = VehicleWidthPixels + (2 * LaneMarginPixels);

            // Calculate the size of the road
            int newHeight = ActiveLaneCount * laneWidth;
            MinimumSize = new Size(MinimumSize.Width, 530 + 17 + newHeight);
            Height = 530 + 17 + newHeight;
            Road.Width = activeRoadLengthPixels;
            Road.Height = newHeight;
            if (FirstLaunch)
            {
                Road.Visible = true;
                FirstLaunch = false;
            }

            // Create the lane objects and populate the TreeViews with the lane nodes
            TreeNode finishedVehiclesLaneNode = new TreeNode("Failed");
            TreeViewFinishedVehicles.Nodes.Add(finishedVehiclesLaneNode);
            for (int i = 0; i < ActiveLaneCount; i++)
            {
                LaneControl lane = new LaneControl(this, i);
                lane.Location = new Point(0, laneWidth * i);
                lane.Size = new Size(activeRoadLengthPixels, laneWidth);
                lane.LaneNode = new TreeNode("Lane " + (lane.LaneId + 1));
                finishedVehiclesLaneNode = new TreeNode("Lane " + (lane.LaneId + 1));
                Road.Controls.Add(lane);
                Lanes.Add(lane);

                TreeViewFinishedVehicles.Nodes.Add(finishedVehiclesLaneNode);
                TreeViewVehicles.Nodes.Add(lane.LaneNode);
            }

            // Add some manual spawn instructions to the debug mode to allow for testing specific circumstances
            DebugVehicleSpawnInstruction instruction;

            /*
            // Create an individual spawn instruction
            instruction = new DebugVehicleSpawnInstruction(0, VehicleTypes.Car, Lanes[0], 0, 96000, 40, 120, false);
            DebugModeInstructions.Add(instruction);
            instruction = new DebugVehicleSpawnInstruction(1, VehicleTypes.Car, Lanes[0], 3000, 112000, 4, -1, false);
            DebugModeInstructions.Add(instruction);
            instruction = new DebugVehicleSpawnInstruction(2, VehicleTypes.Car, Lanes[1], 2700, 86000, 4, -1, true);
            DebugModeInstructions.Add(instruction);
            */
            
            LastTickMeasurementTimerValue = 0;
            TickMeasurementTickCount = 0;
            LastArrivalTimerValue = -1;
            TimePassed = 0;
            StopwatchTimer.Restart();
            FormTick.Enabled = true;
            SimulationState = SimulationStates.Started;
            //Road.Visible = true;

            // Update the enabled state of the Play, Pause and Stop and FindVehicle buttons
            ButtonStart.Enabled = false;
            ButtonStop.Enabled = true;
            ButtonPause.Enabled = true;
            ButtonFindVehicle.Enabled = false;
            CheckBoxRunForDuration.Enabled = false;
            DateTimeRunDuration.Enabled = false;

            // Reset the scroll bars
            HorizontalScroll.Value = 0;
            TrackBarRoadStartPoint.Value = 0;
        }

        /// <summary>
        /// Resumes a paused simulation
        /// </summary>
        private void ResumeSimulation()
        {
            ActiveRunDurationEnabled = CheckBoxRunForDuration.Checked;
            if (ActiveRunDurationEnabled)
            {
                ActiveRunDuration = DateTimeRunDuration.Value;
                ActiveRunDurationMilliseconds = 1000 * ((ActiveRunDuration.Hour * 3600) + (ActiveRunDuration.Minute * 60) + ActiveRunDuration.Second);
            }

            // Resume the stopwatch
            StopwatchTimer.Start();

            // Resume the form ticks
            FormTick.Enabled = true;

            // Update the simulation state
            SimulationState = SimulationStates.Started;

            // Update the enabled state of the Play, Pause and Stop buttons
            ButtonStart.Enabled = false;
            ButtonStop.Enabled = true;
            ButtonPause.Enabled = true;
            CheckBoxRunForDuration.Enabled = false;
        }

        /// <summary>
        /// Combines each lane's list of vehicles to produce a list of all active vehicles (i.e. vehicles on the road) then sorts by progress along the road
        /// </summary>
        /// <returns>A list of all active vehicles ordered by their progress along the road (furthest first)</returns>
        private Vehicle[] AllActiveVehiclesOrderByLocation()
        {
            // Produce a list of all active vehicles
            List<Vehicle> allVehicles = new List<Vehicle>();
            foreach (LaneControl lane in Lanes)
            {
                allVehicles.AddRange(lane.Vehicles);
            }

            // Sort the vehicles by progress
            return allVehicles.OrderByDescending(vehicle => vehicle.ExactProgressMetres).ToArray();
        }

        /// <summary>
        /// Checks whether a new vehicle is due to be spawned according to the interarrival time
        /// </summary>
        private void CheckVehicle()
        {
            if (DebugMode)
            {
                // Debug mode is active, so vehicle spawn time is predetermined

                for (int instructionIndex = 0; instructionIndex < DebugModeInstructions.Count;)
                {
                    DebugVehicleSpawnInstruction instruction = DebugModeInstructions[instructionIndex];
                    //if (StopwatchTimer.ElapsedMilliseconds >= instruction.RealTimeSpawnTime)
                    if (TimePassed >= instruction.RealTimeSpawnTime)
                    {
                        // Spawn time for this instruction has passed
                        Vehicle vehicle;
                        switch (instruction.Type)
                        {
                            case VehicleTypes.Car:
                                vehicle = new Car(this, instruction.VehicleId, instruction.VehicleLength, instruction.DesiredSpeedMetresHour, instruction.CrashLocation, instruction.Camper);
                                break;
                            case VehicleTypes.LGV:
                                vehicle = new LGV(this, instruction.VehicleId, instruction.VehicleLength, instruction.DesiredSpeedMetresHour, instruction.CrashLocation, instruction.Camper);
                                break;
                            case VehicleTypes.HGV:
                                vehicle = new HGV(this, instruction.VehicleId, instruction.VehicleLength, instruction.DesiredSpeedMetresHour, instruction.CrashLocation, instruction.Camper);
                                break;
                            case VehicleTypes.Bus:
                                vehicle = new Bus(this, instruction.VehicleId, instruction.VehicleLength, instruction.DesiredSpeedMetresHour, instruction.CrashLocation, instruction.Camper);
                                break;
                            default:
                                vehicle = null;
                                break;
                        }

                        // Setup the initial values
                        if (instruction.DesiredSpeedMetresHour != 0)
                        {
                            vehicle.DesiredSpeedMetresHour = instruction.DesiredSpeedMetresHour;
                        }
                        if (instruction.VehicleLength != 0)
                        {
                            vehicle.VehicleLengthMetres = instruction.VehicleLength;
                            vehicle.VehicleLengthPixels = (int)Math.Round(MetresToPixels(instruction.VehicleLength));
                        }

                        // Add vehicle to the specified lane
                        bool success = instruction.Lane.AddVehicleToLane(vehicle);

                        if (!success)
                        {
                            // Adding the vehicle failed

                            // Create a node for the failed vehicle in the finished vehicle TreeView
                            TreeNode finishedVehicleNode = new TreeNode("#" + (vehicle.VehicleId + 1) + " - " + vehicle.VehicleType + " - " + Math.Round(vehicle.ActualSpeedMetresHour / 1000, 0) + " kph");
                            finishedVehicleNode.Tag = vehicle;
                            TreeViewFinishedVehicles.Nodes[0].Nodes.Add(finishedVehicleNode);
                        }

                        // Add the vehicle to the list of all vehicles
                        AllVehicles.Add(vehicle);

                        DebugModeInstructions.RemoveAt(instructionIndex);
                    }
                    else
                    {
                        instructionIndex++;
                    }
                }
            }
            else
            {
                // Not in debug mode

                if (ChosenInterArrivalVariationPercentage == -1)
                {
                    // Don't have a chosen arrival variation percentage yet
                    // This means that this is the first check since the last vehicle spawn
                    ChosenInterArrivalVariationPercentage = (RandomGenerator.NextDouble() * ActiveInterArrivalTimeVariationPercentage * 2) - ActiveInterArrivalTimeVariationPercentage;
                }

                // Calculate the delta simulation time since the last tick
                double tempTime = TimePassed;
                double elapsedTime = tempTime - LastArrivalTimerValue;
                double randomisedInterArrivalTime = ActiveInterArrivalTime + (ActiveInterArrivalTime * ChosenInterArrivalVariationPercentage);

                // Lower the trigger time by 1% since timer has resolution of 15ms and without a lower bound will always check *after* the trigger point by some number of ms
                if (elapsedTime >= randomisedInterArrivalTime * 0.99 || LastArrivalTimerValue == -1)
                {
                    // Reset the chosen variation percentage
                    ChosenInterArrivalVariationPercentage = -1;

                    // Update the last arrival timer value so delta time can be calculated next check
                    LastArrivalTimerValue = tempTime;

                    // Add a new vehicle
                    AddVehicle();
                }
            }
        }

        /// <summary>
        /// Attempts to add a new vehicle to the road
        /// </summary>
        private void AddVehicle()
        {
            // Generate a vehicle object
            Vehicle newVehicle = GenerateVehicle(AllVehicles.Count);

            int lane = 0;
            bool success = false;

            // Try to add the vehicle to each lane in succession (starting with the left most lane)
            while (!success && newVehicle.MaximumLane > lane && lane < ActiveLaneCount)
            {
                success = Lanes[lane].AddVehicleToLane(newVehicle);
                lane++;
            }
            if (!success)
            {
                // Adding the vehicle failed

                // Create a node for the failed vehicle in the finished vehicle TreeView
                TreeNode finishedVehicleNode = new TreeNode("#" + (newVehicle.VehicleId + 1) + " - " + newVehicle.VehicleType + " - " + Math.Round(newVehicle.ActualSpeedMetresHour / 1000, 0) + " kph");
                finishedVehicleNode.Tag = newVehicle;
                TreeViewFinishedVehicles.Nodes[0].Nodes.Add(finishedVehicleNode);
            }

            // Add the vehicle to the list of all vehicles
            AllVehicles.Add(newVehicle);
        }

        /// <summary>
        /// Randomly generates a vehicle from the vehicle spawn probabilities set when the simulation started
        /// </summary>
        /// <param name="id">The numerical ID of the vehicle to spawn</param>
        /// <returns>The vehicle object for the new vehicle</returns>
        private Vehicle GenerateVehicle(int id)
        {
            Vehicle newVehicle;
            double rand = RandomGenerator.NextDouble();
            double total = 0;
            if (rand < VehicleParameters[VehicleTypes.Car].Probability)
            {
                // Generate a Car
                newVehicle = new Car(this, id);
            }
            else
            {
                total += VehicleParameters[VehicleTypes.Car].Probability;
                if (total <= rand && rand < total + VehicleParameters[VehicleTypes.LGV].Probability)
                {
                    // Generate a LGV
                    newVehicle = new LGV(this, id);
                }
                else
                {
                    total += VehicleParameters[VehicleTypes.LGV].Probability;
                    if (total <= rand && rand < total + VehicleParameters[VehicleTypes.HGV].Probability)
                    {
                        // Generate a HGV
                        newVehicle = new HGV(this, id);
                    }
                    else
                    {
                        // Generate a Bus
                        newVehicle = new Bus(this, id);
                    }
                }
            }
            return newVehicle;
        }

        /// <summary>
        /// The method that retrieves and calculates all the data for the vehicle specific records
        /// </summary>
        /// <param name="vehicle"></param>
        private VehicleData GetVehicleData(Vehicle vehicle, DataFormat format)
        {
            VehicleData data = new VehicleData();

            bool finished = !vehicle.InEffect;
            TimeSpan appearance = TimeSpan.FromMilliseconds(vehicle.TimeAppearance);
            TimeSpan disappearance = TimeSpan.FromMilliseconds(vehicle.TimeDisappearance);
            TimeSpan lifetime = TimeSpan.FromMilliseconds(vehicle.LifetimeMilliseconds);

            // Update the vehicle ID output
            data.vehicleID = (vehicle.VehicleId + 1).ToString();

            // Update the vehicle type output
            data.vehicleType = vehicle.VehicleType.ToString();

            string nullString = "";

            if (format == DataFormat.Panel)
            {
                // This is NOT to a file with units so add unit data etc
                nullString = "---";

                // Update the vehicle length output
                data.vehicleLength = Math.Round(vehicle.VehicleLengthMetres, 2) + "m";

                // Update the vehicle desired speed output
                data.vehicleDesiredSpeed = Math.Round(vehicle.DesiredSpeedMetresHour / 1000, 2) + "kph";

                // Update the vehicle spawn time output
                data.vehicleSpawnTime = appearance.Hours.ToString().PadLeft(2, '0') + "h " + appearance.Minutes.ToString().PadLeft(2, '0') + "m " + appearance.Seconds.ToString().PadLeft(2, '0') + "s " + appearance.Milliseconds.ToString().PadLeft(3, '0') + "ms";

                // Update the vehicle despawn time output
                if (vehicle.SuccessfulSpawn && finished)
                {
                    data.vehicleDespawnTime = disappearance.Hours.ToString().PadLeft(2, '0') + "h " + disappearance.Minutes.ToString().PadLeft(2, '0') + "m " + disappearance.Seconds.ToString().PadLeft(2, '0') + "s " + disappearance.Milliseconds.ToString().PadLeft(3, '0') + "ms";
                }
                else
                {
                    data.vehicleDespawnTime = nullString;
                }

                // Update the vehicle lifetime output
                // Update the vehicle average speed output
                // Update the vehicle actual speed output
                // Update the vehicle progress output
                if (vehicle.SuccessfulSpawn)
                {
                    data.vehicleLifetime = lifetime.Hours.ToString().PadLeft(2, '0') + "h " + lifetime.Minutes.ToString().PadLeft(2, '0') + "m " + lifetime.Seconds.ToString().PadLeft(2, '0') + "s " + lifetime.Milliseconds.ToString().PadLeft(3, '0') + "ms";
                    data.vehicleAverageSpeed = Math.Round(vehicle.AverageSpeedMetresHour / 1000, 2) + "kph";
                    data.vehicleProgress = Math.Round(vehicle.ExactProgressMetres, 1) + "m";
                    data.vehicleActualSpeed = Math.Round(vehicle.ActualSpeedMetresHour / 1000, 2) + "kph";
                }
                else
                {
                    data.vehicleLifetime = nullString;
                    data.vehicleAverageSpeed = nullString;
                    data.vehicleProgress = nullString;
                    data.vehicleActualSpeed = nullString;
                }
            }
            else
            {
                // This is to a file with units so remove unncecessary data

                nullString = "";

                // Update the vehicle length output
                data.vehicleLength = Math.Round(vehicle.VehicleLengthMetres, 2).ToString();

                // Update the vehicle desired speed output
                data.vehicleDesiredSpeed = vehicle.DesiredSpeedMetresHour.ToString();

                // Update the vehicle actual speed output
                // Update the vehicle progress output

                // Update the vehicle spawn time output
                data.vehicleSpawnTime = appearance.Hours.ToString().PadLeft(2, '0') + "-" + appearance.Minutes.ToString().PadLeft(2, '0') + "-" + appearance.Seconds.ToString().PadLeft(2, '0') + "." + appearance.Milliseconds.ToString().PadLeft(3, '0');

                // Update the vehicle despawn time output
                if (vehicle.SuccessfulSpawn && finished)
                {
                    data.vehicleDespawnTime = disappearance.Hours.ToString().PadLeft(2, '0') + "-" + disappearance.Minutes.ToString().PadLeft(2, '0') + "-" + disappearance.Seconds.ToString().PadLeft(2, '0') + "." + disappearance.Milliseconds.ToString().PadLeft(3, '0');
                }
                else
                {
                    data.vehicleDespawnTime = nullString;
                }

                // Update the vehicle lifetime output
                // Update the vehicle average speed output
                // Update the vehicle actual speed output
                // Update the vehicle progress output
                if (vehicle.SuccessfulSpawn)
                {
                    data.vehicleAverageSpeed = vehicle.AverageSpeedMetresHour.ToString();
                    data.vehicleLifetime = lifetime.Hours.ToString().PadLeft(2, '0') + "-" + lifetime.Minutes.ToString().PadLeft(2, '0') + "-" + lifetime.Seconds.ToString().PadLeft(2, '0') + "." + lifetime.Milliseconds.ToString().PadLeft(3, '0');
                    data.vehicleProgress = Math.Round(vehicle.ExactProgressMetres, 1).ToString();
                    data.vehicleActualSpeed = vehicle.ActualSpeedMetresHour.ToString();
                }
                else
                {
                    data.vehicleAverageSpeed = nullString;
                    data.vehicleLifetime = nullString;
                    data.vehicleProgress = nullString;
                    data.vehicleActualSpeed = nullString;
                }
            }

            // Update the vehicle successful spawn output
            data.vehicleSuccessfulSpawn = vehicle.SuccessfulSpawn.ToString();

            // Update the vehicle congestion output
            // Update the vehicle lane output
            if (vehicle.SuccessfulSpawn)
            {
                data.vehicleCongestion = vehicle.Congestion.ToString();
                data.vehicleLane = (vehicle.ParentLane.LaneId + 1).ToString();
            }
            else
            {
                data.vehicleCongestion = nullString;
                data.vehicleLane = nullString;
            }

            // Update the vehicle camper output
            data.vehicleCamper = vehicle.Camper.ToString();

            // Update the vehicle crashed output
            data.vehicleCrashed = vehicle.Crashed.ToString();

            return data;
        }

        /// <summary>
        /// The method that retrieves and calculates all the data for the simulation
        /// </summary>
        private SimulationData GetSimulationData(DataFormat format)
        {
            SimulationData data = new SimulationData();

            int successCount = 0;
            int failedCount = 0;

            int carCount = 0;
            int lGVCount = 0;
            int hGVCount = 0;
            int busCount = 0;

            int carCrashes = 0;
            int lGVCrashes = 0;
            int hGVCrashes = 0;
            int busCrashes = 0;

            int carCampers = 0;
            int lGVCampers = 0;
            int hGVCampers = 0;
            int busCampers = 0;

            int notCongestedCount = 0;
            int mildyCongestedCount = 0;
            int severelyCongestedCount = 0;

            // Calculate number of Cars
            // Calculate number of LGVs
            // Calculate number of HGVs
            // Calculate number of Buses
            // Calculate the number of successful spawns
            // Calculate the number of unsuccessful spawns
            // Calculate the number of mildly congested vehicles
            // Calculate the number of severely congested vehicles
            // Calculate the number of vehicles not congested
            foreach (Vehicle vehicle in AllVehicles)
            {
                if (vehicle.SuccessfulSpawn)
                {
                    successCount++;

                    if (vehicle.Crashed)
                    {
                        switch (vehicle.VehicleType)
                        {
                            case VehicleTypes.Car:
                                carCrashes++;
                                break;
                            case VehicleTypes.LGV:
                                lGVCrashes++;
                                break;
                            case VehicleTypes.HGV:
                                hGVCrashes++;
                                break;
                            case VehicleTypes.Bus:
                                busCrashes++;
                                break;
                        }
                    }

                    if (vehicle.Camper)
                    {
                        switch (vehicle.VehicleType)
                        {
                            case VehicleTypes.Car:
                                carCampers++;
                                break;
                            case VehicleTypes.LGV:
                                lGVCampers++;
                                break;
                            case VehicleTypes.HGV:
                                hGVCampers++;
                                break;
                            case VehicleTypes.Bus:
                                busCampers++;
                                break;
                        }
                    }

                    switch (vehicle.Congestion)
                    {
                        case CongestionStates.None:
                            notCongestedCount++;
                            break;
                        case CongestionStates.Mild:
                            mildyCongestedCount++;
                            break;
                        case CongestionStates.Severe:
                            severelyCongestedCount++;
                            break;
                    }
                }
                else
                {
                    failedCount++;
                }

                switch (vehicle.VehicleType)
                {
                    case VehicleTypes.Car:
                        carCount++;
                        break;
                    case VehicleTypes.LGV:
                        lGVCount++;
                        break;
                    case VehicleTypes.HGV:
                        hGVCount++;
                        break;
                    case VehicleTypes.Bus:
                        busCount++;
                        break;
                }
            }



            string nullString = "";

            if (format == DataFormat.Panel)
            {
                // This is NOT to a file with units so add unit data etc

                if (AllVehicles.Count > 0)
                {
                    // Percentages can be calculated as won't divide by 0
                    // The (double)s are required to avoid integer division

                    // Calculate and update the all vehicle successful spawn percentage output
                    data.simulationSuccessfulSpawnsPercent = Math.Round((successCount / (double)AllVehicles.Count) * 100, 1) + "%";

                    // Calculate and update the all vehicle failed spawn percentage output
                    data.simulationFailedSpawnsPercent = Math.Round((failedCount / (double)AllVehicles.Count) * 100, 1) + "%";


                    // Calculate and update the all vehicle car percentage output 
                    data.simulationCarPercent = Math.Round((carCount / (double)AllVehicles.Count) * 100, 1) + "%";

                    // Calculate and update the all vehicle LGV percentage output 
                    data.simulationLGVPercent = Math.Round((lGVCount / (double)AllVehicles.Count) * 100, 1) + "%";

                    // Calculate and update the all vehicle HGV percentage output 
                    data.simulationHGVPercent = Math.Round((hGVCount / (double)AllVehicles.Count) * 100, 1) + "%";

                    // Calculate and update the all vehicle bus percentage output 
                    data.simulationBusPercent = Math.Round((busCount / (double)AllVehicles.Count) * 100, 1) + "%";
                }
                else
                {
                    // Calculating percentages will result in dividing by 0 so just update the labels to default values

                    data.simulationSuccessfulSpawnsPercent = nullString;
                    data.simulationFailedSpawnsPercent = nullString;

                    data.simulationCarPercent = nullString;
                    data.simulationLGVPercent = nullString;
                    data.simulationHGVPercent = nullString;
                    data.simulationBusPercent = nullString;
                }

                if (successCount > 0)
                {
                    // Percentages can be calculated as won't divide by 0
                    // The (double)s are required to avoid integer division

                    // Calculate and update the all vehicle not congested percentage output 
                    data.simulationNotCongestedPercent = Math.Round((notCongestedCount / (double)successCount) * 100, 1) + "%";

                    // Calculate and update the all vehicle mildly congested percentage output 
                    data.simulationMildlyCongestedPercent = Math.Round((mildyCongestedCount / (double)successCount) * 100, 1) + "%";

                    // Calculate and update the all vehicle severely congested percentage output 
                    data.simulationSeverelyCongestedPercent = Math.Round((severelyCongestedCount / (double)successCount) * 100, 1) + "%";
                }
                else
                {
                    // Calculating percentages will result in dividing by 0 so just update the labels to default values
                    data.simulationNotCongestedPercent = nullString;
                    data.simulationMildlyCongestedPercent = nullString;
                    data.simulationSeverelyCongestedPercent = nullString;
                }

                // Update the simulation lifetime output
                TimeSpan simulationLifetime = TimeSpan.FromMilliseconds(TimePassed);
                data.simulationLifetime = simulationLifetime.Hours.ToString().PadLeft(2, '0') + "h " + simulationLifetime.Minutes.ToString().PadLeft(2, '0') + "m " + simulationLifetime.Seconds.ToString().PadLeft(2, '0') + "s " + simulationLifetime.Milliseconds.ToString().PadLeft(3, '0') + "ms";

            }
            else
            {
                // This is to a file with units so remove unncecessary data

                nullString = "";

                if (AllVehicles.Count > 0)
                {
                    // Percentages can be calculated as won't divide by 0
                    // The (double)s are required to avoid integer division

                    // Calculate and update the all vehicle successful spawn percentage output
                    data.simulationSuccessfulSpawnsPercent = Math.Round(successCount / (double)AllVehicles.Count, 3).ToString();

                    // Calculate and update the all vehicle failed spawn percentage output
                    data.simulationFailedSpawnsPercent = Math.Round(failedCount / (double)AllVehicles.Count, 3).ToString();


                    // Calculate and update the all vehicle car percentage output 
                    data.simulationCarPercent = Math.Round(carCount / (double)AllVehicles.Count, 3).ToString();

                    // Calculate and update the all vehicle LGV percentage output 
                    data.simulationLGVPercent = Math.Round(lGVCount / (double)AllVehicles.Count, 3).ToString();

                    // Calculate and update the all vehicle HGV percentage output 
                    data.simulationHGVPercent = Math.Round(hGVCount / (double)AllVehicles.Count, 3).ToString();

                    // Calculate and update the all vehicle bus percentage output 
                    data.simulationBusPercent = Math.Round(busCount / (double)AllVehicles.Count, 3).ToString();
                }
                else
                {
                    // Calculating percentages will result in dividing by 0 so just update the labels to default values

                    data.simulationSuccessfulSpawnsPercent = nullString;
                    data.simulationFailedSpawnsPercent = nullString;

                    data.simulationCarPercent = nullString;
                    data.simulationLGVPercent = nullString;
                    data.simulationHGVPercent = nullString;
                    data.simulationBusPercent = nullString;
                }

                if (successCount > 0)
                {
                    // Percentages can be calculated as won't divide by 0
                    // The (double)s are required to avoid integer division

                    // Calculate and update the all vehicle not congested percentage output 
                    data.simulationNotCongestedPercent = Math.Round(notCongestedCount / (double)successCount, 3).ToString();

                    // Calculate and update the all vehicle mildly congested percentage output 
                    data.simulationMildlyCongestedPercent = Math.Round(mildyCongestedCount / (double)successCount, 3).ToString();

                    // Calculate and update the all vehicle severely congested percentage output 
                    data.simulationSeverelyCongestedPercent = Math.Round(severelyCongestedCount / (double)successCount, 3).ToString();
                }
                else
                {
                    // Calculating percentages will result in dividing by 0 so just update the labels to default values
                    data.simulationNotCongestedPercent = nullString;
                    data.simulationMildlyCongestedPercent = nullString;
                    data.simulationSeverelyCongestedPercent = nullString;
                }

                // Update the simulation lifetime output
                TimeSpan simulationLifetime = TimeSpan.FromMilliseconds(TimePassed);
                data.simulationLifetime = simulationLifetime.Hours.ToString().PadLeft(2, '0') + "-" + simulationLifetime.Minutes.ToString().PadLeft(2, '0') + "-" + simulationLifetime.Seconds.ToString().PadLeft(2, '0') + "." + simulationLifetime.Milliseconds.ToString().PadLeft(3, '0');
            }



            // Update the all vehicle total vehicles output
            data.simulationTotalVehicles = AllVehicles.Count.ToString();

            // Update the all vehicle successful spawns output
            data.simulationTotalSuccessfulSpawns = successCount.ToString();

            // Update the all vehicle failed spawns output
            data.simulationTotalFailedSpawns = failedCount.ToString();


            // Update the all vehicle total cars output
            data.simulationTotalCar = carCount.ToString();

            // Update the all vehicle total LGVs output
            data.simulationTotalLGV = lGVCount.ToString();

            // Update the all vehicle total HGVs output
            data.simulationTotalHGV = hGVCount.ToString();

            // Update the all vehicle total buses output
            data.simulationTotalBus = busCount.ToString();


            // Update the Car Crashes count
            data.simulationCarCrashes = carCrashes.ToString();

            // Update the LGV Crashes count
            data.simulationLGVCrashes = lGVCrashes.ToString();

            // Update the HGV Crashes count
            data.simulationHGVCrashes = hGVCrashes.ToString();

            // Update the Bus Crashes count
            data.simulationBusCrashes = busCrashes.ToString();

            // Update the Total Crashes count
            data.simulationTotalCrashes = (carCrashes + lGVCrashes + hGVCrashes + busCrashes).ToString();


            // Update the Car Campers count
            data.simulationCarCampers = carCampers.ToString();

            // Update the LGV Campers count
            data.simulationLGVCampers = lGVCampers.ToString();

            // Update the HGV Campers count
            data.simulationHGVCampers = hGVCampers.ToString();

            // Update the Bus Campers count
            data.simulationBusCampers = busCampers.ToString();

            // Update the Total Campers count
            data.simulationTotalCampers = (carCampers + lGVCampers + hGVCampers + busCampers).ToString();


            // Update the all vehicle total not congested output
            data.simulationTotalNotCongested = notCongestedCount.ToString();

            // Update the all vehicle total mildly congested output
            data.simulationTotalMildlyCongested = mildyCongestedCount.ToString();

            // Update the all vehicle total severely congested output
            data.simulationTotalSeverelyCongested = severelyCongestedCount.ToString();


            return data;
        }

        /// <summary>
        /// The method which is in charge of updating each piece of information on the output data tab
        /// </summary>
        private void UpdateData()
        {
            // Update the vehicles TreeView
            UpdateTreeViewVehicles();

            if (SelectedVehicle != null)
            {
                // Vehicle is actually selected
                VehicleData selectedVehicleData = GetVehicleData(SelectedVehicle, DataFormat.Panel);

                // Update the vehicle ID output
                LabelVehicleID.Text = selectedVehicleData.vehicleID;

                // Update the vehicle type output
                LabelVehicleType.Text = selectedVehicleData.vehicleType;

                // Update the vehicle length output
                LabelVehicleLength.Text = selectedVehicleData.vehicleLength;

                // Update the vehicle desired speed output
                LabelVehicleDesiredSpeed.Text = selectedVehicleData.vehicleDesiredSpeed;

                // Update the vehicle actual speed output
                LabelVehicleActualSpeed.Text = selectedVehicleData.vehicleActualSpeed;

                // Update the vehicle successful spawn output
                LabelVehicleSuccessfulSpawn.Text = selectedVehicleData.vehicleSuccessfulSpawn;

                // Update the vehicle spawn time output
                LabelVehicleSpawnTime.Text = selectedVehicleData.vehicleSpawnTime;

                // Update the vehicle despawn time output
                LabelVehicleDespawnTime.Text = selectedVehicleData.vehicleDespawnTime;

                // Update the vehicle lifetime output
                LabelVehicleLifetime.Text = selectedVehicleData.vehicleLifetime;

                // Update the vehicle progress output
                LabelVehicleProgress.Text = selectedVehicleData.vehicleProgress;

                // Update the vehicle lane output
                LabelVehicleLane.Text = selectedVehicleData.vehicleLane;

                // Update the vehicle camper output
                LabelVehicleCamper.Text = selectedVehicleData.vehicleCamper;

                // Update the vehicle average speed output
                LabelVehicleAverageSpeed.Text = selectedVehicleData.vehicleAverageSpeed;

                // Update the vehicle congestion output
                LabelVehicleCongestion.Text = selectedVehicleData.vehicleCongestion;

                // Update the vehicle crashed output
                LabelVehicleCrashed.Text = selectedVehicleData.vehicleCrashed;
            }
            else
            {
                string nullString = "---";
                
                LabelVehicleID.Text = nullString;
                LabelVehicleType.Text = nullString;
                LabelVehicleLength.Text = nullString;
                LabelVehicleDesiredSpeed.Text = nullString;
                LabelVehicleActualSpeed.Text = nullString;
                LabelVehicleSuccessfulSpawn.Text = nullString;
                LabelVehicleSpawnTime.Text = nullString;
                LabelVehicleDespawnTime.Text = nullString;
                LabelVehicleLifetime.Text = nullString;
                LabelVehicleProgress.Text = nullString;
                LabelVehicleLane.Text = nullString;
                LabelVehicleCamper.Text = nullString;
                LabelVehicleAverageSpeed.Text = nullString;
                LabelVehicleCongestion.Text = nullString;
                LabelVehicleCrashed.Text = nullString;
            }

            SimulationData simulationData = GetSimulationData(DataFormat.Panel);

            // Update the all vehicle total vehicles output
            LabelAllVehiclesTotalVehicles.Text = simulationData.simulationTotalVehicles;

            // Update the all vehicle successful spawns output
            LabelAllVehiclesTotalSuccessfulSpawns.Text = simulationData.simulationTotalSuccessfulSpawns;

            // Update the all vehicle failed spawns output
            LabelAllVehiclesTotalFailedSpawns.Text = simulationData.simulationTotalFailedSpawns;


            // Update the all vehicle total cars output
            LabelAllVehiclesTotalCar.Text = simulationData.simulationTotalCar;

            // Update the all vehicle total LGVs output
            LabelAllVehiclesTotalLGV.Text = simulationData.simulationTotalLGV;

            // Update the all vehicle total HGVs output
            LabelAllVehiclesTotalHGV.Text = simulationData.simulationTotalHGV;

            // Update the all vehicle total buses output
            LabelAllVehiclesTotalBus.Text = simulationData.simulationTotalBus;


            // Update the Car Crashes count
            LabelAllVehiclesCarCrashes.Text = simulationData.simulationCarCrashes;

            // Update the LGV Crashes count
            LabelAllVehiclesLGVCrashes.Text = simulationData.simulationLGVCrashes;

            // Update the HGV Crashes count
            LabelAllVehiclesHGVCrashes.Text = simulationData.simulationHGVCrashes;

            // Update the Bus Crashes count
            LabelAllVehiclesBusCrashes.Text = simulationData.simulationBusCrashes;

            // Update the Total Crashes count
            LabelAllVehiclesTotalCrashes.Text = simulationData.simulationTotalCrashes;


            // Update the Car Campers count
            LabelAllVehiclesCarCampers.Text = simulationData.simulationCarCampers;

            // Update the LGV Campers count
            LabelAllVehiclesLGVCampers.Text = simulationData.simulationLGVCampers;

            // Update the HGV Campers count
            LabelAllVehiclesHGVCampers.Text = simulationData.simulationHGVCampers;

            // Update the Bus Campers count
            LabelAllVehiclesBusCampers.Text = simulationData.simulationBusCampers;

            // Update the Total Campers count
            LabelAllVehiclesTotalCampers.Text = simulationData.simulationTotalCampers;


            // Update the all vehicle total not congested output
            LabelAllVehiclesTotalNotCongested.Text = simulationData.simulationTotalNotCongested;

            // Update the all vehicle total mildly congested output
            LabelAllVehiclesTotalMildlyCongested.Text = simulationData.simulationTotalMildlyCongested;

            // Update the all vehicle total severely congested output
            LabelAllVehiclesTotalSeverelyCongested.Text = simulationData.simulationTotalSeverelyCongested;

            // Calculate and update the all vehicle successful spawn percentage output
            LabelAllVehiclesSuccessfulSpawnsPercent.Text = simulationData.simulationSuccessfulSpawnsPercent;

            // Calculate and update the all vehicle failed spawn percentage output
            LabelAllVehiclesFailedSpawnsPercent.Text = simulationData.simulationFailedSpawnsPercent;


            // Calculate and update the all vehicle car percentage output 
            LabelAllVehiclesCarPercent.Text = simulationData.simulationCarPercent;

            // Calculate and update the all vehicle LGV percentage output 
            LabelAllVehiclesLGVPercent.Text = simulationData.simulationLGVPercent;

            // Calculate and update the all vehicle HGV percentage output 
            LabelAllVehiclesHGVPercent.Text = simulationData.simulationHGVPercent;

            // Calculate and update the all vehicle bus percentage output 
            LabelAllVehiclesBusPercent.Text = simulationData.simulationBusPercent;

            // Calculate and update the all vehicle not congested percentage output 
            LabelAllVehiclesNotCongestedPercent.Text = simulationData.simulationNotCongestedPercent;

            // Calculate and update the all vehicle mildly congested percentage output 
            LabelAllVehiclesMildlyCongestedPercent.Text = simulationData.simulationMildlyCongestedPercent;

            // Calculate and update the all vehicle severely congested percentage output 
            LabelAllVehiclesSeverelyCongestedPercent.Text = simulationData.simulationSeverelyCongestedPercent;

            // Update the simulation lifetime output
            LabelAllVehiclesLifetime.Text = simulationData.simulationLifetime;
        }

        private void SaveData()
        {
            string filename = ActiveRunStartTime.ToString("yyyy-MM-dd-T-HH-mm-ss-fff");
            string path = Path.Combine("data", filename);
            Directory.CreateDirectory("data");
            using (StreamWriter inDataFile = new StreamWriter(path + "-INPUT.csv"))
            {
                string header = "Run Duration Enabled (Boolean)," +
                    "Run Duration (hh-mm-ss.ms)," +
                    "Road Length (Metres)," +
                    "Interarrival Time Base (Seconds)," +
                    "Interarrival Variation (±%)," +
                    "Stopping Time (Seconds)," +
                    "Lane Count (Lanes)," +
                    "Vehicle Width (Metres)," +
                    "Max Crash Count (Crashes)," +
                    "Metre To Pixel Scaling Factor," +
                    "Congestion Mild Trip Point (Metres/H)," +
                    "Congestion Severe Trip Point (Metres/H)," +
                    "Length Base Car (Metres)," +
                    "Length Base LGV (Metres)," +
                    "Length Base HGV (Metres)," +
                    "Length Base Bus (Metres)," +
                    "Length Variation Car (±Metres)," +
                    "Length Variation LGV (±Metres)," +
                    "Length Variation HGV (±Metres)," +
                    "Length Variation Bus (±Metres)," +
                    "Speed Base Car (Metres/H)," +
                    "Speed Base LGV (Metres/H)," +
                    "Speed Base HGV (Metres/H)," +
                    "Speed Base Bus (Metres/H)," +
                    "Speed Variation Car (±Metres/H)," +
                    "Speed Variation LGV (±Metres/H)," +
                    "Speed Variation HGV (±Metres/H)," +
                    "Speed Variation Bus (±Metres/H)," +
                    "Maximum Lane Car (Lane #)," +
                    "Maximum Lane LGV (Lane #)," +
                    "Maximum Lane HGV (Lane #)," +
                    "Maximum Lane Bus (Lane #)," +
                    "Camper Probability Car," +
                    "Camper Probability LGV," +
                    "Camper Probability HGV," +
                    "Camper Probability Bus," +
                    "Crash Probability Car," +
                    "Crash Probability LGV," +
                    "Crash Probability HGV," +
                    "Crash Probability Bus," +
                    "Spawn Probability Car," +
                    "Spawn Probability LGV," +
                    "Spawn Probability HGV," +
                    "Spawn Probability Bus";
                string dataString = ActiveRunDurationEnabled + "," +
                    ActiveRunDuration.Hour + "-" + ActiveRunDuration.Minute + "-" + ActiveRunDuration.Second + "." + ActiveRunDuration.Millisecond + "," +
                    ActiveRoadLengthMetres + "," +
                    ActiveInterArrivalTime + "," +
                    ActiveInterArrivalTimeVariationPercentage + "," +
                    ActiveStoppingTime + "," +
                    ActiveLaneCount + "," +
                    ActiveVehicleWidthMetres + "," +
                    ActiveMaxCrashCount + "," +
                    ActiveMetresToPixelsScalingFactor + "," +
                    ActiveMildCongestionTriggerMetresHour + "," +
                    ActiveSevereCongestionTriggerMetresHour + "," +
                    VehicleParameters[VehicleTypes.Car].Length + "," +
                    VehicleParameters[VehicleTypes.LGV].Length + "," +
                    VehicleParameters[VehicleTypes.HGV].Length + "," +
                    VehicleParameters[VehicleTypes.Bus].Length + "," +
                    VehicleParameters[VehicleTypes.Car].LengthVariation + "," +
                    VehicleParameters[VehicleTypes.LGV].LengthVariation + "," +
                    VehicleParameters[VehicleTypes.HGV].LengthVariation + "," +
                    VehicleParameters[VehicleTypes.Bus].LengthVariation + "," +
                    VehicleParameters[VehicleTypes.Car].DesiredSpeed + "," +
                    VehicleParameters[VehicleTypes.LGV].DesiredSpeed + "," +
                    VehicleParameters[VehicleTypes.HGV].DesiredSpeed + "," +
                    VehicleParameters[VehicleTypes.Bus].DesiredSpeed + "," +
                    VehicleParameters[VehicleTypes.Car].DesiredSpeedVariation + "," +
                    VehicleParameters[VehicleTypes.LGV].DesiredSpeedVariation + "," +
                    VehicleParameters[VehicleTypes.HGV].DesiredSpeedVariation + "," +
                    VehicleParameters[VehicleTypes.Bus].DesiredSpeedVariation + "," +
                    VehicleParameters[VehicleTypes.Car].MaximumLane + "," +
                    VehicleParameters[VehicleTypes.LGV].MaximumLane + "," +
                    VehicleParameters[VehicleTypes.HGV].MaximumLane + "," +
                    VehicleParameters[VehicleTypes.Bus].MaximumLane + "," +
                    VehicleParameters[VehicleTypes.Car].CamperProbability + "," +
                    VehicleParameters[VehicleTypes.LGV].CamperProbability + "," +
                    VehicleParameters[VehicleTypes.HGV].CamperProbability + "," +
                    VehicleParameters[VehicleTypes.Bus].CamperProbability + "," +
                    VehicleParameters[VehicleTypes.Car].CrashProbability + "," +
                    VehicleParameters[VehicleTypes.LGV].CrashProbability + "," +
                    VehicleParameters[VehicleTypes.HGV].CrashProbability + "," +
                    VehicleParameters[VehicleTypes.Bus].CrashProbability + "," +
                    VehicleParameters[VehicleTypes.Car].Probability + "," +
                    VehicleParameters[VehicleTypes.LGV].Probability + "," +
                    VehicleParameters[VehicleTypes.HGV].Probability + "," +
                    VehicleParameters[VehicleTypes.Bus].Probability;
                inDataFile.WriteLine(header);
                inDataFile.WriteLine(dataString);
            }
            using (StreamWriter outOverallDataFile = new StreamWriter(path + "-OVERALL-OUTPUT.csv"))
            {
                string header = "Total Vehicles (#)," +
                    "Total Cars (#)," +
                    "Total LGVs (#)," +
                    "Total HGVs (#)," +
                    "Total Buses (#)," +
                    "Cars (%)," +
                    "LGVs (%)," +
                    "HGVs (%)," +
                    "Buses (%)," +
                    "Total Not Congested (#)," +
                    "Total Mildly Congested (#)," +
                    "Total Severely Congested (#)," +
                    "Not Congested (%)," +
                    "Mildly Congested (%)," +
                    "Severely Congested (%)," +
                    "Car Crashes (#)," +
                    "LGV Crashes (#)," +
                    "HGV Crashes (#)," +
                    "Bus Crashes (#)," +
                    "Total Crashes (#)," +
                    "Car Campers (#)," +
                    "LGV Campers (#)," +
                    "HGV Campers (#)," +
                    "Bus Campers (#)," +
                    "Total Campers (#)," +
                    "Successful Spawns (#)," +
                    "Failed Spawns (#)," +
                    "Successful Spawns (%)," +
                    "Failed Spawns (%)," +
                    "Total Lifetime (hh-mm-ss.ms)";
                SimulationData simulationData = GetSimulationData(DataFormat.File);
                string dataString = simulationData.simulationTotalVehicles + "," +
                    simulationData.simulationTotalCar + "," +
                    simulationData.simulationTotalLGV + "," +
                    simulationData.simulationTotalHGV + "," +
                    simulationData.simulationTotalBus + "," +
                    simulationData.simulationCarPercent + "," +
                    simulationData.simulationLGVPercent + "," +
                    simulationData.simulationHGVPercent + "," +
                    simulationData.simulationBusPercent + "," +
                    simulationData.simulationTotalNotCongested + "," +
                    simulationData.simulationTotalMildlyCongested + "," +
                    simulationData.simulationTotalSeverelyCongested + "," +
                    simulationData.simulationNotCongestedPercent + "," +
                    simulationData.simulationMildlyCongestedPercent + "," +
                    simulationData.simulationSeverelyCongestedPercent + "," +
                    simulationData.simulationCarCrashes + "," +
                    simulationData.simulationLGVCrashes + "," +
                    simulationData.simulationHGVCrashes + "," +
                    simulationData.simulationBusCrashes + "," +
                    simulationData.simulationTotalCrashes + "," +
                    simulationData.simulationCarCampers + "," +
                    simulationData.simulationLGVCampers + "," +
                    simulationData.simulationHGVCampers + "," +
                    simulationData.simulationBusCampers + "," +
                    simulationData.simulationTotalCampers + "," +
                    simulationData.simulationTotalSuccessfulSpawns + "," +
                    simulationData.simulationTotalFailedSpawns + "," +
                    simulationData.simulationSuccessfulSpawnsPercent + "," +
                    simulationData.simulationFailedSpawnsPercent + "," +
                    simulationData.simulationLifetime;
                outOverallDataFile.WriteLine(header);
                outOverallDataFile.WriteLine(dataString);
            }
            using (StreamWriter outVehicleDataFile = new StreamWriter(path + "-VEHICLE-OUTPUT.csv"))
            {
                string header = "Vehicle ID," +
                    "Vehicle Type," +
                    "Vehicle Length (Metres)," +
                    "Successful Spawn (Boolean)," +
                    "Spawn Time (hh-mm-ss.ms)," +
                    "Despawn Time (hh-mm-ss.ms)," +
                    "Lifetime (hh-mm-ss.ms)," +
                    "Progress (Metres)," +
                    "Lane (#)," +
                    "Lane Camper (Boolean)," +
                    "Desired Speed (Metres/H)," +
                    "Actual Speed (Metres/H)," +
                    "Average Speed (Metres/H)," +
                    "Congestion," +
                    "Crashed (Boolean)";
                outVehicleDataFile.WriteLine(header);
                foreach (Vehicle vehicle in AllVehicles)
                {
                    VehicleData vehicleData = GetVehicleData(vehicle, DataFormat.File);
                    string dataString = vehicleData.vehicleID + "," +
                        vehicleData.vehicleType + "," +
                        vehicleData.vehicleLength + "," +
                        vehicleData.vehicleSuccessfulSpawn + "," +
                        vehicleData.vehicleSpawnTime + "," +
                        vehicleData.vehicleDespawnTime + "," +
                        vehicleData.vehicleLifetime + "," +
                        vehicleData.vehicleProgress + "," +
                        vehicleData.vehicleLane + "," +
                        vehicleData.vehicleCamper + "," +
                        vehicleData.vehicleDesiredSpeed + "," +
                        vehicleData.vehicleActualSpeed + "," +
                        vehicleData.vehicleAverageSpeed + "," +
                        vehicleData.vehicleCongestion + "," +
                        vehicle.Crashed;
                    outVehicleDataFile.WriteLine(dataString);
                }
            }
        }

        /// <summary>
        /// Prompts each lane to update its specific lane node on the vehicles TreeView
        /// </summary>
        private void UpdateTreeViewVehicles()
        {
            for (int laneIndex = 0; laneIndex < ActiveLaneCount; laneIndex++)
            {
                // Updates that lane's lane node
                LaneControl lane = Lanes[laneIndex];
                lane.UpdateTreeNode();
            }
        }

        #endregion
    }

    /// <summary>
    /// Each instance of this class describes each detail of a different type of vehicle.
    /// In this simulation there will be 4 instances of this class, one to describe each of Car, LGV, HGV, and Bus
    /// </summary>
    public class VehicleTemplate
    {
        #region Variable Declarations

        /// <summary>
        /// Describes the base length of the vehicle type (metres)
        /// </summary>
        public double Length;

        /// <summary>
        /// Describes the plus or minus value from the base length (metres)
        /// </summary>
        public double LengthVariation;

        /// <summary>
        /// Describes the base desired speed of the vehicle type (metres per hour)
        /// </summary>
        public int DesiredSpeed;

        /// <summary>
        /// Describes the plus or minus value from the base desired speed of the vehicle type (metres per hour)
        /// </summary>
        public double DesiredSpeedVariation;

        /// <summary>
        /// Describes the probability (0.00 - 1.00) of that vehicle type camping
        /// </summary>
        public double CamperProbability;

        /// <summary>
        /// Describes the probability (0.00 - 1.00) of that vehicle type crashing
        /// </summary>
        public double CrashProbability;

        /// <summary>
        /// Describes the probability (0.00 - 1.00) of that vehicle type spawning
        /// </summary>
        public double Probability;

        /// <summary>
        /// Describes the maximum possible lane that vehicle type is permitted to occupy
        /// </summary>
        public int MaximumLane;

        #endregion

        /// <summary>
        /// This is the constructor for the VehicleTemplate class. It requires all details be passed into the constructor at initialisation time.
        /// </summary>
        /// <param name="length">The base length of the vehicle type (metres)</param>
        /// <param name="lengthVariation">The plus or minus length of the vehicle type (metres)</param>
        /// <param name="desiredSpeed">The base desired speed of the vehicle type (mph)</param>
        /// <param name="desiredSpeedVariation">The plus or minus speed of the vehicle type (mph)</param>
        /// <param name="maximumLane">The maximum lane that the vehicle type can occupy</param>
        /// <param name="probability">The probability of that vehicle type spawning (0.00-1.00)</param>
        public VehicleTemplate(double length, double lengthVariation, int desiredSpeed, double desiredSpeedVariation, int maximumLane, double camperProbability, double crashProbability, double spawnProbability)
        {
            Length = length;
            LengthVariation = lengthVariation;
            DesiredSpeed = desiredSpeed;
            DesiredSpeedVariation = desiredSpeedVariation;
            MaximumLane = maximumLane;
            CrashProbability = crashProbability;
            CamperProbability = camperProbability;
            Probability = spawnProbability;
        }
    }

    /// <summary>
    /// Each instance of this class describes each detail of spawning in a vehicle at a particular time in the simulation
    /// </summary>
    public class DebugVehicleSpawnInstruction
    {
        #region Variable Declarations

        /// <summary>
        /// The ID of the vehicle to spawn
        /// </summary>
        public int VehicleId;

        /// <summary>
        /// The enum type of the vehicle to spawn
        /// </summary>
        public VehicleTypes Type;

        /// <summary>
        /// The lane of the vehicle to spawn in
        /// </summary>
        public LaneControl Lane;

        /// <summary>
        /// The time in realtime to spawn the vehicle
        /// </summary>
        public long RealTimeSpawnTime;

        /// <summary>
        /// The desired speed in metres per hour of the vehicle to spawn
        /// </summary>
        public double DesiredSpeedMetresHour;

        /// <summary>
        /// The Length of the vehicle to spawn in metres
        /// </summary>
        public double VehicleLength;

        /// <summary>
        /// The location that this vehicle will crash at
        /// </summary>
        public double CrashLocation;

        /// <summary>
        /// If this vehicle is lane camper
        /// </summary>
        public bool Camper;

        #endregion

        /// <summary>
        /// This is the constructor for the DebugVehicleSpawnInstruction class. It requires all details be passed into the constructor at initialisation time.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to spawn</param>
        /// <param name="type">The enum type of the vehicle to spawn</param>
        /// <param name="lane">The lane of the vehicle to spawn in</param>
        /// <param name="realTimeSpawnTime">The time in realtime to spawn the vehicle</param>
        /// <param name="desiredSpeedMetresHour">The desired speed in metres per hour of the vehicle to spawn</param>
        /// <param name="vehicleLength">The Length of the vehicle to spawn in metres</param>
        /// <param name="crashLocation">The location for the vehicle to crash</param>
        /// <param name="camper">If this vehicle is lane camper</param>
        public DebugVehicleSpawnInstruction(int vehicleId, VehicleTypes type, LaneControl lane, long realTimeSpawnTime, double desiredSpeedMetresHour = 0, double vehicleLength = 0, double crashLocation = -1, bool camper = false)
        {
            VehicleId = vehicleId;
            Type = type;
            Lane = lane;
            RealTimeSpawnTime = realTimeSpawnTime;
            DesiredSpeedMetresHour = desiredSpeedMetresHour;
            VehicleLength = vehicleLength;
            CrashLocation = crashLocation;
            Camper = camper;
        }
    }

    public enum DataFormat
    {
        Panel,
        File
    }

    /// <summary>
    /// Each instance of this class contains the data for a vehicle that should be displayed on its record
    /// </summary>
    public class VehicleData
    {
        public string vehicleID;
        public string vehicleType;
        public string vehicleLength;
        public string vehicleDesiredSpeed;
        public string vehicleActualSpeed;
        public string vehicleSuccessfulSpawn;
        public string vehicleSpawnTime;
        public string vehicleDespawnTime;
        public string vehicleLifetime;
        public string vehicleProgress;
        public string vehicleLane;
        public string vehicleCamper;
        public string vehicleAverageSpeed;
        public string vehicleCongestion;
        public string vehicleCrashed;
    }

    /// <summary>
    /// Each instance of this class contains the data for the overall simulation
    /// </summary>
    public class SimulationData
    {
        public string simulationTotalVehicles;
        public string simulationTotalSuccessfulSpawns;
        public string simulationTotalFailedSpawns;
        public string simulationSuccessfulSpawnsPercent;
        public string simulationFailedSpawnsPercent;
        public string simulationTotalCar;
        public string simulationTotalLGV;
        public string simulationTotalHGV;
        public string simulationTotalBus;
        public string simulationCarPercent;
        public string simulationLGVPercent;
        public string simulationHGVPercent;
        public string simulationBusPercent;
        public string simulationCarCrashes;
        public string simulationLGVCrashes;
        public string simulationHGVCrashes;
        public string simulationBusCrashes;
        public string simulationTotalCrashes;
        public string simulationCarCampers;
        public string simulationLGVCampers;
        public string simulationHGVCampers;
        public string simulationBusCampers;
        public string simulationTotalCampers;
        public string simulationTotalNotCongested;
        public string simulationTotalMildlyCongested;
        public string simulationTotalSeverelyCongested;
        public string simulationNotCongestedPercent;
        public string simulationMildlyCongestedPercent;
        public string simulationSeverelyCongestedPercent;
        public string simulationLifetime;
    }
}