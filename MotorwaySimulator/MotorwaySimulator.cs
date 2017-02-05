﻿using CustomControls;
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

    public enum SimulationStates
    {
        Started,
        Stopped,
        Paused
    }

    public partial class MotorwaySimulatorForm : Form
    {
        private const int MetresToPixelsScalingFactor = 10;
        private const double VehicleWidthMetres = 2;
        private const double LaneMarginMetres = 0.8;

        public int RoadLengthPixels;
        public int RoadLengthMetres;
        public int LaneCount;

        public int LaneMarginPixels;
        public int VehicleWidthPixels;

        public int SafetyDistance;
        private long LastTimerValue;
        public int InterArrivalTime;
        public double InterArrivalTimeVariationPercentage;
        public double ChosenInterArrivalPercentage;
        private int LastId;
        public double TimeScale;
        public Dictionary<VehicleTypes, VehicleTemplate> VehicleParameters;

        public List<LaneControl> Lanes;
        public bool DebugSpawn;
        public List<DebugVehicleSpawnInstruction> DebugSpawnInstructions;
        public Random Random;
        public Stopwatch Timer;
        public SimulationStates SimulationState;

        public MotorwaySimulatorForm()
        {
            InitializeComponent();
        }

        private void MotorwaySimulator_Load(object sender, EventArgs e)
        {
            Timer = new Stopwatch();
            Random = new Random();
            SimulationState = SimulationStates.Stopped;

            UpdateInterArrivalTime();
            UpdateInterArrivalVariation();
            UpdateRoadLength();
            UpdateTimescale();
        }

        private void TrackBarInterArrivalTime_Scroll(object sender, EventArgs e)
        {
            UpdateInterArrivalTime();
        }

        private void TrackBarInterArrivalVariation_Scroll(object sender, EventArgs e)
        {
            UpdateInterArrivalVariation();
        }

        private void TrackBarRoadLength_Scroll(object sender, EventArgs e)
        {
            UpdateRoadLength();
        }

        private void TrackBarTimescale_Scroll(object sender, EventArgs e)
        {
            UpdateTimescale();
        }

        private void UpdateInterArrivalTime()
        {
            this.LabelInterArrivalTime.Text = Math.Round(this.TrackBarInterArrivalTime.Value / (double)10, 10) + "s"; // must be (double) to stop integer division
            InterArrivalTime = this.TrackBarInterArrivalTime.Value * 100;
        }

        private void UpdateInterArrivalVariation()
        {
            this.LabelInterArrivalVariation.Text = Math.Round(this.TrackBarInterArrivalVariation.Value / (double)10, 1) + "%"; // must be (double) to stop integer division
            InterArrivalTimeVariationPercentage = this.TrackBarInterArrivalVariation.Value / (double)1000; // must be (double) to stop integer division
        }

        private void UpdateRoadLength()
        {
            this.LabelRoadLength.Text = Math.Round(this.TrackBarRoadLength.Value / (double)100, 2) + " km"; // must be (double) to stop integer division
            RoadLengthMetres = this.TrackBarRoadLength.Value * 10;
        }

        private void UpdateTimescale()
        {
            this.TimeScale = TrackBarTimescale.Value / (double)100;
            this.LabelTimeScale.Text = Math.Round(this.TrackBarTimescale.Value / (double)100, 2) + "x"; // must be (double) to stop integer division
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            switch(SimulationState)
            {
                case SimulationStates.Stopped:
                    NewSimulation();
                    break;
                case SimulationStates.Paused:
                    ResumeSimulation();
                    break;
            }
        }

        private void NewSimulation()
        {
            DebugSpawnInstructions = new List<DebugVehicleSpawnInstruction>();
            DebugSpawn = false;
            Lanes = new List<LaneControl>();

            VehicleParameters = new Dictionary<VehicleTypes, VehicleTemplate>()
            {
                // Length (metres), Length Variation (+-) (metres), Desired Speed (meters/hour), Desired Speed Variation (+-) (meters/hour), Probability

                { VehicleTypes.Car, new VehicleTemplate((double)this.NumericCarLength.Value, (double)this.NumericCarLengthVar.Value,  (double)this.NumericCarDesiredSpeed.Value*1000,  (double)this.NumericCarDesiredSpeedVar.Value*1000,     0.74) },
                { VehicleTypes.LGV, new VehicleTemplate((double)this.NumericLGVLength.Value, (double)this.NumericLGVLengthVar.Value,  (double)this.NumericLGVDesiredSpeed.Value*1000,  (double)this.NumericLGVDesiredSpeedVar.Value*1000,      0.14) },
                { VehicleTypes.HGV, new VehicleTemplate((double)this.NumericHGVLength.Value, (double)this.NumericHGVLengthVar.Value,  (double)this.NumericHGVDesiredSpeed.Value*1000,  (double)this.NumericHGVDesiredSpeedVar.Value*1000,      0.11) },
                { VehicleTypes.Bus, new VehicleTemplate((double)this.NumericBusLength.Value, (double)this.NumericBusLengthVar.Value,  (double)this.NumericBusDesiredSpeed.Value*1000,  (double)this.NumericBusDesiredSpeedVar.Value*1000,      0.01) }



                /*{ VehicleTypes.Car, new VehicleTemplate(4,     0,  112000,    0,      1) },
                { VehicleTypes.LGV, new VehicleTemplate(5.5,   0,  111000,    0,      0) },
                { VehicleTypes.HGV, new VehicleTemplate(12,    0,  96000,     0,      0) },
                { VehicleTypes.Bus, new VehicleTemplate(11,    0,  96000,     0,      0) }*/
            };

            TimeScale = 1;
            LastId = 0;
            LaneCount = 7;
            RoadLengthPixels = (int)Math.Round(MetresToPixels(RoadLengthMetres), 0);
            LaneMarginPixels = (int)Math.Round(MetresToPixels(LaneMarginMetres), 0);
            VehicleWidthPixels = (int)Math.Round(MetresToPixels(VehicleWidthMetres), 0);

            ChosenInterArrivalPercentage = -1;
            LastTimerValue = 0;

            int laneWidth = VehicleWidthPixels + (2 * LaneMarginPixels);

            Road.Width = RoadLengthPixels;
            Road.Height = LaneCount * laneWidth;
            
            for (int i = 0; i < LaneCount; i++)
            {
                LaneControl lane = new LaneControl(this, i);
                lane.Location = new Point(0, laneWidth * i);
                lane.Size = new Size(RoadLengthPixels, laneWidth);
                lane.LaneNode = new TreeNode("Lane " + (lane.LaneId + 1));
                this.Road.Controls.Add(lane);
                this.Lanes.Add(lane);
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
            for (int laneIndex = 0; laneIndex < LaneCount; laneIndex++)
            {
                LaneControl lane = Lanes[laneIndex];
                this.TreeViewVehicles.Nodes.Add(lane.LaneNode);
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            this.FormTick.Enabled = false;

            for (int i = LaneCount-1; i >= 0; i--)
            {
                LaneControl lane = Lanes[i];
                this.Road.Controls.Remove(lane);
                this.Lanes.Remove(lane);
            }

            this.TreeViewVehicles.Nodes.Clear();
            this.Road.Size = new Size(10, 10);

            SimulationState = SimulationStates.Stopped;
            this.ButtonStop.Enabled = false;
            this.ButtonPause.Enabled = false;
            this.ButtonStart.Enabled = true;
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

        private Vehicle[] AllVehiclesOrderByLocation()
        {
            List<Vehicle> allVehicles = new List<Vehicle>();
            foreach (LaneControl lane in Lanes)
            {
                allVehicles.AddRange(lane.Vehicles);
            }
            return allVehicles.OrderByDescending(vehicle => vehicle.ExactProgress).ToArray();
        }

        private void AddVehicle()
        {
            LastId++;

            Vehicle newVehicle = GenerateVehicle(LastId);

            int lane = 0;
            bool success = false;
            while (!success && lane < this.LaneCount)
            {
                success = Lanes[lane].AddVehicleToLane(newVehicle);
                lane++;
            }
        }

        private void CheckVehicle()
        {
            if(DebugSpawn)
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
                            vehicle.VehicleHeight = (int)Math.Round(MetresToPixels(instruction.VehicleHeight));
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
                    ChosenInterArrivalPercentage = (Random.NextDouble() * InterArrivalTimeVariationPercentage * 2) - InterArrivalTimeVariationPercentage;
                }
                long tempTime = Timer.ElapsedMilliseconds;
                long elapsedTime = tempTime - LastTimerValue;
                double scaledElapsedTime = elapsedTime * this.TimeScale;
                double randomisedInterArrivalTime = InterArrivalTime + (InterArrivalTime * ChosenInterArrivalPercentage);
                double onePercent = randomisedInterArrivalTime * 0.01;
                double LowerBoundInterArrivalTime = randomisedInterArrivalTime - onePercent; // Seems fairly accurate, lowers the trigger time depending on the TimeScale since the timer has a resolution of 15ms

                if (scaledElapsedTime >= LowerBoundInterArrivalTime || LastTimerValue == 0)
                {
                    ChosenInterArrivalPercentage = -1;
                    LastTimerValue = tempTime;
                    AddVehicle();
                }
            }
        }

        private void UpdateTreeViewVehicles()
        {
            for (int laneIndex = 0; laneIndex < LaneCount; laneIndex++)
            {
                LaneControl lane = Lanes[laneIndex];
                lane.UpdateTreeNode();
            }
        }

        private void FormTick_Tick(object sender, EventArgs e)
        {
            CheckVehicle();
            Vehicle[] OrderedVehicles = AllVehiclesOrderByLocation();
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
                    Vehicle previousVehicleNextLane = null;
                    if (vehicle.ParentLane.LaneId != this.LaneCount - 1)
                    {
                        previousVehicleNextLane = this.Lanes[vehicle.ParentLane.LaneId + 1].PreviousVehicleDifferentLane(vehicle);
                    }
                    if (previousVehicle == null && previousVehicleNextLane == null)
                    {
                        vehicle.InEffect = false;
                    }
                    else if (previousVehicle == null)
                    {
                        if (!previousVehicleNextLane.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                    else if (previousVehicleNextLane == null)
                    {
                        if (!previousVehicle.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                    else
                    {
                        if (!previousVehicle.InSight && !previousVehicleNextLane.InSight)
                        {
                            vehicle.InEffect = false;
                        }
                    }
                }
                if (!vehicle.InEffect)
                {
                    vehicle.ParentLane.Vehicles.Remove(vehicle);
                }
            }

            foreach ( LaneControl lane in Lanes)
            {
                lane.Invalidate(); // Repaint the lane
            }

            UpdateTreeViewVehicles();
        }

        public double PixelHoursToPixelTicks(double pixels, double TimeElapsed)
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
            // node is selected
            Vehicle selectedVehicle = (Vehicle)e.Node.Tag;
            if (selectedVehicle != null)
            {
                Console.WriteLine(selectedVehicle.VehicleId);
            }
        }
    }

    public class VehicleTemplate
    {
        public double Length, LengthVariation, DesiredSpeed, DesiredSpeedVariation, Probability;
        public VehicleTemplate(double length, double lengthVariation, double desiredSpeed, double desiredSpeedVariation, double probability)
        {
            this.Length = length;
            this.LengthVariation = lengthVariation;
            this.DesiredSpeed = desiredSpeed;
            this.DesiredSpeedVariation = desiredSpeedVariation;
            this.Probability = probability;
        }
    }

    public class DebugVehicleSpawnInstruction
    {
        public int VehicleId;
        public double ExactProgress;
        public VehicleTypes Type;
        public LaneControl Lane;
        public long SpawnTime;
        public double DesiredSpeedMetresHour;
        public int VehicleHeight;

        public DebugVehicleSpawnInstruction(int vehicleId, double exactProgress, VehicleTypes type, LaneControl lane, long spawnTime, double desiredSpeedMetresHour = 0, int vehicleHeight = 0)
        {
            this.VehicleId = vehicleId;
            this.ExactProgress = exactProgress;
            this.Type = type;
            this.Lane = lane;
            this.SpawnTime = spawnTime;
            this.DesiredSpeedMetresHour = desiredSpeedMetresHour;
            this.VehicleHeight = vehicleHeight;
        }
    }
}