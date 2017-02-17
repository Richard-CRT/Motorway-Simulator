using CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorwaySimulator
{

    public enum VehicleTypes
    {
        Car,
        LGV,
        HGV,
        Bus
    }

    public enum CongestionStates
    {
        None,
        Mild,
        Severe
    }

    public enum SimulationStates
    {
        Started,
        Stopped,
        Paused
    }

    public partial class MotorwaySimulatorForm : Form
    {
        public const double VehicleWidthMetres = 2;
        private const int MetresToPixelsScalingFactor = 10;
        private const double LaneMarginMetres = 0.8;

        public int RoadLengthMetres;
        public int ActiveRoadLengthMetres;

        private int LaneCount;
        public int ActiveLaneCount;

        public int LaneMarginPixels;
        public int VehicleWidthPixels;

        public int SafetyDistance;
        private long LastTimerValue;

        private int InterArrivalTime;
        private double InterArrivalTimeVariationPercentage;
        private int ActiveInterArrivalTime;
        private double ActiveInterArrivalTimeVariationPercentage;
        public double ChosenInterArrivalPercentage;
        private int LastVehicleId;

        public double TimeScale;
        //public double ActiveTimeScale;
        public Dictionary<VehicleTypes, VehicleTemplate> VehicleParameters;

        public List<LaneControl> Lanes;
        public List<Vehicle> AllVehicles;
        public bool DebugSpawn;
        public List<DebugVehicleSpawnInstruction> DebugSpawnInstructions;
        public Random Random;
        public Stopwatch Timer;
        public SimulationStates SimulationState;

        public int MildCongestionTriggerMetresHour;
        public int SevereCongestionTriggerMetresHour;

        private Vehicle SelectedVehicle;

        public MotorwaySimulatorForm()
        {
            InitializeComponent();
        }

        private void MotorwaySimulator_Load(object sender, EventArgs e)
        {
            this.Timer = new Stopwatch();
            this.Random = new Random();
            this.SimulationState = SimulationStates.Stopped;
            this.Lanes = new List<LaneControl>();
            this.AllVehicles = new List<Vehicle>();
            this.SelectedVehicle = null;

            this.UpdateInterArrivalTime(null, null);
            this.UpdateInterArrivalVariation(null, null);
            this.UpdateLaneCount(null, null);
            this.UpdateRoadLength(null, null);
            this.UpdateTimescale(null, null);
            this.ValidateProbabilityChange(null, null);
        }

        private void UpdateInterArrivalTime(object sender, EventArgs e)
        {
            this.LabelInterArrivalTime.Text = Math.Round(this.TrackBarInterArrivalTime.Value / (double)10, 10) + "s"; // must be (double) to stop integer division
            InterArrivalTime = this.TrackBarInterArrivalTime.Value * 100;
        }

        private void UpdateInterArrivalVariation(object sender, EventArgs e)
        {
            this.LabelInterArrivalVariation.Text = Math.Round(this.TrackBarInterArrivalVariation.Value / (double)10, 1) + "%"; // must be (double) to stop integer division
            InterArrivalTimeVariationPercentage = this.TrackBarInterArrivalVariation.Value / (double)1000; // must be (double) to stop integer division
        }

        private void UpdateLaneCount(object sender, EventArgs e)
        {
            this.LabelLaneCount.Text = this.TrackBarLaneCount.Value + " lane(s)";
            this.LaneCount = this.TrackBarLaneCount.Value;
            this.NumericCarMaximumLane.Maximum = this.LaneCount;
            if (this.NumericCarMaximumLane.Value > this.LaneCount)
            {
                this.NumericCarMaximumLane.Value = this.LaneCount;
            }
            this.NumericLGVMaximumLane.Maximum = this.LaneCount;
            if (this.NumericLGVMaximumLane.Value > this.LaneCount)
            {
                this.NumericLGVMaximumLane.Value = this.LaneCount;
            }
            this.NumericHGVMaximumLane.Maximum = this.LaneCount;
            if (this.NumericHGVMaximumLane.Value > this.LaneCount)
            {
                this.NumericHGVMaximumLane.Value = this.LaneCount;
            }
            this.NumericBusMaximumLane.Maximum = this.LaneCount;
            if (this.NumericBusMaximumLane.Value > this.LaneCount)
            {
                this.NumericBusMaximumLane.Value = this.LaneCount;
            }
        }

        private void UpdateRoadLength(object sender, EventArgs e)
        {
            this.LabelRoadLength.Text = Math.Round(this.TrackBarRoadLength.Value / (double)100, 2) + " km"; // must be (double) to stop integer division
            RoadLengthMetres = this.TrackBarRoadLength.Value * 10;
        }

        private void UpdateTimescale(object sender, EventArgs e)
        {
            this.TimeScale = TrackBarTimescale.Value / (double)100;
            this.LabelTimeScale.Text = Math.Round(this.TrackBarTimescale.Value / (double)100, 2) + "x"; // must be (double) to stop integer division
        }

        private void ValidateProbabilityChange(object sender, EventArgs e)
        {
            int totalPercentage = GetTotalSpawnProbability();
            int margin = totalPercentage - 100;
            if (margin > 0)
            {
                if ((int)this.NumericBusSpawnProbability.Value >= margin)
                {
                    this.NumericBusSpawnProbability.Value -= margin;
                }
                else
                {
                    margin -= (int)this.NumericBusSpawnProbability.Value;
                    this.NumericBusSpawnProbability.Value = 0;

                    if ((int)this.NumericHGVSpawnProbability.Value >= margin)
                    {
                        this.NumericHGVSpawnProbability.Value -= margin;
                    }
                    else
                    {
                        margin -= (int)this.NumericHGVSpawnProbability.Value;
                        this.NumericBusSpawnProbability.Value = 0;

                        if (this.NumericLGVSpawnProbability.Value >= margin)
                        {
                            this.NumericLGVSpawnProbability.Value -= margin;
                        }
                        else
                        {
                            margin -= (int)this.NumericLGVSpawnProbability.Value;
                            this.NumericLGVSpawnProbability.Value = 0;

                            if ((int)this.NumericLGVSpawnProbability.Value >= margin)
                            {
                                this.NumericLGVSpawnProbability.Value -= margin;
                            }
                            else
                            {
                                margin -= (int)this.NumericCarSpawnProbability.Value;
                                this.NumericCarSpawnProbability.Value = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                this.LabelSpawnProbabilityUnassigned.Text = (margin * -1) + "% unassigned";
            }
        }

        private int GetTotalSpawnProbability()
        {
            return (int)(this.NumericCarSpawnProbability.Value + this.NumericLGVSpawnProbability.Value + this.NumericHGVSpawnProbability.Value + this.NumericBusSpawnProbability.Value); // drop the decimal parts as the values should be integers despite the decimal type
        }

        private async void ButtonStart_Click(object sender, EventArgs e) // Async for flashing UI
        {
            switch (SimulationState)
            {
                case SimulationStates.Stopped:
                    if (GetTotalSpawnProbability() == 100)
                    {
                        NewSimulation();
                    }
                    else
                    {
                        this.TabControlControlPanel.SelectedIndex = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            this.LabelSpawnProbabilityTitle.ForeColor = Color.Red;
                            this.LabelSpawnProbabilityUnassigned.ForeColor = Color.Red;
                            await FlashSpawnProbabilityDelay();
                            this.LabelSpawnProbabilityTitle.ForeColor = Color.Black;
                            this.LabelSpawnProbabilityUnassigned.ForeColor = Color.Black;
                            await FlashSpawnProbabilityDelay();
                        }
                    }
                    break;
                case SimulationStates.Paused:
                    ResumeSimulation();
                    break;
            }
        }

        private async Task FlashSpawnProbabilityDelay()
        {
            await Task.Delay(100);
        }

        private void NewSimulation()
        {
            this.Lanes.Clear();
            this.AllVehicles.Clear();
            this.Road.Controls.Clear();
            this.TreeViewVehicles.Nodes.Clear();
            this.TreeViewFinishedVehicles.Nodes.Clear();
            this.Road.Size = new Size(10, 10);

            DebugSpawnInstructions = new List<DebugVehicleSpawnInstruction>();
            DebugSpawn = false;

            VehicleParameters = new Dictionary<VehicleTypes, VehicleTemplate>()
            {
                // Length (metres), Length Variation (+-) (metres), Desired Speed (meters/hour), Desired Speed Variation (+-) (meters/hour), Maximum Lane, Probability

                { VehicleTypes.Car, new VehicleTemplate((double)this.NumericCarLength.Value, (double)this.NumericCarLengthVar.Value,  (int)(this.NumericCarDesiredSpeed.Value*1000),  (double)(this.NumericCarDesiredSpeedVar.Value*1000), (int)(this.NumericCarMaximumLane.Value),  (double)(this.NumericCarSpawnProbability.Value/(decimal)100)) },
                { VehicleTypes.LGV, new VehicleTemplate((double)this.NumericLGVLength.Value, (double)this.NumericLGVLengthVar.Value,  (int)(this.NumericLGVDesiredSpeed.Value*1000),  (double)(this.NumericLGVDesiredSpeedVar.Value*1000), (int)(this.NumericCarMaximumLane.Value),  (double)(this.NumericLGVSpawnProbability.Value/(decimal)100)) },
                { VehicleTypes.HGV, new VehicleTemplate((double)this.NumericHGVLength.Value, (double)this.NumericHGVLengthVar.Value,  (int)(this.NumericHGVDesiredSpeed.Value*1000),  (double)(this.NumericHGVDesiredSpeedVar.Value*1000), (int)(this.NumericCarMaximumLane.Value),  (double)(this.NumericHGVSpawnProbability.Value/(decimal)100)) },
                { VehicleTypes.Bus, new VehicleTemplate((double)this.NumericBusLength.Value, (double)this.NumericBusLengthVar.Value,  (int)(this.NumericBusDesiredSpeed.Value*1000),  (double)(this.NumericBusDesiredSpeedVar.Value*1000), (int)(this.NumericCarMaximumLane.Value),  (double)(this.NumericBusSpawnProbability.Value/(decimal)100)) }



                /*{ VehicleTypes.Car, new VehicleTemplate(4,     0,  112000,    0,      1) },
                { VehicleTypes.LGV, new VehicleTemplate(5.5,   0,  111000,    0,      0) },
                { VehicleTypes.HGV, new VehicleTemplate(12,    0,  96000,     0,      0) },
                { VehicleTypes.Bus, new VehicleTemplate(11,    0,  96000,     0,      0) }*/
            };

            this.ActiveLaneCount = this.LaneCount;

            LastVehicleId = 0;
            ActiveRoadLengthMetres = RoadLengthMetres;
            int activeRoadLengthPixels = (int)Math.Round(MetresToPixels(ActiveRoadLengthMetres), 0);

            LaneMarginPixels = (int)Math.Round(MetresToPixels(LaneMarginMetres), 0);
            VehicleWidthPixels = (int)Math.Round(MetresToPixels(VehicleWidthMetres), 0);

            MildCongestionTriggerMetresHour = (int)this.NumericMildCongestion.Value * 1000;
            SevereCongestionTriggerMetresHour = (int)this.NumericSevereCongestion.Value * 1000;

            ActiveInterArrivalTime = InterArrivalTime;
            ActiveInterArrivalTimeVariationPercentage = InterArrivalTimeVariationPercentage;
            ChosenInterArrivalPercentage = -1;
            LastTimerValue = 0;

            int laneWidth = VehicleWidthPixels + (2 * LaneMarginPixels);

            int newHeight = ActiveLaneCount * laneWidth;
            this.Height = 512 + 17 + newHeight;
            Road.Width = activeRoadLengthPixels;
            Road.Height = newHeight;

            TreeNode finishedVehiclesLaneNode = new TreeNode("Failed");
            this.TreeViewFinishedVehicles.Nodes.Add(finishedVehiclesLaneNode);
            for (int i = 0; i < ActiveLaneCount; i++)
            {
                LaneControl lane = new LaneControl(this, i);
                lane.Location = new Point(0, laneWidth * i);
                lane.Size = new Size(activeRoadLengthPixels, laneWidth);
                lane.LaneNode = new TreeNode("Lane " + (lane.LaneId + 1));
                finishedVehiclesLaneNode = new TreeNode("Lane " + (lane.LaneId + 1));
                this.Road.Controls.Add(lane);
                this.Lanes.Add(lane);
                this.TreeViewFinishedVehicles.Nodes.Add(finishedVehiclesLaneNode);
            }
            PopulateTreeViewVehicles();

            DebugVehicleSpawnInstruction instruction;

            instruction = new DebugVehicleSpawnInstruction(0, 0, VehicleTypes.HGV, Lanes[0], 0, 96000, 8);
            DebugSpawnInstructions.Add(instruction);
            instruction = new DebugVehicleSpawnInstruction(1, 0, VehicleTypes.HGV, Lanes[0], 1200, 100000, 6);
            DebugSpawnInstructions.Add(instruction);
            instruction = new DebugVehicleSpawnInstruction(2, 0, VehicleTypes.Car, Lanes[0], 3000, 112000, 4);
            DebugSpawnInstructions.Add(instruction);

            Timer.Restart();
            this.FormTick.Enabled = true;

            SimulationState = SimulationStates.Started;
            this.ButtonStart.Enabled = false;
            this.ButtonStop.Enabled = true;
            this.ButtonPause.Enabled = true;
            this.ButtonFindVehicle.Enabled = false;
            this.Road.Visible = true;
        }

        private void ResumeSimulation()
        {
            this.FormTick.Enabled = true;
            this.Timer.Start();

            SimulationState = SimulationStates.Started;
            this.ButtonStart.Enabled = false;
            this.ButtonStop.Enabled = true;
            this.ButtonPause.Enabled = true;
        }

        private void PopulateTreeViewVehicles()
        {
            this.TreeViewVehicles.Nodes.Clear();
            for (int laneIndex = 0; laneIndex < ActiveLaneCount; laneIndex++)
            {
                LaneControl lane = Lanes[laneIndex];
                this.TreeViewVehicles.Nodes.Add(lane.LaneNode);
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            this.FormTick.Enabled = false;

            SimulationState = SimulationStates.Stopped;
            this.ButtonStop.Enabled = false;
            this.ButtonPause.Enabled = false;
            this.ButtonStart.Enabled = true;
        }

        private void ButtonFindVehicle_Click(object sender, EventArgs e)
        {
            if (SelectedVehicle != null)
            {
                int viewPortWidth = this.Width;
                int newPosition = SelectedVehicle.ProgressPixels - (viewPortWidth / 8);
                if (newPosition < 0)
                {
                    newPosition = 0;
                }
                if (newPosition > this.HorizontalScroll.Maximum)
                {
                    newPosition = this.HorizontalScroll.Maximum;
                }
                this.HorizontalScroll.Value = newPosition;
                this.UpdateControlPanelLocation();
            }
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            this.Timer.Stop();
            this.FormTick.Enabled = false;

            SimulationState = SimulationStates.Paused;
            this.ButtonStop.Enabled = true;
            this.ButtonPause.Enabled = false;
            this.ButtonStart.Enabled = true;
        }

        private Vehicle GenerateVehicle(int id)
        {
            Vehicle newVehicle;
            double rand = this.Random.NextDouble();
            double total = 0;
            if (rand < this.VehicleParameters[VehicleTypes.Car].Probability)
            {
                //Car
                newVehicle = new Car(this, id);
            }
            else
            {
                total += this.VehicleParameters[VehicleTypes.Car].Probability;
                if (total <= rand && rand < total + this.VehicleParameters[VehicleTypes.LGV].Probability)
                {
                    //LGV
                    newVehicle = new LGV(this, id);
                }
                else
                {
                    total += this.VehicleParameters[VehicleTypes.LGV].Probability;
                    if (total <= rand && rand < total + this.VehicleParameters[VehicleTypes.HGV].Probability)
                    {
                        //HGV
                        newVehicle = new HGV(this, id);
                    }
                    else
                    {
                        //Bus
                        newVehicle = new Bus(this, id);
                    }
                }
            }
            return newVehicle;
        }

        private Vehicle[] AllActiveVehiclesOrderByLocation()
        {
            List<Vehicle> allVehicles = new List<Vehicle>();
            foreach (LaneControl lane in Lanes)
            {
                allVehicles.AddRange(lane.Vehicles);
            }
            return allVehicles.OrderByDescending(vehicle => vehicle.ExactProgressMetres).ToArray();
        }

        private void CheckVehicle()
        {
            if (DebugSpawn)
            {
                for (int instructionIndex = 0; instructionIndex < DebugSpawnInstructions.Count;)
                {
                    DebugVehicleSpawnInstruction instruction = DebugSpawnInstructions[instructionIndex];
                    if (Timer.ElapsedMilliseconds >= instruction.SpawnTime)
                    {
                        Vehicle vehicle;
                        switch (instruction.Type)
                        {
                            case VehicleTypes.Car:
                                vehicle = new Car(this, instruction.VehicleId);
                                break;
                            case VehicleTypes.LGV:
                                vehicle = new LGV(this, instruction.VehicleId);
                                break;
                            case VehicleTypes.HGV:
                                vehicle = new HGV(this, instruction.VehicleId);
                                break;
                            case VehicleTypes.Bus:
                                vehicle = new Bus(this, instruction.VehicleId);
                                break;
                            default:
                                vehicle = null;
                                break;
                        }
                        if (instruction.DesiredSpeedMetresHour != 0)
                        {
                            vehicle.DesiredSpeedMetresHour = instruction.DesiredSpeedMetresHour;
                            vehicle.DesiredSpeedPixelsHour = MetresToPixels(instruction.DesiredSpeedMetresHour);
                        }
                        if (instruction.VehicleHeight != 0)
                        {
                            vehicle.VehicleHeightMetres = instruction.VehicleHeight;
                            vehicle.VehicleHeightPixels = (int)Math.Round(MetresToPixels(instruction.VehicleHeight));
                        }
                        instruction.Lane.AddVehicleToLane(vehicle);
                        DebugSpawnInstructions.RemoveAt(instructionIndex);
                    }
                    else
                    {
                        instructionIndex++;
                    }
                }
            }
            else
            {
                if (ChosenInterArrivalPercentage == -1)
                {
                    ChosenInterArrivalPercentage = (Random.NextDouble() * ActiveInterArrivalTimeVariationPercentage * 2) - ActiveInterArrivalTimeVariationPercentage;
                }
                long tempTime = Timer.ElapsedMilliseconds;
                long elapsedTime = tempTime - LastTimerValue;
                double scaledElapsedTime = elapsedTime * this.TimeScale;
                double randomisedInterArrivalTime = ActiveInterArrivalTime + (ActiveInterArrivalTime * ChosenInterArrivalPercentage);
                double onePercent = randomisedInterArrivalTime * 0.01;
                double LowerBoundInterArrivalTime = randomisedInterArrivalTime - onePercent; // Seems fairly accurate, lowers the trigger time by 1% since timer has resolution of 15ms

                if (scaledElapsedTime >= LowerBoundInterArrivalTime || LastTimerValue == 0)
                {
                    ChosenInterArrivalPercentage = -1;
                    LastTimerValue = tempTime;
                    AddVehicle();
                }
            }
        }

        private void AddVehicle()
        {
            LastVehicleId++;

            Vehicle newVehicle = GenerateVehicle(LastVehicleId);

            int lane = 0;
            bool success = false;
            newVehicle.TimeAppearance = Timer.Elapsed;
            while (!success && newVehicle.MaximumLane > lane && lane < this.ActiveLaneCount)
            {
                success = Lanes[lane].AddVehicleToLane(newVehicle);
                lane++;
            }
            if (!success)
            {
                TreeNode finishedVehicleNode = new TreeNode("#" + newVehicle.VehicleId + " - " + newVehicle.VehicleType + " - " + Math.Round(newVehicle.ActualSpeedMetresHour/1000, 0) + " kph");
                finishedVehicleNode.Tag = newVehicle;
                this.TreeViewFinishedVehicles.Nodes[0].Nodes.Add(finishedVehicleNode);
            }
            this.AllVehicles.Add(newVehicle);
        }

        private void UpdateTreeViewVehicles()
        {
            for (int laneIndex = 0; laneIndex < ActiveLaneCount; laneIndex++)
            {
                LaneControl lane = Lanes[laneIndex];
                lane.UpdateTreeNode();
            }
        }

        private void FormTick_Tick(object sender, EventArgs e)
        {
            CheckVehicle();
            Vehicle[] OrderedVehicles = AllActiveVehiclesOrderByLocation();
            foreach (Vehicle vehicle in OrderedVehicles)
            {
                vehicle.LaneTick();
            }

            foreach (Vehicle vehicle in OrderedVehicles)
            {
                vehicle.MovementTick();
                if (!vehicle.InSight)
                {
                    Vehicle previousVehicle = vehicle.ParentLane.PreviousVehicle(vehicle);
                    Vehicle previousVehicleRightLane = null;
                    if (vehicle.ParentLane.LaneId != this.ActiveLaneCount - 1)
                    {
                        previousVehicleRightLane = this.Lanes[vehicle.ParentLane.LaneId + 1].PreviousVehicleDifferentLane(vehicle);
                    }
                    Vehicle previousVehicleLeftLane = null;
                    if (vehicle.ParentLane.LaneId != 0)
                    {
                        previousVehicleLeftLane = this.Lanes[vehicle.ParentLane.LaneId - 1].PreviousVehicleDifferentLane(vehicle);
                    }

                    if (previousVehicle == null && previousVehicleRightLane == null && previousVehicleLeftLane == null)
                    {
                        vehicle.InEffect = false;
                    }
                    else if (previousVehicle == null && previousVehicleLeftLane == null)
                    {
                        if (!previousVehicleRightLane.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicle == null && previousVehicleRightLane == null)
                    {
                        if (!previousVehicleLeftLane.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicleLeftLane == null && previousVehicleRightLane == null)
                    {
                        if (!previousVehicle.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicle == null)
                    {
                        if (!previousVehicleLeftLane.InSight && !previousVehicleRightLane.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicleLeftLane == null)
                    {
                        if (!previousVehicle.InSight && !previousVehicleRightLane.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicleRightLane == null)
                    {
                        if (!previousVehicle.InSight && !previousVehicleLeftLane.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                    else
                    {
                        if (!previousVehicle.InSight && !previousVehicleLeftLane.InSight && !previousVehicleRightLane.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                }
                if (!vehicle.InEffect)
                {
                    vehicle.ParentLane.Vehicles.Remove(vehicle);
                    vehicle.TimeDisappearance = this.Timer.Elapsed;
                    TreeNode finishedVehicleNode = new TreeNode("#" + vehicle.VehicleId + " - " + vehicle.VehicleType + " - " + Math.Round(vehicle.ActualSpeedMetresHour/1000, 0) + " kph");
                    finishedVehicleNode.Tag = vehicle;
                    TreeNode LaneNode = this.TreeViewFinishedVehicles.Nodes[vehicle.ParentLane.LaneId + 1];
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

            foreach (LaneControl lane in Lanes)
            {
                lane.Invalidate(); // Repaint the lane
            }

            UpdateData();
        }

        private void UpdateData()
        {
            UpdateTreeViewVehicles();

            if (this.SelectedVehicle != null)
            {
                // Vehicle node was selected, not lane
                bool finished = !this.SelectedVehicle.InEffect;
                TimeSpan lifetime = TimeSpan.FromMilliseconds(SelectedVehicle.LifetimeMilliseconds);

                this.LabelVehicleID.Text = this.SelectedVehicle.VehicleId.ToString();
                this.LabelVehicleType.Text = this.SelectedVehicle.VehicleType.ToString();
                this.LabelVehicleLength.Text = Math.Round(this.SelectedVehicle.VehicleHeightMetres, 2) + "m";
                this.LabelVehicleDesiredSpeed.Text = Math.Round(this.SelectedVehicle.DesiredSpeedMetresHour / 1000, 2) + "kph";
                if (this.SelectedVehicle.SuccessfulSpawn && !finished)
                {
                    this.LabelVehicleActualSpeed.Text = Math.Round(this.SelectedVehicle.ActualSpeedMetresHour / 1000, 2) + "kph";
                }
                else
                {
                    this.LabelVehicleActualSpeed.Text = "---";
                }
                this.LabelVehicleSuccessfulSpawn.Text = this.SelectedVehicle.SuccessfulSpawn.ToString();

                this.LabelVehicleSpawnTime.Text = this.SelectedVehicle.TimeAppearance.Hours.ToString().PadLeft(2,'0') + "h " + this.SelectedVehicle.TimeAppearance.Minutes.ToString().PadLeft(2, '0') + "m " + this.SelectedVehicle.TimeAppearance.Seconds.ToString().PadLeft(2, '0') + "s " + this.SelectedVehicle.TimeAppearance.Milliseconds.ToString().PadLeft(3, '0') + "ms";

                if (this.SelectedVehicle.SuccessfulSpawn && finished)
                {
                    this.LabelVehicleDespawnTime.Text = this.SelectedVehicle.TimeDisappearance.Hours.ToString().PadLeft(2, '0') + "h " + this.SelectedVehicle.TimeDisappearance.Minutes.ToString().PadLeft(2, '0') + "m " + this.SelectedVehicle.TimeDisappearance.Seconds.ToString().PadLeft(2, '0') + "s " + this.SelectedVehicle.TimeDisappearance.Milliseconds.ToString().PadLeft(3, '0') + "ms";
                }
                else
                {
                    this.LabelVehicleDespawnTime.Text = "---";
                }

                if (this.SelectedVehicle.SuccessfulSpawn)
                {
                    this.LabelVehicleLifetime.Text = lifetime.Hours.ToString().PadLeft(2, '0') + "h " + lifetime.Minutes.ToString().PadLeft(2, '0') + "m " + lifetime.Seconds.ToString().PadLeft(2, '0') + "s " + lifetime.Milliseconds.ToString().PadLeft(3, '0') + "ms";
                }
                else
                {
                    this.LabelVehicleLifetime.Text = "---";
                }

                if (this.SelectedVehicle.SuccessfulSpawn && !finished)
                {
                    this.LabelVehicleProgress.Text = Math.Round(this.SelectedVehicle.ExactProgressMetres,0) + "m";
                }
                else
                {
                    this.LabelVehicleProgress.Text = "---";
                }

                if (this.SelectedVehicle.SuccessfulSpawn)
                {
                    this.LabelVehicleAverageSpeed.Text = Math.Round(((this.SelectedVehicle.ExactProgressMetres+this.SelectedVehicle.OriginalDistanceOffsetMetres)/1000) / lifetime.TotalHours, 2) + "kph";
                }
                else
                {
                    this.LabelVehicleAverageSpeed.Text = "---";
                }

                if (this.SelectedVehicle.SuccessfulSpawn)
                {
                    this.LabelVehicleCongestion.Text = this.SelectedVehicle.Congestion.ToString();
                }
                else
                {
                    this.LabelVehicleCongestion.Text = "---";
                }
            }

            this.LabelAllVehiclesTotalVehicles.Text = this.AllVehicles.Count.ToString();
            int successCount = 0;
            int failedCount = 0;

            int carCount = 0;
            int lGVCount = 0;
            int hGVCount = 0;
            int busCount = 0;

            int notCongestedCount = 0;
            int mildyCongestedCount = 0;
            int severelyCongestedCount = 0;
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
            this.LabelAllVehiclesTotalSuccessfulSpawns.Text = successCount.ToString();
            this.LabelAllVehiclesTotalFailedSpawns.Text = failedCount.ToString();

            this.LabelAllVehiclesTotalCar.Text = carCount.ToString();
            this.LabelAllVehiclesTotalLGV.Text = lGVCount.ToString();
            this.LabelAllVehiclesTotalHGV.Text = hGVCount.ToString();
            this.LabelAllVehiclesTotalBus.Text = busCount.ToString();

            this.LabelAllVehiclesTotalNotCongested.Text = notCongestedCount.ToString();
            this.LabelAllVehiclesTotalMildlyCongested.Text = mildyCongestedCount.ToString();
            this.LabelAllVehiclesTotalSeverelyCongested.Text = severelyCongestedCount.ToString();

            if (this.AllVehicles.Count > 0)
            {
                this.LabelAllVehiclesSuccessfulSpawnsPercent.Text = Math.Round((successCount / (double)this.AllVehicles.Count)*100,1) + "%"; // Must be double to avoid integer division
                this.LabelAllVehiclesFailedSpawnsPercent.Text = Math.Round((failedCount / (double)this.AllVehicles.Count) * 100, 1) + "%"; // Must be double to avoid integer division
                 
                this.LabelAllVehiclesCarPercent.Text = Math.Round((carCount / (double)this.AllVehicles.Count) * 100, 1) + "%"; // Must be double to avoid integer division
                this.LabelAllVehiclesLGVPercent.Text = Math.Round((lGVCount / (double)this.AllVehicles.Count) * 100, 1) + "%"; // Must be double to avoid integer division
                this.LabelAllVehiclesHGVPercent.Text = Math.Round((hGVCount / (double)this.AllVehicles.Count) * 100, 1) + "%"; // Must be double to avoid integer division
                this.LabelAllVehiclesBusPercent.Text = Math.Round((busCount / (double)this.AllVehicles.Count) * 100, 1) + "%"; // Must be double to avoid integer division

                this.LabelAllVehiclesNotCongestedPercent.Text = Math.Round((notCongestedCount / (double)successCount) * 100, 1) + "%"; // Must be double to avoid integer division
                this.LabelAllVehiclesMildlyCongestedPercent.Text = Math.Round((mildyCongestedCount / (double)successCount) * 100, 1) + "%"; // Must be double to avoid integer division
                this.LabelAllVehiclesSeverelyCongestedPercent.Text = Math.Round((severelyCongestedCount / (double)successCount) * 100, 1) + "%"; // Must be double to avoid integer division
            }
            else
            {
                this.LabelAllVehiclesSuccessfulSpawnsPercent.Text = "---";
                this.LabelAllVehiclesFailedSpawnsPercent.Text = "---";

                this.LabelAllVehiclesCarPercent.Text = "---";
                this.LabelAllVehiclesLGVPercent.Text = "---";
                this.LabelAllVehiclesHGVPercent.Text = "---";
                this.LabelAllVehiclesBusPercent.Text = "---";

                this.LabelAllVehiclesNotCongestedPercent.Text = "---";
                this.LabelAllVehiclesMildlyCongestedPercent.Text = "---";
                this.LabelAllVehiclesSeverelyCongestedPercent.Text = "---";
            }
        }

        public double PerHourToPerTick(double pixels, double TimeElapsed)
        {
            if (TimeElapsed > 0)
            {
                return pixels / (60f * 60f * (1000.0f / TimeElapsed));
            }
            else
            {
                return 0;
            }
        }

        public double MetresToPixels(double metres)
        {
            return metres * MetresToPixelsScalingFactor;
        }

        public double StoppingDistance(double speed)
        {
            return (speed / 3600) * 0.5;
        }

        public void UpdateControlPanelLocation()
        {
            PanelSettings.Location = new Point(12, 12);
        }

        private void FormScrolled(object sender, ScrollEventArgs e)
        {
            UpdateControlPanelLocation();
        }

        public void TreeNodeVehicleSelected(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Node is selected
            Vehicle selectedVehicle = (Vehicle)e.Node.Tag;
            if (selectedVehicle != null)
            {
                this.SelectedVehicle = selectedVehicle;
                this.ButtonFindVehicle.Enabled = true;
                UpdateData();
            }
        }
    }

    public class VehicleTemplate
    {
        public double Length, LengthVariation, DesiredSpeedVariation, Probability;
        public int DesiredSpeed, MaximumLane;
        public VehicleTemplate(double length, double lengthVariation, int desiredSpeed, double desiredSpeedVariation, int maximumLane, double probability)
        {
            this.Length = length;
            this.LengthVariation = lengthVariation;
            this.DesiredSpeed = desiredSpeed;
            this.DesiredSpeedVariation = desiredSpeedVariation;
            this.MaximumLane = maximumLane;
            this.Probability = probability;
        }
    }

    public class DebugVehicleSpawnInstruction
    {
        public int VehicleId;
        public double ExactProgressPixels;
        public VehicleTypes Type;
        public LaneControl Lane;
        public long SpawnTime;
        public double DesiredSpeedMetresHour;
        public int VehicleHeight;

        public DebugVehicleSpawnInstruction(int vehicleId, double ExactProgressPixels, VehicleTypes type, LaneControl lane, long spawnTime, double desiredSpeedMetresHour = 0, int vehicleHeight = 0)
        {
            this.VehicleId = vehicleId;
            this.ExactProgressPixels = ExactProgressPixels;
            this.Type = type;
            this.Lane = lane;
            this.SpawnTime = spawnTime;
            this.DesiredSpeedMetresHour = desiredSpeedMetresHour;
            this.VehicleHeight = vehicleHeight;
        }
    }
}