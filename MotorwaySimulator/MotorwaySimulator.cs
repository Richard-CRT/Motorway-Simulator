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
    public partial class MotorwaySimulator : Form
    {
        public int RoadLength;
        private int LaneCount;
        public int LaneWidth;
        public int LaneMargin;
        public int VehicleWidth;
        public int SafetyDistance;
        private long LastTimerValue;
        public int InterArrivalTime;
        private int LastId;
        public double TimeScale;
        public Dictionary<string, VehicleTemplate> VehicleParameters = new Dictionary<string, VehicleTemplate>()
        {
            // Length (metres), Length Variation (+-) (metres), Desired Speed (meters/hour), Desired Speed Variation (+-) (meters/hour), Probability

            { "Car", new VehicleTemplate(4,     1,  112000,    16000,     0.74) },
            { "LGV", new VehicleTemplate(5.5,   1,  112000,    8000,      0.14) },
            { "HGV", new VehicleTemplate(12,    2,  96000,     4000,      0.11) },
            { "Bus", new VehicleTemplate(11,    2,  96000,     4000,      0.01) }

            /*{ "Car", new VehicleTemplate(4,     0,  112000,    0,      0.5) },
            { "LGV", new VehicleTemplate(5.5,   0,  111000,    0,      0.5) },
            { "HGV", new VehicleTemplate(12,    0,  96000,     0,      0) },
            { "Bus", new VehicleTemplate(11,    0,  96000,     0,      0) }*/
        };

        public List<LaneControl> Lanes;
        public Random Random;
        public Stopwatch Timer;

        public MotorwaySimulator()
        {
            InitializeComponent();
        }

        private void MotorwaySimulator_Load(object sender, EventArgs e)
        {
            Lanes = new List<LaneControl>();
            Timer = new Stopwatch();
            Timer.Start();

            Random = new Random();
            TimeScale = 1;
            LastId = 0;
            LaneCount = 7;
            RoadLength = 900;
            LaneWidth = 40;
            LaneMargin = 8;
            InterArrivalTime = 50;
            LastTimerValue = 0;
            VehicleWidth = LaneWidth - (2 * LaneMargin);

            Road.Height = RoadLength;
            Road.Width = LaneCount * LaneWidth;
            this.Controls.Add(Road);

            for (int i = 0; i < LaneCount; i++)
            {
                LaneControl lane = new LaneControl(this, i);
                lane.Location = new Point(LaneWidth * i, 0);
                lane.Size = new Size(LaneWidth, this.Road.Height);
                this.Road.Controls.Add(lane);
                this.Lanes.Add(lane);
            }
        }

        private Vehicle GenerateVehicle(int id)
        {
            Vehicle newVehicle;
            double rand = this.Random.NextDouble();
            double total = 0;
            if (rand < this.VehicleParameters["Car"].Probability)
            {
                //Car
                newVehicle = new Car(this, id);
            }
            else
            {
                total += this.VehicleParameters["Car"].Probability;
                if (total <= rand && rand < total + this.VehicleParameters["LGV"].Probability)
                {
                    //LGV
                    newVehicle = new LGV(this, id);
                }
                else
                {
                    total += this.VehicleParameters["LGV"].Probability;
                    if (total <= rand && rand < total + this.VehicleParameters["HGV"].Probability)
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
            long tempTime = Timer.ElapsedMilliseconds;
            long elapsedTime = tempTime - LastTimerValue;
            double scaledElapsedTime = elapsedTime * this.TimeScale;

            double onePercent = InterArrivalTime * 0.01;
            double LowerBoundInterArrivalTime = InterArrivalTime - (onePercent*this.TimeScale); // Seems fairly accurate, lowers the trigger time depending on the TimeScale since the timer has a resolution of 15ms

            if (scaledElapsedTime >= LowerBoundInterArrivalTime || LastTimerValue == 0)
            {
                LabelData2.Text = scaledElapsedTime.ToString();
                LastTimerValue = tempTime;
                AddVehicle();
            }
        }

        private Vehicle[] AllVehiclesOrderByLocation()
        {
            List<Vehicle> allVehicles = new List<Vehicle>();
            foreach (LaneControl lane in Lanes)
            {
                allVehicles.AddRange(lane.Vehicles);
            }
            return allVehicles.OrderBy(vehicle => vehicle.ExactLocationY).ToArray();
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
                    vehicle.ParentLane.Vehicles.Remove(vehicle);
                }
                data += vehicle.VehicleId + ": " + vehicle.DesiredSpeedMetresHour / 1000 + " kph" + Environment.NewLine;
            }

            foreach ( LaneControl lane in Lanes)
            {
                lane.Invalidate(); // Repaint the lane
            }

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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.TimeScale = trackBar1.Value/10.0f;
        }

        private void formScrolled(object sender, ScrollEventArgs e)
        {
            Panel.Location = new Point(283, 44);
        }
    }

    public class VehicleTemplate
    {
        public double Length, LengthVariation, DesiredSpeed, DesiredSpeedVariation, Probability;
        public VehicleTemplate(double length, double lengthVariation, double desiredSpeed, double desiredSpeedVariation, double probability)
        {
            Length = length;
            LengthVariation = lengthVariation;
            DesiredSpeed = desiredSpeed;
            DesiredSpeedVariation = desiredSpeedVariation;
            Probability = probability;
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
            return this.Vehicles.OrderBy(vehicle => vehicle.ExactLocationY).ToArray();
        }

        private Vehicle[] VehiclesOrderByReverseLocation()
        {
            return this.Vehicles.OrderByDescending(vehicle => vehicle.ExactLocationY).ToArray();
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

        public Vehicle NextVehicleDifferentLane(Vehicle vehicle)
        {
            Vehicle[] OrderedVehicles = VehiclesOrderByReverseLocation();
            Vehicle nextVehicle = null;
            if (OrderedVehicles.Length > 0)
            {
                foreach(Vehicle myVehicle in this.Vehicles)
                {
                    if (myVehicle.ExactLocationY < vehicle.ExactLocationY)
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
            Vehicle[] OrderedVehicles = VehiclesOrderByLocation();
            Vehicle previousVehicle = null;
            if (OrderedVehicles.Length > 0)
            {
                foreach (Vehicle myVehicle in this.Vehicles)
                {
                    if (myVehicle.LocationY >= vehicle.ExactLocationY) // equal to because otherwise anomaly when vehicle in same location [unlikely the ever happen]
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

        public bool SpaceInLane(Vehicle vehicleFromOtherLane)
        {
            int projectedStopppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(StoppingDistance(vehicleFromOtherLane.ActualSpeedMetresHour)), 0);
            int projectedOccupiedAreaLocationY = vehicleFromOtherLane.LocationY - projectedStopppingDistancePixels;
            int projectedOccupiedAreaHeight = vehicleFromOtherLane.VehicleHeight + projectedStopppingDistancePixels;

            Vehicle nextVehicle = NextVehicleDifferentLane(vehicleFromOtherLane);
            Vehicle previousVehicle = PreviousVehicleDifferentLane(vehicleFromOtherLane);
            
            if (nextVehicle == null && previousVehicle == null)
            {
                return true;
            }

            return false;
        }

        public double StoppingDistance(double speed)
        {
            return (speed / 3600) * 0.5;
        }

        public bool AddVehicleToLane(Vehicle newVehicle)
        {
            Vehicle nextVehicle = LastVehicle();
            //
            if (nextVehicle != null)
            {
                double projectedDesiredStopppingDistanceMetres = StoppingDistance(newVehicle.DesiredSpeedMetresHour);
                int projectedDesiredStopppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(projectedDesiredStopppingDistanceMetres));
                int backOfNextVehicle = nextVehicle.LocationY + nextVehicle.VehicleHeight;

                if (nextVehicle.ActualSpeedMetresHour > newVehicle.DesiredSpeedMetresHour)
                {
                    // Next vehicle travelling faster than new vehicle wants to travel
                    // To spawn stopping distance needs to be at back of vehicle or further away
                    if ((newVehicle.LocationY - projectedDesiredStopppingDistancePixels) < backOfNextVehicle)
                    {
                        // Stopping distance overlaps back of next vehicle
                        // Can't spawn
                        return false;
                    }
                    else
                    {
                        // Can spawn
                    }
                }
                else if (nextVehicle.ActualSpeedMetresHour == newVehicle.DesiredSpeedMetresHour)
                {
                    // Next vehicle travelling equal to new vehicle
                    // To spawn stopping distance needs to be at back of vehicle or further away
                    if ((newVehicle.LocationY - projectedDesiredStopppingDistancePixels) < backOfNextVehicle)
                    {
                        // Stopping distance overlaps back of next vehicle
                        // Can't spawn
                        return false;
                    }
                    else
                    {
                        // Can spawn
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
                    int stoppingDistanceChangeByChangingSpeedsPixels = projectedDesiredStopppingDistancePixels - (int)Math.Round(MainForm.MetresToPixels(StoppingDistance(nextVehicle.ActualSpeedMetresHour)));
                    if ((newVehicle.LocationY - projectedDesiredStopppingDistancePixels) <= (backOfNextVehicle - stoppingDistanceChangeByChangingSpeedsPixels))
                    {
                        // Stopping distance overlaps (back of next vehicle - margin)
                        // Can't spawn
                        return false;
                    }
                    else
                    {
                        // Can spawn
                    }
                }
            }

            newVehicle.ParentLane = this;
            this.Vehicles.Add(newVehicle);
            return true;
        }
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            using (Pen whitePen = new Pen(Color.White, 1))
            {
                whitePen.DashPattern = new float[] { 15, 20 };
                pe.Graphics.DrawLine(whitePen, new Point(this.Size.Width - 1, 0), new Point(this.Size.Width - 1, this.Size.Height));
                pe.Graphics.DrawLine(whitePen, new Point(0, 0), new Point(0, this.Size.Height));
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

                    int safetyDistanceHeight = (int)Math.Round(MainForm.MetresToPixels(StoppingDistance(vehicle.ActualSpeedMetresHour)), 0);

                    Rectangle safetyRect = new Rectangle(new Point(MainForm.LaneMargin, vehicle.LocationY - safetyDistanceHeight), new Size(vehicle.VehicleWidth, safetyDistanceHeight));
                    if (vehicle.ActualSpeedMetresHour == vehicle.DesiredSpeedMetresHour)
                    {
                        pe.Graphics.FillRectangle(translucentYellowBrush, safetyRect);
                    }
                    else
                    {
                        pe.Graphics.FillRectangle(translucentRedBrush, safetyRect);
                    }
                    pe.Graphics.DrawRectangle(whitePen, safetyRect);

                    Rectangle vehicleRect = new Rectangle(new Point(MainForm.LaneMargin, vehicle.LocationY), vehicle.VehicleSize);
                    switch (vehicle.Type)
                    {
                        case "Car":
                            pe.Graphics.FillRectangle(yellowBrush, vehicleRect);
                            break;
                        case "LGV":
                            pe.Graphics.FillRectangle(greenBrush, vehicleRect);
                            break;
                        case "HGV":
                            pe.Graphics.FillRectangle(redBrush, vehicleRect);
                            break;
                        case "Bus":
                            pe.Graphics.FillRectangle(blueBrush, vehicleRect);
                            break;
                    }
                    pe.Graphics.DrawRectangle(blackPen, vehicleRect);
                    using (Font drawFont = new Font("Courier New", 8))
                    {
                        pe.Graphics.DrawString(vehicle.VehicleId.ToString().PadLeft(3, '0'), drawFont, blackBrush, MainForm.LaneMargin, vehicle.LocationY);
                    }
                }
            }
        }
    }
}