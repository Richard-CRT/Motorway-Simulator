namespace MotorwaySimulator
{
    partial class MotorwaySimulatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FormTick = new System.Windows.Forms.Timer(this.components);
            this.Road = new System.Windows.Forms.Panel();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.TrackBarTimescale = new System.Windows.Forms.TrackBar();
            this.PanelSettings = new System.Windows.Forms.Panel();
            this.TabControlControlPanel = new System.Windows.Forms.TabControl();
            this.TabPageSetup = new System.Windows.Forms.TabPage();
            this.LabelDesiredSpeedVarUnit = new System.Windows.Forms.Label();
            this.LabelRoadLengthTitle = new System.Windows.Forms.Label();
            this.LabelDesiredSpeedUnitTitle = new System.Windows.Forms.Label();
            this.LabelRoadLength = new System.Windows.Forms.Label();
            this.LabelLengthVariationUnitTitle = new System.Windows.Forms.Label();
            this.NumericCarLength = new System.Windows.Forms.NumericUpDown();
            this.LabelLengthUnitTitle = new System.Windows.Forms.Label();
            this.NumericCarLengthVar = new System.Windows.Forms.NumericUpDown();
            this.LabelCarTitle = new System.Windows.Forms.Label();
            this.NumericCarDesiredSpeed = new System.Windows.Forms.NumericUpDown();
            this.LableBusTitle = new System.Windows.Forms.Label();
            this.NumericCarDesiredSpeedVar = new System.Windows.Forms.NumericUpDown();
            this.LabelHGVTitle = new System.Windows.Forms.Label();
            this.NumericLGVLength = new System.Windows.Forms.NumericUpDown();
            this.LabelLGVTitle = new System.Windows.Forms.Label();
            this.NumericLGVLengthVar = new System.Windows.Forms.NumericUpDown();
            this.TrackBarInterArrivalVariation = new System.Windows.Forms.TrackBar();
            this.NumericLGVDesiredSpeed = new System.Windows.Forms.NumericUpDown();
            this.LabelInterArrivalVariation = new System.Windows.Forms.Label();
            this.NumericLGVDesiredSpeedVar = new System.Windows.Forms.NumericUpDown();
            this.LabelInterArrivalVariationTitle = new System.Windows.Forms.Label();
            this.NumericHGVLength = new System.Windows.Forms.NumericUpDown();
            this.LabelInterArrivalTime = new System.Windows.Forms.Label();
            this.NumericHGVLengthVar = new System.Windows.Forms.NumericUpDown();
            this.TrackBarInterArrivalTime = new System.Windows.Forms.TrackBar();
            this.NumericHGVDesiredSpeed = new System.Windows.Forms.NumericUpDown();
            this.LabelInterArrivalTimeTitle = new System.Windows.Forms.Label();
            this.NumericHGVDesiredSpeedVar = new System.Windows.Forms.NumericUpDown();
            this.LabelDesiredSpeedVarTitle = new System.Windows.Forms.Label();
            this.NumericBusLength = new System.Windows.Forms.NumericUpDown();
            this.LabelDesiredSpeedTitle = new System.Windows.Forms.Label();
            this.NumericBusLengthVar = new System.Windows.Forms.NumericUpDown();
            this.LabelLengthVarTitle = new System.Windows.Forms.Label();
            this.NumericBusDesiredSpeed = new System.Windows.Forms.NumericUpDown();
            this.LabelLengthTitle = new System.Windows.Forms.Label();
            this.NumericBusDesiredSpeedVar = new System.Windows.Forms.NumericUpDown();
            this.TrackBarRoadLength = new System.Windows.Forms.TrackBar();
            this.TabPageSimulation = new System.Windows.Forms.TabPage();
            this.TreeViewVehicles = new System.Windows.Forms.TreeView();
            this.CheckBoxTrackVehicle = new System.Windows.Forms.CheckBox();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.NumericVehicleId = new System.Windows.Forms.NumericUpDown();
            this.ButtonStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTimescale)).BeginInit();
            this.PanelSettings.SuspendLayout();
            this.TabControlControlPanel.SuspendLayout();
            this.TabPageSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarLengthVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarDesiredSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarDesiredSpeedVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVLengthVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarInterArrivalVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVDesiredSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVDesiredSpeedVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVLengthVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarInterArrivalTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVDesiredSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVDesiredSpeedVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusLengthVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusDesiredSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusDesiredSpeedVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRoadLength)).BeginInit();
            this.TabPageSimulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericVehicleId)).BeginInit();
            this.SuspendLayout();
            // 
            // FormTick
            // 
            this.FormTick.Interval = 15;
            this.FormTick.Tick += new System.EventHandler(this.FormTick_Tick);
            // 
            // Road
            // 
            this.Road.BackColor = System.Drawing.SystemColors.Control;
            this.Road.Location = new System.Drawing.Point(12, 337);
            this.Road.Name = "Road";
            this.Road.Size = new System.Drawing.Size(100, 100);
            this.Road.TabIndex = 0;
            // 
            // ButtonPause
            // 
            this.ButtonPause.Enabled = false;
            this.ButtonPause.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonPause.Location = new System.Drawing.Point(75, 6);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(65, 35);
            this.ButtonPause.TabIndex = 2;
            this.ButtonPause.Text = "Pause";
            this.ButtonPause.UseVisualStyleBackColor = true;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // TrackBarTimescale
            // 
            this.TrackBarTimescale.LargeChange = 10;
            this.TrackBarTimescale.Location = new System.Drawing.Point(378, 31);
            this.TrackBarTimescale.Minimum = 1;
            this.TrackBarTimescale.Name = "TrackBarTimescale";
            this.TrackBarTimescale.Size = new System.Drawing.Size(120, 45);
            this.TrackBarTimescale.TabIndex = 4;
            this.TrackBarTimescale.Value = 10;
            this.TrackBarTimescale.Scroll += new System.EventHandler(this.TrackBarTimescale_Scroll);
            // 
            // PanelSettings
            // 
            this.PanelSettings.Controls.Add(this.TabControlControlPanel);
            this.PanelSettings.Location = new System.Drawing.Point(12, 12);
            this.PanelSettings.Name = "PanelSettings";
            this.PanelSettings.Size = new System.Drawing.Size(1332, 304);
            this.PanelSettings.TabIndex = 7;
            // 
            // TabControlControlPanel
            // 
            this.TabControlControlPanel.Controls.Add(this.TabPageSetup);
            this.TabControlControlPanel.Controls.Add(this.TabPageSimulation);
            this.TabControlControlPanel.Location = new System.Drawing.Point(3, 3);
            this.TabControlControlPanel.Name = "TabControlControlPanel";
            this.TabControlControlPanel.SelectedIndex = 0;
            this.TabControlControlPanel.Size = new System.Drawing.Size(937, 282);
            this.TabControlControlPanel.TabIndex = 52;
            // 
            // TabPageSetup
            // 
            this.TabPageSetup.BackColor = System.Drawing.Color.White;
            this.TabPageSetup.Controls.Add(this.LabelDesiredSpeedVarUnit);
            this.TabPageSetup.Controls.Add(this.LabelRoadLengthTitle);
            this.TabPageSetup.Controls.Add(this.LabelDesiredSpeedUnitTitle);
            this.TabPageSetup.Controls.Add(this.LabelRoadLength);
            this.TabPageSetup.Controls.Add(this.LabelLengthVariationUnitTitle);
            this.TabPageSetup.Controls.Add(this.NumericCarLength);
            this.TabPageSetup.Controls.Add(this.LabelLengthUnitTitle);
            this.TabPageSetup.Controls.Add(this.NumericCarLengthVar);
            this.TabPageSetup.Controls.Add(this.LabelCarTitle);
            this.TabPageSetup.Controls.Add(this.NumericCarDesiredSpeed);
            this.TabPageSetup.Controls.Add(this.LableBusTitle);
            this.TabPageSetup.Controls.Add(this.NumericCarDesiredSpeedVar);
            this.TabPageSetup.Controls.Add(this.LabelHGVTitle);
            this.TabPageSetup.Controls.Add(this.NumericLGVLength);
            this.TabPageSetup.Controls.Add(this.LabelLGVTitle);
            this.TabPageSetup.Controls.Add(this.NumericLGVLengthVar);
            this.TabPageSetup.Controls.Add(this.TrackBarInterArrivalVariation);
            this.TabPageSetup.Controls.Add(this.NumericLGVDesiredSpeed);
            this.TabPageSetup.Controls.Add(this.LabelInterArrivalVariation);
            this.TabPageSetup.Controls.Add(this.NumericLGVDesiredSpeedVar);
            this.TabPageSetup.Controls.Add(this.LabelInterArrivalVariationTitle);
            this.TabPageSetup.Controls.Add(this.NumericHGVLength);
            this.TabPageSetup.Controls.Add(this.LabelInterArrivalTime);
            this.TabPageSetup.Controls.Add(this.NumericHGVLengthVar);
            this.TabPageSetup.Controls.Add(this.TrackBarInterArrivalTime);
            this.TabPageSetup.Controls.Add(this.NumericHGVDesiredSpeed);
            this.TabPageSetup.Controls.Add(this.LabelInterArrivalTimeTitle);
            this.TabPageSetup.Controls.Add(this.NumericHGVDesiredSpeedVar);
            this.TabPageSetup.Controls.Add(this.LabelDesiredSpeedVarTitle);
            this.TabPageSetup.Controls.Add(this.NumericBusLength);
            this.TabPageSetup.Controls.Add(this.LabelDesiredSpeedTitle);
            this.TabPageSetup.Controls.Add(this.NumericBusLengthVar);
            this.TabPageSetup.Controls.Add(this.LabelLengthVarTitle);
            this.TabPageSetup.Controls.Add(this.NumericBusDesiredSpeed);
            this.TabPageSetup.Controls.Add(this.LabelLengthTitle);
            this.TabPageSetup.Controls.Add(this.NumericBusDesiredSpeedVar);
            this.TabPageSetup.Controls.Add(this.TrackBarRoadLength);
            this.TabPageSetup.Location = new System.Drawing.Point(4, 22);
            this.TabPageSetup.Name = "TabPageSetup";
            this.TabPageSetup.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSetup.Size = new System.Drawing.Size(929, 256);
            this.TabPageSetup.TabIndex = 0;
            this.TabPageSetup.Text = "Setup";
            // 
            // LabelDesiredSpeedVarUnit
            // 
            this.LabelDesiredSpeedVarUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelDesiredSpeedVarUnit.Location = new System.Drawing.Point(490, 214);
            this.LabelDesiredSpeedVarUnit.Name = "LabelDesiredSpeedVarUnit";
            this.LabelDesiredSpeedVarUnit.Size = new System.Drawing.Size(40, 20);
            this.LabelDesiredSpeedVarUnit.TabIndex = 50;
            this.LabelDesiredSpeedVarUnit.Text = "kph";
            this.LabelDesiredSpeedVarUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelRoadLengthTitle
            // 
            this.LabelRoadLengthTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelRoadLengthTitle.Location = new System.Drawing.Point(10, 13);
            this.LabelRoadLengthTitle.Name = "LabelRoadLengthTitle";
            this.LabelRoadLengthTitle.Size = new System.Drawing.Size(196, 28);
            this.LabelRoadLengthTitle.TabIndex = 44;
            this.LabelRoadLengthTitle.Text = "Road Length";
            this.LabelRoadLengthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelDesiredSpeedUnitTitle
            // 
            this.LabelDesiredSpeedUnitTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelDesiredSpeedUnitTitle.Location = new System.Drawing.Point(490, 188);
            this.LabelDesiredSpeedUnitTitle.Name = "LabelDesiredSpeedUnitTitle";
            this.LabelDesiredSpeedUnitTitle.Size = new System.Drawing.Size(40, 20);
            this.LabelDesiredSpeedUnitTitle.TabIndex = 49;
            this.LabelDesiredSpeedUnitTitle.Text = "kph";
            this.LabelDesiredSpeedUnitTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelRoadLength
            // 
            this.LabelRoadLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRoadLength.Location = new System.Drawing.Point(205, 13);
            this.LabelRoadLength.Name = "LabelRoadLength";
            this.LabelRoadLength.Size = new System.Drawing.Size(60, 28);
            this.LabelRoadLength.TabIndex = 46;
            this.LabelRoadLength.Text = "0 km";
            this.LabelRoadLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelLengthVariationUnitTitle
            // 
            this.LabelLengthVariationUnitTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLengthVariationUnitTitle.Location = new System.Drawing.Point(490, 162);
            this.LabelLengthVariationUnitTitle.Name = "LabelLengthVariationUnitTitle";
            this.LabelLengthVariationUnitTitle.Size = new System.Drawing.Size(40, 20);
            this.LabelLengthVariationUnitTitle.TabIndex = 48;
            this.LabelLengthVariationUnitTitle.Text = "m";
            this.LabelLengthVariationUnitTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumericCarLength
            // 
            this.NumericCarLength.DecimalPlaces = 1;
            this.NumericCarLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericCarLength.Location = new System.Drawing.Point(215, 136);
            this.NumericCarLength.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericCarLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericCarLength.Name = "NumericCarLength";
            this.NumericCarLength.Size = new System.Drawing.Size(61, 20);
            this.NumericCarLength.TabIndex = 9;
            this.NumericCarLength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // LabelLengthUnitTitle
            // 
            this.LabelLengthUnitTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLengthUnitTitle.Location = new System.Drawing.Point(490, 136);
            this.LabelLengthUnitTitle.Name = "LabelLengthUnitTitle";
            this.LabelLengthUnitTitle.Size = new System.Drawing.Size(40, 20);
            this.LabelLengthUnitTitle.TabIndex = 47;
            this.LabelLengthUnitTitle.Text = "m";
            this.LabelLengthUnitTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumericCarLengthVar
            // 
            this.NumericCarLengthVar.DecimalPlaces = 1;
            this.NumericCarLengthVar.Location = new System.Drawing.Point(215, 162);
            this.NumericCarLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericCarLengthVar.Name = "NumericCarLengthVar";
            this.NumericCarLengthVar.Size = new System.Drawing.Size(61, 20);
            this.NumericCarLengthVar.TabIndex = 10;
            this.NumericCarLengthVar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelCarTitle
            // 
            this.LabelCarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCarTitle.Location = new System.Drawing.Point(211, 110);
            this.LabelCarTitle.Name = "LabelCarTitle";
            this.LabelCarTitle.Size = new System.Drawing.Size(65, 23);
            this.LabelCarTitle.TabIndex = 8;
            this.LabelCarTitle.Text = "Car";
            this.LabelCarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumericCarDesiredSpeed
            // 
            this.NumericCarDesiredSpeed.Location = new System.Drawing.Point(215, 188);
            this.NumericCarDesiredSpeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NumericCarDesiredSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericCarDesiredSpeed.Name = "NumericCarDesiredSpeed";
            this.NumericCarDesiredSpeed.Size = new System.Drawing.Size(61, 20);
            this.NumericCarDesiredSpeed.TabIndex = 11;
            this.NumericCarDesiredSpeed.Value = new decimal(new int[] {
            112,
            0,
            0,
            0});
            // 
            // LableBusTitle
            // 
            this.LableBusTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LableBusTitle.Location = new System.Drawing.Point(424, 110);
            this.LableBusTitle.Name = "LableBusTitle";
            this.LableBusTitle.Size = new System.Drawing.Size(65, 23);
            this.LableBusTitle.TabIndex = 25;
            this.LableBusTitle.Text = "Bus";
            this.LableBusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumericCarDesiredSpeedVar
            // 
            this.NumericCarDesiredSpeedVar.Location = new System.Drawing.Point(215, 214);
            this.NumericCarDesiredSpeedVar.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumericCarDesiredSpeedVar.Name = "NumericCarDesiredSpeedVar";
            this.NumericCarDesiredSpeedVar.Size = new System.Drawing.Size(61, 20);
            this.NumericCarDesiredSpeedVar.TabIndex = 12;
            this.NumericCarDesiredSpeedVar.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // LabelHGVTitle
            // 
            this.LabelHGVTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelHGVTitle.Location = new System.Drawing.Point(353, 110);
            this.LabelHGVTitle.Name = "LabelHGVTitle";
            this.LabelHGVTitle.Size = new System.Drawing.Size(65, 23);
            this.LabelHGVTitle.TabIndex = 20;
            this.LabelHGVTitle.Text = "HGV";
            this.LabelHGVTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumericLGVLength
            // 
            this.NumericLGVLength.DecimalPlaces = 1;
            this.NumericLGVLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericLGVLength.Location = new System.Drawing.Point(286, 136);
            this.NumericLGVLength.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericLGVLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericLGVLength.Name = "NumericLGVLength";
            this.NumericLGVLength.Size = new System.Drawing.Size(61, 20);
            this.NumericLGVLength.TabIndex = 16;
            this.NumericLGVLength.Value = new decimal(new int[] {
            55,
            0,
            0,
            65536});
            // 
            // LabelLGVTitle
            // 
            this.LabelLGVTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLGVTitle.Location = new System.Drawing.Point(282, 110);
            this.LabelLGVTitle.Name = "LabelLGVTitle";
            this.LabelLGVTitle.Size = new System.Drawing.Size(65, 23);
            this.LabelLGVTitle.TabIndex = 15;
            this.LabelLGVTitle.Text = "LGV";
            this.LabelLGVTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumericLGVLengthVar
            // 
            this.NumericLGVLengthVar.DecimalPlaces = 1;
            this.NumericLGVLengthVar.Location = new System.Drawing.Point(286, 162);
            this.NumericLGVLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericLGVLengthVar.Name = "NumericLGVLengthVar";
            this.NumericLGVLengthVar.Size = new System.Drawing.Size(61, 20);
            this.NumericLGVLengthVar.TabIndex = 17;
            this.NumericLGVLengthVar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TrackBarInterArrivalVariation
            // 
            this.TrackBarInterArrivalVariation.LargeChange = 1000;
            this.TrackBarInterArrivalVariation.Location = new System.Drawing.Point(261, 73);
            this.TrackBarInterArrivalVariation.Maximum = 1000;
            this.TrackBarInterArrivalVariation.Name = "TrackBarInterArrivalVariation";
            this.TrackBarInterArrivalVariation.Size = new System.Drawing.Size(228, 45);
            this.TrackBarInterArrivalVariation.SmallChange = 100;
            this.TrackBarInterArrivalVariation.TabIndex = 43;
            this.TrackBarInterArrivalVariation.TickFrequency = 50;
            this.TrackBarInterArrivalVariation.Value = 500;
            this.TrackBarInterArrivalVariation.Scroll += new System.EventHandler(this.TrackBarInterArrivalVariation_Scroll);
            // 
            // NumericLGVDesiredSpeed
            // 
            this.NumericLGVDesiredSpeed.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeed.Location = new System.Drawing.Point(286, 188);
            this.NumericLGVDesiredSpeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeed.Name = "NumericLGVDesiredSpeed";
            this.NumericLGVDesiredSpeed.Size = new System.Drawing.Size(61, 20);
            this.NumericLGVDesiredSpeed.TabIndex = 18;
            this.NumericLGVDesiredSpeed.Value = new decimal(new int[] {
            112,
            0,
            0,
            0});
            // 
            // LabelInterArrivalVariation
            // 
            this.LabelInterArrivalVariation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInterArrivalVariation.Location = new System.Drawing.Point(207, 73);
            this.LabelInterArrivalVariation.Name = "LabelInterArrivalVariation";
            this.LabelInterArrivalVariation.Size = new System.Drawing.Size(53, 28);
            this.LabelInterArrivalVariation.TabIndex = 42;
            this.LabelInterArrivalVariation.Text = "0%";
            this.LabelInterArrivalVariation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericLGVDesiredSpeedVar
            // 
            this.NumericLGVDesiredSpeedVar.Location = new System.Drawing.Point(286, 214);
            this.NumericLGVDesiredSpeedVar.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeedVar.Name = "NumericLGVDesiredSpeedVar";
            this.NumericLGVDesiredSpeedVar.Size = new System.Drawing.Size(61, 20);
            this.NumericLGVDesiredSpeedVar.TabIndex = 19;
            this.NumericLGVDesiredSpeedVar.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // LabelInterArrivalVariationTitle
            // 
            this.LabelInterArrivalVariationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelInterArrivalVariationTitle.Location = new System.Drawing.Point(6, 73);
            this.LabelInterArrivalVariationTitle.Name = "LabelInterArrivalVariationTitle";
            this.LabelInterArrivalVariationTitle.Size = new System.Drawing.Size(200, 28);
            this.LabelInterArrivalVariationTitle.TabIndex = 41;
            this.LabelInterArrivalVariationTitle.Text = "Interarrival Variation (±)";
            this.LabelInterArrivalVariationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericHGVLength
            // 
            this.NumericHGVLength.DecimalPlaces = 1;
            this.NumericHGVLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericHGVLength.Location = new System.Drawing.Point(357, 136);
            this.NumericHGVLength.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericHGVLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericHGVLength.Name = "NumericHGVLength";
            this.NumericHGVLength.Size = new System.Drawing.Size(61, 20);
            this.NumericHGVLength.TabIndex = 21;
            this.NumericHGVLength.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // LabelInterArrivalTime
            // 
            this.LabelInterArrivalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInterArrivalTime.Location = new System.Drawing.Point(212, 43);
            this.LabelInterArrivalTime.Name = "LabelInterArrivalTime";
            this.LabelInterArrivalTime.Size = new System.Drawing.Size(43, 28);
            this.LabelInterArrivalTime.TabIndex = 40;
            this.LabelInterArrivalTime.Text = "0s";
            this.LabelInterArrivalTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericHGVLengthVar
            // 
            this.NumericHGVLengthVar.DecimalPlaces = 1;
            this.NumericHGVLengthVar.Location = new System.Drawing.Point(357, 162);
            this.NumericHGVLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericHGVLengthVar.Name = "NumericHGVLengthVar";
            this.NumericHGVLengthVar.Size = new System.Drawing.Size(61, 20);
            this.NumericHGVLengthVar.TabIndex = 22;
            this.NumericHGVLengthVar.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // TrackBarInterArrivalTime
            // 
            this.TrackBarInterArrivalTime.LargeChange = 10;
            this.TrackBarInterArrivalTime.Location = new System.Drawing.Point(261, 45);
            this.TrackBarInterArrivalTime.Maximum = 1000;
            this.TrackBarInterArrivalTime.Minimum = 1;
            this.TrackBarInterArrivalTime.Name = "TrackBarInterArrivalTime";
            this.TrackBarInterArrivalTime.Size = new System.Drawing.Size(228, 45);
            this.TrackBarInterArrivalTime.TabIndex = 39;
            this.TrackBarInterArrivalTime.TickFrequency = 50;
            this.TrackBarInterArrivalTime.Value = 5;
            this.TrackBarInterArrivalTime.Scroll += new System.EventHandler(this.TrackBarInterArrivalTime_Scroll);
            // 
            // NumericHGVDesiredSpeed
            // 
            this.NumericHGVDesiredSpeed.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeed.Location = new System.Drawing.Point(357, 188);
            this.NumericHGVDesiredSpeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeed.Name = "NumericHGVDesiredSpeed";
            this.NumericHGVDesiredSpeed.Size = new System.Drawing.Size(61, 20);
            this.NumericHGVDesiredSpeed.TabIndex = 23;
            this.NumericHGVDesiredSpeed.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // LabelInterArrivalTimeTitle
            // 
            this.LabelInterArrivalTimeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelInterArrivalTimeTitle.Location = new System.Drawing.Point(10, 43);
            this.LabelInterArrivalTimeTitle.Name = "LabelInterArrivalTimeTitle";
            this.LabelInterArrivalTimeTitle.Size = new System.Drawing.Size(196, 28);
            this.LabelInterArrivalTimeTitle.TabIndex = 37;
            this.LabelInterArrivalTimeTitle.Text = "Interarrival Time Base";
            this.LabelInterArrivalTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericHGVDesiredSpeedVar
            // 
            this.NumericHGVDesiredSpeedVar.Location = new System.Drawing.Point(357, 214);
            this.NumericHGVDesiredSpeedVar.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeedVar.Name = "NumericHGVDesiredSpeedVar";
            this.NumericHGVDesiredSpeedVar.Size = new System.Drawing.Size(61, 20);
            this.NumericHGVDesiredSpeedVar.TabIndex = 24;
            this.NumericHGVDesiredSpeedVar.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // LabelDesiredSpeedVarTitle
            // 
            this.LabelDesiredSpeedVarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelDesiredSpeedVarTitle.Location = new System.Drawing.Point(37, 214);
            this.LabelDesiredSpeedVarTitle.Name = "LabelDesiredSpeedVarTitle";
            this.LabelDesiredSpeedVarTitle.Size = new System.Drawing.Size(169, 20);
            this.LabelDesiredSpeedVarTitle.TabIndex = 36;
            this.LabelDesiredSpeedVarTitle.Text = "Speed Variation (±)";
            this.LabelDesiredSpeedVarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericBusLength
            // 
            this.NumericBusLength.DecimalPlaces = 1;
            this.NumericBusLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericBusLength.Location = new System.Drawing.Point(428, 136);
            this.NumericBusLength.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericBusLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericBusLength.Name = "NumericBusLength";
            this.NumericBusLength.Size = new System.Drawing.Size(61, 20);
            this.NumericBusLength.TabIndex = 26;
            this.NumericBusLength.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // LabelDesiredSpeedTitle
            // 
            this.LabelDesiredSpeedTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelDesiredSpeedTitle.Location = new System.Drawing.Point(37, 188);
            this.LabelDesiredSpeedTitle.Name = "LabelDesiredSpeedTitle";
            this.LabelDesiredSpeedTitle.Size = new System.Drawing.Size(169, 20);
            this.LabelDesiredSpeedTitle.TabIndex = 35;
            this.LabelDesiredSpeedTitle.Text = "Speed Base";
            this.LabelDesiredSpeedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericBusLengthVar
            // 
            this.NumericBusLengthVar.DecimalPlaces = 1;
            this.NumericBusLengthVar.Location = new System.Drawing.Point(428, 162);
            this.NumericBusLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericBusLengthVar.Name = "NumericBusLengthVar";
            this.NumericBusLengthVar.Size = new System.Drawing.Size(61, 20);
            this.NumericBusLengthVar.TabIndex = 27;
            this.NumericBusLengthVar.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LabelLengthVarTitle
            // 
            this.LabelLengthVarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLengthVarTitle.Location = new System.Drawing.Point(37, 162);
            this.LabelLengthVarTitle.Name = "LabelLengthVarTitle";
            this.LabelLengthVarTitle.Size = new System.Drawing.Size(169, 20);
            this.LabelLengthVarTitle.TabIndex = 34;
            this.LabelLengthVarTitle.Text = "Length Variation (±)";
            this.LabelLengthVarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericBusDesiredSpeed
            // 
            this.NumericBusDesiredSpeed.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericBusDesiredSpeed.Location = new System.Drawing.Point(428, 188);
            this.NumericBusDesiredSpeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NumericBusDesiredSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericBusDesiredSpeed.Name = "NumericBusDesiredSpeed";
            this.NumericBusDesiredSpeed.Size = new System.Drawing.Size(61, 20);
            this.NumericBusDesiredSpeed.TabIndex = 28;
            this.NumericBusDesiredSpeed.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // LabelLengthTitle
            // 
            this.LabelLengthTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLengthTitle.Location = new System.Drawing.Point(37, 136);
            this.LabelLengthTitle.Name = "LabelLengthTitle";
            this.LabelLengthTitle.Size = new System.Drawing.Size(169, 20);
            this.LabelLengthTitle.TabIndex = 33;
            this.LabelLengthTitle.Text = "Length Base";
            this.LabelLengthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericBusDesiredSpeedVar
            // 
            this.NumericBusDesiredSpeedVar.Location = new System.Drawing.Point(428, 214);
            this.NumericBusDesiredSpeedVar.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumericBusDesiredSpeedVar.Name = "NumericBusDesiredSpeedVar";
            this.NumericBusDesiredSpeedVar.Size = new System.Drawing.Size(61, 20);
            this.NumericBusDesiredSpeedVar.TabIndex = 29;
            this.NumericBusDesiredSpeedVar.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // TrackBarRoadLength
            // 
            this.TrackBarRoadLength.LargeChange = 100;
            this.TrackBarRoadLength.Location = new System.Drawing.Point(261, 14);
            this.TrackBarRoadLength.Maximum = 5000;
            this.TrackBarRoadLength.Minimum = 10;
            this.TrackBarRoadLength.Name = "TrackBarRoadLength";
            this.TrackBarRoadLength.Size = new System.Drawing.Size(228, 45);
            this.TrackBarRoadLength.SmallChange = 10;
            this.TrackBarRoadLength.TabIndex = 45;
            this.TrackBarRoadLength.TickFrequency = 250;
            this.TrackBarRoadLength.Value = 100;
            this.TrackBarRoadLength.Scroll += new System.EventHandler(this.TrackBarRoadLength_Scroll);
            // 
            // TabPageSimulation
            // 
            this.TabPageSimulation.BackColor = System.Drawing.Color.White;
            this.TabPageSimulation.Controls.Add(this.TreeViewVehicles);
            this.TabPageSimulation.Controls.Add(this.CheckBoxTrackVehicle);
            this.TabPageSimulation.Controls.Add(this.ButtonStart);
            this.TabPageSimulation.Controls.Add(this.NumericVehicleId);
            this.TabPageSimulation.Controls.Add(this.ButtonStop);
            this.TabPageSimulation.Controls.Add(this.TrackBarTimescale);
            this.TabPageSimulation.Controls.Add(this.ButtonPause);
            this.TabPageSimulation.Location = new System.Drawing.Point(4, 22);
            this.TabPageSimulation.Name = "TabPageSimulation";
            this.TabPageSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSimulation.Size = new System.Drawing.Size(929, 256);
            this.TabPageSimulation.TabIndex = 1;
            this.TabPageSimulation.Text = "Simulation";
            // 
            // TreeViewVehicles
            // 
            this.TreeViewVehicles.Location = new System.Drawing.Point(620, 3);
            this.TreeViewVehicles.Name = "TreeViewVehicles";
            this.TreeViewVehicles.Size = new System.Drawing.Size(185, 244);
            this.TreeViewVehicles.TabIndex = 8;
            this.TreeViewVehicles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNodeVehicleSelected);
            // 
            // CheckBoxTrackVehicle
            // 
            this.CheckBoxTrackVehicle.AutoSize = true;
            this.CheckBoxTrackVehicle.Location = new System.Drawing.Point(378, 124);
            this.CheckBoxTrackVehicle.Name = "CheckBoxTrackVehicle";
            this.CheckBoxTrackVehicle.Size = new System.Drawing.Size(54, 17);
            this.CheckBoxTrackVehicle.TabIndex = 32;
            this.CheckBoxTrackVehicle.Text = "Track";
            this.CheckBoxTrackVehicle.UseVisualStyleBackColor = true;
            // 
            // ButtonStart
            // 
            this.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonStart.Location = new System.Drawing.Point(6, 6);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(65, 35);
            this.ButtonStart.TabIndex = 13;
            this.ButtonStart.Text = "Play";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // NumericVehicleId
            // 
            this.NumericVehicleId.Location = new System.Drawing.Point(395, 82);
            this.NumericVehicleId.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.NumericVehicleId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericVehicleId.Name = "NumericVehicleId";
            this.NumericVehicleId.Size = new System.Drawing.Size(120, 20);
            this.NumericVehicleId.TabIndex = 30;
            this.NumericVehicleId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ButtonStop
            // 
            this.ButtonStop.Enabled = false;
            this.ButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonStop.Location = new System.Drawing.Point(146, 6);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(65, 35);
            this.ButtonStop.TabIndex = 14;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // MotorwaySimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1268, 681);
            this.Controls.Add(this.Road);
            this.Controls.Add(this.PanelSettings);
            this.Name = "MotorwaySimulatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Motorway Simulator";
            this.Load += new System.EventHandler(this.MotorwaySimulator_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FormScrolled);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTimescale)).EndInit();
            this.PanelSettings.ResumeLayout(false);
            this.TabControlControlPanel.ResumeLayout(false);
            this.TabPageSetup.ResumeLayout(false);
            this.TabPageSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarLengthVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarDesiredSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarDesiredSpeedVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVLengthVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarInterArrivalVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVDesiredSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVDesiredSpeedVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVLengthVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarInterArrivalTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVDesiredSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVDesiredSpeedVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusLengthVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusDesiredSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusDesiredSpeedVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRoadLength)).EndInit();
            this.TabPageSimulation.ResumeLayout(false);
            this.TabPageSimulation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericVehicleId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer FormTick;
        private System.Windows.Forms.Panel Road;
        private System.Windows.Forms.Button ButtonPause;
        private System.Windows.Forms.TrackBar TrackBarTimescale;
        private System.Windows.Forms.Panel PanelSettings;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonStop;
        public System.Windows.Forms.NumericUpDown NumericVehicleId;
        public System.Windows.Forms.CheckBox CheckBoxTrackVehicle;
        private System.Windows.Forms.TreeView TreeViewVehicles;
        private System.Windows.Forms.TabControl TabControlControlPanel;
        private System.Windows.Forms.TabPage TabPageSimulation;
        private System.Windows.Forms.TabPage TabPageSetup;
        private System.Windows.Forms.TrackBar TrackBarRoadLength;
        private System.Windows.Forms.Label LabelDesiredSpeedVarUnit;
        private System.Windows.Forms.Label LabelRoadLengthTitle;
        private System.Windows.Forms.Label LabelDesiredSpeedUnitTitle;
        private System.Windows.Forms.Label LabelRoadLength;
        private System.Windows.Forms.Label LabelLengthVariationUnitTitle;
        private System.Windows.Forms.NumericUpDown NumericCarLength;
        private System.Windows.Forms.Label LabelLengthUnitTitle;
        private System.Windows.Forms.NumericUpDown NumericCarLengthVar;
        private System.Windows.Forms.Label LabelCarTitle;
        private System.Windows.Forms.NumericUpDown NumericCarDesiredSpeed;
        private System.Windows.Forms.Label LableBusTitle;
        private System.Windows.Forms.NumericUpDown NumericCarDesiredSpeedVar;
        private System.Windows.Forms.Label LabelHGVTitle;
        private System.Windows.Forms.NumericUpDown NumericLGVLength;
        private System.Windows.Forms.Label LabelLGVTitle;
        private System.Windows.Forms.NumericUpDown NumericLGVLengthVar;
        private System.Windows.Forms.TrackBar TrackBarInterArrivalVariation;
        private System.Windows.Forms.NumericUpDown NumericLGVDesiredSpeed;
        private System.Windows.Forms.Label LabelInterArrivalVariation;
        private System.Windows.Forms.NumericUpDown NumericLGVDesiredSpeedVar;
        private System.Windows.Forms.Label LabelInterArrivalVariationTitle;
        private System.Windows.Forms.NumericUpDown NumericHGVLength;
        private System.Windows.Forms.Label LabelInterArrivalTime;
        private System.Windows.Forms.NumericUpDown NumericHGVLengthVar;
        private System.Windows.Forms.TrackBar TrackBarInterArrivalTime;
        private System.Windows.Forms.NumericUpDown NumericHGVDesiredSpeed;
        private System.Windows.Forms.Label LabelInterArrivalTimeTitle;
        private System.Windows.Forms.NumericUpDown NumericHGVDesiredSpeedVar;
        private System.Windows.Forms.Label LabelDesiredSpeedVarTitle;
        private System.Windows.Forms.NumericUpDown NumericBusLength;
        private System.Windows.Forms.Label LabelDesiredSpeedTitle;
        private System.Windows.Forms.NumericUpDown NumericBusLengthVar;
        private System.Windows.Forms.Label LabelLengthVarTitle;
        private System.Windows.Forms.NumericUpDown NumericBusDesiredSpeed;
        private System.Windows.Forms.Label LabelLengthTitle;
        private System.Windows.Forms.NumericUpDown NumericBusDesiredSpeedVar;
    }
}

