using MotorwaySimulator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CustomControls
{
    public class LaneControl : UserControl
    {
        public TreeNode LaneNode;
        private Vehicle[] OldOrderedLaneVehicles;
        public int LaneId;
        public List<Vehicle> Vehicles;
        private MotorwaySimulatorForm MainForm;

        public LaneControl(MotorwaySimulatorForm mainForm, int laneId)
        {
            SetStyle(ControlStyles.UserPaint, true); // this should be true to set AllPaintingInWmPaint true
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // this should be true to set OptimizedDoubleBuffer true
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainForm = mainForm;
            this.LaneId = laneId;

            Vehicles = new List<Vehicle>();
            OldOrderedLaneVehicles = new Vehicle[0];
        }

        public void UpdateTreeNode()
        {
            List<Vehicle> vehiclesToAdd = new List<Vehicle>();
            List<Vehicle> vehiclesToRemove = new List<Vehicle>();

            Vehicle[] orderedLaneVehicles = VehiclesOrderByLocation();

            foreach (Vehicle vehicle in orderedLaneVehicles)
            {
                if (!OldOrderedLaneVehicles.Contains(vehicle))
                {
                    vehiclesToAdd.Add(vehicle);
                }
            }

            foreach (Vehicle oldVehicle in OldOrderedLaneVehicles)
            {
                if (!orderedLaneVehicles.Contains(oldVehicle))
                {
                    vehiclesToRemove.Add(oldVehicle);
                }
            }

            if (vehiclesToRemove.Count > 0)
            {
                for (int treeNodeIndex = 0; treeNodeIndex < LaneNode.Nodes.Count;)
                {
                    TreeNode treeNode = LaneNode.Nodes[treeNodeIndex];
                    if (vehiclesToRemove.Contains((Vehicle)treeNode.Tag))
                    {
                        LaneNode.Nodes.RemoveAt(treeNodeIndex);
                    }
                    else
                    {
                        treeNodeIndex++;
                    }
                }
            }

            foreach (TreeNode treeNode in LaneNode.Nodes)
            {
                Vehicle vehicle = (Vehicle)treeNode.Tag;
                if (vehicle.IsTravellingAtDesiredSpeed)
                {
                    treeNode.BackColor = Color.LimeGreen;
                }
                else
                {
                    treeNode.BackColor = Color.Red;
                }
            }

            TreeNode[] newVehicleNodes = new TreeNode[vehiclesToAdd.Count];
            for (int vehicleIndex = 0; vehicleIndex < vehiclesToAdd.Count; vehicleIndex++)
            {
                Vehicle vehicle = vehiclesToAdd[vehicleIndex];
                newVehicleNodes[vehicleIndex] = new TreeNode("#" + vehicle.VehicleId + " - " + vehicle.VehicleType + " - " + vehicle.ActualSpeedKilometresHour + " kph");
                newVehicleNodes[vehicleIndex].Tag = vehicle;
                newVehicleNodes[vehicleIndex].ForeColor = Color.White;
                if (vehicle.IsTravellingAtDesiredSpeed)
                {
                    newVehicleNodes[vehicleIndex].BackColor = Color.LimeGreen;
                }
                else
                {
                    newVehicleNodes[vehicleIndex].BackColor = Color.Red;
                }
            }
            LaneNode.Nodes.AddRange(newVehicleNodes);
            OldOrderedLaneVehicles = orderedLaneVehicles;
        }

        public Vehicle[] VehiclesOrderByLocation()
        {
            return this.Vehicles.OrderByDescending(vehicle => vehicle.ExactProgress).ToArray();
        }

        public Vehicle[] VehiclesOrderByReverseLocation()
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
                return OrderedVehicles[thisIndex - 1];
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
            if (OrderedVehicles.Length > 0 && thisIndex < OrderedVehicles.Length - 1)
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
                foreach (Vehicle myVehicle in orderedVehicles)
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
                pe.Graphics.DrawLine(whitePen, new Point(0, 0), new Point(this.Size.Width, 0));
                pe.Graphics.DrawLine(whitePen, new Point(0, this.Size.Height - 1), new Point(this.Size.Width, this.Size.Height - 1));
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
                        MainForm.UpdateControlPanelLocation();
                    }

                    if ((vehicle.Progress + safetyDistanceHeight) >= viewPortLocation && (vehicle.Progress - vehicle.VehicleHeight) < viewPortLocation + viewPortWidth)
                    {

                        Rectangle safetyRect = new Rectangle(new Point(vehicle.Progress, MainForm.LaneMarginPixels), new Size(safetyDistanceHeight, vehicle.VehicleWidth));
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

                        Rectangle vehicleRect = new Rectangle(new Point(vehicle.Progress - vehicle.VehicleHeight, MainForm.LaneMarginPixels), vehicleSize);
                        switch (vehicle.VehicleType)
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
                            pe.Graphics.DrawString(vehicle.VehicleId.ToString().PadLeft(3, '0'), drawFont, blackBrush, vehicle.Progress - vehicle.VehicleHeight, MainForm.LaneMarginPixels);
                        }
                    }
                }
            }
        }
    }
}
