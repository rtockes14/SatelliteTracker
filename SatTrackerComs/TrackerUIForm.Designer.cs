namespace SatTrackerComs
{
    partial class TrackerUIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackerUIForm));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Home = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.userLatitudeLabel = new System.Windows.Forms.Label();
            this.userLongitudeLabel = new System.Windows.Forms.Label();
            this.currentlyTrackingLabel = new System.Windows.Forms.Label();
            this.satelliteLabel = new System.Windows.Forms.Label();
            this.userLatitudeBox = new System.Windows.Forms.TextBox();
            this.savedLocationDropDown = new System.Windows.Forms.ComboBox();
            this.userSavedLocationLabel = new System.Windows.Forms.Label();
            this.savedSatsListBox = new System.Windows.Forms.ListBox();
            this.userLongitudeBox = new System.Windows.Forms.TextBox();
            this.newSatelliteIDLabel = new System.Windows.Forms.Label();
            this.newSatelliteIDBox = new System.Windows.Forms.TextBox();
            this.addSatelliteIDButton = new System.Windows.Forms.Button();
            this.satelliteLatitudeLabel = new System.Windows.Forms.Label();
            this.satelliteLatitudeActual = new System.Windows.Forms.Label();
            this.satelliteLongitudeActual = new System.Windows.Forms.Label();
            this.satelliteLongitudeLabel = new System.Windows.Forms.Label();
            this.satelliteAltitudeActual = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.satelliteElevationActual = new System.Windows.Forms.Label();
            this.satelliteElevationLabel = new System.Windows.Forms.Label();
            this.satelliteAzimuthActual = new System.Windows.Forms.Label();
            this.satelliteAzimuthLabel = new System.Windows.Forms.Label();
            this.saveUserLocationLabel = new System.Windows.Forms.Label();
            this.saveUserLocationButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.locationNameBox = new System.Windows.Forms.TextBox();
            this.locationNameLabel = new System.Windows.Forms.Label();
            this.userAltitudeLabel = new System.Windows.Forms.Label();
            this.userAltitudeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM10";
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(90, 647);
            this.Home.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(135, 46);
            this.Home.TabIndex = 0;
            this.Home.Text = "HOME";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(380, 647);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "CW";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(522, 647);
            this.button4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 46);
            this.button4.TabIndex = 4;
            this.button4.Text = "ELEV UP";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(667, 647);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "ELEV DWN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(235, 647);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 46);
            this.button2.TabIndex = 7;
            this.button2.Text = "CCW";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // userLatitudeLabel
            // 
            this.userLatitudeLabel.AutoSize = true;
            this.userLatitudeLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.userLatitudeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userLatitudeLabel.Location = new System.Drawing.Point(86, 422);
            this.userLatitudeLabel.Name = "userLatitudeLabel";
            this.userLatitudeLabel.Size = new System.Drawing.Size(183, 30);
            this.userLatitudeLabel.TabIndex = 8;
            this.userLatitudeLabel.Text = "USER LATITUDE:";
            this.userLatitudeLabel.Click += new System.EventHandler(this.userLatitudeLabel_Click);
            // 
            // userLongitudeLabel
            // 
            this.userLongitudeLabel.AutoSize = true;
            this.userLongitudeLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.userLongitudeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userLongitudeLabel.Location = new System.Drawing.Point(69, 469);
            this.userLongitudeLabel.Name = "userLongitudeLabel";
            this.userLongitudeLabel.Size = new System.Drawing.Size(207, 30);
            this.userLongitudeLabel.TabIndex = 9;
            this.userLongitudeLabel.Text = "USER LONGITUDE:";
            this.userLongitudeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // currentlyTrackingLabel
            // 
            this.currentlyTrackingLabel.AutoSize = true;
            this.currentlyTrackingLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 24F);
            this.currentlyTrackingLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentlyTrackingLabel.Location = new System.Drawing.Point(60, 36);
            this.currentlyTrackingLabel.Name = "currentlyTrackingLabel";
            this.currentlyTrackingLabel.Size = new System.Drawing.Size(544, 62);
            this.currentlyTrackingLabel.TabIndex = 10;
            this.currentlyTrackingLabel.Text = "CURRENTLY TRACKING: ";
            // 
            // satelliteLabel
            // 
            this.satelliteLabel.AutoSize = true;
            this.satelliteLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 24F);
            this.satelliteLabel.ForeColor = System.Drawing.Color.Lime;
            this.satelliteLabel.Location = new System.Drawing.Point(429, 36);
            this.satelliteLabel.Name = "satelliteLabel";
            this.satelliteLabel.Size = new System.Drawing.Size(200, 62);
            this.satelliteLabel.TabIndex = 11;
            this.satelliteLabel.Text = "<none>";
            this.satelliteLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // userLatitudeBox
            // 
            this.userLatitudeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.userLatitudeBox.Location = new System.Drawing.Point(231, 414);
            this.userLatitudeBox.Name = "userLatitudeBox";
            this.userLatitudeBox.Size = new System.Drawing.Size(308, 44);
            this.userLatitudeBox.TabIndex = 12;
            // 
            // savedLocationDropDown
            // 
            this.savedLocationDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.savedLocationDropDown.FormattingEnabled = true;
            this.savedLocationDropDown.Location = new System.Drawing.Point(231, 321);
            this.savedLocationDropDown.Name = "savedLocationDropDown";
            this.savedLocationDropDown.Size = new System.Drawing.Size(308, 45);
            this.savedLocationDropDown.TabIndex = 13;
            // 
            // userSavedLocationLabel
            // 
            this.userSavedLocationLabel.AutoSize = true;
            this.userSavedLocationLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.userSavedLocationLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userSavedLocationLabel.Location = new System.Drawing.Point(71, 329);
            this.userSavedLocationLabel.Name = "userSavedLocationLabel";
            this.userSavedLocationLabel.Size = new System.Drawing.Size(206, 30);
            this.userSavedLocationLabel.TabIndex = 14;
            this.userSavedLocationLabel.Text = "SAVED LOCATION";
            this.userSavedLocationLabel.Click += new System.EventHandler(this.userSavedLocationLabel_Click);
            // 
            // savedSatsListBox
            // 
            this.savedSatsListBox.FormattingEnabled = true;
            this.savedSatsListBox.ItemHeight = 29;
            this.savedSatsListBox.Location = new System.Drawing.Point(67, 140);
            this.savedSatsListBox.Name = "savedSatsListBox";
            this.savedSatsListBox.Size = new System.Drawing.Size(472, 149);
            this.savedSatsListBox.TabIndex = 15;
            // 
            // userLongitudeBox
            // 
            this.userLongitudeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.userLongitudeBox.Location = new System.Drawing.Point(231, 461);
            this.userLongitudeBox.Name = "userLongitudeBox";
            this.userLongitudeBox.Size = new System.Drawing.Size(308, 44);
            this.userLongitudeBox.TabIndex = 16;
            // 
            // newSatelliteIDLabel
            // 
            this.newSatelliteIDLabel.AutoSize = true;
            this.newSatelliteIDLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.newSatelliteIDLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.newSatelliteIDLabel.Location = new System.Drawing.Point(63, 99);
            this.newSatelliteIDLabel.Name = "newSatelliteIDLabel";
            this.newSatelliteIDLabel.Size = new System.Drawing.Size(220, 30);
            this.newSatelliteIDLabel.TabIndex = 17;
            this.newSatelliteIDLabel.Text = "NEW SATELLITE ID: ";
            this.newSatelliteIDLabel.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // newSatelliteIDBox
            // 
            this.newSatelliteIDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.newSatelliteIDBox.Location = new System.Drawing.Point(209, 91);
            this.newSatelliteIDBox.Name = "newSatelliteIDBox";
            this.newSatelliteIDBox.Size = new System.Drawing.Size(234, 44);
            this.newSatelliteIDBox.TabIndex = 18;
            // 
            // addSatelliteIDButton
            // 
            this.addSatelliteIDButton.Location = new System.Drawing.Point(451, 91);
            this.addSatelliteIDButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.addSatelliteIDButton.Name = "addSatelliteIDButton";
            this.addSatelliteIDButton.Size = new System.Drawing.Size(88, 32);
            this.addSatelliteIDButton.TabIndex = 19;
            this.addSatelliteIDButton.Text = "ADD";
            this.addSatelliteIDButton.UseVisualStyleBackColor = true;
            this.addSatelliteIDButton.Click += new System.EventHandler(this.addSatelliteIDButton_Click);
            // 
            // satelliteLatitudeLabel
            // 
            this.satelliteLatitudeLabel.AutoSize = true;
            this.satelliteLatitudeLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.satelliteLatitudeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.satelliteLatitudeLabel.Location = new System.Drawing.Point(582, 97);
            this.satelliteLatitudeLabel.Name = "satelliteLatitudeLabel";
            this.satelliteLatitudeLabel.Size = new System.Drawing.Size(164, 30);
            this.satelliteLatitudeLabel.TabIndex = 20;
            this.satelliteLatitudeLabel.Text = "SAT LATITUDE";
            // 
            // satelliteLatitudeActual
            // 
            this.satelliteLatitudeActual.AutoSize = true;
            this.satelliteLatitudeActual.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.satelliteLatitudeActual.ForeColor = System.Drawing.Color.Lime;
            this.satelliteLatitudeActual.Location = new System.Drawing.Point(582, 135);
            this.satelliteLatitudeActual.Name = "satelliteLatitudeActual";
            this.satelliteLatitudeActual.Size = new System.Drawing.Size(133, 40);
            this.satelliteLatitudeActual.TabIndex = 22;
            this.satelliteLatitudeActual.Text = "<none>";
            // 
            // satelliteLongitudeActual
            // 
            this.satelliteLongitudeActual.AutoSize = true;
            this.satelliteLongitudeActual.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.satelliteLongitudeActual.ForeColor = System.Drawing.Color.Lime;
            this.satelliteLongitudeActual.Location = new System.Drawing.Point(580, 232);
            this.satelliteLongitudeActual.Name = "satelliteLongitudeActual";
            this.satelliteLongitudeActual.Size = new System.Drawing.Size(133, 40);
            this.satelliteLongitudeActual.TabIndex = 24;
            this.satelliteLongitudeActual.Text = "<none>";
            // 
            // satelliteLongitudeLabel
            // 
            this.satelliteLongitudeLabel.AutoSize = true;
            this.satelliteLongitudeLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.satelliteLongitudeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.satelliteLongitudeLabel.Location = new System.Drawing.Point(581, 193);
            this.satelliteLongitudeLabel.Name = "satelliteLongitudeLabel";
            this.satelliteLongitudeLabel.Size = new System.Drawing.Size(188, 30);
            this.satelliteLongitudeLabel.TabIndex = 23;
            this.satelliteLongitudeLabel.Text = "SAT LONGITUDE";
            // 
            // satelliteAltitudeActual
            // 
            this.satelliteAltitudeActual.AutoSize = true;
            this.satelliteAltitudeActual.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.satelliteAltitudeActual.ForeColor = System.Drawing.Color.Lime;
            this.satelliteAltitudeActual.Location = new System.Drawing.Point(582, 336);
            this.satelliteAltitudeActual.Name = "satelliteAltitudeActual";
            this.satelliteAltitudeActual.Size = new System.Drawing.Size(133, 40);
            this.satelliteAltitudeActual.TabIndex = 26;
            this.satelliteAltitudeActual.Text = "<none>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(582, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 30);
            this.label4.TabIndex = 25;
            this.label4.Text = "SAT ALTITUDE";
            // 
            // satelliteElevationActual
            // 
            this.satelliteElevationActual.AutoSize = true;
            this.satelliteElevationActual.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.satelliteElevationActual.ForeColor = System.Drawing.Color.Lime;
            this.satelliteElevationActual.Location = new System.Drawing.Point(580, 428);
            this.satelliteElevationActual.Name = "satelliteElevationActual";
            this.satelliteElevationActual.Size = new System.Drawing.Size(133, 40);
            this.satelliteElevationActual.TabIndex = 28;
            this.satelliteElevationActual.Text = "<none>";
            // 
            // satelliteElevationLabel
            // 
            this.satelliteElevationLabel.AutoSize = true;
            this.satelliteElevationLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.satelliteElevationLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.satelliteElevationLabel.Location = new System.Drawing.Point(582, 391);
            this.satelliteElevationLabel.Name = "satelliteElevationLabel";
            this.satelliteElevationLabel.Size = new System.Drawing.Size(181, 30);
            this.satelliteElevationLabel.TabIndex = 27;
            this.satelliteElevationLabel.Text = "SAT ELEVATION";
            // 
            // satelliteAzimuthActual
            // 
            this.satelliteAzimuthActual.AutoSize = true;
            this.satelliteAzimuthActual.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.satelliteAzimuthActual.ForeColor = System.Drawing.Color.Lime;
            this.satelliteAzimuthActual.Location = new System.Drawing.Point(581, 514);
            this.satelliteAzimuthActual.Name = "satelliteAzimuthActual";
            this.satelliteAzimuthActual.Size = new System.Drawing.Size(133, 40);
            this.satelliteAzimuthActual.TabIndex = 30;
            this.satelliteAzimuthActual.Text = "<none>";
            // 
            // satelliteAzimuthLabel
            // 
            this.satelliteAzimuthLabel.AutoSize = true;
            this.satelliteAzimuthLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.satelliteAzimuthLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.satelliteAzimuthLabel.Location = new System.Drawing.Point(584, 477);
            this.satelliteAzimuthLabel.Name = "satelliteAzimuthLabel";
            this.satelliteAzimuthLabel.Size = new System.Drawing.Size(164, 30);
            this.satelliteAzimuthLabel.TabIndex = 29;
            this.satelliteAzimuthLabel.Text = "SAT AZIMUTH";
            // 
            // saveUserLocationLabel
            // 
            this.saveUserLocationLabel.AutoEllipsis = true;
            this.saveUserLocationLabel.AutoSize = true;
            this.saveUserLocationLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.saveUserLocationLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveUserLocationLabel.Location = new System.Drawing.Point(72, 565);
            this.saveUserLocationLabel.Name = "saveUserLocationLabel";
            this.saveUserLocationLabel.Size = new System.Drawing.Size(251, 30);
            this.saveUserLocationLabel.TabIndex = 31;
            this.saveUserLocationLabel.Text = "SAVE USER LOCATION";
            this.saveUserLocationLabel.Click += new System.EventHandler(this.saveUserLocationLabel_Click);
            // 
            // saveUserLocationButton
            // 
            this.saveUserLocationButton.Location = new System.Drawing.Point(249, 558);
            this.saveUserLocationButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveUserLocationButton.Name = "saveUserLocationButton";
            this.saveUserLocationButton.Size = new System.Drawing.Size(98, 41);
            this.saveUserLocationButton.TabIndex = 32;
            this.saveUserLocationButton.Text = "SAVE";
            this.saveUserLocationButton.UseVisualStyleBackColor = true;
            this.saveUserLocationButton.Click += new System.EventHandler(this.saveUserLocationButton_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.RosyBrown;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button5.Location = new System.Drawing.Point(389, 558);
            this.button5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(170, 59);
            this.button5.TabIndex = 33;
            this.button5.Text = "TRACK";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // locationNameBox
            // 
            this.locationNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.locationNameBox.Location = new System.Drawing.Point(231, 369);
            this.locationNameBox.Name = "locationNameBox";
            this.locationNameBox.Size = new System.Drawing.Size(308, 44);
            this.locationNameBox.TabIndex = 35;
            // 
            // locationNameLabel
            // 
            this.locationNameLabel.AutoSize = true;
            this.locationNameLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.locationNameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.locationNameLabel.Location = new System.Drawing.Point(72, 373);
            this.locationNameLabel.Name = "locationNameLabel";
            this.locationNameLabel.Size = new System.Drawing.Size(206, 30);
            this.locationNameLabel.TabIndex = 34;
            this.locationNameLabel.Text = "LOCATION NAME:";
            // 
            // userAltitudeLabel
            // 
            this.userAltitudeLabel.AutoSize = true;
            this.userAltitudeLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.userAltitudeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userAltitudeLabel.Location = new System.Drawing.Point(86, 519);
            this.userAltitudeLabel.Name = "userAltitudeLabel";
            this.userAltitudeLabel.Size = new System.Drawing.Size(183, 30);
            this.userAltitudeLabel.TabIndex = 36;
            this.userAltitudeLabel.Text = "USER ALTITUDE:";
            // 
            // userAltitudeBox
            // 
            this.userAltitudeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.userAltitudeBox.Location = new System.Drawing.Point(231, 511);
            this.userAltitudeBox.Name = "userAltitudeBox";
            this.userAltitudeBox.Size = new System.Drawing.Size(308, 44);
            this.userAltitudeBox.TabIndex = 37;
            // 
            // TrackerUIForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(7)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(902, 734);
            this.Controls.Add(this.userAltitudeBox);
            this.Controls.Add(this.userAltitudeLabel);
            this.Controls.Add(this.locationNameBox);
            this.Controls.Add(this.locationNameLabel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.saveUserLocationButton);
            this.Controls.Add(this.saveUserLocationLabel);
            this.Controls.Add(this.satelliteAzimuthActual);
            this.Controls.Add(this.satelliteAzimuthLabel);
            this.Controls.Add(this.satelliteElevationActual);
            this.Controls.Add(this.satelliteElevationLabel);
            this.Controls.Add(this.satelliteAltitudeActual);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.satelliteLongitudeActual);
            this.Controls.Add(this.satelliteLongitudeLabel);
            this.Controls.Add(this.satelliteLatitudeActual);
            this.Controls.Add(this.satelliteLatitudeLabel);
            this.Controls.Add(this.addSatelliteIDButton);
            this.Controls.Add(this.newSatelliteIDBox);
            this.Controls.Add(this.newSatelliteIDLabel);
            this.Controls.Add(this.userLongitudeBox);
            this.Controls.Add(this.savedSatsListBox);
            this.Controls.Add(this.userSavedLocationLabel);
            this.Controls.Add(this.savedLocationDropDown);
            this.Controls.Add(this.userLatitudeBox);
            this.Controls.Add(this.satelliteLabel);
            this.Controls.Add(this.currentlyTrackingLabel);
            this.Controls.Add(this.userLongitudeLabel);
            this.Controls.Add(this.userLatitudeLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Home);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "TrackerUIForm";
            this.Text = "SAT TRACKER v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label userLatitudeLabel;
        private System.Windows.Forms.Label userLongitudeLabel;
        private System.Windows.Forms.Label currentlyTrackingLabel;
        private System.Windows.Forms.Label satelliteLabel;
        private System.Windows.Forms.TextBox userLatitudeBox;
        private System.Windows.Forms.ComboBox savedLocationDropDown;
        private System.Windows.Forms.Label userSavedLocationLabel;
        private System.Windows.Forms.ListBox savedSatsListBox;
        private System.Windows.Forms.TextBox userLongitudeBox;
        private System.Windows.Forms.Label newSatelliteIDLabel;
        private System.Windows.Forms.TextBox newSatelliteIDBox;
        private System.Windows.Forms.Button addSatelliteIDButton;
        private System.Windows.Forms.Label satelliteLatitudeLabel;
        private System.Windows.Forms.Label satelliteLatitudeActual;
        private System.Windows.Forms.Label satelliteLongitudeActual;
        private System.Windows.Forms.Label satelliteLongitudeLabel;
        private System.Windows.Forms.Label satelliteAltitudeActual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label satelliteElevationActual;
        private System.Windows.Forms.Label satelliteElevationLabel;
        private System.Windows.Forms.Label satelliteAzimuthActual;
        private System.Windows.Forms.Label satelliteAzimuthLabel;
        private System.Windows.Forms.Label saveUserLocationLabel;
        private System.Windows.Forms.Button saveUserLocationButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox locationNameBox;
        private System.Windows.Forms.Label locationNameLabel;
        private System.Windows.Forms.Label userAltitudeLabel;
        private System.Windows.Forms.TextBox userAltitudeBox;
    }
}

