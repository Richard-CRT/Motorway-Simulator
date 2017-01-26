namespace MotorwaySimulator
{
    partial class MotorwaySimulator
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
            this.TextBoxData = new System.Windows.Forms.TextBox();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.ButtonResume = new System.Windows.Forms.Button();
            this.TrackBarTimescale = new System.Windows.Forms.TrackBar();
            this.LabelData2 = new System.Windows.Forms.Label();
            this.LabelData3 = new System.Windows.Forms.Label();
            this.PanelSettings = new System.Windows.Forms.Panel();
            this.CheckBoxTrackVehicle = new System.Windows.Forms.CheckBox();
            this.NumericVehicleId = new System.Windows.Forms.NumericUpDown();
            this.NumericBusDesiredSpeedVar = new System.Windows.Forms.NumericUpDown();
            this.NumericBusDesiredSpeed = new System.Windows.Forms.NumericUpDown();
            this.NumericBusLengthVar = new System.Windows.Forms.NumericUpDown();
            this.NumericBusLength = new System.Windows.Forms.NumericUpDown();
            this.LableBusTitle = new System.Windows.Forms.Label();
            this.NumericHGVDesiredSpeedVar = new System.Windows.Forms.NumericUpDown();
            this.NumericHGVDesiredSpeed = new System.Windows.Forms.NumericUpDown();
            this.NumericHGVLengthVar = new System.Windows.Forms.NumericUpDown();
            this.NumericHGVLength = new System.Windows.Forms.NumericUpDown();
            this.LabelHGVTitle = new System.Windows.Forms.Label();
            this.NumericLGVDesiredSpeedVar = new System.Windows.Forms.NumericUpDown();
            this.NumericLGVDesiredSpeed = new System.Windows.Forms.NumericUpDown();
            this.NumericLGVLengthVar = new System.Windows.Forms.NumericUpDown();
            this.NumericLGVLength = new System.Windows.Forms.NumericUpDown();
            this.LabelLGVTitle = new System.Windows.Forms.Label();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.NumericCarDesiredSpeedVar = new System.Windows.Forms.NumericUpDown();
            this.NumericCarDesiredSpeed = new System.Windows.Forms.NumericUpDown();
            this.NumericCarLengthVar = new System.Windows.Forms.NumericUpDown();
            this.NumericCarLength = new System.Windows.Forms.NumericUpDown();
            this.LabelCarTitle = new System.Windows.Forms.Label();
            this.LabelVehicleCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTimescale)).BeginInit();
            this.PanelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericVehicleId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusDesiredSpeedVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusDesiredSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusLengthVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVDesiredSpeedVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVDesiredSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVLengthVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVDesiredSpeedVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVDesiredSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVLengthVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarDesiredSpeedVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarDesiredSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarLengthVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarLength)).BeginInit();
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
            this.Road.Location = new System.Drawing.Point(0, 0);
            this.Road.Name = "Road";
            this.Road.Size = new System.Drawing.Size(100, 100);
            this.Road.TabIndex = 0;
            // 
            // TextBoxData
            // 
            this.TextBoxData.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxData.Location = new System.Drawing.Point(14, 12);
            this.TextBoxData.Multiline = true;
            this.TextBoxData.Name = "TextBoxData";
            this.TextBoxData.ReadOnly = true;
            this.TextBoxData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxData.Size = new System.Drawing.Size(148, 260);
            this.TextBoxData.TabIndex = 1;
            // 
            // ButtonPause
            // 
            this.ButtonPause.Location = new System.Drawing.Point(168, 157);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(120, 41);
            this.ButtonPause.TabIndex = 2;
            this.ButtonPause.Text = "Pause";
            this.ButtonPause.UseVisualStyleBackColor = true;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // ButtonResume
            // 
            this.ButtonResume.Location = new System.Drawing.Point(168, 111);
            this.ButtonResume.Name = "ButtonResume";
            this.ButtonResume.Size = new System.Drawing.Size(120, 41);
            this.ButtonResume.TabIndex = 3;
            this.ButtonResume.Text = "Resume";
            this.ButtonResume.UseVisualStyleBackColor = true;
            this.ButtonResume.Click += new System.EventHandler(this.ButtonResume_Click);
            // 
            // TrackBarTimescale
            // 
            this.TrackBarTimescale.LargeChange = 10;
            this.TrackBarTimescale.Location = new System.Drawing.Point(168, 212);
            this.TrackBarTimescale.Minimum = 1;
            this.TrackBarTimescale.Name = "TrackBarTimescale";
            this.TrackBarTimescale.Size = new System.Drawing.Size(120, 45);
            this.TrackBarTimescale.TabIndex = 4;
            this.TrackBarTimescale.Value = 10;
            this.TrackBarTimescale.Scroll += new System.EventHandler(this.TrackBarTimescale_Scroll);
            // 
            // LabelData2
            // 
            this.LabelData2.AutoSize = true;
            this.LabelData2.Location = new System.Drawing.Point(294, 12);
            this.LabelData2.Name = "LabelData2";
            this.LabelData2.Size = new System.Drawing.Size(35, 13);
            this.LabelData2.TabIndex = 5;
            this.LabelData2.Text = "label1";
            // 
            // LabelData3
            // 
            this.LabelData3.AutoSize = true;
            this.LabelData3.Location = new System.Drawing.Point(294, 26);
            this.LabelData3.Name = "LabelData3";
            this.LabelData3.Size = new System.Drawing.Size(13, 13);
            this.LabelData3.TabIndex = 6;
            this.LabelData3.Text = "0";
            // 
            // PanelSettings
            // 
            this.PanelSettings.Controls.Add(this.CheckBoxTrackVehicle);
            this.PanelSettings.Controls.Add(this.NumericVehicleId);
            this.PanelSettings.Controls.Add(this.NumericBusDesiredSpeedVar);
            this.PanelSettings.Controls.Add(this.NumericBusDesiredSpeed);
            this.PanelSettings.Controls.Add(this.NumericBusLengthVar);
            this.PanelSettings.Controls.Add(this.NumericBusLength);
            this.PanelSettings.Controls.Add(this.LableBusTitle);
            this.PanelSettings.Controls.Add(this.NumericHGVDesiredSpeedVar);
            this.PanelSettings.Controls.Add(this.NumericHGVDesiredSpeed);
            this.PanelSettings.Controls.Add(this.NumericHGVLengthVar);
            this.PanelSettings.Controls.Add(this.NumericHGVLength);
            this.PanelSettings.Controls.Add(this.LabelHGVTitle);
            this.PanelSettings.Controls.Add(this.NumericLGVDesiredSpeedVar);
            this.PanelSettings.Controls.Add(this.NumericLGVDesiredSpeed);
            this.PanelSettings.Controls.Add(this.NumericLGVLengthVar);
            this.PanelSettings.Controls.Add(this.NumericLGVLength);
            this.PanelSettings.Controls.Add(this.LabelLGVTitle);
            this.PanelSettings.Controls.Add(this.ButtonStop);
            this.PanelSettings.Controls.Add(this.ButtonStart);
            this.PanelSettings.Controls.Add(this.NumericCarDesiredSpeedVar);
            this.PanelSettings.Controls.Add(this.NumericCarDesiredSpeed);
            this.PanelSettings.Controls.Add(this.NumericCarLengthVar);
            this.PanelSettings.Controls.Add(this.NumericCarLength);
            this.PanelSettings.Controls.Add(this.LabelCarTitle);
            this.PanelSettings.Controls.Add(this.LabelVehicleCount);
            this.PanelSettings.Controls.Add(this.LabelData3);
            this.PanelSettings.Controls.Add(this.TextBoxData);
            this.PanelSettings.Controls.Add(this.LabelData2);
            this.PanelSettings.Controls.Add(this.ButtonPause);
            this.PanelSettings.Controls.Add(this.TrackBarTimescale);
            this.PanelSettings.Controls.Add(this.ButtonResume);
            this.PanelSettings.Location = new System.Drawing.Point(12, 287);
            this.PanelSettings.Name = "PanelSettings";
            this.PanelSettings.Size = new System.Drawing.Size(874, 285);
            this.PanelSettings.TabIndex = 7;
            // 
            // CheckBoxTrackVehicle
            // 
            this.CheckBoxTrackVehicle.AutoSize = true;
            this.CheckBoxTrackVehicle.Location = new System.Drawing.Point(706, 64);
            this.CheckBoxTrackVehicle.Name = "CheckBoxTrackVehicle";
            this.CheckBoxTrackVehicle.Size = new System.Drawing.Size(54, 17);
            this.CheckBoxTrackVehicle.TabIndex = 32;
            this.CheckBoxTrackVehicle.Text = "Track";
            this.CheckBoxTrackVehicle.UseVisualStyleBackColor = true;
            // 
            // NumericVehicleId
            // 
            this.NumericVehicleId.Location = new System.Drawing.Point(706, 37);
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
            // NumericBusDesiredSpeedVar
            // 
            this.NumericBusDesiredSpeedVar.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericBusDesiredSpeedVar.Location = new System.Drawing.Point(542, 235);
            this.NumericBusDesiredSpeedVar.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.NumericBusDesiredSpeedVar.Name = "NumericBusDesiredSpeedVar";
            this.NumericBusDesiredSpeedVar.Size = new System.Drawing.Size(120, 20);
            this.NumericBusDesiredSpeedVar.TabIndex = 29;
            this.NumericBusDesiredSpeedVar.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // NumericBusDesiredSpeed
            // 
            this.NumericBusDesiredSpeed.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericBusDesiredSpeed.Location = new System.Drawing.Point(542, 209);
            this.NumericBusDesiredSpeed.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.NumericBusDesiredSpeed.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericBusDesiredSpeed.Name = "NumericBusDesiredSpeed";
            this.NumericBusDesiredSpeed.Size = new System.Drawing.Size(120, 20);
            this.NumericBusDesiredSpeed.TabIndex = 28;
            this.NumericBusDesiredSpeed.Value = new decimal(new int[] {
            96000,
            0,
            0,
            0});
            // 
            // NumericBusLengthVar
            // 
            this.NumericBusLengthVar.DecimalPlaces = 1;
            this.NumericBusLengthVar.Location = new System.Drawing.Point(542, 183);
            this.NumericBusLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericBusLengthVar.Name = "NumericBusLengthVar";
            this.NumericBusLengthVar.Size = new System.Drawing.Size(120, 20);
            this.NumericBusLengthVar.TabIndex = 27;
            this.NumericBusLengthVar.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // NumericBusLength
            // 
            this.NumericBusLength.DecimalPlaces = 1;
            this.NumericBusLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericBusLength.Location = new System.Drawing.Point(542, 157);
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
            this.NumericBusLength.Size = new System.Drawing.Size(120, 20);
            this.NumericBusLength.TabIndex = 26;
            this.NumericBusLength.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // LableBusTitle
            // 
            this.LableBusTitle.AutoSize = true;
            this.LableBusTitle.Location = new System.Drawing.Point(539, 139);
            this.LableBusTitle.Name = "LableBusTitle";
            this.LableBusTitle.Size = new System.Drawing.Size(25, 13);
            this.LableBusTitle.TabIndex = 25;
            this.LableBusTitle.Text = "Bus";
            // 
            // NumericHGVDesiredSpeedVar
            // 
            this.NumericHGVDesiredSpeedVar.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeedVar.Location = new System.Drawing.Point(417, 235);
            this.NumericHGVDesiredSpeedVar.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeedVar.Name = "NumericHGVDesiredSpeedVar";
            this.NumericHGVDesiredSpeedVar.Size = new System.Drawing.Size(120, 20);
            this.NumericHGVDesiredSpeedVar.TabIndex = 24;
            this.NumericHGVDesiredSpeedVar.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // NumericHGVDesiredSpeed
            // 
            this.NumericHGVDesiredSpeed.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeed.Location = new System.Drawing.Point(417, 209);
            this.NumericHGVDesiredSpeed.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeed.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericHGVDesiredSpeed.Name = "NumericHGVDesiredSpeed";
            this.NumericHGVDesiredSpeed.Size = new System.Drawing.Size(120, 20);
            this.NumericHGVDesiredSpeed.TabIndex = 23;
            this.NumericHGVDesiredSpeed.Value = new decimal(new int[] {
            96000,
            0,
            0,
            0});
            // 
            // NumericHGVLengthVar
            // 
            this.NumericHGVLengthVar.DecimalPlaces = 1;
            this.NumericHGVLengthVar.Location = new System.Drawing.Point(417, 183);
            this.NumericHGVLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericHGVLengthVar.Name = "NumericHGVLengthVar";
            this.NumericHGVLengthVar.Size = new System.Drawing.Size(120, 20);
            this.NumericHGVLengthVar.TabIndex = 22;
            this.NumericHGVLengthVar.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // NumericHGVLength
            // 
            this.NumericHGVLength.DecimalPlaces = 1;
            this.NumericHGVLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericHGVLength.Location = new System.Drawing.Point(417, 157);
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
            this.NumericHGVLength.Size = new System.Drawing.Size(120, 20);
            this.NumericHGVLength.TabIndex = 21;
            this.NumericHGVLength.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // LabelHGVTitle
            // 
            this.LabelHGVTitle.AutoSize = true;
            this.LabelHGVTitle.Location = new System.Drawing.Point(414, 139);
            this.LabelHGVTitle.Name = "LabelHGVTitle";
            this.LabelHGVTitle.Size = new System.Drawing.Size(30, 13);
            this.LabelHGVTitle.TabIndex = 20;
            this.LabelHGVTitle.Text = "HGV";
            // 
            // NumericLGVDesiredSpeedVar
            // 
            this.NumericLGVDesiredSpeedVar.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeedVar.Location = new System.Drawing.Point(542, 111);
            this.NumericLGVDesiredSpeedVar.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeedVar.Name = "NumericLGVDesiredSpeedVar";
            this.NumericLGVDesiredSpeedVar.Size = new System.Drawing.Size(120, 20);
            this.NumericLGVDesiredSpeedVar.TabIndex = 19;
            this.NumericLGVDesiredSpeedVar.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // NumericLGVDesiredSpeed
            // 
            this.NumericLGVDesiredSpeed.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeed.Location = new System.Drawing.Point(542, 85);
            this.NumericLGVDesiredSpeed.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeed.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericLGVDesiredSpeed.Name = "NumericLGVDesiredSpeed";
            this.NumericLGVDesiredSpeed.Size = new System.Drawing.Size(120, 20);
            this.NumericLGVDesiredSpeed.TabIndex = 18;
            this.NumericLGVDesiredSpeed.Value = new decimal(new int[] {
            112000,
            0,
            0,
            0});
            // 
            // NumericLGVLengthVar
            // 
            this.NumericLGVLengthVar.DecimalPlaces = 1;
            this.NumericLGVLengthVar.Location = new System.Drawing.Point(542, 59);
            this.NumericLGVLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericLGVLengthVar.Name = "NumericLGVLengthVar";
            this.NumericLGVLengthVar.Size = new System.Drawing.Size(120, 20);
            this.NumericLGVLengthVar.TabIndex = 17;
            this.NumericLGVLengthVar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumericLGVLength
            // 
            this.NumericLGVLength.DecimalPlaces = 1;
            this.NumericLGVLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericLGVLength.Location = new System.Drawing.Point(542, 33);
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
            this.NumericLGVLength.Size = new System.Drawing.Size(120, 20);
            this.NumericLGVLength.TabIndex = 16;
            this.NumericLGVLength.Value = new decimal(new int[] {
            55,
            0,
            0,
            65536});
            // 
            // LabelLGVTitle
            // 
            this.LabelLGVTitle.AutoSize = true;
            this.LabelLGVTitle.Location = new System.Drawing.Point(539, 15);
            this.LabelLGVTitle.Name = "LabelLGVTitle";
            this.LabelLGVTitle.Size = new System.Drawing.Size(28, 13);
            this.LabelLGVTitle.TabIndex = 15;
            this.LabelLGVTitle.Text = "LGV";
            // 
            // ButtonStop
            // 
            this.ButtonStop.Enabled = false;
            this.ButtonStop.Location = new System.Drawing.Point(168, 64);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(120, 41);
            this.ButtonStop.TabIndex = 14;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(168, 17);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(120, 41);
            this.ButtonStart.TabIndex = 13;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // NumericCarDesiredSpeedVar
            // 
            this.NumericCarDesiredSpeedVar.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericCarDesiredSpeedVar.Location = new System.Drawing.Point(417, 111);
            this.NumericCarDesiredSpeedVar.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.NumericCarDesiredSpeedVar.Name = "NumericCarDesiredSpeedVar";
            this.NumericCarDesiredSpeedVar.Size = new System.Drawing.Size(120, 20);
            this.NumericCarDesiredSpeedVar.TabIndex = 12;
            this.NumericCarDesiredSpeedVar.Value = new decimal(new int[] {
            16000,
            0,
            0,
            0});
            // 
            // NumericCarDesiredSpeed
            // 
            this.NumericCarDesiredSpeed.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericCarDesiredSpeed.Location = new System.Drawing.Point(417, 85);
            this.NumericCarDesiredSpeed.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.NumericCarDesiredSpeed.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericCarDesiredSpeed.Name = "NumericCarDesiredSpeed";
            this.NumericCarDesiredSpeed.Size = new System.Drawing.Size(120, 20);
            this.NumericCarDesiredSpeed.TabIndex = 11;
            this.NumericCarDesiredSpeed.Value = new decimal(new int[] {
            112000,
            0,
            0,
            0});
            // 
            // NumericCarLengthVar
            // 
            this.NumericCarLengthVar.DecimalPlaces = 1;
            this.NumericCarLengthVar.Location = new System.Drawing.Point(417, 59);
            this.NumericCarLengthVar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericCarLengthVar.Name = "NumericCarLengthVar";
            this.NumericCarLengthVar.Size = new System.Drawing.Size(120, 20);
            this.NumericCarLengthVar.TabIndex = 10;
            this.NumericCarLengthVar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumericCarLength
            // 
            this.NumericCarLength.DecimalPlaces = 1;
            this.NumericCarLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericCarLength.Location = new System.Drawing.Point(417, 33);
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
            this.NumericCarLength.Size = new System.Drawing.Size(120, 20);
            this.NumericCarLength.TabIndex = 9;
            this.NumericCarLength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // LabelCarTitle
            // 
            this.LabelCarTitle.AutoSize = true;
            this.LabelCarTitle.Location = new System.Drawing.Point(414, 15);
            this.LabelCarTitle.Name = "LabelCarTitle";
            this.LabelCarTitle.Size = new System.Drawing.Size(23, 13);
            this.LabelCarTitle.TabIndex = 8;
            this.LabelCarTitle.Text = "Car";
            // 
            // LabelVehicleCount
            // 
            this.LabelVehicleCount.AutoSize = true;
            this.LabelVehicleCount.Location = new System.Drawing.Point(294, 40);
            this.LabelVehicleCount.Name = "LabelVehicleCount";
            this.LabelVehicleCount.Size = new System.Drawing.Size(35, 13);
            this.LabelVehicleCount.TabIndex = 7;
            this.LabelVehicleCount.Text = "label1";
            // 
            // MotorwaySimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1120, 594);
            this.Controls.Add(this.Road);
            this.Controls.Add(this.PanelSettings);
            this.Name = "MotorwaySimulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Motorway Simulator";
            this.Load += new System.EventHandler(this.MotorwaySimulator_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FormScrolled);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTimescale)).EndInit();
            this.PanelSettings.ResumeLayout(false);
            this.PanelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericVehicleId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusDesiredSpeedVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusDesiredSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusLengthVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBusLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVDesiredSpeedVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVDesiredSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVLengthVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHGVLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVDesiredSpeedVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVDesiredSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVLengthVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLGVLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarDesiredSpeedVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarDesiredSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarLengthVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCarLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer FormTick;
        private System.Windows.Forms.Panel Road;
        private System.Windows.Forms.TextBox TextBoxData;
        private System.Windows.Forms.Button ButtonPause;
        private System.Windows.Forms.Button ButtonResume;
        private System.Windows.Forms.TrackBar TrackBarTimescale;
        private System.Windows.Forms.Label LabelData2;
        private System.Windows.Forms.Label LabelData3;
        private System.Windows.Forms.Panel PanelSettings;
        private System.Windows.Forms.Label LabelVehicleCount;
        private System.Windows.Forms.Label LabelCarTitle;
        private System.Windows.Forms.NumericUpDown NumericCarLength;
        private System.Windows.Forms.NumericUpDown NumericCarLengthVar;
        private System.Windows.Forms.NumericUpDown NumericCarDesiredSpeed;
        private System.Windows.Forms.NumericUpDown NumericCarDesiredSpeedVar;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.NumericUpDown NumericLGVDesiredSpeedVar;
        private System.Windows.Forms.NumericUpDown NumericLGVDesiredSpeed;
        private System.Windows.Forms.NumericUpDown NumericLGVLengthVar;
        private System.Windows.Forms.NumericUpDown NumericLGVLength;
        private System.Windows.Forms.Label LabelLGVTitle;
        private System.Windows.Forms.NumericUpDown NumericBusDesiredSpeedVar;
        private System.Windows.Forms.NumericUpDown NumericBusDesiredSpeed;
        private System.Windows.Forms.NumericUpDown NumericBusLengthVar;
        private System.Windows.Forms.NumericUpDown NumericBusLength;
        private System.Windows.Forms.Label LableBusTitle;
        private System.Windows.Forms.NumericUpDown NumericHGVDesiredSpeedVar;
        private System.Windows.Forms.NumericUpDown NumericHGVDesiredSpeed;
        private System.Windows.Forms.NumericUpDown NumericHGVLengthVar;
        private System.Windows.Forms.NumericUpDown NumericHGVLength;
        private System.Windows.Forms.Label LabelHGVTitle;
        public System.Windows.Forms.NumericUpDown NumericVehicleId;
        public System.Windows.Forms.CheckBox CheckBoxTrackVehicle;
    }
}

