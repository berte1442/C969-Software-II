namespace UserLogInForm
{
    partial class CalenderForm
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
            this.calenderDGV = new System.Windows.Forms.DataGridView();
            this.weekRadioButton = new System.Windows.Forms.RadioButton();
            this.monthRadioButton = new System.Windows.Forms.RadioButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.exitButton = new System.Windows.Forms.Button();
            this.dgvLabel = new System.Windows.Forms.Label();
            this.typesButton = new System.Windows.Forms.Button();
            this.typesComboBox = new System.Windows.Forms.ComboBox();
            this.typesLabel = new System.Windows.Forms.Label();
            this.userSchedLabel = new System.Windows.Forms.Label();
            this.userIdComboBox = new System.Windows.Forms.ComboBox();
            this.userIdEnterButton = new System.Windows.Forms.Button();
            this.comAppLabel = new System.Windows.Forms.Label();
            this.totalAppNumLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.calenderDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // calenderDGV
            // 
            this.calenderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calenderDGV.Location = new System.Drawing.Point(109, 28);
            this.calenderDGV.Name = "calenderDGV";
            this.calenderDGV.ReadOnly = true;
            this.calenderDGV.Size = new System.Drawing.Size(351, 150);
            this.calenderDGV.TabIndex = 0;
            // 
            // weekRadioButton
            // 
            this.weekRadioButton.AutoSize = true;
            this.weekRadioButton.Location = new System.Drawing.Point(28, 94);
            this.weekRadioButton.Name = "weekRadioButton";
            this.weekRadioButton.Size = new System.Drawing.Size(54, 17);
            this.weekRadioButton.TabIndex = 1;
            this.weekRadioButton.Text = "Week";
            this.weekRadioButton.UseVisualStyleBackColor = true;
            this.weekRadioButton.CheckedChanged += new System.EventHandler(this.weekRadioButton_CheckedChanged);
            // 
            // monthRadioButton
            // 
            this.monthRadioButton.AutoSize = true;
            this.monthRadioButton.Location = new System.Drawing.Point(28, 142);
            this.monthRadioButton.Name = "monthRadioButton";
            this.monthRadioButton.Size = new System.Drawing.Size(55, 17);
            this.monthRadioButton.TabIndex = 2;
            this.monthRadioButton.Text = "Month";
            this.monthRadioButton.UseVisualStyleBackColor = true;
            this.monthRadioButton.CheckedChanged += new System.EventHandler(this.monthRadioButton_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 218);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(367, 357);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Close";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // dgvLabel
            // 
            this.dgvLabel.AutoSize = true;
            this.dgvLabel.Location = new System.Drawing.Point(187, 9);
            this.dgvLabel.Name = "dgvLabel";
            this.dgvLabel.Size = new System.Drawing.Size(0, 13);
            this.dgvLabel.TabIndex = 5;
            // 
            // typesButton
            // 
            this.typesButton.Location = new System.Drawing.Point(367, 267);
            this.typesButton.Name = "typesButton";
            this.typesButton.Size = new System.Drawing.Size(75, 23);
            this.typesButton.TabIndex = 6;
            this.typesButton.Text = "Enter";
            this.typesButton.UseVisualStyleBackColor = true;
            this.typesButton.Click += new System.EventHandler(this.typesButton_Click);
            // 
            // typesComboBox
            // 
            this.typesComboBox.FormattingEnabled = true;
            this.typesComboBox.Location = new System.Drawing.Point(257, 267);
            this.typesComboBox.Name = "typesComboBox";
            this.typesComboBox.Size = new System.Drawing.Size(104, 21);
            this.typesComboBox.TabIndex = 7;
            this.typesComboBox.Text = "Select App Type";
            this.typesComboBox.SelectedIndexChanged += new System.EventHandler(this.typesComboBox_SelectedIndexChanged);
            // 
            // typesLabel
            // 
            this.typesLabel.AutoSize = true;
            this.typesLabel.Location = new System.Drawing.Point(269, 251);
            this.typesLabel.Name = "typesLabel";
            this.typesLabel.Size = new System.Drawing.Size(164, 13);
            this.typesLabel.TabIndex = 8;
            this.typesLabel.Text = "Appointment Type Monthly Count";
            // 
            // userSchedLabel
            // 
            this.userSchedLabel.AutoSize = true;
            this.userSchedLabel.Location = new System.Drawing.Point(292, 195);
            this.userSchedLabel.Name = "userSchedLabel";
            this.userSchedLabel.Size = new System.Drawing.Size(105, 13);
            this.userSchedLabel.TabIndex = 9;
            this.userSchedLabel.Text = "Consultant Schedule";
            // 
            // userIdComboBox
            // 
            this.userIdComboBox.FormattingEnabled = true;
            this.userIdComboBox.Location = new System.Drawing.Point(257, 211);
            this.userIdComboBox.Name = "userIdComboBox";
            this.userIdComboBox.Size = new System.Drawing.Size(104, 21);
            this.userIdComboBox.TabIndex = 10;
            this.userIdComboBox.Text = "Select User ID";
            // 
            // userIdEnterButton
            // 
            this.userIdEnterButton.Location = new System.Drawing.Point(367, 211);
            this.userIdEnterButton.Name = "userIdEnterButton";
            this.userIdEnterButton.Size = new System.Drawing.Size(75, 23);
            this.userIdEnterButton.TabIndex = 11;
            this.userIdEnterButton.Text = "Enter";
            this.userIdEnterButton.UseVisualStyleBackColor = true;
            this.userIdEnterButton.Click += new System.EventHandler(this.userIdEnterButton_Click);
            // 
            // comAppLabel
            // 
            this.comAppLabel.AutoSize = true;
            this.comAppLabel.Location = new System.Drawing.Point(269, 308);
            this.comAppLabel.Name = "comAppLabel";
            this.comAppLabel.Size = new System.Drawing.Size(84, 39);
            this.comAppLabel.TabIndex = 12;
            this.comAppLabel.Text = "Total Completed\r\n   Appoinments\r\n      this month";
            // 
            // totalAppNumLabel
            // 
            this.totalAppNumLabel.AutoSize = true;
            this.totalAppNumLabel.Location = new System.Drawing.Point(384, 322);
            this.totalAppNumLabel.Name = "totalAppNumLabel";
            this.totalAppNumLabel.Size = new System.Drawing.Size(13, 13);
            this.totalAppNumLabel.TabIndex = 13;
            this.totalAppNumLabel.Text = "0";
            this.totalAppNumLabel.Click += new System.EventHandler(this.totalAppNumLabel_Click);
            // 
            // CalenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 398);
            this.Controls.Add(this.totalAppNumLabel);
            this.Controls.Add(this.comAppLabel);
            this.Controls.Add(this.userIdEnterButton);
            this.Controls.Add(this.userIdComboBox);
            this.Controls.Add(this.userSchedLabel);
            this.Controls.Add(this.typesLabel);
            this.Controls.Add(this.typesComboBox);
            this.Controls.Add(this.typesButton);
            this.Controls.Add(this.dgvLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.monthRadioButton);
            this.Controls.Add(this.weekRadioButton);
            this.Controls.Add(this.calenderDGV);
            this.Name = "CalenderForm";
            this.Text = "Calender";
            this.Load += new System.EventHandler(this.CalenderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.calenderDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView calenderDGV;
        private System.Windows.Forms.RadioButton weekRadioButton;
        private System.Windows.Forms.RadioButton monthRadioButton;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label dgvLabel;
        private System.Windows.Forms.Button typesButton;
        private System.Windows.Forms.ComboBox typesComboBox;
        private System.Windows.Forms.Label typesLabel;
        private System.Windows.Forms.Label userSchedLabel;
        private System.Windows.Forms.ComboBox userIdComboBox;
        private System.Windows.Forms.Button userIdEnterButton;
        private System.Windows.Forms.Label comAppLabel;
        private System.Windows.Forms.Label totalAppNumLabel;
    }
}