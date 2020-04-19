namespace UserLogInForm
{
    partial class AddAppointmentForm
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
            this.customerDGV = new System.Windows.Forms.DataGridView();
            this.customerIdLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.customerIdTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.dgvLabel = new System.Windows.Forms.Label();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startComboBox = new System.Windows.Forms.ComboBox();
            this.endComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDGV
            // 
            this.customerDGV.AllowUserToAddRows = false;
            this.customerDGV.AllowUserToDeleteRows = false;
            this.customerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDGV.Location = new System.Drawing.Point(88, 38);
            this.customerDGV.MultiSelect = false;
            this.customerDGV.Name = "customerDGV";
            this.customerDGV.ReadOnly = true;
            this.customerDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDGV.Size = new System.Drawing.Size(279, 150);
            this.customerDGV.TabIndex = 0;
            this.customerDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerDGV_CellDoubleClick);
            // 
            // customerIdLabel
            // 
            this.customerIdLabel.AutoSize = true;
            this.customerIdLabel.Location = new System.Drawing.Point(12, 201);
            this.customerIdLabel.Name = "customerIdLabel";
            this.customerIdLabel.Size = new System.Drawing.Size(65, 13);
            this.customerIdLabel.TabIndex = 1;
            this.customerIdLabel.Text = "Customer ID";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 246);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Title";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(12, 290);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(48, 13);
            this.locationLabel.TabIndex = 3;
            this.locationLabel.Text = "Location";
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Location = new System.Drawing.Point(249, 204);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(44, 13);
            this.contactLabel.TabIndex = 4;
            this.contactLabel.Text = "Contact";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(249, 246);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 5;
            this.typeLabel.Text = "Type";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(249, 290);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(29, 13);
            this.urlLabel.TabIndex = 6;
            this.urlLabel.Text = "URL";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(194, 342);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(55, 13);
            this.startLabel.TabIndex = 7;
            this.startLabel.Text = "Start Time";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(194, 408);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(52, 13);
            this.endLabel.TabIndex = 8;
            this.endLabel.Text = "End Time";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 342);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 9;
            this.descriptionLabel.Text = "Description";
            // 
            // customerIdTextBox
            // 
            this.customerIdTextBox.Location = new System.Drawing.Point(88, 201);
            this.customerIdTextBox.Name = "customerIdTextBox";
            this.customerIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.customerIdTextBox.TabIndex = 10;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(88, 246);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(100, 20);
            this.titleTextBox.TabIndex = 11;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(88, 290);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(100, 20);
            this.locationTextBox.TabIndex = 12;
            // 
            // contactTextBox
            // 
            this.contactTextBox.Location = new System.Drawing.Point(311, 198);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactTextBox.TabIndex = 13;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(311, 243);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(100, 20);
            this.typeTextBox.TabIndex = 14;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(313, 290);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(100, 20);
            this.urlTextBox.TabIndex = 15;
            // 
            // dgvLabel
            // 
            this.dgvLabel.AutoSize = true;
            this.dgvLabel.Location = new System.Drawing.Point(167, 22);
            this.dgvLabel.Name = "dgvLabel";
            this.dgvLabel.Size = new System.Drawing.Size(137, 13);
            this.dgvLabel.TabIndex = 18;
            this.dgvLabel.Text = "Customer / Customer ID #\'s";
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(78, 342);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(110, 106);
            this.descriptionRichTextBox.TabIndex = 19;
            this.descriptionRichTextBox.Text = "";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(65, 454);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(98, 47);
            this.addButton.TabIndex = 20;
            this.addButton.Text = "Add Appointment";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(190, 455);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(96, 46);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(311, 454);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(98, 46);
            this.closeButton.TabIndex = 22;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(262, 401);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 24;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(262, 336);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateTimePicker.TabIndex = 25;
            this.startDateTimePicker.Value = new System.DateTime(2020, 4, 7, 0, 0, 0, 0);
            // 
            // startComboBox
            // 
            this.startComboBox.FormattingEnabled = true;
            this.startComboBox.Items.AddRange(new object[] {
            "8:00:00 AM",
            "8:30:00 AM",
            "9:00:00 AM",
            "10:00:00 AM",
            "10:00:00 AM",
            "10:30:00 AM",
            "11:00.:00 AM",
            "11:30:00 AM",
            "12:00:00 PM",
            "12:30:00 PM",
            "1:00:00 PM",
            "1:30:00 PM",
            "2:00:00 PM",
            "2:30:00 PM",
            "3:00:00 PM",
            "3:30:00 PM",
            "4:00:00 PM",
            "4:30:00 PM",
            "5:00:00 PM",
            "5:30:00 PM",
            "6:00:00 PM",
            "6:30:00 PM",
            "7:00:00 PM",
            "7:30:00 PM",
            "8:00:00 PM",
            "8:30:00 PM",
            "9:00:00 PM",
            "9:30:00 PM",
            "10:00:00 PM",
            "10:30:00 PM",
            "11:00:00 PM",
            "11:30:00 PM",
            "12:00:00 AM",
            "12:30:00 AM",
            "1:00:00 AM",
            "1:30:00 AM",
            "2:00:00 AM",
            "2:30:00 AM",
            "3:00:00 AM",
            "3:30:00 AM",
            "4:00:00 AM",
            "4:30:00 AM",
            "5:00:00 AM",
            "5:30:00 AM",
            "6:00:00 AM",
            "6:30:00 AM",
            "7:00:00 AM",
            "7:30:00 AM"});
            this.startComboBox.Location = new System.Drawing.Point(262, 362);
            this.startComboBox.Name = "startComboBox";
            this.startComboBox.Size = new System.Drawing.Size(200, 21);
            this.startComboBox.TabIndex = 26;
            // 
            // endComboBox
            // 
            this.endComboBox.FormattingEnabled = true;
            this.endComboBox.Items.AddRange(new object[] {
            "8:30:00 AM",
            "9:00:00 AM",
            "10:00:00 AM",
            "10:00:00 AM",
            "10:30:00 AM",
            "11:00.:00 AM",
            "11:30:00 AM",
            "12:00:00 PM",
            "12:30:00 PM",
            "1:00:00 PM",
            "1:30:00 PM",
            "2:00:00 PM",
            "2:30:00 PM",
            "3:00:00 PM",
            "3:30:00 PM",
            "4:00:00 PM",
            "4:30:00 PM",
            "5:00:00 PM",
            "5:30:00 PM",
            "6:00:00 PM",
            "6:30:00 PM",
            "7:00:00 PM",
            "7:30:00 PM",
            "8:00:00 PM",
            "8:30:00 PM",
            "9:00:00 PM",
            "9:30:00 PM",
            "10:00:00 PM",
            "10:30:00 PM",
            "11:00:00 PM",
            "11:30:00 PM",
            "12:00:00 AM",
            "12:30:00 AM",
            "1:00:00 AM",
            "1:30:00 AM",
            "2:00:00 AM",
            "2:30:00 AM",
            "3:00:00 AM",
            "3:30:00 AM",
            "4:00:00 AM",
            "4:30:00 AM",
            "5:00:00 AM",
            "5:30:00 AM",
            "6:00:00 AM",
            "6:30:00 AM",
            "7:00:00 AM",
            "7:30:00 AM",
            "8:00:00 AM"});
            this.endComboBox.Location = new System.Drawing.Point(262, 427);
            this.endComboBox.Name = "endComboBox";
            this.endComboBox.Size = new System.Drawing.Size(200, 21);
            this.endComboBox.TabIndex = 27;
            // 
            // AddAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 513);
            this.Controls.Add(this.endComboBox);
            this.Controls.Add(this.startComboBox);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.descriptionRichTextBox);
            this.Controls.Add(this.dgvLabel);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.contactTextBox);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.customerIdTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.contactLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.customerIdLabel);
            this.Controls.Add(this.customerDGV);
            this.Name = "AddAppointmentForm";
            this.Text = "Add Appointment";
            this.Load += new System.EventHandler(this.AddAppointmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerDGV;
        private System.Windows.Forms.Label customerIdLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox customerIdTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label dgvLabel;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.ComboBox startComboBox;
        private System.Windows.Forms.ComboBox endComboBox;
    }
}