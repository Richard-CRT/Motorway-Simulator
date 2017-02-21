/* Included System Namespaces/Libraries */
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* My Custom Control Namespace/Library */
using CustomControls;

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
        /// Width of each vehicle in metres
        /// </summary>
        private const double VehicleWidthMetres = 2;
        /// <summary>
        /// Scaling factor from Metres To Pixels
        /// </summary>
        private const int MetresToPixelsScalingFactor = 10;
        /// <summary>
        /// The margin between the white line and the side of each vehicle in metres
        /// </summary>
        private const double LaneMarginMetres = 0.8;
        /// <summary>
        /// The number of seconds the simulation will allow for the vehicles to to stop in when calculating stopping distance
        /// </summary>
        private const double StoppingTime = 1;


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
        /// The margin that the average speed of a vehicle must be below it's desired spped to be mildly congested
        /// </summary>
        public int ActiveMildCongestionTriggerMetresHour;
        /// <summary>
        /// The margin that the average speed of a vehicle must be below it's desired spped to be severely congested
        /// </summary>
        public int ActiveSevereCongestionTriggerMetresHour;
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


        /* Interarrival Variables */

        /// <summary>
        /// The last timer value in milliseconds used to calculate delta-time for the vehicle arrival algorithm
        /// </summary>
        private long LastArrivalTimerValue;
        /// <summary>
        /// The chosen variation for the next vehicle spawn
        /// </summary>
        private double ChosenInterArrivalVariationPercentage;


        /* Time */

        /// <summary>
        /// Provides the realtime time measuring capability (stopwatch is a system class not created by me)
        /// </summary>
        public Stopwatch Timer;
        /// <summary>
        /// The scaling factor for all delta-times in the simulation - Allows for slowing down the simulation realtime
        /// </summary>
        public double TimeScale;
        /// <summary>
        /// The scaled time passed since the beginning of the simulation
        /// </summary>
        public double ScaledTimePassed;
        /// <summary>
        /// The timer value in milliseconds recorded during the last tick used to calculate delta-time for the scaled time passed
        /// </summary>
        private long LastTimerValue;


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
        /// Contains the state of the simulation Started, Stopped or Paused (see the SimulationStates enumerator)
        /// </summary>
        private SimulationStates SimulationState;
        /// <summary>
        /// The specific vehicle object that has been selected for data output
        /// </summary>
        private Vehicle SelectedVehicle;


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

            // Initialise variables
            DebugMode = true;
            Timer = new Stopwatch();
            RandomGenerator = new Random();
            SimulationState = SimulationStates.Stopped;
            Lanes = new List<LaneControl>();
            AllVehicles = new List<Vehicle>();
            SelectedVehicle = null;
            DebugModeInstructions = new List<DebugVehicleSpawnInstruction>();

            // Update labels
            UpdateInterArrivalTime(null, null);
            UpdateInterArrivalVariation(null, null);
            UpdateLaneCount(null, null);
            UpdateRoadLength(null, null);
            UpdateTimescale(null, null);
            ValidateProbabilityChange(null, null);

            // Calculate values in pixels from metre constants
            LaneMarginPixels = (int)Math.Round(MetresToPixels(MotorwaySimulatorForm.LaneMarginMetres), 0);
            VehicleWidthPixels = (int)Math.Round(MetresToPixels(MotorwaySimulatorForm.VehicleWidthMetres), 0);
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
            LabelRoadLength.Text = Math.Round(TrackBarRoadLength.Value / (double)100, 2) + " km";
            RoadLengthMetres = TrackBarRoadLength.Value * 10;
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
            // The TrackBar stores increments of 0.1%, so divide by 10 to get % or divide by 1000 to get decimal %
            // The (double) is required to avoid integer division
            LabelInterArrivalVariation.Text = Math.Round(TrackBarInterArrivalVariation.Value / (double)10, 1) + "%";
            InterArrivalTimeVariationPercentage = TrackBarInterArrivalVariation.Value / (double)1000;
        }

        /// <summary>
        /// Updates LabelLaneCount and the LaneCount variable to the new value whenever TrackBarLaneCount changes value.
        /// Also reduces the maximum of value of each of the 'maximum lane' fields to the new lane count.
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
        /// Updates LabelTimeScale and the TimeScale variable to the new value whenever TrackBarTimescale changes value.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void UpdateTimescale(object sender, EventArgs e)
        {
            // The TrackBar stores increments of 0.01x, so divide by 100 to get the scaling factor
            // The (double) is required to avoid integer division
            TimeScale = TrackBarTimescale.Value / (double)100;
            LabelTimeScale.Text = Math.Round(TrackBarTimescale.Value / (double)100, 2) + "x";
        }

        /// <summary>
        /// This method simply updates the panel control which contains the 'control panel' location to be on screen whenever the form is scrolled
        /// </summary>
        private void UpdateControlPanelLocation(object sender, ScrollEventArgs e)
        {
            PanelSettings.Location = new Point(12, 12);
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
            Timer.Stop();
            // Pause the form ticks
            FormTick.Enabled = false;

            // Update the simulation state
            SimulationState = SimulationStates.Paused;

            // Update the enabled state of the Play, Pause and Stop buttons
            ButtonStop.Enabled = true;
            ButtonPause.Enabled = false;
            ButtonStart.Enabled = true;
        }

        /// <summary>
        /// Stop the simulation when the stop button is clicked
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            // Pause the stopwatch
            Timer.Stop();
            // Pause the form ticks
            FormTick.Enabled = false;

            // Update the simulation state
            SimulationState = SimulationStates.Stopped;

            // Update the enabled state of the Play, Pause and Stop buttons
            ButtonStop.Enabled = false;
            ButtonPause.Enabled = false;
            ButtonStart.Enabled = true;
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
                int newPosition = SelectedVehicle.ProgressPixels - (Width / 8);
                if (newPosition < 0)
                {
                    newPosition = 0;
                }
                if (newPosition > HorizontalScroll.Maximum)
                {
                    newPosition = HorizontalScroll.Maximum;
                }
                // Scroll the form to the right place
                HorizontalScroll.Value = newPosition;
                // Update the location of the control panel so it is still in view
                UpdateControlPanelLocation(null, null);
            }
        }

        /// <summary>
        /// This is the underlying update structure of the simulation. Everytime the FormTick form control 'ticks' (every 15ms) this function is called.
        /// Firstly it checks to see if a new vehicle should be spawned.
        /// Secondly, it increments the scaled time passed by the scaled elapsed miliseconds since the last tick
        /// Thirdly, it individually ticks each vehicle's lane handling method in order of progress along the road.
        /// Then, it individually ticks each vehicle's movement handling method in order of progress along the road.
        ///     After ticking each vehicle's movement handling method, it checks if the vehicle is having a visible effect on any other vehicles on the road.
        /// If the vehicles behind in the lane to the left, right and the same as the current vehicle are out of sight, the vehicle is deemed to be no longer affecting any vehicles and removed from the road and vehicles TreeView.
        ///     A new entry is also created for the vehicle in the finished vehicle TreeView.
        /// Penultimately, the method marks each lane for repainting on the form as the vehicle's positions have changed.
        /// Finally, the method updates the output data shown on the data tab.
        /// </summary>
        /// <param name="sender">(Auto-generated) Object that sends the event</param>
        /// <param name="e">(Auto-generated) Event arguments containing the details of the event</param>
        private void FormTick_Tick(object sender, EventArgs e)
        {
            // Check if a new vehicle should be spawned
            CheckVehicle();

            // Increment the scaled time passed by the scaled elapsed time
            long tempTime = Timer.ElapsedMilliseconds;
            long elapsedTime = tempTime - LastTimerValue;
            LastTimerValue = tempTime;
            double scaledElapsedTime = elapsedTime * TimeScale;
            ScaledTimePassed += scaledElapsedTime;

            Vehicle[] OrderedVehicles = AllActiveVehiclesOrderByLocation();

            // Tick the lane handling method of each vehicle by location
            foreach (Vehicle vehicle in OrderedVehicles)
            {
                vehicle.LaneTick();
            }

            foreach (Vehicle vehicle in OrderedVehicles)
            {
                // Tick the movment handling method of each vehicle by location
                vehicle.MovementTick();
                
                if (!vehicle.InSight)
                {
                    // The vehicle is still in sight

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
                    vehicle.TimeDisappearance = ScaledTimePassed;

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

            // Update the output data of the data tab
            UpdateData();
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
            return metres * MotorwaySimulatorForm.MetresToPixelsScalingFactor;
        }

        /// <summary>
        /// This method calculates the stopping distance in metres given a speed in metres per hour (using a time period of 1s to stop in) using the StoppingTime constant
        /// </summary>
        /// <param name="metresHour">The number of metres per hour to be used in the calculation</param>
        /// <returns>The stopping distance in metres</returns>
        public double StoppingDistance(double metresHour)
        {
            return (metresHour * MotorwaySimulatorForm.StoppingTime) / (60 * 60);
        }

        /// <summary>
        /// Sums together the spawn probabilities from the form inputs
        /// </summary>
        /// <returns>The sum of the spawn probabilities from the form inputs</returns>
        private int GetTotalSpawnProbability()
        {
            return (int)(NumericCarSpawnProbability.Value + NumericLGVSpawnProbability.Value + NumericHGVSpawnProbability.Value + NumericBusSpawnProbability.Value); // drop the decimal parts as the values should be integers despite the decimal type
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

            // Assign the parameters for use in the simulation from the form inputs
            VehicleParameters = new Dictionary<VehicleTypes, VehicleTemplate>()
            {
                // Length (metres), Length Variation (+-) (metres), Desired Speed (meters/hour), Desired Speed Variation (+-) (meters/hour), Maximum Lane, Probability

                { VehicleTypes.Car, new VehicleTemplate((double)NumericCarLength.Value, (double)NumericCarLengthVar.Value,  (int)(NumericCarDesiredSpeed.Value*1000),  (double)(NumericCarDesiredSpeedVar.Value*1000), (int)(NumericCarMaximumLane.Value),  (double)(NumericCarSpawnProbability.Value/100)) },
                { VehicleTypes.LGV, new VehicleTemplate((double)NumericLGVLength.Value, (double)NumericLGVLengthVar.Value,  (int)(NumericLGVDesiredSpeed.Value*1000),  (double)(NumericLGVDesiredSpeedVar.Value*1000), (int)(NumericCarMaximumLane.Value),  (double)(NumericLGVSpawnProbability.Value/100)) },
                { VehicleTypes.HGV, new VehicleTemplate((double)NumericHGVLength.Value, (double)NumericHGVLengthVar.Value,  (int)(NumericHGVDesiredSpeed.Value*1000),  (double)(NumericHGVDesiredSpeedVar.Value*1000), (int)(NumericCarMaximumLane.Value),  (double)(NumericHGVSpawnProbability.Value/100)) },
                { VehicleTypes.Bus, new VehicleTemplate((double)NumericBusLength.Value, (double)NumericBusLengthVar.Value,  (int)(NumericBusDesiredSpeed.Value*1000),  (double)(NumericBusDesiredSpeedVar.Value*1000), (int)(NumericCarMaximumLane.Value),  (double)(NumericBusSpawnProbability.Value/100)) }
            };

            ActiveLaneCount = LaneCount;

            ActiveRoadLengthMetres = RoadLengthMetres;
            int activeRoadLengthPixels = (int)Math.Round(MetresToPixels(ActiveRoadLengthMetres), 0);


            ActiveMildCongestionTriggerMetresHour = (int)NumericMildCongestion.Value * 1000;
            ActiveSevereCongestionTriggerMetresHour = (int)NumericSevereCongestion.Value * 1000;

            ActiveInterArrivalTime = InterArrivalTime;
            ActiveInterArrivalTimeVariationPercentage = InterArrivalTimeVariationPercentage;
            ChosenInterArrivalVariationPercentage = -1;

            int laneWidth = VehicleWidthPixels + (2 * LaneMarginPixels);

            // Calculate the size of the road
            int newHeight = ActiveLaneCount * laneWidth;
            Height = 512 + 17 + newHeight;
            Road.Width = activeRoadLengthPixels;
            Road.Height = newHeight;

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
            // Create an individual spawn instruction
            instruction = new DebugVehicleSpawnInstruction(0, VehicleTypes.Car, Lanes[0], 0, 96000, 6);
            DebugModeInstructions.Add(instruction);
            // Create an individual spawn instruction
            instruction = new DebugVehicleSpawnInstruction(1, VehicleTypes.Car, Lanes[1], 300, 112000, 6);
            DebugModeInstructions.Add(instruction);

            // Start the simulation
            LastTimerValue = 0;
            LastArrivalTimerValue = 0;
            ScaledTimePassed = 0;
            Timer.Restart();
            FormTick.Enabled = true;
            SimulationState = SimulationStates.Started;
            Road.Visible = true;

            // Update the enabled state of the Play, Pause and Stop and FindVehicle buttons
            ButtonStart.Enabled = false;
            ButtonStop.Enabled = true;
            ButtonPause.Enabled = true;
            ButtonFindVehicle.Enabled = false;
        }

        /// <summary>
        /// Resumes a paused simulation
        /// </summary>
        private void ResumeSimulation()
        {
            // Resume the stopwatch
            Timer.Start();

            // Resume the form ticks
            FormTick.Enabled = true;

            // Update the simulation state
            SimulationState = SimulationStates.Started;

            // Update the enabled state of the Play, Pause and Stop buttons
            ButtonStart.Enabled = false;
            ButtonStop.Enabled = true;
            ButtonPause.Enabled = true;
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
                    if (ScaledTimePassed >= instruction.SpawnTime)
                    {
                        // Spawn time for this instruction has passed
                        Vehicle vehicle;
                        switch (instruction.Type)
                        {
                            case VehicleTypes.Car:
                                vehicle = new Car(this, instruction.VehicleId, instruction.VehicleLength, instruction.DesiredSpeedMetresHour);
                                break;
                            case VehicleTypes.LGV:
                                vehicle = new LGV(this, instruction.VehicleId, instruction.VehicleLength, instruction.DesiredSpeedMetresHour);
                                break;
                            case VehicleTypes.HGV:
                                vehicle = new HGV(this, instruction.VehicleId, instruction.VehicleLength, instruction.DesiredSpeedMetresHour);
                                break;
                            case VehicleTypes.Bus:
                                vehicle = new Bus(this, instruction.VehicleId, instruction.VehicleLength, instruction.DesiredSpeedMetresHour);
                                break;
                            default:
                                vehicle = null;
                                break;
                        }

                        // Add vehicle to the specified lane
                        instruction.Lane.AddVehicleToLane(vehicle);
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

                // Calculate the delta time since the last check then scale it
                long tempTime = Timer.ElapsedMilliseconds;
                long elapsedTime = tempTime - LastArrivalTimerValue;
                double scaledElapsedTime = elapsedTime * TimeScale;
                double randomisedInterArrivalTime = ActiveInterArrivalTime + (ActiveInterArrivalTime * ChosenInterArrivalVariationPercentage);
                
                // Lower the trigger time by 1% since timer has resolution of 15ms and without a lower bound will always check *after* the trigger point by some number of ms
                if (scaledElapsedTime >= randomisedInterArrivalTime * 0.99 || LastArrivalTimerValue == 0)
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

            // Record the time of appearance
            newVehicle.TimeAppearance = ScaledTimePassed;

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
                TreeNode finishedVehicleNode = new TreeNode("#" + (newVehicle.VehicleId+1) + " - " + newVehicle.VehicleType + " - " + Math.Round(newVehicle.ActualSpeedMetresHour/1000, 0) + " kph");
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
        /// The method which is in charge of updating each piece of information on the output data tab
        /// </summary>
        private void UpdateData()
        {
            // Update the vehicles TreeView
            UpdateTreeViewVehicles();

            if (SelectedVehicle != null)
            {
                // Vehicle is actually selected

                bool finished = !SelectedVehicle.InEffect;
                TimeSpan appearance = TimeSpan.FromMilliseconds(SelectedVehicle.TimeAppearance);
                TimeSpan disappearance = TimeSpan.FromMilliseconds(SelectedVehicle.TimeDisappearance);
                TimeSpan lifetime = TimeSpan.FromMilliseconds(SelectedVehicle.LifetimeMilliseconds);

                // Update the vehicle ID output
                LabelVehicleID.Text = (SelectedVehicle.VehicleId+1).ToString();

                // Update the vehicle type output
                LabelVehicleType.Text = SelectedVehicle.VehicleType.ToString();

                // Update the vehicle length output
                LabelVehicleLength.Text = Math.Round(SelectedVehicle.VehicleLengthMetres, 2) + "m";

                // Update the vehicle desired speed output
                LabelVehicleDesiredSpeed.Text = Math.Round(SelectedVehicle.DesiredSpeedMetresHour / 1000, 2) + "kph";

                // Update the vehicle actual speed output
                if (SelectedVehicle.SuccessfulSpawn && !finished)
                {
                    LabelVehicleActualSpeed.Text = Math.Round(SelectedVehicle.ActualSpeedMetresHour / 1000, 2) + "kph";
                }
                else
                {
                    LabelVehicleActualSpeed.Text = "---";
                }

                // Update the vehicle successful spawn output
                LabelVehicleSuccessfulSpawn.Text = SelectedVehicle.SuccessfulSpawn.ToString();

                // Update the vehicle spawn time output
                LabelVehicleSpawnTime.Text = appearance.Hours.ToString().PadLeft(2,'0') + "h " + appearance.Minutes.ToString().PadLeft(2, '0') + "m " + appearance.Seconds.ToString().PadLeft(2, '0') + "s " + appearance.Milliseconds.ToString().PadLeft(3, '0') + "ms";

                // Update the vehicle despawn time output
                if (SelectedVehicle.SuccessfulSpawn && finished)
                {
                    LabelVehicleDespawnTime.Text = disappearance.Hours.ToString().PadLeft(2, '0') + "h " + disappearance.Minutes.ToString().PadLeft(2, '0') + "m " + disappearance.Seconds.ToString().PadLeft(2, '0') + "s " + disappearance.Milliseconds.ToString().PadLeft(3, '0') + "ms";
                }
                else
                {
                    LabelVehicleDespawnTime.Text = "---";
                }

                // Update the vehicle lifetime output
                if (SelectedVehicle.SuccessfulSpawn)
                {
                    LabelVehicleLifetime.Text = lifetime.Hours.ToString().PadLeft(2, '0') + "h " + lifetime.Minutes.ToString().PadLeft(2, '0') + "m " + lifetime.Seconds.ToString().PadLeft(2, '0') + "s " + lifetime.Milliseconds.ToString().PadLeft(3, '0') + "ms";
                }
                else
                {
                    LabelVehicleLifetime.Text = "---";
                }

                // Update the vehicle progress output
                if (SelectedVehicle.SuccessfulSpawn && !finished)
                {
                    LabelVehicleProgress.Text = Math.Round(SelectedVehicle.ExactProgressMetres,0) + "m";
                }
                else
                {
                    LabelVehicleProgress.Text = "---";
                }

                // Update the vehicle average speed output
                if (SelectedVehicle.SuccessfulSpawn)
                {
                    LabelVehicleAverageSpeed.Text = Math.Round(SelectedVehicle.AverageSpeedMetresHour/1000, 2) + "kph";
                }
                else
                {
                    LabelVehicleAverageSpeed.Text = "---";
                }

                // Update the vehicle congestion output
                if (SelectedVehicle.SuccessfulSpawn)
                {
                    LabelVehicleCongestion.Text = SelectedVehicle.Congestion.ToString();
                }
                else
                {
                    LabelVehicleCongestion.Text = "---";
                }
            }

            int successCount = 0;
            int failedCount = 0;

            int carCount = 0;
            int lGVCount = 0;
            int hGVCount = 0;
            int busCount = 0;

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

                switch(vehicle.VehicleType)
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


            // Update the all vehicle total vehicles output
            LabelAllVehiclesTotalVehicles.Text = AllVehicles.Count.ToString();

            // Update the all vehicle successful spawns output
            LabelAllVehiclesTotalSuccessfulSpawns.Text = successCount.ToString();

            // Update the all vehicle failed spawns output
            LabelAllVehiclesTotalFailedSpawns.Text = failedCount.ToString();


            // Update the all vehicle total cars output
            LabelAllVehiclesTotalCar.Text = carCount.ToString();

            // Update the all vehicle total LGVs output
            LabelAllVehiclesTotalLGV.Text = lGVCount.ToString();

            // Update the all vehicle total HGVs output
            LabelAllVehiclesTotalHGV.Text = hGVCount.ToString();

            // Update the all vehicle total buses output
            LabelAllVehiclesTotalBus.Text = busCount.ToString();


            // Update the all vehicle total not congested output
            LabelAllVehiclesTotalNotCongested.Text = notCongestedCount.ToString();
            
            // Update the all vehicle total mildly congested output
            LabelAllVehiclesTotalMildlyCongested.Text = mildyCongestedCount.ToString();

            // Update the all vehicle total severely congested output
            LabelAllVehiclesTotalSeverelyCongested.Text = severelyCongestedCount.ToString();

            if (AllVehicles.Count > 0)
            {
                // Percentages can be calculated as won't divide by 0
                // The (double)s are required to avoid integer division

                // Calculate and update the all vehicle successful spawn percentage output
                LabelAllVehiclesSuccessfulSpawnsPercent.Text = Math.Round((successCount / (double)AllVehicles.Count) * 100, 1) + "%";

                // Calculate and update the all vehicle failed spawn percentage output
                LabelAllVehiclesFailedSpawnsPercent.Text = Math.Round((failedCount / (double)AllVehicles.Count) * 100, 1) + "%";


                // Calculate and update the all vehicle car percentage output 
                LabelAllVehiclesCarPercent.Text = Math.Round((carCount / (double)AllVehicles.Count) * 100, 1) + "%";

                // Calculate and update the all vehicle LGV percentage output 
                LabelAllVehiclesLGVPercent.Text = Math.Round((lGVCount / (double)AllVehicles.Count) * 100, 1) + "%";

                // Calculate and update the all vehicle HGV percentage output 
                LabelAllVehiclesHGVPercent.Text = Math.Round((hGVCount / (double)AllVehicles.Count) * 100, 1) + "%";

                // Calculate and update the all vehicle bus percentage output 
                LabelAllVehiclesBusPercent.Text = Math.Round((busCount / (double)AllVehicles.Count) * 100, 1) + "%";
            }
            else
            {
                // Calculating percentages will result in dividing by 0 so just update the labels to default values

                LabelAllVehiclesSuccessfulSpawnsPercent.Text = "---";
                LabelAllVehiclesFailedSpawnsPercent.Text = "---";

                LabelAllVehiclesCarPercent.Text = "---";
                LabelAllVehiclesLGVPercent.Text = "---";
                LabelAllVehiclesHGVPercent.Text = "---";
                LabelAllVehiclesBusPercent.Text = "---";
            }
            
            if (successCount > 0)
            {
                // Percentages can be calculated as won't divide by 0
                // The (double)s are required to avoid integer division

                // Calculate and update the all vehicle not congested percentage output 
                LabelAllVehiclesNotCongestedPercent.Text = Math.Round((notCongestedCount / (double)successCount) * 100, 1) + "%";

                // Calculate and update the all vehicle mildly congested percentage output 
                LabelAllVehiclesMildlyCongestedPercent.Text = Math.Round((mildyCongestedCount / (double)successCount) * 100, 1) + "%";

                // Calculate and update the all vehicle severely congested percentage output 
                LabelAllVehiclesSeverelyCongestedPercent.Text = Math.Round((severelyCongestedCount / (double)successCount) * 100, 1) + "%";
            }
            else
            {
                // Calculating percentages will result in dividing by 0 so just update the labels to default values

                LabelAllVehiclesSuccessfulSpawnsPercent.Text = "---";
                LabelAllVehiclesNotCongestedPercent.Text = "---";
                LabelAllVehiclesMildlyCongestedPercent.Text = "---";
                LabelAllVehiclesSeverelyCongestedPercent.Text = "---";
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
        public VehicleTemplate(double length, double lengthVariation, int desiredSpeed, double desiredSpeedVariation, int maximumLane, double probability)
        {
            Length = length;
            LengthVariation = lengthVariation;
            DesiredSpeed = desiredSpeed;
            DesiredSpeedVariation = desiredSpeedVariation;
            MaximumLane = maximumLane;
            Probability = probability;
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
        /// The time in the simulation to spawn the vehicle
        /// </summary>
        public double SpawnTime;

        /// <summary>
        /// The desired speed in metres per hour of the vehicle to spawn
        /// </summary>
        public double DesiredSpeedMetresHour;

        /// <summary>
        /// The Length of the vehicle to spawn in metres
        /// </summary>
        public int VehicleLength;

        #endregion

        /// <summary>
        /// This is the constructor for the DebugVehicleSpawnInstruction class. It requires all details be passed into the constructor at initialisation time.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to spawn</param>
        /// <param name="type">The enum type of the vehicle to spawn</param>
        /// <param name="lane">The lane of the vehicle to spawn in</param>
        /// <param name="spawnTime">The time in the simulation to spawn the vehicle</param>
        /// <param name="desiredSpeedMetresHour">The (optional, default value = 0) desired speed in metres per hour of the vehicle to spawn</param>
        /// <param name="vehicleLength">The (optional, default value = 0) length of the vehicle to spawn in metres</param>
        public DebugVehicleSpawnInstruction(int vehicleId, VehicleTypes type, LaneControl lane, double spawnTime, double desiredSpeedMetresHour = 0, int vehicleLength = 0)
        {
            VehicleId = vehicleId;
            Type = type;
            Lane = lane;
            SpawnTime = spawnTime;
            DesiredSpeedMetresHour = desiredSpeedMetresHour;
            VehicleLength = vehicleLength;
        }
    }
}