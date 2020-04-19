namespace UserLogInForm
{
    partial class OptionsForm
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
            this.cusRecsLabel = new System.Windows.Forms.Label();
            this.appointmentLabel = new System.Windows.Forms.Label();
            this.cusRecsButton = new System.Windows.Forms.Button();
            this.appointmentsButton = new System.Windows.Forms.Button();
            this.viewCalLabel = new System.Windows.Forms.Label();
            this.viewCalButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.newUserButton = new System.Windows.Forms.Button();
            this.newUserLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cusRecsLabel
            // 
            this.cusRecsLabel.AutoSize = true;
            this.cusRecsLabel.Location = new System.Drawing.Point(30, 36);
            this.cusRecsLabel.Name = "cusRecsLabel";
            this.cusRecsLabel.Size = new System.Drawing.Size(132, 13);
            this.cusRecsLabel.TabIndex = 0;
            this.cusRecsLabel.Text = "Access Customer Records";
            // 
            // appointmentLabel
            // 
            this.appointmentLabel.AutoSize = true;
            this.appointmentLabel.Location = new System.Drawing.Point(53, 94);
            this.appointmentLabel.Name = "appointmentLabel";
            this.appointmentLabel.Size = new System.Drawing.Size(109, 13);
            this.appointmentLabel.TabIndex = 1;
            this.appointmentLabel.Text = "Access Appointments";
            // 
            // cusRecsButton
            // 
            this.cusRecsButton.Location = new System.Drawing.Point(203, 31);
            this.cusRecsButton.Name = "cusRecsButton";
            this.cusRecsButton.Size = new System.Drawing.Size(75, 23);
            this.cusRecsButton.TabIndex = 3;
            this.cusRecsButton.Text = "Enter";
            this.cusRecsButton.UseVisualStyleBackColor = true;
            this.cusRecsButton.Click += new System.EventHandler(this.cusRecsButton_Click);
            // 
            // appointmentsButton
            // 
            this.appointmentsButton.Location = new System.Drawing.Point(203, 89);
            this.appointmentsButton.Name = "appointmentsButton";
            this.appointmentsButton.Size = new System.Drawing.Size(75, 23);
            this.appointmentsButton.TabIndex = 4;
            this.appointmentsButton.Text = "Enter";
            this.appointmentsButton.UseVisualStyleBackColor = true;
            this.appointmentsButton.Click += new System.EventHandler(this.appointmentsButton_Click);
            // 
            // viewCalLabel
            // 
            this.viewCalLabel.AutoSize = true;
            this.viewCalLabel.Location = new System.Drawing.Point(87, 153);
            this.viewCalLabel.Name = "viewCalLabel";
            this.viewCalLabel.Size = new System.Drawing.Size(75, 13);
            this.viewCalLabel.TabIndex = 5;
            this.viewCalLabel.Text = "View Calendar";
            // 
            // viewCalButton
            // 
            this.viewCalButton.Location = new System.Drawing.Point(203, 148);
            this.viewCalButton.Name = "viewCalButton";
            this.viewCalButton.Size = new System.Drawing.Size(75, 23);
            this.viewCalButton.TabIndex = 6;
            this.viewCalButton.Text = "Enter";
            this.viewCalButton.UseVisualStyleBackColor = true;
            this.viewCalButton.Click += new System.EventHandler(this.viewCalButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(70, 268);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(75, 23);
            this.logOutButton.TabIndex = 7;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(203, 268);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // newUserButton
            // 
            this.newUserButton.Location = new System.Drawing.Point(203, 204);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(75, 23);
            this.newUserButton.TabIndex = 9;
            this.newUserButton.Text = "Enter";
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // newUserLabel
            // 
            this.newUserLabel.AutoSize = true;
            this.newUserLabel.Location = new System.Drawing.Point(74, 209);
            this.newUserLabel.Name = "newUserLabel";
            this.newUserLabel.Size = new System.Drawing.Size(88, 13);
            this.newUserLabel.TabIndex = 10;
            this.newUserLabel.Text = "Create New User";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 326);
            this.Controls.Add(this.newUserLabel);
            this.Controls.Add(this.newUserButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.viewCalButton);
            this.Controls.Add(this.viewCalLabel);
            this.Controls.Add(this.appointmentsButton);
            this.Controls.Add(this.cusRecsButton);
            this.Controls.Add(this.appointmentLabel);
            this.Controls.Add(this.cusRecsLabel);
            this.Name = "OptionsForm";
            this.Text = "Select Action";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cusRecsLabel;
        private System.Windows.Forms.Label appointmentLabel;
        private System.Windows.Forms.Button cusRecsButton;
        private System.Windows.Forms.Button appointmentsButton;
        private System.Windows.Forms.Label viewCalLabel;
        private System.Windows.Forms.Button viewCalButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.Label newUserLabel;
    }
}