/* Included System Namespaces/Libraries */
using MotorwaySimulator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CustomControls
{
    /// <summary>
    /// Each instance of this class represents a lane on the road and is in charge of keeping track of and painting the vehicles.
    /// It inherits from the UserControl class which provides a control base which is designed to be edited by developers
    /// </summary>
    public class LaneControl : UserControl
    {

        #region Variable Declarations

        /* Lane Details */

        /// <summary>
        /// The ID of the lane
        /// </summary>
        public int LaneId;

        
        /* TreeView */
        
        /// <summary>
        /// The TreeNode for this lane in the vehicles TreeView on the main form (TreeNode is a system class that I have not created)
        /// </summary>
        public TreeNode LaneNode;


        /* Contents of the lane */

        /// <summary>
        /// The dynamic list of vehicles on this lane of the road
        /// </summary>
        public List<Vehicle> Vehicles;
        /// <summary>
        /// Used for comparison to calculate the new vehicles from the old ones
        /// </summary>
        private Vehicle[] OldOrderedLaneVehicles;


        /* Parents */

        /// <summary>
        /// The main form object which allows access to the main form's methods, properties and controls
        /// </summary>
        private MotorwaySimulatorForm MainForm;

        #endregion

        /// <summary>
        /// This is the constructor for the LaneControl class.
        /// It sets a few ControlStyles to try to combat the flashing effect when the lane is repainted.
        /// It sets the background of the lane to a rough road colour.
        /// It initialises two variables that need initial values.
        /// </summary>
        /// <param name="mainForm">The main form object which allows access to the main form's methods, properties and controls</param>
        /// <param name="laneId">The ID of the lane to construct</param>
        public LaneControl (MotorwaySimulatorForm mainForm, int laneId)
        {
            // Set the styles to avoid the flashing effect
            SetStyle(ControlStyles.UserPaint, true); // this should be true to set AllPaintingInWmPaint true
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // this should be true to set OptimizedDoubleBuffer true
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            // Sets the background colour of the control
            BackColor = Color.DarkGray;

            // Initialises the default values of these variables
            Vehicles = new List<Vehicle>();
            OldOrderedLaneVehicles = new Vehicle[0];

            // Assign the properties of the class to the parameters of the constructor
            MainForm = mainForm;
            LaneId = laneId;
        }

        #region Methods

        /// <summary>
        /// This method will calculate which vehicles need to be added/removed from this lanes TreeNode in the vehicles 
        /// 
        /// 
        /// on the main form
        /// </summary>
        public void UpdateTreeNode()
        {
            List<Vehicle> vehiclesToAdd = new List<Vehicle>();
            List<Vehicle> vehiclesToRemove = new List<Vehicle>();

            Vehicle[] orderedLaneVehicles = VehiclesOrderByLocation();

            // Calculate the vehicles to add to this lane's TreeNode
            foreach (Vehicle vehicle in orderedLaneVehicles)
            {
                if (!OldOrderedLaneVehicles.Contains(vehicle))
                {
                    vehiclesToAdd.Add(vehicle);
                }
            }

            // Calculate the vehicles to remove from this lane's TreeNode
            foreach (Vehicle oldVehicle in OldOrderedLaneVehicles)
            {
                if (!orderedLaneVehicles.Contains(oldVehicle))
                {
                    vehiclesToRemove.Add(oldVehicle);
                }
            }

            if (vehiclesToRemove.Count > 0)
            {
                // Remove each vehicle to remove from this lane's TreeNode
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

            // Update the background colour of the existing nodes to the reflect the congestion level
            // LimeGreen : No Congestion
            // Red       : Mildly Congestion
            // DarkRed   : Severely Congestion
            foreach (TreeNode treeNode in LaneNode.Nodes)
            {
                Vehicle vehicle = (Vehicle)treeNode.Tag;
                switch (vehicle.Congestion)
                {
                    case CongestionStates.None:
                        treeNode.BackColor = Color.LimeGreen;
                        break;
                    case CongestionStates.Mild:
                        treeNode.BackColor = Color.Red;
                        break;
                    case CongestionStates.Severe:
                        treeNode.BackColor = Color.DarkRed;
                        break;
                }
            }

            TreeNode[] newVehicleNodes = new TreeNode[vehiclesToAdd.Count];
            // Construct the nodes for the vehicles that need to be added to the lane's TreeNode
            for (int vehicleIndex = 0; vehicleIndex < vehiclesToAdd.Count; vehicleIndex++)
            {
                Vehicle vehicle = vehiclesToAdd[vehicleIndex];
                newVehicleNodes[vehicleIndex] = new TreeNode("#" + (vehicle.VehicleId+1) + " - " + vehicle.VehicleType + " - " + Math.Round(vehicle.ActualSpeedMetresHour/1000,0) + " kph");
                newVehicleNodes[vehicleIndex].Tag = vehicle;
                newVehicleNodes[vehicleIndex].ForeColor = Color.White;
                switch(vehicle.Congestion)
                {
                    case CongestionStates.None:
                        newVehicleNodes[vehicleIndex].BackColor = Color.LimeGreen;
                        break;
                    case CongestionStates.Mild:
                        newVehicleNodes[vehicleIndex].BackColor = Color.Red;
                        break;
                    case CongestionStates.Severe:
                        newVehicleNodes[vehicleIndex].BackColor = Color.DarkRed;
                        break;
                }
            }

            // Iterate through the exisiting nodes and insert the new vehicle nodes in order of the vehicle's progress along the road. The vehicles further along the road are higher up the lane's TreeNode
            List<TreeNode> newVehicleNodesList = newVehicleNodes.OrderByDescending(node => ((Vehicle)node.Tag).ExactProgressMetres).ToList();
            for(int laneVehicleNodeIndex = 0; laneVehicleNodeIndex < LaneNode.Nodes.Count; laneVehicleNodeIndex++)
            {
                TreeNode laneVehicleNode = LaneNode.Nodes[laneVehicleNodeIndex];
                for (int vehicleNodeIndex = 0; vehicleNodeIndex < newVehicleNodesList.Count; )
                {
                    TreeNode newVehicleNode = newVehicleNodesList[vehicleNodeIndex];
                    if (((Vehicle)newVehicleNode.Tag).ExactProgressMetres > ((Vehicle)laneVehicleNode.Tag).ExactProgressMetres)
                    {
                        LaneNode.Nodes.Insert(laneVehicleNodeIndex, newVehicleNode);
                        laneVehicleNodeIndex++;

                        newVehicleNodesList.RemoveAt(vehicleNodeIndex);
                    }
                    else
                    {
                        vehicleNodeIndex++;
                    }
                }
            }

            // Add the nodes that have not been added yet because they do not fit in before the end of the lane's TreeNode
            newVehicleNodes.Reverse();
            foreach (TreeNode newVehicleNode in newVehicleNodes)
            {
                if (LaneNode.Nodes.Count == 0 || ((Vehicle)newVehicleNode.Tag).ExactProgressMetres < ((Vehicle)LaneNode.Nodes[LaneNode.Nodes.Count-1].Tag).ExactProgressMetres)
                {
                    LaneNode.Nodes.Add(newVehicleNode);
                }
            }

            // Update the old dynamic list of vehicles so that the method can compare next tick
            OldOrderedLaneVehicles = orderedLaneVehicles;
        }

        /// <summary>
        /// Gets the last vehicle in the lane (i.e. the one that has made the least progress)
        /// </summary>
        /// <returns>The object of the last vehicle in the lane (i.e the one that has made the least progress)</returns>
        public Vehicle LastVehicle()
        {
            Vehicle[] OrderedVehicles = VehiclesOrderByReverseLocation();
            if (OrderedVehicles.Length > 0)
            {
                // There are vehicles in this lane

                // return the vehicle that has made the least progress
                return OrderedVehicles[0];
            }
            else
            {
                // There are no vehicles in this lane

                return null;
            }
        }

        /// <summary>
        /// Gets the vehicle just ahead of the vehicle passed in as a parameter in this lane (the vehicle passed in isn't necessarily in the same lane)
        /// </summary>
        /// <param name="vehicle">The vehicle object to use as a reference point in finding vehicle before (not necessarily in the same lane)</param>
        /// <returns>The object of the vehicle just ahead of the vehicle passed in as a parameter in this lane</returns>
        public Vehicle NextVehicle(Vehicle vehicle)
        {
            Vehicle[] orderedVehicles = VehiclesOrderByReverseLocation();
            Vehicle nextVehicle = null;
            if (orderedVehicles.Length > 0)
            {
                foreach (Vehicle myVehicle in orderedVehicles)
                {
                    if (myVehicle.ExactProgressMetres > vehicle.ExactProgressMetres)
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

        /// <summary>
        /// Gets the vehicle just after or at exactly the same place as the vehicle passed in as a parameter in this lane (the vehicle passed in isn't necessarily in the same lane)
        /// </summary>
        /// <param name="vehicle">The vehicle object to use as a reference point in finding vehicle after (not necessarily in the same lane)</param>
        /// <returns>The object of the vehicle just after or at exactly the same place as the vehicle passed in as a parameter in this lane</returns>
        public Vehicle PreviousVehicle(Vehicle vehicle)
        {
            Vehicle[] orderedVehicles = VehiclesOrderByLocation();
            Vehicle previousVehicle = null;
            if (orderedVehicles.Length > 0)
            {
                foreach (Vehicle myVehicle in orderedVehicles)
                {
                    if (myVehicle.ExactProgressMetres <= vehicle.ExactProgressMetres)
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

        /// <summary>
        /// Orders all the vehicles in this lane by progress along the road (furthest first)
        /// </summary>
        /// <returns>An array containing all the vehicles in this lane ordered by progress along the road (furthest first)</returns>
        public Vehicle[] VehiclesOrderByLocation()
        {
            return Vehicles.OrderByDescending(vehicle => vehicle.ExactProgressMetres).ToArray();
        }

        /// <summary>
        /// Orders all the vehicles in this lane by progress along the road (furthest last)
        /// </summary>
        /// <returns>An array containing all the vehicles in this lane ordered by progress along the road (furthest last)</returns>
        public Vehicle[] VehiclesOrderByReverseLocation()
        {
            return Vehicles.OrderBy(vehicle => vehicle.ExactProgressMetres).ToArray();
        }

        /// <summary>
        /// Will calculate whether the vehicle from the other lane is clear of both the vehicle ahead of it and behind it in this lane
        /// </summary>
        /// <param name="vehicleFromOtherLane">The vehicle object from a different lane to use as a reference point in checking if there's space in the lane</param>
        /// <returns>Returns True or False depending whether there is space for a vehicle from another lane to switch to this lane </returns>
        public bool SpaceInLane(Vehicle vehicleFromOtherLane)
        {
            // Return whether the vehicle from the other lane is clear of the vehicle ahead and clear of the vehicle behind in this lane
            return ClearOfNextVehicle(vehicleFromOtherLane) && ClearOfPreviousVehicle(vehicleFromOtherLane);
        }

        /// <summary>
        /// Will calculate whether the vehicle from the other lane is clear of the vehicle ahead in this lane
        /// </summary>
        /// <param name="vehicleFromOtherLane">The vehicle object from a different lane to use as a reference point in checking if it's clear of the vehicle ahead in this lane</param>
        /// <returns></returns>
        private bool ClearOfNextVehicle(Vehicle vehicleFromOtherLane)
        {
            // Get the vehicle ahead of the vehicle from the other lane
            Vehicle nextVehicle = NextVehicle(vehicleFromOtherLane);

            if (nextVehicle != null)
            {

                // Calculate the location of the back of the next vehicle
                int backOfNextVehicle = nextVehicle.ProgressPixels - nextVehicle.VehicleLengthPixels;

                // Specification requires vehicles changing to lane N-1 must be able to travel at their desired speed and vehicles changing to lane N+1 must be able to travel at least at its current speed.
                // If the vehicle from the other lane is allowed to overlap then in theory it must change speed to match that of the next vehicle during the next tick. That is against the specification,
                // so the vehicle from the other lane cannot overlap. The stopping distance is either for desired speed or actual speed depending on whether vehicle is changing to lane N-1 or N+1

                // Since all vehicles will strive to be in lane N-1, if a vehicle joins lane N+1 to overtake, it will immediately rejoin lane N. To combat this an extra 10% of the
                // stopping distance space will be required to change lane N to lane N-1
                double modifier;
                int vehicleFromOtherLaneProjectedStoppingDistancePixels;
                if (vehicleFromOtherLane.ParentLane.LaneId > LaneId)
                {
                    // Changing lane to the left
                    modifier = 1.1;

                    // Calculate the stopping distance of the vehicle from the other lane at desired speed
                    vehicleFromOtherLaneProjectedStoppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(vehicleFromOtherLane.DesiredSpeedMetresHour)), 0);
                }
                else
                {
                    // Changing lane to the right
                    modifier = 1.0;

                    // Calculate the stopping distance of the vehicle from the other lane at desired speed
                    vehicleFromOtherLaneProjectedStoppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(vehicleFromOtherLane.ActualSpeedMetresHour)), 0);
                }

                if (vehicleFromOtherLane.ProgressPixels + (vehicleFromOtherLaneProjectedStoppingDistancePixels * modifier) < backOfNextVehicle)
                {
                    // The stopping distance of the vehicle from the other lane does not overlap with the next vehicle

                    // Return that the vehicle from the other lane is clear of the next vehicle
                    return true;
                }
                else
                {
                    // The stopping distance of the vehicle from the other lane overlaps with the next vehicle

                    // Return that the vehicle from the other lane is not clear of the next vehicle
                    return false;
                }
            }
            else
            {
                // There is no vehicle in this lane ahead of the vehicle from the other lane

                // Return that the vehicle from the other lane is clear of the (non-existent) next vehicle in this lane
                return true;
            }
        }

        /// <summary>
        /// Will calculate whether the vehicle from the other lane is clear of the vehicle behind in this lane
        /// </summary>
        /// <param name="vehicleFromOtherLane">The vehicle object from a different lane to use as a reference point in checking if it's clear of the vehicle behind in this lane</param>
        /// <returns></returns>
        private bool ClearOfPreviousVehicle(Vehicle vehicleFromOtherLane)
        {
            // Get the vehicle behind the vehicle from the other lane
            Vehicle previousVehicle = PreviousVehicle(vehicleFromOtherLane);

            if (previousVehicle != null)
            {
                // Calculate the stopping distance of the vehicle behind the vehicle from the other lane
                int previousVehicleStoppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(previousVehicle.ActualSpeedMetresHour)), 0);

                // Calculate the location of the back of the vehicle from the other lane
                int backOfOtherLaneVehicle = vehicleFromOtherLane.ProgressPixels - vehicleFromOtherLane.VehicleLengthPixels;
                
                double speedInQuestion;
                if (vehicleFromOtherLane.ParentLane.LaneId > LaneId)
                {
                    // Changing lane to the left

                    // Calculate the stopping distance of the vehicle from the other lane
                    speedInQuestion = vehicleFromOtherLane.DesiredSpeedMetresHour;
                }
                else
                {
                    // Changing lane to the right

                    // Calculate the stopping distance of the vehicle from the other lane
                    speedInQuestion = vehicleFromOtherLane.ActualSpeedMetresHour;
                }

                if (previousVehicle.ActualSpeedMetresHour > speedInQuestion)
                {
                    // Calculate the stopping distance of the vehicle from the other lane
                    int vehicleFromOtherLaneProjectedStoppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(speedInQuestion)), 0);

                    // The vehicle behind the vehicle from the other lane is travelling faster than the vehicle from the other lane
                    // Therefore the vehicle behind the vehicle from the other lane can slow down, meaning the stopping distance can overlap

                    // Calculate the overlap allowed in pixels
                    int previousVehicleStoppingDistanceChangeByChangingSpeedsPixels = previousVehicleStoppingDistancePixels - vehicleFromOtherLaneProjectedStoppingDistancePixels;

                    if (previousVehicle.ProgressPixels + previousVehicleStoppingDistancePixels < backOfOtherLaneVehicle + previousVehicleStoppingDistanceChangeByChangingSpeedsPixels)
                    {
                        // The stopping distance overlaps, but only by less than the overlap allowed

                        // Return that the vehicle from the other lane is clear of the vehicle behind it
                        return true;
                    }
                    else
                    {
                        // The stopping distance overlaps by more than the previous vehicle can compensate for

                        // Return that the vehicle from the other lane is not clear of the vehicle behind it
                        return false;
                    }
                }
                else
                {
                    // The vehicle behind the vehicle from the other lane is travelling slower than the vehicle from the other lane
                    // Therefore the vehicle behind the vehicle from the other lane cannot slow down, meaning the stopping distance cannot overlap
                    if (previousVehicle.ProgressPixels + previousVehicleStoppingDistancePixels < backOfOtherLaneVehicle)
                    {
                        // The stopping distance of the vehicle behind the vehicle from the other lane does not overlap with the vehicle from the other lane

                        // Return that the vehicle from the other lane is clear of the vehicle behind it
                        return true;
                    }
                    else
                    {
                        // The stopping distance of the vehicle behind the vehicle from the other lane overlaps with the vehicle from the other lane

                        // Return that the vehicle from the other lane is not clear of the vehicle behind it
                        return false;
                    }
                }
            }
            else
            {
                // There is no vehicle in this lane behind the vehicle from the other lane

                // Return that the vehicle from the other lane is clear of the (non-existent) vehicle behind in this lane
                return true;
            }
        }

        /// <summary>
        /// Attempt to add the vehicle passed in as a parameter to this lane
        /// </summary>
        /// <param name="newVehicle">The vehicle to attempt to add to this lane</param>
        /// <returns>Whether the attempt to add the vehicle to this lane is successful or not</returns>
        public bool AddVehicleToLane(Vehicle newVehicle)
        {
            // Get the last vehicle on the lane
            Vehicle lastVehicle = LastVehicle();
            
            if (lastVehicle != null)
            {
                // There is actually a vehicle on the lane

                // Calculate the stopping distance of the new vehicle
                int projectedDesiredStoppingDistancePixels = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(newVehicle.DesiredSpeedMetresHour)));

                // Calculate the location of the back of the last vehicle on the lane
                int backOfNextVehicle = lastVehicle.ProgressPixels - lastVehicle.VehicleLengthPixels;

                if (lastVehicle.ActualSpeedMetresHour >= newVehicle.DesiredSpeedMetresHour)
                {
                    // Last vehicle on the lan travelling faster or equal to than new vehicle wants to travel
                    // To spawn stopping distance needs to be at back of vehicle or further away, i.e. no stopping distance overlap is allowed
                    if (newVehicle.ProgressPixels + projectedDesiredStoppingDistancePixels >= backOfNextVehicle)
                    {
                        // Stopping distance overlaps the back of the last vehicle on the lane

                        // Return that the attempt failed
                        return false;
                    }
                }
                else
                {
                    // Last vehicle on the lane is travelling slower than new vehicle wants to travel
                    // Therefore the vehicle behind the vehicle from the other lane can slow down, meaning the stopping distance can overlap

                    // Calculate the overlap allowed in pixels
                    int stoppingDistanceChangeByChangingSpeedsPixels = projectedDesiredStoppingDistancePixels - (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(lastVehicle.ActualSpeedMetresHour)));
                    
                    if (newVehicle.ProgressPixels + projectedDesiredStoppingDistancePixels >= backOfNextVehicle + stoppingDistanceChangeByChangingSpeedsPixels)
                    {
                        // The projected stopping distance of the new vehicle overlaps with the last vehicle on the lane

                        // Return that the attempt failed
                        return false;
                    }
                }
            }

            // Add the vehicle to the lane
            newVehicle.ParentLane = this;
            Vehicles.Add(newVehicle);

            // Return that the attempt to add the vehicle to the lane was successful
            return true;
        }

        /// <summary>
        /// Override the paint function for this usercontrol so I can paint the lanes and the vehicle
        /// </summary>
        /// <param name="pe">(Auto-generated) Event arguments containing the details of the event</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Paint the dotted white lines down both sides of the lane
            using (Pen whitePen = new Pen(Color.White, 1))
            {
                whitePen.DashPattern = new float[] { 15, 20 };
                pe.Graphics.DrawLine(whitePen, new Point(0, 0), new Point(Size.Width, 0));
                pe.Graphics.DrawLine(whitePen, new Point(0, Size.Height - 1), new Point(Size.Width, Size.Height - 1));
            }

            // Prepare the coloured pens, brushes, and font in order to paint the lane and the vehicles
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
            using (Font drawFont = new Font("Courier New", 8))
            {
                for (int vehicleIndex = 0; vehicleIndex < Vehicles.Count; vehicleIndex++)
                {
                    // For each vehicle on the lane
                    Vehicle vehicle = Vehicles[vehicleIndex];

                    // Calculate the length of the stopping distance for the actual speed of the vehicle
                    int stoppingDistanceLength = (int)Math.Round(MainForm.MetresToPixels(MainForm.StoppingDistance(vehicle.ActualSpeedMetresHour)), 0);
                    
                    if (vehicle.ProgressPixels + stoppingDistanceLength >= MainForm.HorizontalScroll.Value && vehicle.ProgressPixels - vehicle.VehicleLengthPixels < MainForm.HorizontalScroll.Value + MainForm.Width)
                    {
                        // The vehicle is within the viewport of the window

                        // Create a rectangle for stopping distance from the coordinates and dimensions
                        Rectangle safetyRect = new Rectangle(new Point(vehicle.ProgressPixels, MainForm.LaneMarginPixels), new Size(stoppingDistanceLength, vehicle.VehicleWidthPixels));
                        if (vehicle.IsTravellingAtDesiredSpeed)
                        {
                            // Vehicle is travelling at its desired speed

                            // Fill in the safety rectangle with yellow
                            pe.Graphics.FillRectangle(translucentYellowBrush, safetyRect);
                        }
                        else
                        {
                            // Vehicle is not travelling at its desired speed

                            // Fill in the safety rectangle with red
                            pe.Graphics.FillRectangle(translucentRedBrush, safetyRect);
                        }

                        // Draw a white rectangle around the safety rectangle
                        pe.Graphics.DrawRectangle(whitePen, safetyRect);
                        
                        // Create a rectangle for the vehicle from the coordinates and dimensions
                        Rectangle vehicleRect = new Rectangle(new Point(vehicle.ProgressPixels - vehicle.VehicleLengthPixels, MainForm.LaneMarginPixels), new Size(vehicle.VehicleLengthPixels, vehicle.VehicleWidthPixels));
                        switch (vehicle.VehicleType)
                        {
                            case VehicleTypes.Car:
                                // Vehicle is a car

                                // Fill in the vehicle rectangle with yellow
                                pe.Graphics.FillRectangle(yellowBrush, vehicleRect);
                                break;
                            case VehicleTypes.LGV:
                                // Vehicle is a LGV

                                // Fill in the vehicle rectangle with green
                                pe.Graphics.FillRectangle(greenBrush, vehicleRect);
                                break;
                            case VehicleTypes.HGV:
                                // Vehicle is a HGV

                                // Fill in the vehicle rectangle with red
                                pe.Graphics.FillRectangle(redBrush, vehicleRect);
                                break;
                            case VehicleTypes.Bus:
                                // Vehicle is a Bus

                                // Fill in the vehicle rectangle with blue
                                pe.Graphics.FillRectangle(blueBrush, vehicleRect);
                                break;
                        }

                        // Draw a black rectangle around the vehicle rectangle
                        pe.Graphics.DrawRectangle(blackPen, vehicleRect);
                        
                        // Print the vehicle ID in the vehicle rectangle
                        pe.Graphics.DrawString((vehicle.VehicleId+1).ToString().PadLeft(3, '0'), drawFont, blackBrush, vehicle.ProgressPixels - vehicle.VehicleLengthPixels, MainForm.LaneMarginPixels);
                    }
                }
            }
        }

        #endregion

    }
}
