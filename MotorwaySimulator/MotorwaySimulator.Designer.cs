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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.LabelData2 = new System.Windows.Forms.Label();
            this.LabelData3 = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormTick
            // 
            this.FormTick.Enabled = true;
            this.FormTick.Interval = 15;
            this.FormTick.Tick += new System.EventHandler(this.FormTick_Tick);
            // 
            // Road
            // 
            this.Road.BackColor = System.Drawing.SystemColors.Control;
            this.Road.Location = new System.Drawing.Point(0, 0);
            this.Road.Name = "Road";
            this.Road.Size = new System.Drawing.Size(100, 900);
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
            this.ButtonPause.Location = new System.Drawing.Point(24, 278);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(120, 41);
            this.ButtonPause.TabIndex = 2;
            this.ButtonPause.Text = "Pause";
            this.ButtonPause.UseVisualStyleBackColor = true;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // ButtonResume
            // 
            this.ButtonResume.Location = new System.Drawing.Point(24, 325);
            this.ButtonResume.Name = "ButtonResume";
            this.ButtonResume.Size = new System.Drawing.Size(120, 41);
            this.ButtonResume.TabIndex = 3;
            this.ButtonResume.Text = "Resume";
            this.ButtonResume.UseVisualStyleBackColor = true;
            this.ButtonResume.Click += new System.EventHandler(this.ButtonResume_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(24, 372);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(120, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // LabelData2
            // 
            this.LabelData2.AutoSize = true;
            this.LabelData2.Location = new System.Drawing.Point(59, 420);
            this.LabelData2.Name = "LabelData2";
            this.LabelData2.Size = new System.Drawing.Size(35, 13);
            this.LabelData2.TabIndex = 5;
            this.LabelData2.Text = "label1";
            // 
            // LabelData3
            // 
            this.LabelData3.AutoSize = true;
            this.LabelData3.Location = new System.Drawing.Point(59, 447);
            this.LabelData3.Name = "LabelData3";
            this.LabelData3.Size = new System.Drawing.Size(13, 13);
            this.LabelData3.TabIndex = 6;
            this.LabelData3.Text = "0";
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.LabelData3);
            this.Panel.Controls.Add(this.TextBoxData);
            this.Panel.Controls.Add(this.LabelData2);
            this.Panel.Controls.Add(this.ButtonPause);
            this.Panel.Controls.Add(this.trackBar1);
            this.Panel.Controls.Add(this.ButtonResume);
            this.Panel.Location = new System.Drawing.Point(283, 44);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(175, 474);
            this.Panel.TabIndex = 7;
            // 
            // MotorwaySimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(501, 900);
            this.Controls.Add(this.Road);
            this.Controls.Add(this.Panel);
            this.Name = "MotorwaySimulator";
            this.Text = "Motorway Simulator";
            this.Load += new System.EventHandler(this.MotorwaySimulator_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.formScrolled);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer FormTick;
        private System.Windows.Forms.Panel Road;
        private System.Windows.Forms.TextBox TextBoxData;
        private System.Windows.Forms.Button ButtonPause;
        private System.Windows.Forms.Button ButtonResume;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label LabelData2;
        private System.Windows.Forms.Label LabelData3;
        private System.Windows.Forms.Panel Panel;
    }
}

