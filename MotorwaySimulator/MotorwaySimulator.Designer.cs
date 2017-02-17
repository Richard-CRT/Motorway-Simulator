﻿namespace MotorwaySimulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotorwaySimulatorForm));
            this.FormTick = new System.Windows.Forms.Timer(this.components);
            this.Road = new System.Windows.Forms.Panel();
            this.TrackBarTimescale = new System.Windows.Forms.TrackBar();
            this.PanelSettings = new System.Windows.Forms.Panel();
            this.LabelTimeScale = new System.Windows.Forms.Label();
            this.LabelTimescaleTitle = new System.Windows.Forms.Label();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.TabControlControlPanel = new System.Windows.Forms.TabControl();
            this.TabPageSetup = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NumericMildCongestion = new System.Windows.Forms.NumericUpDown();
            this.NumericSevereCongestion = new System.Windows.Forms.NumericUpDown();
            this.LabelCongestionTitle = new System.Windows.Forms.Label();
            this.LabelMaximumLaneUnitTitle = new System.Windows.Forms.Label();
            this.NumericCarMaximumLane = new System.Windows.Forms.NumericUpDown();
            this.NumericLGVMaximumLane = new System.Windows.Forms.NumericUpDown();
            this.NumericHGVMaximumLane = new System.Windows.Forms.NumericUpDown();
            this.LabelMaximumLaneTitle = new System.Windows.Forms.Label();
            this.NumericBusMaximumLane = new System.Windows.Forms.NumericUpDown();
            this.LabelSpawnProbabilityUnassigned = new System.Windows.Forms.Label();
            this.LabelSpawnProbabilityUnitTitle = new System.Windows.Forms.Label();
            this.NumericCarSpawnProbability = new System.Windows.Forms.NumericUpDown();
            this.NumericLGVSpawnProbability = new System.Windows.Forms.NumericUpDown();
            this.NumericHGVSpawnProbability = new System.Windows.Forms.NumericUpDown();
            this.LabelSpawnProbabilityTitle = new System.Windows.Forms.Label();
            this.NumericBusSpawnProbability = new System.Windows.Forms.NumericUpDown();
            this.LabelLaneCount = new System.Windows.Forms.Label();
            this.TrackBarLaneCount = new System.Windows.Forms.TrackBar();
            this.LabelLaneCountTitle = new System.Windows.Forms.Label();
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
            this.LabelAllVehiclesTotalSeverelyCongested = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalSeverelyCongestedTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalMildlyCongested = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalMildlyCongestedTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalNotCongested = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalNotCongestedTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesSeverelyCongestedPercent = new System.Windows.Forms.Label();
            this.LabelAllVehiclesSeverelyCongestedPercentTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesMildlyCongestedPercent = new System.Windows.Forms.Label();
            this.LabelAllVehiclesMildlyCongestedPercentTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesNotCongestedPercent = new System.Windows.Forms.Label();
            this.LabelAllVehiclesNotCongestedPercentTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesBusPercent = new System.Windows.Forms.Label();
            this.LabelAllVehiclesBusPercentTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesHGVPercent = new System.Windows.Forms.Label();
            this.LabelAllVehiclesHGVPercentTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalVehicles = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalVehiclesTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalLGV = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalLGVTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesLGVPercent = new System.Windows.Forms.Label();
            this.LabelAllVehiclesLGVPercentTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalHGV = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalHGVTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalCar = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalCarTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesFailedSpawnsPercent = new System.Windows.Forms.Label();
            this.LabelAllVehiclesFailedSpawnsPercentTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesSuccessfulSpawnsPercent = new System.Windows.Forms.Label();
            this.LabelAllVehiclesSuccessfulSpawnsPercentTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesCarPercent = new System.Windows.Forms.Label();
            this.LabelAllVehiclesCarPercentTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalBus = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalBusTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalFailedSpawns = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalFailedSpawnsTitle = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalSuccessfulSpawns = new System.Windows.Forms.Label();
            this.LabelAllVehiclesTotalSuccessfulSpawnsTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonFindVehicle = new System.Windows.Forms.Button();
            this.LabelVehicleCongestion = new System.Windows.Forms.Label();
            this.LabelVehicleCongestionTitle = new System.Windows.Forms.Label();
            this.LabelVehicleID = new System.Windows.Forms.Label();
            this.LabelVehicleIDTitle = new System.Windows.Forms.Label();
            this.LabelVehicleLifetime = new System.Windows.Forms.Label();
            this.LabelVehicleLifetimeTitle = new System.Windows.Forms.Label();
            this.LabelVehicleAverageSpeed = new System.Windows.Forms.Label();
            this.LabelVehicleAverageSpeedTitle = new System.Windows.Forms.Label();
            this.LabelVehicleProgress = new System.Windows.Forms.Label();
            this.LabelVehicleProgressTitle = new System.Windows.Forms.Label();
            this.LabelVehicleDespawnTime = new System.Windows.Forms.Label();
            this.LabelVehicleDespawnTimeTitle = new System.Windows.Forms.Label();
            this.LabelVehicleSpawnTime = new System.Windows.Forms.Label();
            this.LabelVehicleSpawnTimeTitle = new System.Windows.Forms.Label();
            this.LabelVehicleSuccessfulSpawn = new System.Windows.Forms.Label();
            this.LabelVehicleSuccessfulSpawnTitle = new System.Windows.Forms.Label();
            this.LabelVehicleActualSpeed = new System.Windows.Forms.Label();
            this.LabelVehicleActualSpeedTitle = new System.Windows.Forms.Label();
            this.LabelVehicleDesiredSpeed = new System.Windows.Forms.Label();
            this.LabelVehicleDesiredSpeedTitle = new System.Windows.Forms.Label();
            this.LabelVehicleLength = new System.Windows.Forms.Label();
            this.LabelVehicleLengthTitle = new System.Windows.Forms.Label();
            this.LabelVehicleType = new System.Windows.Forms.Label();
            this.LabelVehicleTypeTitle = new System.Windows.Forms.Label();
            this.LableVehicleDataTitle = new System.Windows.Forms.Label();
            this.LabelFinishedVehiclesTitle = new System.Windows.Forms.Label();
            this.TreeViewFinishedVehicles = new System.Windows.Forms.TreeView();
            this.LabelVehiclesTitle = new System.Windows.Forms.Label();
            this.TreeViewVehicles = new System.Windows.Forms.TreeView();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTimescale)).BeginInit();
            this.PanelSettings.SuspendLayout();
            this.TabControlControlPanel.SuspendLayout();
            this.TabPageSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericMildCongestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericSevereCongestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarMaximumLane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVMaximumLane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVMaximumLane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusMaximumLane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarSpawnProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVSpawnProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVSpawnProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusSpawnProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarLaneCount)).BeginInit();
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
            this.Road.Location = new System.Drawing.Point(0, 473);
            this.Road.Name = "Road";
            this.Road.Size = new System.Drawing.Size(10, 10);
            this.Road.TabIndex = 0;
            this.Road.Visible = false;
            // 
            // TrackBarTimescale
            // 
            this.TrackBarTimescale.LargeChange = 10;
            this.TrackBarTimescale.Location = new System.Drawing.Point(306, 12);
            this.TrackBarTimescale.Maximum = 100;
            this.TrackBarTimescale.Minimum = 1;
            this.TrackBarTimescale.Name = "TrackBarTimescale";
            this.TrackBarTimescale.Size = new System.Drawing.Size(831, 45);
            this.TrackBarTimescale.TabIndex = 3;
            this.TrackBarTimescale.Value = 100;
            this.TrackBarTimescale.Scroll += new System.EventHandler(this.UpdateTimescale);
            // 
            // PanelSettings
            // 
            this.PanelSettings.Controls.Add(this.LabelTimeScale);
            this.PanelSettings.Controls.Add(this.LabelTimescaleTitle);
            this.PanelSettings.Controls.Add(this.ButtonPause);
            this.PanelSettings.Controls.Add(this.TabControlControlPanel);
            this.PanelSettings.Controls.Add(this.TrackBarTimescale);
            this.PanelSettings.Controls.Add(this.ButtonStop);
            this.PanelSettings.Controls.Add(this.ButtonStart);
            this.PanelSettings.Location = new System.Drawing.Point(11, 12);
            this.PanelSettings.Name = "PanelSettings";
            this.PanelSettings.Size = new System.Drawing.Size(1143, 451);
            this.PanelSettings.TabIndex = 7;
            // 
            // LabelTimeScale
            // 
            this.LabelTimeScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTimeScale.Location = new System.Drawing.Point(263, 17);
            this.LabelTimeScale.Name = "LabelTimeScale";
            this.LabelTimeScale.Size = new System.Drawing.Size(42, 22);
            this.LabelTimeScale.TabIndex = 47;
            this.LabelTimeScale.Text = "0x";
            this.LabelTimeScale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelTimescaleTitle
            // 
            this.LabelTimescaleTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelTimescaleTitle.Location = new System.Drawing.Point(172, 16);
            this.LabelTimescaleTitle.Name = "LabelTimescaleTitle";
            this.LabelTimescaleTitle.Size = new System.Drawing.Size(100, 22);
            this.LabelTimescaleTitle.TabIndex = 45;
            this.LabelTimescaleTitle.Text = "Timescale";
            this.LabelTimescaleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonPause
            // 
            this.ButtonPause.BackColor = System.Drawing.Color.Transparent;
            this.ButtonPause.BackgroundImage = global::MotorwaySimulator.Properties.Resources.Pause_Icon;
            this.ButtonPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonPause.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonPause.Enabled = false;
            this.ButtonPause.Location = new System.Drawing.Point(56, 3);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(47, 47);
            this.ButtonPause.TabIndex = 1;
            this.ButtonPause.UseVisualStyleBackColor = false;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // TabControlControlPanel
            // 
            this.TabControlControlPanel.Controls.Add(this.TabPageSetup);
            this.TabControlControlPanel.Controls.Add(this.TabPageSimulation);
            this.TabControlControlPanel.Location = new System.Drawing.Point(3, 63);
            this.TabControlControlPanel.Name = "TabControlControlPanel";
            this.TabControlControlPanel.SelectedIndex = 0;
            this.TabControlControlPanel.Size = new System.Drawing.Size(1138, 386);
            this.TabControlControlPanel.TabIndex = 0;
            // 
            // TabPageSetup
            // 
            this.TabPageSetup.BackColor = System.Drawing.Color.White;
            this.TabPageSetup.Controls.Add(this.label3);
            this.TabPageSetup.Controls.Add(this.label4);
            this.TabPageSetup.Controls.Add(this.label1);
            this.TabPageSetup.Controls.Add(this.NumericMildCongestion);
            this.TabPageSetup.Controls.Add(this.NumericSevereCongestion);
            this.TabPageSetup.Controls.Add(this.LabelCongestionTitle);
            this.TabPageSetup.Controls.Add(this.LabelMaximumLaneUnitTitle);
            this.TabPageSetup.Controls.Add(this.NumericCarMaximumLane);
            this.TabPageSetup.Controls.Add(this.NumericLGVMaximumLane);
            this.TabPageSetup.Controls.Add(this.NumericHGVMaximumLane);
            this.TabPageSetup.Controls.Add(this.LabelMaximumLaneTitle);
            this.TabPageSetup.Controls.Add(this.NumericBusMaximumLane);
            this.TabPageSetup.Controls.Add(this.LabelSpawnProbabilityUnassigned);
            this.TabPageSetup.Controls.Add(this.LabelSpawnProbabilityUnitTitle);
            this.TabPageSetup.Controls.Add(this.NumericCarSpawnProbability);
            this.TabPageSetup.Controls.Add(this.NumericLGVSpawnProbability);
            this.TabPageSetup.Controls.Add(this.NumericHGVSpawnProbability);
            this.TabPageSetup.Controls.Add(this.LabelSpawnProbabilityTitle);
            this.TabPageSetup.Controls.Add(this.NumericBusSpawnProbability);
            this.TabPageSetup.Controls.Add(this.LabelLaneCount);
            this.TabPageSetup.Controls.Add(this.TrackBarLaneCount);
            this.TabPageSetup.Controls.Add(this.LabelLaneCountTitle);
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
            this.TabPageSetup.Size = new System.Drawing.Size(1130, 360);
            this.TabPageSetup.TabIndex = 0;
            this.TabPageSetup.Text = "Setup";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 70;
            this.label3.Text = "Mild";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(291, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 71;
            this.label4.Text = "Severe";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(362, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "kph from desired";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumericMildCongestion
            // 
            this.NumericMildCongestion.Location = new System.Drawing.Point(224, 249);
            this.NumericMildCongestion.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericMildCongestion.Name = "NumericMildCongestion";
            this.NumericMildCongestion.Size = new System.Drawing.Size(61, 20);
            this.NumericMildCongestion.TabIndex = 64;
            this.NumericMildCongestion.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // NumericSevereCongestion
            // 
            this.NumericSevereCongestion.Location = new System.Drawing.Point(295, 249);
            this.NumericSevereCongestion.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericSevereCongestion.Name = "NumericSevereCongestion";
            this.NumericSevereCongestion.Size = new System.Drawing.Size(61, 20);
            this.NumericSevereCongestion.TabIndex = 65;
            this.NumericSevereCongestion.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // LabelCongestionTitle
            // 
            this.LabelCongestionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelCongestionTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelCongestionTitle.Location = new System.Drawing.Point(111, 249);
            this.LabelCongestionTitle.Name = "LabelCongestionTitle";
            this.LabelCongestionTitle.Size = new System.Drawing.Size(104, 20);
            this.LabelCongestionTitle.TabIndex = 69;
            this.LabelCongestionTitle.Text = "Congestion";
            this.LabelCongestionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelMaximumLaneUnitTitle
            // 
            this.LabelMaximumLaneUnitTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelMaximumLaneUnitTitle.Location = new System.Drawing.Point(1048, 217);
            this.LabelMaximumLaneUnitTitle.Name = "LabelMaximumLaneUnitTitle";
            this.LabelMaximumLaneUnitTitle.Size = new System.Drawing.Size(54, 20);
            this.LabelMaximumLaneUnitTitle.TabIndex = 63;
            this.LabelMaximumLaneUnitTitle.Text = "lane";
            this.LabelMaximumLaneUnitTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumericCarMaximumLane
            // 
            this.NumericCarMaximumLane.Location = new System.Drawing.Point(773, 217);
            this.NumericCarMaximumLane.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericCarMaximumLane.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericCarMaximumLane.Name = "NumericCarMaximumLane";
            this.NumericCarMaximumLane.Size = new System.Drawing.Size(61, 20);
            this.NumericCarMaximumLane.TabIndex = 57;
            this.NumericCarMaximumLane.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // NumericLGVMaximumLane
            // 
            this.NumericLGVMaximumLane.Location = new System.Drawing.Point(844, 217);
            this.NumericLGVMaximumLane.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericLGVMaximumLane.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericLGVMaximumLane.Name = "NumericLGVMaximumLane";
            this.NumericLGVMaximumLane.Size = new System.Drawing.Size(61, 20);
            this.NumericLGVMaximumLane.TabIndex = 58;
            this.NumericLGVMaximumLane.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // NumericHGVMaximumLane
            // 
            this.NumericHGVMaximumLane.Location = new System.Drawing.Point(915, 217);
            this.NumericHGVMaximumLane.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericHGVMaximumLane.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericHGVMaximumLane.Name = "NumericHGVMaximumLane";
            this.NumericHGVMaximumLane.Size = new System.Drawing.Size(61, 20);
            this.NumericHGVMaximumLane.TabIndex = 59;
            this.NumericHGVMaximumLane.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LabelMaximumLaneTitle
            // 
            this.LabelMaximumLaneTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelMaximumLaneTitle.Location = new System.Drawing.Point(595, 217);
            this.LabelMaximumLaneTitle.Name = "LabelMaximumLaneTitle";
            this.LabelMaximumLaneTitle.Size = new System.Drawing.Size(169, 20);
            this.LabelMaximumLaneTitle.TabIndex = 62;
            this.LabelMaximumLaneTitle.Text = "Maximum Lane #";
            this.LabelMaximumLaneTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericBusMaximumLane
            // 
            this.NumericBusMaximumLane.Location = new System.Drawing.Point(986, 217);
            this.NumericBusMaximumLane.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericBusMaximumLane.Name = "NumericBusMaximumLane";
            this.NumericBusMaximumLane.Size = new System.Drawing.Size(61, 20);
            this.NumericBusMaximumLane.TabIndex = 60;
            this.NumericBusMaximumLane.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LabelSpawnProbabilityUnassigned
            // 
            this.LabelSpawnProbabilityUnassigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSpawnProbabilityUnassigned.Location = new System.Drawing.Point(650, 263);
            this.LabelSpawnProbabilityUnassigned.Name = "LabelSpawnProbabilityUnassigned";
            this.LabelSpawnProbabilityUnassigned.Size = new System.Drawing.Size(114, 28);
            this.LabelSpawnProbabilityUnassigned.TabIndex = 56;
            this.LabelSpawnProbabilityUnassigned.Text = "0% unassigned";
            this.LabelSpawnProbabilityUnassigned.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelSpawnProbabilityUnitTitle
            // 
            this.LabelSpawnProbabilityUnitTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelSpawnProbabilityUnitTitle.Location = new System.Drawing.Point(1048, 243);
            this.LabelSpawnProbabilityUnitTitle.Name = "LabelSpawnProbabilityUnitTitle";
            this.LabelSpawnProbabilityUnitTitle.Size = new System.Drawing.Size(25, 20);
            this.LabelSpawnProbabilityUnitTitle.TabIndex = 54;
            this.LabelSpawnProbabilityUnitTitle.Text = "%";
            this.LabelSpawnProbabilityUnitTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumericCarSpawnProbability
            // 
            this.NumericCarSpawnProbability.Location = new System.Drawing.Point(773, 243);
            this.NumericCarSpawnProbability.Name = "NumericCarSpawnProbability";
            this.NumericCarSpawnProbability.Size = new System.Drawing.Size(61, 20);
            this.NumericCarSpawnProbability.TabIndex = 50;
            this.NumericCarSpawnProbability.Value = new decimal(new int[] {
            74,
            0,
            0,
            0});
            this.NumericCarSpawnProbability.ValueChanged += new System.EventHandler(this.ValidateProbabilityChange);
            // 
            // NumericLGVSpawnProbability
            // 
            this.NumericLGVSpawnProbability.Location = new System.Drawing.Point(844, 243);
            this.NumericLGVSpawnProbability.Name = "NumericLGVSpawnProbability";
            this.NumericLGVSpawnProbability.Size = new System.Drawing.Size(61, 20);
            this.NumericLGVSpawnProbability.TabIndex = 51;
            this.NumericLGVSpawnProbability.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.NumericLGVSpawnProbability.ValueChanged += new System.EventHandler(this.ValidateProbabilityChange);
            // 
            // NumericHGVSpawnProbability
            // 
            this.NumericHGVSpawnProbability.Location = new System.Drawing.Point(915, 243);
            this.NumericHGVSpawnProbability.Name = "NumericHGVSpawnProbability";
            this.NumericHGVSpawnProbability.Size = new System.Drawing.Size(61, 20);
            this.NumericHGVSpawnProbability.TabIndex = 52;
            this.NumericHGVSpawnProbability.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.NumericHGVSpawnProbability.ValueChanged += new System.EventHandler(this.ValidateProbabilityChange);
            // 
            // LabelSpawnProbabilityTitle
            // 
            this.LabelSpawnProbabilityTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelSpawnProbabilityTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelSpawnProbabilityTitle.Location = new System.Drawing.Point(599, 243);
            this.LabelSpawnProbabilityTitle.Name = "LabelSpawnProbabilityTitle";
            this.LabelSpawnProbabilityTitle.Size = new System.Drawing.Size(165, 20);
            this.LabelSpawnProbabilityTitle.TabIndex = 55;
            this.LabelSpawnProbabilityTitle.Text = "Spawn Probability";
            this.LabelSpawnProbabilityTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericBusSpawnProbability
            // 
            this.NumericBusSpawnProbability.Location = new System.Drawing.Point(986, 243);
            this.NumericBusSpawnProbability.Name = "NumericBusSpawnProbability";
            this.NumericBusSpawnProbability.Size = new System.Drawing.Size(61, 20);
            this.NumericBusSpawnProbability.TabIndex = 53;
            this.NumericBusSpawnProbability.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericBusSpawnProbability.ValueChanged += new System.EventHandler(this.ValidateProbabilityChange);
            // 
            // LabelLaneCount
            // 
            this.LabelLaneCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLaneCount.Location = new System.Drawing.Point(211, 183);
            this.LabelLaneCount.Name = "LabelLaneCount";
            this.LabelLaneCount.Size = new System.Drawing.Size(71, 28);
            this.LabelLaneCount.TabIndex = 49;
            this.LabelLaneCount.Text = "0 lane(s)";
            this.LabelLaneCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrackBarLaneCount
            // 
            this.TrackBarLaneCount.LargeChange = 1;
            this.TrackBarLaneCount.Location = new System.Drawing.Point(283, 183);
            this.TrackBarLaneCount.Minimum = 1;
            this.TrackBarLaneCount.Name = "TrackBarLaneCount";
            this.TrackBarLaneCount.Size = new System.Drawing.Size(283, 45);
            this.TrackBarLaneCount.TabIndex = 48;
            this.TrackBarLaneCount.Value = 3;
            this.TrackBarLaneCount.Scroll += new System.EventHandler(this.UpdateLaneCount);
            // 
            // LabelLaneCountTitle
            // 
            this.LabelLaneCountTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLaneCountTitle.Location = new System.Drawing.Point(28, 183);
            this.LabelLaneCountTitle.Name = "LabelLaneCountTitle";
            this.LabelLaneCountTitle.Size = new System.Drawing.Size(187, 28);
            this.LabelLaneCountTitle.TabIndex = 47;
            this.LabelLaneCountTitle.Text = "Lane Count";
            this.LabelLaneCountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelDesiredSpeedVarUnit
            // 
            this.LabelDesiredSpeedVarUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelDesiredSpeedVarUnit.Location = new System.Drawing.Point(1048, 190);
            this.LabelDesiredSpeedVarUnit.Name = "LabelDesiredSpeedVarUnit";
            this.LabelDesiredSpeedVarUnit.Size = new System.Drawing.Size(40, 20);
            this.LabelDesiredSpeedVarUnit.TabIndex = 22;
            this.LabelDesiredSpeedVarUnit.Text = "kph";
            this.LabelDesiredSpeedVarUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelRoadLengthTitle
            // 
            this.LabelRoadLengthTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelRoadLengthTitle.Location = new System.Drawing.Point(32, 95);
            this.LabelRoadLengthTitle.Name = "LabelRoadLengthTitle";
            this.LabelRoadLengthTitle.Size = new System.Drawing.Size(196, 28);
            this.LabelRoadLengthTitle.TabIndex = 44;
            this.LabelRoadLengthTitle.Text = "Road Length";
            this.LabelRoadLengthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelDesiredSpeedUnitTitle
            // 
            this.LabelDesiredSpeedUnitTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelDesiredSpeedUnitTitle.Location = new System.Drawing.Point(1048, 164);
            this.LabelDesiredSpeedUnitTitle.Name = "LabelDesiredSpeedUnitTitle";
            this.LabelDesiredSpeedUnitTitle.Size = new System.Drawing.Size(40, 20);
            this.LabelDesiredSpeedUnitTitle.TabIndex = 21;
            this.LabelDesiredSpeedUnitTitle.Text = "kph";
            this.LabelDesiredSpeedUnitTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelRoadLength
            // 
            this.LabelRoadLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRoadLength.Location = new System.Drawing.Point(227, 95);
            this.LabelRoadLength.Name = "LabelRoadLength";
            this.LabelRoadLength.Size = new System.Drawing.Size(60, 28);
            this.LabelRoadLength.TabIndex = 46;
            this.LabelRoadLength.Text = "0 km";
            this.LabelRoadLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelLengthVariationUnitTitle
            // 
            this.LabelLengthVariationUnitTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLengthVariationUnitTitle.Location = new System.Drawing.Point(1048, 138);
            this.LabelLengthVariationUnitTitle.Name = "LabelLengthVariationUnitTitle";
            this.LabelLengthVariationUnitTitle.Size = new System.Drawing.Size(40, 20);
            this.LabelLengthVariationUnitTitle.TabIndex = 20;
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
            this.NumericCarLength.Location = new System.Drawing.Point(773, 112);
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
            this.NumericCarLength.TabIndex = 3;
            this.NumericCarLength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // LabelLengthUnitTitle
            // 
            this.LabelLengthUnitTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLengthUnitTitle.Location = new System.Drawing.Point(1048, 112);
            this.LabelLengthUnitTitle.Name = "LabelLengthUnitTitle";
            this.LabelLengthUnitTitle.Size = new System.Drawing.Size(40, 20);
            this.LabelLengthUnitTitle.TabIndex = 19;
            this.LabelLengthUnitTitle.Text = "m";
            this.LabelLengthUnitTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumericCarLengthVar
            // 
            this.NumericCarLengthVar.DecimalPlaces = 1;
            this.NumericCarLengthVar.Location = new System.Drawing.Point(773, 138);
            this.NumericCarLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericCarLengthVar.Name = "NumericCarLengthVar";
            this.NumericCarLengthVar.Size = new System.Drawing.Size(61, 20);
            this.NumericCarLengthVar.TabIndex = 4;
            this.NumericCarLengthVar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelCarTitle
            // 
            this.LabelCarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCarTitle.Location = new System.Drawing.Point(769, 86);
            this.LabelCarTitle.Name = "LabelCarTitle";
            this.LabelCarTitle.Size = new System.Drawing.Size(65, 23);
            this.LabelCarTitle.TabIndex = 8;
            this.LabelCarTitle.Text = "Car";
            this.LabelCarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumericCarDesiredSpeed
            // 
            this.NumericCarDesiredSpeed.Location = new System.Drawing.Point(773, 164);
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
            this.NumericCarDesiredSpeed.TabIndex = 5;
            this.NumericCarDesiredSpeed.Value = new decimal(new int[] {
            112,
            0,
            0,
            0});
            // 
            // LableBusTitle
            // 
            this.LableBusTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LableBusTitle.Location = new System.Drawing.Point(982, 86);
            this.LableBusTitle.Name = "LableBusTitle";
            this.LableBusTitle.Size = new System.Drawing.Size(65, 23);
            this.LableBusTitle.TabIndex = 25;
            this.LableBusTitle.Text = "Bus";
            this.LableBusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumericCarDesiredSpeedVar
            // 
            this.NumericCarDesiredSpeedVar.Location = new System.Drawing.Point(773, 190);
            this.NumericCarDesiredSpeedVar.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumericCarDesiredSpeedVar.Name = "NumericCarDesiredSpeedVar";
            this.NumericCarDesiredSpeedVar.Size = new System.Drawing.Size(61, 20);
            this.NumericCarDesiredSpeedVar.TabIndex = 6;
            this.NumericCarDesiredSpeedVar.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // LabelHGVTitle
            // 
            this.LabelHGVTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelHGVTitle.Location = new System.Drawing.Point(911, 86);
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
            this.NumericLGVLength.Location = new System.Drawing.Point(844, 112);
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
            this.NumericLGVLength.TabIndex = 7;
            this.NumericLGVLength.Value = new decimal(new int[] {
            55,
            0,
            0,
            65536});
            // 
            // LabelLGVTitle
            // 
            this.LabelLGVTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLGVTitle.Location = new System.Drawing.Point(840, 86);
            this.LabelLGVTitle.Name = "LabelLGVTitle";
            this.LabelLGVTitle.Size = new System.Drawing.Size(65, 23);
            this.LabelLGVTitle.TabIndex = 15;
            this.LabelLGVTitle.Text = "LGV";
            this.LabelLGVTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumericLGVLengthVar
            // 
            this.NumericLGVLengthVar.DecimalPlaces = 1;
            this.NumericLGVLengthVar.Location = new System.Drawing.Point(844, 138);
            this.NumericLGVLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericLGVLengthVar.Name = "NumericLGVLengthVar";
            this.NumericLGVLengthVar.Size = new System.Drawing.Size(61, 20);
            this.NumericLGVLengthVar.TabIndex = 8;
            this.NumericLGVLengthVar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TrackBarInterArrivalVariation
            // 
            this.TrackBarInterArrivalVariation.LargeChange = 1000;
            this.TrackBarInterArrivalVariation.Location = new System.Drawing.Point(283, 155);
            this.TrackBarInterArrivalVariation.Maximum = 1000;
            this.TrackBarInterArrivalVariation.Name = "TrackBarInterArrivalVariation";
            this.TrackBarInterArrivalVariation.Size = new System.Drawing.Size(283, 45);
            this.TrackBarInterArrivalVariation.SmallChange = 100;
            this.TrackBarInterArrivalVariation.TabIndex = 2;
            this.TrackBarInterArrivalVariation.TickFrequency = 50;
            this.TrackBarInterArrivalVariation.Value = 500;
            this.TrackBarInterArrivalVariation.Scroll += new System.EventHandler(this.UpdateInterArrivalVariation);
            // 
            // NumericLGVDesiredSpeed
            // 
            this.NumericLGVDesiredSpeed.Location = new System.Drawing.Point(844, 164);
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
            this.NumericLGVDesiredSpeed.TabIndex = 9;
            this.NumericLGVDesiredSpeed.Value = new decimal(new int[] {
            112,
            0,
            0,
            0});
            // 
            // LabelInterArrivalVariation
            // 
            this.LabelInterArrivalVariation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInterArrivalVariation.Location = new System.Drawing.Point(229, 155);
            this.LabelInterArrivalVariation.Name = "LabelInterArrivalVariation";
            this.LabelInterArrivalVariation.Size = new System.Drawing.Size(53, 28);
            this.LabelInterArrivalVariation.TabIndex = 42;
            this.LabelInterArrivalVariation.Text = "0%";
            this.LabelInterArrivalVariation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericLGVDesiredSpeedVar
            // 
            this.NumericLGVDesiredSpeedVar.Location = new System.Drawing.Point(844, 190);
            this.NumericLGVDesiredSpeedVar.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeedVar.Name = "NumericLGVDesiredSpeedVar";
            this.NumericLGVDesiredSpeedVar.Size = new System.Drawing.Size(61, 20);
            this.NumericLGVDesiredSpeedVar.TabIndex = 10;
            this.NumericLGVDesiredSpeedVar.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // LabelInterArrivalVariationTitle
            // 
            this.LabelInterArrivalVariationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelInterArrivalVariationTitle.Location = new System.Drawing.Point(28, 155);
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
            this.NumericHGVLength.Location = new System.Drawing.Point(915, 112);
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
            this.NumericHGVLength.TabIndex = 11;
            this.NumericHGVLength.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // LabelInterArrivalTime
            // 
            this.LabelInterArrivalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInterArrivalTime.Location = new System.Drawing.Point(234, 125);
            this.LabelInterArrivalTime.Name = "LabelInterArrivalTime";
            this.LabelInterArrivalTime.Size = new System.Drawing.Size(43, 28);
            this.LabelInterArrivalTime.TabIndex = 40;
            this.LabelInterArrivalTime.Text = "0s";
            this.LabelInterArrivalTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericHGVLengthVar
            // 
            this.NumericHGVLengthVar.DecimalPlaces = 1;
            this.NumericHGVLengthVar.Location = new System.Drawing.Point(915, 138);
            this.NumericHGVLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericHGVLengthVar.Name = "NumericHGVLengthVar";
            this.NumericHGVLengthVar.Size = new System.Drawing.Size(61, 20);
            this.NumericHGVLengthVar.TabIndex = 12;
            this.NumericHGVLengthVar.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // TrackBarInterArrivalTime
            // 
            this.TrackBarInterArrivalTime.LargeChange = 10;
            this.TrackBarInterArrivalTime.Location = new System.Drawing.Point(283, 127);
            this.TrackBarInterArrivalTime.Maximum = 1000;
            this.TrackBarInterArrivalTime.Minimum = 1;
            this.TrackBarInterArrivalTime.Name = "TrackBarInterArrivalTime";
            this.TrackBarInterArrivalTime.Size = new System.Drawing.Size(283, 45);
            this.TrackBarInterArrivalTime.TabIndex = 1;
            this.TrackBarInterArrivalTime.TickFrequency = 50;
            this.TrackBarInterArrivalTime.Value = 5;
            this.TrackBarInterArrivalTime.Scroll += new System.EventHandler(this.UpdateInterArrivalTime);
            // 
            // NumericHGVDesiredSpeed
            // 
            this.NumericHGVDesiredSpeed.Location = new System.Drawing.Point(915, 164);
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
            this.NumericHGVDesiredSpeed.TabIndex = 13;
            this.NumericHGVDesiredSpeed.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // LabelInterArrivalTimeTitle
            // 
            this.LabelInterArrivalTimeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelInterArrivalTimeTitle.Location = new System.Drawing.Point(32, 125);
            this.LabelInterArrivalTimeTitle.Name = "LabelInterArrivalTimeTitle";
            this.LabelInterArrivalTimeTitle.Size = new System.Drawing.Size(196, 28);
            this.LabelInterArrivalTimeTitle.TabIndex = 37;
            this.LabelInterArrivalTimeTitle.Text = "Interarrival Time Base";
            this.LabelInterArrivalTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericHGVDesiredSpeedVar
            // 
            this.NumericHGVDesiredSpeedVar.Location = new System.Drawing.Point(915, 190);
            this.NumericHGVDesiredSpeedVar.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeedVar.Name = "NumericHGVDesiredSpeedVar";
            this.NumericHGVDesiredSpeedVar.Size = new System.Drawing.Size(61, 20);
            this.NumericHGVDesiredSpeedVar.TabIndex = 14;
            this.NumericHGVDesiredSpeedVar.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // LabelDesiredSpeedVarTitle
            // 
            this.LabelDesiredSpeedVarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelDesiredSpeedVarTitle.Location = new System.Drawing.Point(595, 190);
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
            this.NumericBusLength.Location = new System.Drawing.Point(986, 112);
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
            this.NumericBusLength.TabIndex = 15;
            this.NumericBusLength.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // LabelDesiredSpeedTitle
            // 
            this.LabelDesiredSpeedTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelDesiredSpeedTitle.Location = new System.Drawing.Point(595, 164);
            this.LabelDesiredSpeedTitle.Name = "LabelDesiredSpeedTitle";
            this.LabelDesiredSpeedTitle.Size = new System.Drawing.Size(169, 20);
            this.LabelDesiredSpeedTitle.TabIndex = 35;
            this.LabelDesiredSpeedTitle.Text = "Speed Base";
            this.LabelDesiredSpeedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericBusLengthVar
            // 
            this.NumericBusLengthVar.DecimalPlaces = 1;
            this.NumericBusLengthVar.Location = new System.Drawing.Point(986, 138);
            this.NumericBusLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericBusLengthVar.Name = "NumericBusLengthVar";
            this.NumericBusLengthVar.Size = new System.Drawing.Size(61, 20);
            this.NumericBusLengthVar.TabIndex = 16;
            this.NumericBusLengthVar.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LabelLengthVarTitle
            // 
            this.LabelLengthVarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLengthVarTitle.Location = new System.Drawing.Point(595, 138);
            this.LabelLengthVarTitle.Name = "LabelLengthVarTitle";
            this.LabelLengthVarTitle.Size = new System.Drawing.Size(169, 20);
            this.LabelLengthVarTitle.TabIndex = 34;
            this.LabelLengthVarTitle.Text = "Length Variation (±)";
            this.LabelLengthVarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericBusDesiredSpeed
            // 
            this.NumericBusDesiredSpeed.Location = new System.Drawing.Point(986, 164);
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
            this.NumericBusDesiredSpeed.TabIndex = 17;
            this.NumericBusDesiredSpeed.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // LabelLengthTitle
            // 
            this.LabelLengthTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelLengthTitle.Location = new System.Drawing.Point(595, 112);
            this.LabelLengthTitle.Name = "LabelLengthTitle";
            this.LabelLengthTitle.Size = new System.Drawing.Size(169, 20);
            this.LabelLengthTitle.TabIndex = 33;
            this.LabelLengthTitle.Text = "Length Base";
            this.LabelLengthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericBusDesiredSpeedVar
            // 
            this.NumericBusDesiredSpeedVar.Location = new System.Drawing.Point(986, 190);
            this.NumericBusDesiredSpeedVar.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumericBusDesiredSpeedVar.Name = "NumericBusDesiredSpeedVar";
            this.NumericBusDesiredSpeedVar.Size = new System.Drawing.Size(61, 20);
            this.NumericBusDesiredSpeedVar.TabIndex = 18;
            this.NumericBusDesiredSpeedVar.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // TrackBarRoadLength
            // 
            this.TrackBarRoadLength.LargeChange = 100;
            this.TrackBarRoadLength.Location = new System.Drawing.Point(283, 96);
            this.TrackBarRoadLength.Maximum = 5000;
            this.TrackBarRoadLength.Minimum = 10;
            this.TrackBarRoadLength.Name = "TrackBarRoadLength";
            this.TrackBarRoadLength.Size = new System.Drawing.Size(283, 45);
            this.TrackBarRoadLength.SmallChange = 10;
            this.TrackBarRoadLength.TabIndex = 0;
            this.TrackBarRoadLength.TickFrequency = 250;
            this.TrackBarRoadLength.Value = 100;
            this.TrackBarRoadLength.Scroll += new System.EventHandler(this.UpdateRoadLength);
            // 
            // TabPageSimulation
            // 
            this.TabPageSimulation.BackColor = System.Drawing.Color.White;
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalSeverelyCongested);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalSeverelyCongestedTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalMildlyCongested);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalMildlyCongestedTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalNotCongested);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalNotCongestedTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesSeverelyCongestedPercent);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesSeverelyCongestedPercentTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesMildlyCongestedPercent);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesMildlyCongestedPercentTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesNotCongestedPercent);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesNotCongestedPercentTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesBusPercent);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesBusPercentTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesHGVPercent);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesHGVPercentTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalVehicles);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalVehiclesTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalLGV);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalLGVTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesLGVPercent);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesLGVPercentTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalHGV);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalHGVTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalCar);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalCarTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesFailedSpawnsPercent);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesFailedSpawnsPercentTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesSuccessfulSpawnsPercent);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesSuccessfulSpawnsPercentTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesCarPercent);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesCarPercentTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalBus);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalBusTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalFailedSpawns);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalFailedSpawnsTitle);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalSuccessfulSpawns);
            this.TabPageSimulation.Controls.Add(this.LabelAllVehiclesTotalSuccessfulSpawnsTitle);
            this.TabPageSimulation.Controls.Add(this.label2);
            this.TabPageSimulation.Controls.Add(this.ButtonFindVehicle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleCongestion);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleCongestionTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleID);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleIDTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleLifetime);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleLifetimeTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleAverageSpeed);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleAverageSpeedTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleProgress);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleProgressTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleDespawnTime);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleDespawnTimeTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleSpawnTime);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleSpawnTimeTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleSuccessfulSpawn);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleSuccessfulSpawnTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleActualSpeed);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleActualSpeedTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleDesiredSpeed);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleDesiredSpeedTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleLength);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleLengthTitle);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleType);
            this.TabPageSimulation.Controls.Add(this.LabelVehicleTypeTitle);
            this.TabPageSimulation.Controls.Add(this.LableVehicleDataTitle);
            this.TabPageSimulation.Controls.Add(this.LabelFinishedVehiclesTitle);
            this.TabPageSimulation.Controls.Add(this.TreeViewFinishedVehicles);
            this.TabPageSimulation.Controls.Add(this.LabelVehiclesTitle);
            this.TabPageSimulation.Controls.Add(this.TreeViewVehicles);
            this.TabPageSimulation.Location = new System.Drawing.Point(4, 22);
            this.TabPageSimulation.Name = "TabPageSimulation";
            this.TabPageSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSimulation.Size = new System.Drawing.Size(1130, 360);
            this.TabPageSimulation.TabIndex = 1;
            this.TabPageSimulation.Text = "Data";
            // 
            // LabelAllVehiclesTotalSeverelyCongested
            // 
            this.LabelAllVehiclesTotalSeverelyCongested.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalSeverelyCongested.Location = new System.Drawing.Point(1046, 81);
            this.LabelAllVehiclesTotalSeverelyCongested.Name = "LabelAllVehiclesTotalSeverelyCongested";
            this.LabelAllVehiclesTotalSeverelyCongested.Size = new System.Drawing.Size(71, 28);
            this.LabelAllVehiclesTotalSeverelyCongested.TabIndex = 120;
            this.LabelAllVehiclesTotalSeverelyCongested.Text = "0";
            this.LabelAllVehiclesTotalSeverelyCongested.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalSeverelyCongestedTitle
            // 
            this.LabelAllVehiclesTotalSeverelyCongestedTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalSeverelyCongestedTitle.Location = new System.Drawing.Point(883, 81);
            this.LabelAllVehiclesTotalSeverelyCongestedTitle.Name = "LabelAllVehiclesTotalSeverelyCongestedTitle";
            this.LabelAllVehiclesTotalSeverelyCongestedTitle.Size = new System.Drawing.Size(171, 28);
            this.LabelAllVehiclesTotalSeverelyCongestedTitle.TabIndex = 119;
            this.LabelAllVehiclesTotalSeverelyCongestedTitle.Text = "Total Severely Congested:";
            this.LabelAllVehiclesTotalSeverelyCongestedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesTotalMildlyCongested
            // 
            this.LabelAllVehiclesTotalMildlyCongested.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalMildlyCongested.Location = new System.Drawing.Point(1028, 59);
            this.LabelAllVehiclesTotalMildlyCongested.Name = "LabelAllVehiclesTotalMildlyCongested";
            this.LabelAllVehiclesTotalMildlyCongested.Size = new System.Drawing.Size(89, 28);
            this.LabelAllVehiclesTotalMildlyCongested.TabIndex = 118;
            this.LabelAllVehiclesTotalMildlyCongested.Text = "0";
            this.LabelAllVehiclesTotalMildlyCongested.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalMildlyCongestedTitle
            // 
            this.LabelAllVehiclesTotalMildlyCongestedTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalMildlyCongestedTitle.Location = new System.Drawing.Point(883, 59);
            this.LabelAllVehiclesTotalMildlyCongestedTitle.Name = "LabelAllVehiclesTotalMildlyCongestedTitle";
            this.LabelAllVehiclesTotalMildlyCongestedTitle.Size = new System.Drawing.Size(153, 28);
            this.LabelAllVehiclesTotalMildlyCongestedTitle.TabIndex = 117;
            this.LabelAllVehiclesTotalMildlyCongestedTitle.Text = "Total Mildly Congested:";
            this.LabelAllVehiclesTotalMildlyCongestedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesTotalNotCongested
            // 
            this.LabelAllVehiclesTotalNotCongested.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalNotCongested.Location = new System.Drawing.Point(1018, 36);
            this.LabelAllVehiclesTotalNotCongested.Name = "LabelAllVehiclesTotalNotCongested";
            this.LabelAllVehiclesTotalNotCongested.Size = new System.Drawing.Size(99, 28);
            this.LabelAllVehiclesTotalNotCongested.TabIndex = 116;
            this.LabelAllVehiclesTotalNotCongested.Text = "0";
            this.LabelAllVehiclesTotalNotCongested.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalNotCongestedTitle
            // 
            this.LabelAllVehiclesTotalNotCongestedTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalNotCongestedTitle.Location = new System.Drawing.Point(883, 36);
            this.LabelAllVehiclesTotalNotCongestedTitle.Name = "LabelAllVehiclesTotalNotCongestedTitle";
            this.LabelAllVehiclesTotalNotCongestedTitle.Size = new System.Drawing.Size(139, 28);
            this.LabelAllVehiclesTotalNotCongestedTitle.TabIndex = 115;
            this.LabelAllVehiclesTotalNotCongestedTitle.Text = "Total Not Congested:";
            this.LabelAllVehiclesTotalNotCongestedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesSeverelyCongestedPercent
            // 
            this.LabelAllVehiclesSeverelyCongestedPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesSeverelyCongestedPercent.Location = new System.Drawing.Point(1040, 148);
            this.LabelAllVehiclesSeverelyCongestedPercent.Name = "LabelAllVehiclesSeverelyCongestedPercent";
            this.LabelAllVehiclesSeverelyCongestedPercent.Size = new System.Drawing.Size(77, 28);
            this.LabelAllVehiclesSeverelyCongestedPercent.TabIndex = 114;
            this.LabelAllVehiclesSeverelyCongestedPercent.Text = "---";
            this.LabelAllVehiclesSeverelyCongestedPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesSeverelyCongestedPercentTitle
            // 
            this.LabelAllVehiclesSeverelyCongestedPercentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesSeverelyCongestedPercentTitle.Location = new System.Drawing.Point(883, 148);
            this.LabelAllVehiclesSeverelyCongestedPercentTitle.Name = "LabelAllVehiclesSeverelyCongestedPercentTitle";
            this.LabelAllVehiclesSeverelyCongestedPercentTitle.Size = new System.Drawing.Size(161, 28);
            this.LabelAllVehiclesSeverelyCongestedPercentTitle.TabIndex = 113;
            this.LabelAllVehiclesSeverelyCongestedPercentTitle.Text = "Severely Congested (%):";
            this.LabelAllVehiclesSeverelyCongestedPercentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesMildlyCongestedPercent
            // 
            this.LabelAllVehiclesMildlyCongestedPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesMildlyCongestedPercent.Location = new System.Drawing.Point(1015, 125);
            this.LabelAllVehiclesMildlyCongestedPercent.Name = "LabelAllVehiclesMildlyCongestedPercent";
            this.LabelAllVehiclesMildlyCongestedPercent.Size = new System.Drawing.Size(102, 28);
            this.LabelAllVehiclesMildlyCongestedPercent.TabIndex = 112;
            this.LabelAllVehiclesMildlyCongestedPercent.Text = "---";
            this.LabelAllVehiclesMildlyCongestedPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesMildlyCongestedPercentTitle
            // 
            this.LabelAllVehiclesMildlyCongestedPercentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesMildlyCongestedPercentTitle.Location = new System.Drawing.Point(883, 125);
            this.LabelAllVehiclesMildlyCongestedPercentTitle.Name = "LabelAllVehiclesMildlyCongestedPercentTitle";
            this.LabelAllVehiclesMildlyCongestedPercentTitle.Size = new System.Drawing.Size(139, 28);
            this.LabelAllVehiclesMildlyCongestedPercentTitle.TabIndex = 111;
            this.LabelAllVehiclesMildlyCongestedPercentTitle.Text = "Mildly Congested (%):";
            this.LabelAllVehiclesMildlyCongestedPercentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesNotCongestedPercent
            // 
            this.LabelAllVehiclesNotCongestedPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesNotCongestedPercent.Location = new System.Drawing.Point(1007, 103);
            this.LabelAllVehiclesNotCongestedPercent.Name = "LabelAllVehiclesNotCongestedPercent";
            this.LabelAllVehiclesNotCongestedPercent.Size = new System.Drawing.Size(110, 28);
            this.LabelAllVehiclesNotCongestedPercent.TabIndex = 110;
            this.LabelAllVehiclesNotCongestedPercent.Text = "---";
            this.LabelAllVehiclesNotCongestedPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesNotCongestedPercentTitle
            // 
            this.LabelAllVehiclesNotCongestedPercentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesNotCongestedPercentTitle.Location = new System.Drawing.Point(883, 103);
            this.LabelAllVehiclesNotCongestedPercentTitle.Name = "LabelAllVehiclesNotCongestedPercentTitle";
            this.LabelAllVehiclesNotCongestedPercentTitle.Size = new System.Drawing.Size(126, 28);
            this.LabelAllVehiclesNotCongestedPercentTitle.TabIndex = 109;
            this.LabelAllVehiclesNotCongestedPercentTitle.Text = "Not Congested (%):";
            this.LabelAllVehiclesNotCongestedPercentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesBusPercent
            // 
            this.LabelAllVehiclesBusPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesBusPercent.Location = new System.Drawing.Point(703, 320);
            this.LabelAllVehiclesBusPercent.Name = "LabelAllVehiclesBusPercent";
            this.LabelAllVehiclesBusPercent.Size = new System.Drawing.Size(162, 28);
            this.LabelAllVehiclesBusPercent.TabIndex = 108;
            this.LabelAllVehiclesBusPercent.Text = "---";
            this.LabelAllVehiclesBusPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesBusPercentTitle
            // 
            this.LabelAllVehiclesBusPercentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesBusPercentTitle.Location = new System.Drawing.Point(631, 320);
            this.LabelAllVehiclesBusPercentTitle.Name = "LabelAllVehiclesBusPercentTitle";
            this.LabelAllVehiclesBusPercentTitle.Size = new System.Drawing.Size(72, 28);
            this.LabelAllVehiclesBusPercentTitle.TabIndex = 107;
            this.LabelAllVehiclesBusPercentTitle.Text = "Buses (%):";
            this.LabelAllVehiclesBusPercentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesHGVPercent
            // 
            this.LabelAllVehiclesHGVPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesHGVPercent.Location = new System.Drawing.Point(700, 296);
            this.LabelAllVehiclesHGVPercent.Name = "LabelAllVehiclesHGVPercent";
            this.LabelAllVehiclesHGVPercent.Size = new System.Drawing.Size(165, 28);
            this.LabelAllVehiclesHGVPercent.TabIndex = 106;
            this.LabelAllVehiclesHGVPercent.Text = "---";
            this.LabelAllVehiclesHGVPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesHGVPercentTitle
            // 
            this.LabelAllVehiclesHGVPercentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesHGVPercentTitle.Location = new System.Drawing.Point(631, 296);
            this.LabelAllVehiclesHGVPercentTitle.Name = "LabelAllVehiclesHGVPercentTitle";
            this.LabelAllVehiclesHGVPercentTitle.Size = new System.Drawing.Size(72, 28);
            this.LabelAllVehiclesHGVPercentTitle.TabIndex = 105;
            this.LabelAllVehiclesHGVPercentTitle.Text = "HGVs (%):";
            this.LabelAllVehiclesHGVPercentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesTotalVehicles
            // 
            this.LabelAllVehiclesTotalVehicles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalVehicles.Location = new System.Drawing.Point(724, 36);
            this.LabelAllVehiclesTotalVehicles.Name = "LabelAllVehiclesTotalVehicles";
            this.LabelAllVehiclesTotalVehicles.Size = new System.Drawing.Size(141, 28);
            this.LabelAllVehiclesTotalVehicles.TabIndex = 104;
            this.LabelAllVehiclesTotalVehicles.Text = "0";
            this.LabelAllVehiclesTotalVehicles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalVehiclesTitle
            // 
            this.LabelAllVehiclesTotalVehiclesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalVehiclesTitle.Location = new System.Drawing.Point(631, 36);
            this.LabelAllVehiclesTotalVehiclesTitle.Name = "LabelAllVehiclesTotalVehiclesTitle";
            this.LabelAllVehiclesTotalVehiclesTitle.Size = new System.Drawing.Size(100, 28);
            this.LabelAllVehiclesTotalVehiclesTitle.TabIndex = 103;
            this.LabelAllVehiclesTotalVehiclesTitle.Text = "Total Vehicles:";
            this.LabelAllVehiclesTotalVehiclesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesTotalLGV
            // 
            this.LabelAllVehiclesTotalLGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalLGV.Location = new System.Drawing.Point(705, 172);
            this.LabelAllVehiclesTotalLGV.Name = "LabelAllVehiclesTotalLGV";
            this.LabelAllVehiclesTotalLGV.Size = new System.Drawing.Size(160, 28);
            this.LabelAllVehiclesTotalLGV.TabIndex = 102;
            this.LabelAllVehiclesTotalLGV.Text = "0";
            this.LabelAllVehiclesTotalLGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalLGVTitle
            // 
            this.LabelAllVehiclesTotalLGVTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalLGVTitle.Location = new System.Drawing.Point(631, 172);
            this.LabelAllVehiclesTotalLGVTitle.Name = "LabelAllVehiclesTotalLGVTitle";
            this.LabelAllVehiclesTotalLGVTitle.Size = new System.Drawing.Size(117, 28);
            this.LabelAllVehiclesTotalLGVTitle.TabIndex = 101;
            this.LabelAllVehiclesTotalLGVTitle.Text = "Total LGVs:";
            this.LabelAllVehiclesTotalLGVTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesLGVPercent
            // 
            this.LabelAllVehiclesLGVPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesLGVPercent.Location = new System.Drawing.Point(697, 271);
            this.LabelAllVehiclesLGVPercent.Name = "LabelAllVehiclesLGVPercent";
            this.LabelAllVehiclesLGVPercent.Size = new System.Drawing.Size(168, 28);
            this.LabelAllVehiclesLGVPercent.TabIndex = 100;
            this.LabelAllVehiclesLGVPercent.Text = "---";
            this.LabelAllVehiclesLGVPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesLGVPercentTitle
            // 
            this.LabelAllVehiclesLGVPercentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesLGVPercentTitle.Location = new System.Drawing.Point(631, 271);
            this.LabelAllVehiclesLGVPercentTitle.Name = "LabelAllVehiclesLGVPercentTitle";
            this.LabelAllVehiclesLGVPercentTitle.Size = new System.Drawing.Size(72, 28);
            this.LabelAllVehiclesLGVPercentTitle.TabIndex = 99;
            this.LabelAllVehiclesLGVPercentTitle.Text = "LGVs (%):";
            this.LabelAllVehiclesLGVPercentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesTotalHGV
            // 
            this.LabelAllVehiclesTotalHGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalHGV.Location = new System.Drawing.Point(712, 197);
            this.LabelAllVehiclesTotalHGV.Name = "LabelAllVehiclesTotalHGV";
            this.LabelAllVehiclesTotalHGV.Size = new System.Drawing.Size(153, 28);
            this.LabelAllVehiclesTotalHGV.TabIndex = 98;
            this.LabelAllVehiclesTotalHGV.Text = "0";
            this.LabelAllVehiclesTotalHGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalHGVTitle
            // 
            this.LabelAllVehiclesTotalHGVTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalHGVTitle.Location = new System.Drawing.Point(631, 197);
            this.LabelAllVehiclesTotalHGVTitle.Name = "LabelAllVehiclesTotalHGVTitle";
            this.LabelAllVehiclesTotalHGVTitle.Size = new System.Drawing.Size(82, 28);
            this.LabelAllVehiclesTotalHGVTitle.TabIndex = 97;
            this.LabelAllVehiclesTotalHGVTitle.Text = "Total HGVs:";
            this.LabelAllVehiclesTotalHGVTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesTotalCar
            // 
            this.LabelAllVehiclesTotalCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalCar.Location = new System.Drawing.Point(708, 148);
            this.LabelAllVehiclesTotalCar.Name = "LabelAllVehiclesTotalCar";
            this.LabelAllVehiclesTotalCar.Size = new System.Drawing.Size(157, 28);
            this.LabelAllVehiclesTotalCar.TabIndex = 96;
            this.LabelAllVehiclesTotalCar.Text = "0";
            this.LabelAllVehiclesTotalCar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalCarTitle
            // 
            this.LabelAllVehiclesTotalCarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalCarTitle.Location = new System.Drawing.Point(631, 148);
            this.LabelAllVehiclesTotalCarTitle.Name = "LabelAllVehiclesTotalCarTitle";
            this.LabelAllVehiclesTotalCarTitle.Size = new System.Drawing.Size(74, 28);
            this.LabelAllVehiclesTotalCarTitle.TabIndex = 95;
            this.LabelAllVehiclesTotalCarTitle.Text = "Total Cars:";
            this.LabelAllVehiclesTotalCarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesFailedSpawnsPercent
            // 
            this.LabelAllVehiclesFailedSpawnsPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesFailedSpawnsPercent.Location = new System.Drawing.Point(754, 125);
            this.LabelAllVehiclesFailedSpawnsPercent.Name = "LabelAllVehiclesFailedSpawnsPercent";
            this.LabelAllVehiclesFailedSpawnsPercent.Size = new System.Drawing.Size(111, 28);
            this.LabelAllVehiclesFailedSpawnsPercent.TabIndex = 94;
            this.LabelAllVehiclesFailedSpawnsPercent.Text = "---";
            this.LabelAllVehiclesFailedSpawnsPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesFailedSpawnsPercentTitle
            // 
            this.LabelAllVehiclesFailedSpawnsPercentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesFailedSpawnsPercentTitle.Location = new System.Drawing.Point(631, 125);
            this.LabelAllVehiclesFailedSpawnsPercentTitle.Name = "LabelAllVehiclesFailedSpawnsPercentTitle";
            this.LabelAllVehiclesFailedSpawnsPercentTitle.Size = new System.Drawing.Size(125, 28);
            this.LabelAllVehiclesFailedSpawnsPercentTitle.TabIndex = 93;
            this.LabelAllVehiclesFailedSpawnsPercentTitle.Text = "Failed Spawns (%):";
            this.LabelAllVehiclesFailedSpawnsPercentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesSuccessfulSpawnsPercent
            // 
            this.LabelAllVehiclesSuccessfulSpawnsPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesSuccessfulSpawnsPercent.Location = new System.Drawing.Point(780, 103);
            this.LabelAllVehiclesSuccessfulSpawnsPercent.Name = "LabelAllVehiclesSuccessfulSpawnsPercent";
            this.LabelAllVehiclesSuccessfulSpawnsPercent.Size = new System.Drawing.Size(85, 28);
            this.LabelAllVehiclesSuccessfulSpawnsPercent.TabIndex = 92;
            this.LabelAllVehiclesSuccessfulSpawnsPercent.Text = "---";
            this.LabelAllVehiclesSuccessfulSpawnsPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesSuccessfulSpawnsPercentTitle
            // 
            this.LabelAllVehiclesSuccessfulSpawnsPercentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesSuccessfulSpawnsPercentTitle.Location = new System.Drawing.Point(631, 103);
            this.LabelAllVehiclesSuccessfulSpawnsPercentTitle.Name = "LabelAllVehiclesSuccessfulSpawnsPercentTitle";
            this.LabelAllVehiclesSuccessfulSpawnsPercentTitle.Size = new System.Drawing.Size(151, 28);
            this.LabelAllVehiclesSuccessfulSpawnsPercentTitle.TabIndex = 91;
            this.LabelAllVehiclesSuccessfulSpawnsPercentTitle.Text = "Successful Spawns (%):";
            this.LabelAllVehiclesSuccessfulSpawnsPercentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesCarPercent
            // 
            this.LabelAllVehiclesCarPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesCarPercent.Location = new System.Drawing.Point(692, 247);
            this.LabelAllVehiclesCarPercent.Name = "LabelAllVehiclesCarPercent";
            this.LabelAllVehiclesCarPercent.Size = new System.Drawing.Size(173, 28);
            this.LabelAllVehiclesCarPercent.TabIndex = 90;
            this.LabelAllVehiclesCarPercent.Text = "---";
            this.LabelAllVehiclesCarPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesCarPercentTitle
            // 
            this.LabelAllVehiclesCarPercentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesCarPercentTitle.Location = new System.Drawing.Point(631, 247);
            this.LabelAllVehiclesCarPercentTitle.Name = "LabelAllVehiclesCarPercentTitle";
            this.LabelAllVehiclesCarPercentTitle.Size = new System.Drawing.Size(72, 28);
            this.LabelAllVehiclesCarPercentTitle.TabIndex = 89;
            this.LabelAllVehiclesCarPercentTitle.Text = "Cars (%):";
            this.LabelAllVehiclesCarPercentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesTotalBus
            // 
            this.LabelAllVehiclesTotalBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalBus.Location = new System.Drawing.Point(719, 223);
            this.LabelAllVehiclesTotalBus.Name = "LabelAllVehiclesTotalBus";
            this.LabelAllVehiclesTotalBus.Size = new System.Drawing.Size(146, 28);
            this.LabelAllVehiclesTotalBus.TabIndex = 88;
            this.LabelAllVehiclesTotalBus.Text = "0";
            this.LabelAllVehiclesTotalBus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalBusTitle
            // 
            this.LabelAllVehiclesTotalBusTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalBusTitle.Location = new System.Drawing.Point(631, 223);
            this.LabelAllVehiclesTotalBusTitle.Name = "LabelAllVehiclesTotalBusTitle";
            this.LabelAllVehiclesTotalBusTitle.Size = new System.Drawing.Size(88, 28);
            this.LabelAllVehiclesTotalBusTitle.TabIndex = 87;
            this.LabelAllVehiclesTotalBusTitle.Text = "Total Buses:";
            this.LabelAllVehiclesTotalBusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesTotalFailedSpawns
            // 
            this.LabelAllVehiclesTotalFailedSpawns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalFailedSpawns.Location = new System.Drawing.Point(727, 81);
            this.LabelAllVehiclesTotalFailedSpawns.Name = "LabelAllVehiclesTotalFailedSpawns";
            this.LabelAllVehiclesTotalFailedSpawns.Size = new System.Drawing.Size(138, 28);
            this.LabelAllVehiclesTotalFailedSpawns.TabIndex = 86;
            this.LabelAllVehiclesTotalFailedSpawns.Text = "0";
            this.LabelAllVehiclesTotalFailedSpawns.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalFailedSpawnsTitle
            // 
            this.LabelAllVehiclesTotalFailedSpawnsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalFailedSpawnsTitle.Location = new System.Drawing.Point(631, 81);
            this.LabelAllVehiclesTotalFailedSpawnsTitle.Name = "LabelAllVehiclesTotalFailedSpawnsTitle";
            this.LabelAllVehiclesTotalFailedSpawnsTitle.Size = new System.Drawing.Size(100, 28);
            this.LabelAllVehiclesTotalFailedSpawnsTitle.TabIndex = 85;
            this.LabelAllVehiclesTotalFailedSpawnsTitle.Text = "Failed Spawns:";
            this.LabelAllVehiclesTotalFailedSpawnsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAllVehiclesTotalSuccessfulSpawns
            // 
            this.LabelAllVehiclesTotalSuccessfulSpawns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalSuccessfulSpawns.Location = new System.Drawing.Point(757, 59);
            this.LabelAllVehiclesTotalSuccessfulSpawns.Name = "LabelAllVehiclesTotalSuccessfulSpawns";
            this.LabelAllVehiclesTotalSuccessfulSpawns.Size = new System.Drawing.Size(108, 28);
            this.LabelAllVehiclesTotalSuccessfulSpawns.TabIndex = 84;
            this.LabelAllVehiclesTotalSuccessfulSpawns.Text = "0";
            this.LabelAllVehiclesTotalSuccessfulSpawns.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelAllVehiclesTotalSuccessfulSpawnsTitle
            // 
            this.LabelAllVehiclesTotalSuccessfulSpawnsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAllVehiclesTotalSuccessfulSpawnsTitle.Location = new System.Drawing.Point(631, 59);
            this.LabelAllVehiclesTotalSuccessfulSpawnsTitle.Name = "LabelAllVehiclesTotalSuccessfulSpawnsTitle";
            this.LabelAllVehiclesTotalSuccessfulSpawnsTitle.Size = new System.Drawing.Size(138, 28);
            this.LabelAllVehiclesTotalSuccessfulSpawnsTitle.TabIndex = 83;
            this.LabelAllVehiclesTotalSuccessfulSpawnsTitle.Text = "Successful Spawns:";
            this.LabelAllVehiclesTotalSuccessfulSpawnsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(634, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(483, 22);
            this.label2.TabIndex = 82;
            this.label2.Text = "All Vehicle Data";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonFindVehicle
            // 
            this.ButtonFindVehicle.Enabled = false;
            this.ButtonFindVehicle.Location = new System.Drawing.Point(371, 325);
            this.ButtonFindVehicle.Name = "ButtonFindVehicle";
            this.ButtonFindVehicle.Size = new System.Drawing.Size(227, 23);
            this.ButtonFindVehicle.TabIndex = 81;
            this.ButtonFindVehicle.Text = "Find";
            this.ButtonFindVehicle.UseVisualStyleBackColor = true;
            this.ButtonFindVehicle.Click += new System.EventHandler(this.ButtonFindVehicle_Click);
            // 
            // LabelVehicleCongestion
            // 
            this.LabelVehicleCongestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleCongestion.Location = new System.Drawing.Point(446, 296);
            this.LabelVehicleCongestion.Name = "LabelVehicleCongestion";
            this.LabelVehicleCongestion.Size = new System.Drawing.Size(156, 28);
            this.LabelVehicleCongestion.TabIndex = 80;
            this.LabelVehicleCongestion.Text = "---";
            this.LabelVehicleCongestion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleCongestionTitle
            // 
            this.LabelVehicleCongestionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleCongestionTitle.Location = new System.Drawing.Point(368, 296);
            this.LabelVehicleCongestionTitle.Name = "LabelVehicleCongestionTitle";
            this.LabelVehicleCongestionTitle.Size = new System.Drawing.Size(114, 28);
            this.LabelVehicleCongestionTitle.TabIndex = 79;
            this.LabelVehicleCongestionTitle.Text = "Congestion:";
            this.LabelVehicleCongestionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleID
            // 
            this.LabelVehicleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleID.Location = new System.Drawing.Point(389, 36);
            this.LabelVehicleID.Name = "LabelVehicleID";
            this.LabelVehicleID.Size = new System.Drawing.Size(213, 28);
            this.LabelVehicleID.TabIndex = 78;
            this.LabelVehicleID.Text = "---";
            this.LabelVehicleID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleIDTitle
            // 
            this.LabelVehicleIDTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleIDTitle.Location = new System.Drawing.Point(368, 36);
            this.LabelVehicleIDTitle.Name = "LabelVehicleIDTitle";
            this.LabelVehicleIDTitle.Size = new System.Drawing.Size(47, 28);
            this.LabelVehicleIDTitle.TabIndex = 77;
            this.LabelVehicleIDTitle.Text = "ID:";
            this.LabelVehicleIDTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleLifetime
            // 
            this.LabelVehicleLifetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleLifetime.Location = new System.Drawing.Point(421, 172);
            this.LabelVehicleLifetime.Name = "LabelVehicleLifetime";
            this.LabelVehicleLifetime.Size = new System.Drawing.Size(181, 28);
            this.LabelVehicleLifetime.TabIndex = 76;
            this.LabelVehicleLifetime.Text = "---";
            this.LabelVehicleLifetime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleLifetimeTitle
            // 
            this.LabelVehicleLifetimeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleLifetimeTitle.Location = new System.Drawing.Point(368, 172);
            this.LabelVehicleLifetimeTitle.Name = "LabelVehicleLifetimeTitle";
            this.LabelVehicleLifetimeTitle.Size = new System.Drawing.Size(117, 28);
            this.LabelVehicleLifetimeTitle.TabIndex = 75;
            this.LabelVehicleLifetimeTitle.Text = "Lifetime:";
            this.LabelVehicleLifetimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleAverageSpeed
            // 
            this.LabelVehicleAverageSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleAverageSpeed.Location = new System.Drawing.Point(472, 271);
            this.LabelVehicleAverageSpeed.Name = "LabelVehicleAverageSpeed";
            this.LabelVehicleAverageSpeed.Size = new System.Drawing.Size(130, 28);
            this.LabelVehicleAverageSpeed.TabIndex = 74;
            this.LabelVehicleAverageSpeed.Text = "---";
            this.LabelVehicleAverageSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleAverageSpeedTitle
            // 
            this.LabelVehicleAverageSpeedTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleAverageSpeedTitle.Location = new System.Drawing.Point(368, 271);
            this.LabelVehicleAverageSpeedTitle.Name = "LabelVehicleAverageSpeedTitle";
            this.LabelVehicleAverageSpeedTitle.Size = new System.Drawing.Size(114, 28);
            this.LabelVehicleAverageSpeedTitle.TabIndex = 73;
            this.LabelVehicleAverageSpeedTitle.Text = "Average Speed:";
            this.LabelVehicleAverageSpeedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleProgress
            // 
            this.LabelVehicleProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleProgress.Location = new System.Drawing.Point(442, 197);
            this.LabelVehicleProgress.Name = "LabelVehicleProgress";
            this.LabelVehicleProgress.Size = new System.Drawing.Size(160, 28);
            this.LabelVehicleProgress.TabIndex = 72;
            this.LabelVehicleProgress.Text = "---";
            this.LabelVehicleProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleProgressTitle
            // 
            this.LabelVehicleProgressTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleProgressTitle.Location = new System.Drawing.Point(368, 197);
            this.LabelVehicleProgressTitle.Name = "LabelVehicleProgressTitle";
            this.LabelVehicleProgressTitle.Size = new System.Drawing.Size(68, 28);
            this.LabelVehicleProgressTitle.TabIndex = 71;
            this.LabelVehicleProgressTitle.Text = "Progress:";
            this.LabelVehicleProgressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleDespawnTime
            // 
            this.LabelVehicleDespawnTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleDespawnTime.Location = new System.Drawing.Point(469, 148);
            this.LabelVehicleDespawnTime.Name = "LabelVehicleDespawnTime";
            this.LabelVehicleDespawnTime.Size = new System.Drawing.Size(133, 28);
            this.LabelVehicleDespawnTime.TabIndex = 70;
            this.LabelVehicleDespawnTime.Text = "---";
            this.LabelVehicleDespawnTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleDespawnTimeTitle
            // 
            this.LabelVehicleDespawnTimeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleDespawnTimeTitle.Location = new System.Drawing.Point(368, 148);
            this.LabelVehicleDespawnTimeTitle.Name = "LabelVehicleDespawnTimeTitle";
            this.LabelVehicleDespawnTimeTitle.Size = new System.Drawing.Size(117, 28);
            this.LabelVehicleDespawnTimeTitle.TabIndex = 69;
            this.LabelVehicleDespawnTimeTitle.Text = "Despawn Time:";
            this.LabelVehicleDespawnTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleSpawnTime
            // 
            this.LabelVehicleSpawnTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleSpawnTime.Location = new System.Drawing.Point(458, 125);
            this.LabelVehicleSpawnTime.Name = "LabelVehicleSpawnTime";
            this.LabelVehicleSpawnTime.Size = new System.Drawing.Size(144, 28);
            this.LabelVehicleSpawnTime.TabIndex = 68;
            this.LabelVehicleSpawnTime.Text = "---";
            this.LabelVehicleSpawnTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleSpawnTimeTitle
            // 
            this.LabelVehicleSpawnTimeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleSpawnTimeTitle.Location = new System.Drawing.Point(368, 125);
            this.LabelVehicleSpawnTimeTitle.Name = "LabelVehicleSpawnTimeTitle";
            this.LabelVehicleSpawnTimeTitle.Size = new System.Drawing.Size(125, 28);
            this.LabelVehicleSpawnTimeTitle.TabIndex = 67;
            this.LabelVehicleSpawnTimeTitle.Text = "Spawn Time:";
            this.LabelVehicleSpawnTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleSuccessfulSpawn
            // 
            this.LabelVehicleSuccessfulSpawn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleSuccessfulSpawn.Location = new System.Drawing.Point(491, 103);
            this.LabelVehicleSuccessfulSpawn.Name = "LabelVehicleSuccessfulSpawn";
            this.LabelVehicleSuccessfulSpawn.Size = new System.Drawing.Size(111, 28);
            this.LabelVehicleSuccessfulSpawn.TabIndex = 66;
            this.LabelVehicleSuccessfulSpawn.Text = "---";
            this.LabelVehicleSuccessfulSpawn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleSuccessfulSpawnTitle
            // 
            this.LabelVehicleSuccessfulSpawnTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleSuccessfulSpawnTitle.Location = new System.Drawing.Point(368, 103);
            this.LabelVehicleSuccessfulSpawnTitle.Name = "LabelVehicleSuccessfulSpawnTitle";
            this.LabelVehicleSuccessfulSpawnTitle.Size = new System.Drawing.Size(125, 28);
            this.LabelVehicleSuccessfulSpawnTitle.TabIndex = 65;
            this.LabelVehicleSuccessfulSpawnTitle.Text = "Successful Spawn:";
            this.LabelVehicleSuccessfulSpawnTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleActualSpeed
            // 
            this.LabelVehicleActualSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleActualSpeed.Location = new System.Drawing.Point(466, 247);
            this.LabelVehicleActualSpeed.Name = "LabelVehicleActualSpeed";
            this.LabelVehicleActualSpeed.Size = new System.Drawing.Size(136, 28);
            this.LabelVehicleActualSpeed.TabIndex = 64;
            this.LabelVehicleActualSpeed.Text = "---";
            this.LabelVehicleActualSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleActualSpeedTitle
            // 
            this.LabelVehicleActualSpeedTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleActualSpeedTitle.Location = new System.Drawing.Point(368, 247);
            this.LabelVehicleActualSpeedTitle.Name = "LabelVehicleActualSpeedTitle";
            this.LabelVehicleActualSpeedTitle.Size = new System.Drawing.Size(114, 28);
            this.LabelVehicleActualSpeedTitle.TabIndex = 63;
            this.LabelVehicleActualSpeedTitle.Text = "Actual Speed:";
            this.LabelVehicleActualSpeedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleDesiredSpeed
            // 
            this.LabelVehicleDesiredSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleDesiredSpeed.Location = new System.Drawing.Point(466, 223);
            this.LabelVehicleDesiredSpeed.Name = "LabelVehicleDesiredSpeed";
            this.LabelVehicleDesiredSpeed.Size = new System.Drawing.Size(136, 28);
            this.LabelVehicleDesiredSpeed.TabIndex = 62;
            this.LabelVehicleDesiredSpeed.Text = "---";
            this.LabelVehicleDesiredSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleDesiredSpeedTitle
            // 
            this.LabelVehicleDesiredSpeedTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleDesiredSpeedTitle.Location = new System.Drawing.Point(368, 223);
            this.LabelVehicleDesiredSpeedTitle.Name = "LabelVehicleDesiredSpeedTitle";
            this.LabelVehicleDesiredSpeedTitle.Size = new System.Drawing.Size(114, 28);
            this.LabelVehicleDesiredSpeedTitle.TabIndex = 61;
            this.LabelVehicleDesiredSpeedTitle.Text = "Desired Speed:";
            this.LabelVehicleDesiredSpeedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleLength
            // 
            this.LabelVehicleLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleLength.Location = new System.Drawing.Point(415, 81);
            this.LabelVehicleLength.Name = "LabelVehicleLength";
            this.LabelVehicleLength.Size = new System.Drawing.Size(187, 28);
            this.LabelVehicleLength.TabIndex = 60;
            this.LabelVehicleLength.Text = "---";
            this.LabelVehicleLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleLengthTitle
            // 
            this.LabelVehicleLengthTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleLengthTitle.Location = new System.Drawing.Point(368, 81);
            this.LabelVehicleLengthTitle.Name = "LabelVehicleLengthTitle";
            this.LabelVehicleLengthTitle.Size = new System.Drawing.Size(57, 28);
            this.LabelVehicleLengthTitle.TabIndex = 59;
            this.LabelVehicleLengthTitle.Text = "Length:";
            this.LabelVehicleLengthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVehicleType
            // 
            this.LabelVehicleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleType.Location = new System.Drawing.Point(418, 59);
            this.LabelVehicleType.Name = "LabelVehicleType";
            this.LabelVehicleType.Size = new System.Drawing.Size(184, 28);
            this.LabelVehicleType.TabIndex = 58;
            this.LabelVehicleType.Text = "---";
            this.LabelVehicleType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVehicleTypeTitle
            // 
            this.LabelVehicleTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVehicleTypeTitle.Location = new System.Drawing.Point(368, 59);
            this.LabelVehicleTypeTitle.Name = "LabelVehicleTypeTitle";
            this.LabelVehicleTypeTitle.Size = new System.Drawing.Size(47, 28);
            this.LabelVehicleTypeTitle.TabIndex = 57;
            this.LabelVehicleTypeTitle.Text = "Type:";
            this.LabelVehicleTypeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LableVehicleDataTitle
            // 
            this.LableVehicleDataTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LableVehicleDataTitle.Location = new System.Drawing.Point(371, 15);
            this.LableVehicleDataTitle.Name = "LableVehicleDataTitle";
            this.LableVehicleDataTitle.Size = new System.Drawing.Size(231, 22);
            this.LableVehicleDataTitle.TabIndex = 52;
            this.LableVehicleDataTitle.Text = "Selected Vehicle Data";
            this.LableVehicleDataTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelFinishedVehiclesTitle
            // 
            this.LabelFinishedVehiclesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelFinishedVehiclesTitle.Location = new System.Drawing.Point(187, 14);
            this.LabelFinishedVehiclesTitle.Name = "LabelFinishedVehiclesTitle";
            this.LabelFinishedVehiclesTitle.Size = new System.Drawing.Size(159, 22);
            this.LabelFinishedVehiclesTitle.TabIndex = 51;
            this.LabelFinishedVehiclesTitle.Text = "Finished Vehicles";
            this.LabelFinishedVehiclesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TreeViewFinishedVehicles
            // 
            this.TreeViewFinishedVehicles.Location = new System.Drawing.Point(187, 39);
            this.TreeViewFinishedVehicles.Name = "TreeViewFinishedVehicles";
            this.TreeViewFinishedVehicles.Size = new System.Drawing.Size(159, 315);
            this.TreeViewFinishedVehicles.TabIndex = 50;
            this.TreeViewFinishedVehicles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNodeVehicleSelected);
            // 
            // LabelVehiclesTitle
            // 
            this.LabelVehiclesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LabelVehiclesTitle.Location = new System.Drawing.Point(13, 14);
            this.LabelVehiclesTitle.Name = "LabelVehiclesTitle";
            this.LabelVehiclesTitle.Size = new System.Drawing.Size(159, 22);
            this.LabelVehiclesTitle.TabIndex = 49;
            this.LabelVehiclesTitle.Text = "Vehicles";
            this.LabelVehiclesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TreeViewVehicles
            // 
            this.TreeViewVehicles.Location = new System.Drawing.Point(13, 39);
            this.TreeViewVehicles.Name = "TreeViewVehicles";
            this.TreeViewVehicles.Size = new System.Drawing.Size(159, 315);
            this.TreeViewVehicles.TabIndex = 8;
            this.TreeViewVehicles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNodeVehicleSelected);
            // 
            // ButtonStop
            // 
            this.ButtonStop.BackColor = System.Drawing.Color.Transparent;
            this.ButtonStop.BackgroundImage = global::MotorwaySimulator.Properties.Resources.Stop_Icon;
            this.ButtonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStop.Enabled = false;
            this.ButtonStop.Location = new System.Drawing.Point(114, 3);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(47, 47);
            this.ButtonStop.TabIndex = 2;
            this.ButtonStop.UseVisualStyleBackColor = false;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.BackColor = System.Drawing.Color.Transparent;
            this.ButtonStart.BackgroundImage = global::MotorwaySimulator.Properties.Resources.Play_Icon;
            this.ButtonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonStart.Location = new System.Drawing.Point(3, 3);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(47, 47);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.UseVisualStyleBackColor = false;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // MotorwaySimulatorForm
            // 
            this.AcceptButton = this.ButtonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this.ButtonPause;
            this.ClientSize = new System.Drawing.Size(1165, 473);
            this.Controls.Add(this.Road);
            this.Controls.Add(this.PanelSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MotorwaySimulatorForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Motorway Simulator";
            this.Load += new System.EventHandler(this.MotorwaySimulator_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FormScrolled);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTimescale)).EndInit();
            this.PanelSettings.ResumeLayout(false);
            this.PanelSettings.PerformLayout();
            this.TabControlControlPanel.ResumeLayout(false);
            this.TabPageSetup.ResumeLayout(false);
            this.TabPageSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericMildCongestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericSevereCongestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarMaximumLane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVMaximumLane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVMaximumLane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusMaximumLane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarSpawnProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVSpawnProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVSpawnProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusSpawnProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarLaneCount)).EndInit();
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
        private System.Windows.Forms.Label LabelTimescaleTitle;
        private System.Windows.Forms.Label LabelTimeScale;
        private System.Windows.Forms.Label LabelVehiclesTitle;
        private System.Windows.Forms.Label LabelLaneCountTitle;
        private System.Windows.Forms.Label LabelLaneCount;
        private System.Windows.Forms.TrackBar TrackBarLaneCount;
        private System.Windows.Forms.Label LabelSpawnProbabilityUnitTitle;
        private System.Windows.Forms.NumericUpDown NumericCarSpawnProbability;
        private System.Windows.Forms.NumericUpDown NumericLGVSpawnProbability;
        private System.Windows.Forms.NumericUpDown NumericHGVSpawnProbability;
        private System.Windows.Forms.Label LabelSpawnProbabilityTitle;
        private System.Windows.Forms.NumericUpDown NumericBusSpawnProbability;
        private System.Windows.Forms.Label LabelSpawnProbabilityUnassigned;
        private System.Windows.Forms.NumericUpDown NumericCarMaximumLane;
        private System.Windows.Forms.NumericUpDown NumericLGVMaximumLane;
        private System.Windows.Forms.NumericUpDown NumericHGVMaximumLane;
        private System.Windows.Forms.Label LabelMaximumLaneTitle;
        private System.Windows.Forms.NumericUpDown NumericBusMaximumLane;
        private System.Windows.Forms.Label LabelMaximumLaneUnitTitle;
        private System.Windows.Forms.Label LabelFinishedVehiclesTitle;
        private System.Windows.Forms.TreeView TreeViewFinishedVehicles;
        private System.Windows.Forms.Label LableVehicleDataTitle;
        private System.Windows.Forms.Label LabelVehicleType;
        private System.Windows.Forms.Label LabelVehicleTypeTitle;
        private System.Windows.Forms.Label LabelVehicleLength;
        private System.Windows.Forms.Label LabelVehicleLengthTitle;
        private System.Windows.Forms.Label LabelVehicleDesiredSpeed;
        private System.Windows.Forms.Label LabelVehicleDesiredSpeedTitle;
        private System.Windows.Forms.Label LabelVehicleActualSpeed;
        private System.Windows.Forms.Label LabelVehicleActualSpeedTitle;
        private System.Windows.Forms.Label LabelVehicleSuccessfulSpawnTitle;
        private System.Windows.Forms.Label LabelVehicleSuccessfulSpawn;
        private System.Windows.Forms.Label LabelVehicleSpawnTime;
        private System.Windows.Forms.Label LabelVehicleSpawnTimeTitle;
        private System.Windows.Forms.Label LabelVehicleDespawnTime;
        private System.Windows.Forms.Label LabelVehicleDespawnTimeTitle;
        private System.Windows.Forms.Label LabelVehicleProgress;
        private System.Windows.Forms.Label LabelVehicleProgressTitle;
        private System.Windows.Forms.Label LabelVehicleAverageSpeed;
        private System.Windows.Forms.Label LabelVehicleAverageSpeedTitle;
        private System.Windows.Forms.Label LabelVehicleLifetime;
        private System.Windows.Forms.Label LabelVehicleLifetimeTitle;
        private System.Windows.Forms.Label LabelVehicleID;
        private System.Windows.Forms.Label LabelVehicleIDTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumericMildCongestion;
        private System.Windows.Forms.NumericUpDown NumericSevereCongestion;
        private System.Windows.Forms.Label LabelCongestionTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LabelVehicleCongestion;
        private System.Windows.Forms.Label LabelVehicleCongestionTitle;
        private System.Windows.Forms.Button ButtonFindVehicle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelAllVehiclesHGVPercent;
        private System.Windows.Forms.Label LabelAllVehiclesHGVPercentTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalVehicles;
        private System.Windows.Forms.Label LabelAllVehiclesTotalVehiclesTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalLGV;
        private System.Windows.Forms.Label LabelAllVehiclesTotalLGVTitle;
        private System.Windows.Forms.Label LabelAllVehiclesLGVPercent;
        private System.Windows.Forms.Label LabelAllVehiclesLGVPercentTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalHGV;
        private System.Windows.Forms.Label LabelAllVehiclesTotalHGVTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalCar;
        private System.Windows.Forms.Label LabelAllVehiclesTotalCarTitle;
        private System.Windows.Forms.Label LabelAllVehiclesFailedSpawnsPercent;
        private System.Windows.Forms.Label LabelAllVehiclesFailedSpawnsPercentTitle;
        private System.Windows.Forms.Label LabelAllVehiclesSuccessfulSpawnsPercent;
        private System.Windows.Forms.Label LabelAllVehiclesSuccessfulSpawnsPercentTitle;
        private System.Windows.Forms.Label LabelAllVehiclesCarPercent;
        private System.Windows.Forms.Label LabelAllVehiclesCarPercentTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalBus;
        private System.Windows.Forms.Label LabelAllVehiclesTotalBusTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalFailedSpawns;
        private System.Windows.Forms.Label LabelAllVehiclesTotalFailedSpawnsTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalSuccessfulSpawns;
        private System.Windows.Forms.Label LabelAllVehiclesTotalSuccessfulSpawnsTitle;
        private System.Windows.Forms.Label LabelAllVehiclesBusPercent;
        private System.Windows.Forms.Label LabelAllVehiclesBusPercentTitle;
        private System.Windows.Forms.Label LabelAllVehiclesSeverelyCongestedPercent;
        private System.Windows.Forms.Label LabelAllVehiclesSeverelyCongestedPercentTitle;
        private System.Windows.Forms.Label LabelAllVehiclesMildlyCongestedPercent;
        private System.Windows.Forms.Label LabelAllVehiclesMildlyCongestedPercentTitle;
        private System.Windows.Forms.Label LabelAllVehiclesNotCongestedPercent;
        private System.Windows.Forms.Label LabelAllVehiclesNotCongestedPercentTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalSeverelyCongested;
        private System.Windows.Forms.Label LabelAllVehiclesTotalSeverelyCongestedTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalMildlyCongested;
        private System.Windows.Forms.Label LabelAllVehiclesTotalMildlyCongestedTitle;
        private System.Windows.Forms.Label LabelAllVehiclesTotalNotCongested;
        private System.Windows.Forms.Label LabelAllVehiclesTotalNotCongestedTitle;
    }
}

