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
    public partial class MotorwaySimulator : Form
    {
        public int RoadLengthPixels;
        public int RoadLengthMetres;
        public int LaneCount;
        public int LaneWidth;
        public int LaneMargin;
        public int VehicleWidth;
        public int SafetyDistance;
        private long LastTimerValue;
        public int InterArrivalTime;
        private int LastId;
        public double TimeScale;
        public Dictionary<VehicleTypes, VehicleTemplate> VehicleParameters;

        public List<LaneControl> Lanes;
        public bool DebugSpawn;
        public List<DebugVehicleSpawnInstruction> DebugSpawnInstructions;
        public Random Random;
        public Stopwatch Timer;

        public MotorwaySimulator()
        {
            InitializeComponent();
        }

        private void MotorwaySimulator_Load(object sender, EventArgs e)
        {
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            DebugSpawnInstructions = new List<DebugVehicleSpawnInstruction>();
            DebugSpawn = false;
            Lanes = new List<LaneControl>();

            VehicleParameters = new Dictionary<VehicleTypes, VehicleTemplate>()
            {
                // Length (metres), Length Variation (+-) (metres), Desired Speed (meters/hour), Desired Speed Variation (+-) (meters/hour), Probability

                { VehicleTypes.Car, new VehicleTemplate((double)this.NumericCarLength.Value, (double)this.NumericCarLengthVar.Value,  (double)this.NumericCarDesiredSpeed.Value,  (double)this.NumericCarDesiredSpeedVar.Value,     0.74) },
                { VehicleTypes.LGV, new VehicleTemplate((double)this.NumericLGVLength.Value, (double)this.NumericLGVLengthVar.Value,  (double)this.NumericLGVDesiredSpeed.Value,  (double)this.NumericLGVDesiredSpeedVar.Value,      0.14) },
                { VehicleTypes.HGV, new VehicleTemplate((double)this.NumericHGVLength.Value, (double)this.NumericHGVLengthVar.Value,  (double)this.NumericHGVDesiredSpeed.Value,  (double)this.NumericHGVDesiredSpeedVar.Value,      0.11) },
                { VehicleTypes.Bus, new VehicleTemplate((double)this.NumericBusLength.Value, (double)this.NumericBusLengthVar.Value,  (double)this.NumericBusDesiredSpeed.Value,  (double)this.NumericBusDesiredSpeedVar.Value,      0.01) }

                /*{ VehicleTypes.Car, new VehicleTemplate(4,     0,  112000,    0,      1) },
                { VehicleTypes.LGV, new VehicleTemplate(5.5,   0,  111000,    0,      0) },
                { VehicleTypes.HGV, new VehicleTemplate(12,    0,  96000,     0,      0) },
                { VehicleTypes.Bus, new VehicleTemplate(11,    0,  96000,     0,      0) }*/
            };

            Timer = new Stopwatch();

            Random = new Random();
            TimeScale = 1;
            LastId = 0;
            LaneCount = 7;
            RoadLengthMetres = 300;
            RoadLengthPixels = (int)Math.Round(MetresToPixels(RoadLengthMetres), 0);
            LaneWidth = 40;
            LaneMargin = 8;
            InterArrivalTime = 500;
            LastTimerValue = 0;
            VehicleWidth = LaneWidth - (2 * LaneMargin);

            Road.Width = RoadLengthPixels;
            Road.Height = LaneCount * LaneWidth;

            for (int i = 0; i < LaneCount; i++)
            {
                LaneControl lane = new LaneControl(this, i);
                lane.Location = new Point(0, LaneWidth * i);
                lane.Size = new Size(RoadLengthPixels, LaneWidth);
                this.Road.Controls.Add(lane);
                this.Lanes.Add(lane);
            }

            DebugVehicleSpawnInstruction instruction;

            instruction = new DebugVehicleSpawnInstruction(0, 0, VehicleTypes.HGV, Lanes[0], 0, 96000, 8);
            DebugSpawnInstructions.Add(instruction);
            instruction = new DebugVehicleSpawnInstruction(1, 0, VehicleTypes.HGV, Lanes[0], 1200, 100000, 6);
            DebugSpawnInstructions.Add(instruction);
            instruction = new DebugVehicleSpawnInstruction(2, 0, VehicleTypes.Car, Lanes[0], 3000, 112000, 4);
            DebugSpawnInstructions.Add(instruction);

            Timer.Restart();
            this.FormTick.Enabled = true;
            this.ButtonStart.Enabled = false;
            this.ButtonStop.Enabled = true;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Timer.Stop();

            for (int i = LaneCount-1; i >= 0; i--)
            {
                LaneControl lane = Lanes[i];
                this.Road.Controls.Remove(lane);
                this.Lanes.Remove(lane);
            }

            this.ButtonStop.Enabled = false;
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

        private void AddVehicle()
        {
            LastId++;

            Vehicle newVehicle = GenerateVehicle(LastId);

            int lane = 0;
            bool success = false;
            while (!success && lane < this.LaneCount)
            {
                /*
                if (Lanes[lane].Vehicles.Count == 0)
                {
                    success = Lanes[lane].AddVehicleToLane(newVehicle);
                }
                */
                success = Lanes[lane].AddVehicleToLane(newVehicle);
                lane++;
            }

            if (!success)
            {
                LabelData3.Text = (Int32.Parse(LabelData3.Text) + 1).ToString();
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
                long tempTime = Timer.ElapsedMilliseconds;
                long elapsedTime = tempTime - LastTimerValue;
                double scaledElapsedTime = elapsedTime * this.TimeScale;

                double onePercent = InterArrivalTime * 0.01;
                double LowerBoundInterArrivalTime = InterArrivalTime - (onePercent * this.TimeScale); // Seems fairly accurate, lowers the trigger time depending on the TimeScale since the timer has a resolution of 15ms

                if (scaledElapsedTime >= LowerBoundInterArrivalTime || LastTimerValue == 0)
                {
                    LabelData2.Text = scaledElapsedTime.ToString();
                    LastTimerValue = tempTime;
                    AddVehicle();
                }
            }
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

        private void FormTick_Tick(object sender, EventArgs e)
        {
            CheckVehicle();
            Vehicle[] OrderedVehicles = AllVehiclesOrderByLocation();
            string data = "";
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
                data += vehicle.VehicleId + ": " + vehicle.Type + ": " + vehicle.DesiredSpeedMetresHour / 1000 + " kph" + Environment.NewLine;
            }

            foreach ( LaneControl lane in Lanes)
            {
                lane.Invalidate(); // Repaint the lane
            }
            LabelVehicleCount.Text = OrderedVehicles.Length.ToString();
            TextBoxData.Text = data;
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
            return metres * 6;
        }

        public double StoppingDistance(double speed)
        {
            return (speed / 3600) * 0.5;
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            this.FormTick.Enabled = false;
            this.Timer.Stop();
        }

        private void ButtonResume_Click(object sender, EventArgs e)
        {
            this.FormTick.Enabled = true;
            this.Timer.Start();
        }

        private void TrackBarTimescale_Scroll(object sender, EventArgs e)
        {
            this.TimeScale = TrackBarTimescale.Value/10.0f;
        }

        private void FormScrolled(object sender, ScrollEventArgs e)
        {
            PanelSettings.Location = new Point(12, 287);
        }
    }

    public class LaneControl : UserControl
    {
        public int LaneId;
        public List<Vehicle> Vehicles;
        private MotorwaySimulator MainForm;
        
        public LaneControl(MotorwaySimulator mainForm, int laneId)
        {            
            SetStyle(ControlStyles.UserPaint, true); // this should be true to set AllPaintingInWmPaint true
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // this should be true to set OptimizedDoubleBuffer true
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainForm = mainForm;
            this.LaneId = laneId;

            Vehicles = new List<Vehicle>();
        }

        private Vehicle[] VehiclesOrderByLocation()
        {
            return this.Vehicles.OrderByDescending(vehicle => vehicle.ExactProgress).ToArray();
        }

        private Vehicle[] VehiclesOrderByReverseLocation()
        {
            return this.Vehicles.OrderBy(vehicle => vehicle.ExactProgress).ToArray();
        }

        public Vehicle LastVehicle()
        {
            Vehicle[] OrderedVehicles = VehiclesOrderByLocation();
            if (OrderedVehicles.Length > 0)
            {
                return OrderedVehicles[OrderedVehicles.Length - 1];
            }
            else
            {
                return null;
            }
        }

        public Vehicle NextVehicle(Vehicle vehicle)
        {
            Vehicle[] OrderedVehicles = VehiclesOrderByLocation();
            int thisIndex = Array.IndexOf(OrderedVehicles, vehicle);
            if (OrderedVehicles.Length > 0 && thisIndex > 0)
            {
                return OrderedVehicles[thisIndex-1];
            }
            else
            {
                return null;
            }
        }

        public Vehicle PreviousVehicle(Vehicle vehicle)
        {
            Vehicle[] OrderedVehicles = VehiclesOrderByLocation();
            int thisIndex = Array.IndexOf(OrderedVehicles, vehicle);
            if (OrderedVehicles.Length > 0 && thisIndex < OrderedVehicles.Length-1)
            {
                return OrderedVehicles[thisIndex + 1];
            }
            else
            {
                return null;
            }
        }

        public Vehicle NextVehicleDifferentLane(Vehicle vehicle)
        {
            Vehicle[] orderedVehicles = VehiclesOrderByReverseLocation();
            Vehicle nextVehicle = null;
            if (orderedVehicles.Length > 0)
            {
                foreach(Vehicle myVehicle in orderedVehicles)
                {
                    if (myVehicle.ExactProgress > vehicle.ExactProgress)
                    {
                        nextVehicle = myVehicle;
                        break;
                    }
                }
                return nextVehicle;
            }
            else
            {
                return null;
            }
        }

        public Vehicle PreviousVehicleDifferentLane(Vehicle vehicle)
        {
            Vehicle[] orderedVehicles = VehiclesOrderByLocation();
            Vehicle previousVehicle = null;
            if (orderedVehicles.Length > 0)
            {
                foreach (Vehicle myVehicle in orderedVehicles)
                {
                    if (myVehicle.ExactProgress <= vehicle.ExactProgress) // equal to because otherwise anomaly when vehicle in same location [unlikely to ever happen]
                    {
                        previousVehicle = myVehicle;
                        break;
                    }
                }
                return previousVehicle;
            }
            else
            {
                return null;
            }
        }

        private bool ClearOfPreviousVehicle(Vehicle vehicle, Vehicle previousVehicle)
        {
            int vehicleProjectedStopppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(vehicle.ActualSpeedMetresHour)), 0);
            int previousVehicleStoppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(previousVehicle.ActualSpeedMetresHour)), 0);
            int backOfOtherLaneVehicle = vehicle.Progress - vehicle.VehicleHeight;

            if (previousVehicle.ActualSpeedMetresHour > vehicle.ActualSpeedMetresHour)
            {
                // previous vehicle going faster
                // previous vehicle can lose some stopping distance by slowing down so overlap by margin allowed
                int previousVehicleStoppingDistanceChangeByChangingSpeedsPixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(previousVehicle.ActualSpeedMetresHour)), 0) - vehicleProjectedStopppingDistancePixels;

                if (previousVehicle.Progress + previousVehicleStoppingDistancePixels < backOfOtherLaneVehicle + previousVehicleStoppingDistanceChangeByChangingSpeedsPixels)
                {
                    // overlaps but not quite enough that the previous vehicle can adjust speed to match yet [at least 1 pixel]
                    return true;
                }
            }
            else
            {
                // previous vehicle going slower or equal to
                // previous vehicle can't lose stopping distance so no overlap allowed
                if (previousVehicle.Progress + previousVehicleStoppingDistancePixels < backOfOtherLaneVehicle)
                {
                    // no overlap so there is space
                    return true;
                }
            }
            return false;
        }

        private bool ClearOfNextVehicle(Vehicle vehicle, Vehicle nextVehicle)
        {
            int vehicleProjectedStopppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(vehicle.ActualSpeedMetresHour)), 0);
            int backOfNextVehicle = nextVehicle.Progress - nextVehicle.VehicleHeight;

            // we can't overlap to change stopping distance for situations
            // 1) vehicle ahead is faster or equal, overlap impossible
            // 2) spec requires vehicles changing to lane N-1 must be able to stay at current speed
            //      if vehicle allows overlap then in theory they must change speed next tick, which
            //      is against the spec
            // so no overlap allowed
            if (vehicle.Progress + vehicleProjectedStopppingDistancePixels < backOfNextVehicle - (vehicleProjectedStopppingDistancePixels * 0.1)) // add 10% margin to stop cars immediately rejoining n lane after joining n+1
            {
                // no overlap so there is space
                return true;
            }
            return false;
        }

        public bool SpaceInLane(Vehicle vehicleFromOtherLane)
        {
            Vehicle nextVehicle = NextVehicleDifferentLane(vehicleFromOtherLane);
            Vehicle previousVehicle = PreviousVehicleDifferentLane(vehicleFromOtherLane);
            
            if (nextVehicle == null && previousVehicle == null)
            {
                // no vehicles
                return true;
            }
            else if (nextVehicle == null)
            {
                // just vehicle behind
                return ClearOfPreviousVehicle(vehicleFromOtherLane, previousVehicle);
            }
            else if (previousVehicle == null)
            {
                // just vehicle ahead
                return ClearOfNextVehicle(vehicleFromOtherLane, nextVehicle);
            }
            else
            {
                // vehicle ahead & behind
                return ClearOfPreviousVehicle(vehicleFromOtherLane, previousVehicle) && ClearOfNextVehicle(vehicleFromOtherLane, nextVehicle);
            }
        }

        public bool AddVehicleToLane(Vehicle newVehicle)
        {
            Vehicle nextVehicle = LastVehicle();
            //
            if (nextVehicle != null)
            {
                double projectedDesiredStopppingDistanceMetres = MainForm.StoppingDistance(newVehicle.DesiredSpeedMetresHour);
                int projectedDesiredStopppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(projectedDesiredStopppingDistanceMetres));
                int backOfNextVehicle = nextVehicle.Progress - nextVehicle.VehicleHeight;

                if (nextVehicle.ActualSpeedMetresHour >= newVehicle.DesiredSpeedMetresHour)
                {
                    // Next vehicle travelling faster or equal to than new vehicle wants to travel
                    // To spawn stopping distance needs to be at back of vehicle or further away
                    if ((newVehicle.Progress + projectedDesiredStopppingDistancePixels) > backOfNextVehicle)
                    {
                        // Stopping distance overlaps back of next vehicle
                        // Can't spawn
                        return false;
                    }
                }
                else
                {
                    // Next vehicle travelling slower than new vehicle wants to travel
                    // To spawn new vehicle stopping distance can only overlap back of next vehicle by
                    // stopping distance gained by changing speeds from desired [new] -> actual [next]
                    // this is because the new vehicle will switch to the actual speed of the next
                    // as soon as this overlap is reached in order for the stopping distance to be at
                    // the back of the next vehicle
                    int stoppingDistanceChangeByChangingSpeedsPixels = projectedDesiredStopppingDistancePixels - (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(nextVehicle.ActualSpeedMetresHour)));
                    if ((newVehicle.Progress + projectedDesiredStopppingDistancePixels) >= (backOfNextVehicle + stoppingDistanceChangeByChangingSpeedsPixels))
                    {
                        // Stopping distance overlaps (back of next vehicle - margin)
                        // Can't spawn
                        return false;
                    }
                }
            }

            newVehicle.ParentLane = this;
            this.Vehicles.Add(newVehicle);
            return true;
        }
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe);

            int viewPortLocation = this.MainForm.HorizontalScroll.Value;
            int viewPortWidth = this.MainForm.Width;

            using (Pen whitePen = new Pen(Color.White, 1))
            {
                whitePen.DashPattern = new float[] { 15, 20 };
                pe.Graphics.DrawLine(whitePen, new Point(0, 0), new Point(this.Size.Width,0));
                pe.Graphics.DrawLine(whitePen, new Point(0, this.Size.Height - 1), new Point(this.Size.Width, this.Size.Height-1));
            }

            using (Pen whitePen = new Pen(Color.White, 2))
            using (Pen blackPen = new Pen(Color.Black, 2))
            using (Pen yellowPen = new Pen(Color.Yellow, 2))
            using (SolidBrush yellowBrush = new SolidBrush(Color.Yellow))
            using (SolidBrush greenBrush = new SolidBrush(Color.LightGreen))
            using (SolidBrush redBrush = new SolidBrush(Color.OrangeRed))
            using (SolidBrush blueBrush = new SolidBrush(Color.LightBlue))
            using (SolidBrush blackBrush = new SolidBrush(Color.Black))
            using (SolidBrush translucentYellowBrush = new SolidBrush(Color.FromArgb(50, 255, 255, 0)))
            using (SolidBrush translucentRedBrush = new SolidBrush(Color.FromArgb(50, 255, 0, 0)))
            {
                for (int vehicleIndex = 0; vehicleIndex < this.Vehicles.Count; vehicleIndex++)
                {
                    Vehicle vehicle = this.Vehicles[vehicleIndex];
                    int safetyDistanceHeight = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(vehicle.ActualSpeedMetresHour)), 0);
                    
                    if (MainForm.CheckBoxTrackVehicle.Checked && vehicle.VehicleId == (int)MainForm.NumericVehicleId.Value)
                    {
                        if (!vehicle.InSight)
                        {
                            MainForm.CheckBoxTrackVehicle.Checked = false;
                        }
                        int newPosition = vehicle.Progress - (viewPortWidth / 2);
                        if (newPosition < 0)
                        {
                            newPosition = 0;
                        }
                        if (newPosition > MainForm.HorizontalScroll.Maximum)
                        {
                            newPosition = MainForm.HorizontalScroll.Maximum;
                        }
                        MainForm.HorizontalScroll.Value = newPosition;
                    }

                    if ((vehicle.Progress+safetyDistanceHeight) >= viewPortLocation && (vehicle.Progress-vehicle.VehicleHeight) < viewPortLocation + viewPortWidth)
                    {

                        Rectangle safetyRect = new Rectangle(new Point(vehicle.Progress, MainForm.LaneMargin), new Size(safetyDistanceHeight, vehicle.VehicleWidth));
                        if (vehicle.ActualSpeedMetresHour == vehicle.DesiredSpeedMetresHour)
                        {
                            pe.Graphics.FillRectangle(translucentYellowBrush, safetyRect);
                        }
                        else
                        {
                            pe.Graphics.FillRectangle(translucentRedBrush, safetyRect);
                        }
                        pe.Graphics.DrawRectangle(whitePen, safetyRect);

                        Size vehicleSize = new Size(vehicle.VehicleHeight, vehicle.VehicleWidth);

                        Rectangle vehicleRect = new Rectangle(new Point(vehicle.Progress - vehicle.VehicleHeight, MainForm.LaneMargin), vehicleSize);
                        switch (vehicle.Type)
                        {
                            case VehicleTypes.Car:
                                pe.Graphics.FillRectangle(yellowBrush, vehicleRect);
                                break;
                            case VehicleTypes.LGV:
                                pe.Graphics.FillRectangle(greenBrush, vehicleRect);
                                break;
                            case VehicleTypes.HGV:
                                pe.Graphics.FillRectangle(redBrush, vehicleRect);
                                break;
                            case VehicleTypes.Bus:
                                pe.Graphics.FillRectangle(blueBrush, vehicleRect);
                                break;
                        }
                        pe.Graphics.DrawRectangle(blackPen, vehicleRect);
                        using (Font drawFont = new Font("Courier New", 8))
                        {
                            pe.Graphics.DrawString(vehicle.VehicleId.ToString().PadLeft(3, '0'), drawFont, blackBrush, vehicle.Progress - vehicle.VehicleHeight, MainForm.LaneMargin);
                        }
                    }
                }
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