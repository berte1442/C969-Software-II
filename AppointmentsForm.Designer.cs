namespace UserLogInForm
{
    partial class AppointmentsForm
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
            //this.u05m2CDataSet2 = new UserLogInForm.U05m2CDataSet2();
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
           // this.appointmentTableAdapter = new UserLogInForm.U05m2CDataSet2TableAdapters.appointmentTableAdapter();
           // this.tableAdapterManager = new UserLogInForm.U05m2CDataSet2TableAdapters.TableAdapterManager();
            this.addAppointmentButton = new System.Windows.Forms.Button();
            this.appointmentDGV = new System.Windows.Forms.DataGridView();
            this.appointmentTableLabel = new System.Windows.Forms.Label();
            this.updateAppointment = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.cusRecButton = new System.Windows.Forms.Button();
          //  ((System.ComponentModel.ISupportInitialize)(this.u05m2CDataSet2)).BeginInit();
         //   ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // u05m2CDataSet2
            // 
         //   this.u05m2CDataSet2.DataSetName = "U05m2CDataSet2";
         //   this.u05m2CDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // appointmentBindingSource
            // 
           // this.appointmentBindingSource.DataMember = "appointment";
         //   this.appointmentBindingSource.DataSource = this.u05m2CDataSet2;
            // 
            // appointmentTableAdapter
            // 
            //this.appointmentTableAdapter.ClearBeforeFill = true;
            //// 
            //// tableAdapterManager
            //// 
            //this.tableAdapterManager.addressTableAdapter = null;
            //this.tableAdapterManager.appointmentTableAdapter = this.appointmentTableAdapter;
            //this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            //this.tableAdapterManager.cityTableAdapter = null;
            //this.tableAdapterManager.countryTableAdapter = null;
            //this.tableAdapterManager.customerTableAdapter = null;
            //this.tableAdapterManager.scheduleTableAdapter = null;
            //this.tableAdapterManager.UpdateOrder = UserLogInForm.U05m2CDataSet2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //this.tableAdapterManager.userTableAdapter = null;
            // 
            // addAppointmentButton
            // 
            this.addAppointmentButton.Location = new System.Drawing.Point(32, 249);
            this.addAppointmentButton.Name = "addAppointmentButton";
            this.addAppointmentButton.Size = new System.Drawing.Size(94, 73);
            this.addAppointmentButton.TabIndex = 16;
            this.addAppointmentButton.Text = "Add Appointment";
            this.addAppointmentButton.UseVisualStyleBackColor = true;
            this.addAppointmentButton.Click += new System.EventHandler(this.addAppointmentButton_Click);
            // 
            // appointmentDGV
            // 
            this.appointmentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDGV.Location = new System.Drawing.Point(32, 51);
            this.appointmentDGV.MultiSelect = false;
            this.appointmentDGV.Name = "appointmentDGV";
            this.appointmentDGV.ReadOnly = true;
            this.appointmentDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDGV.Size = new System.Drawing.Size(431, 167);
            this.appointmentDGV.TabIndex = 17;
            // 
            // appointmentTableLabel
            // 
            this.appointmentTableLabel.AutoSize = true;
            this.appointmentTableLabel.Location = new System.Drawing.Point(193, 35);
            this.appointmentTableLabel.Name = "appointmentTableLabel";
            this.appointmentTableLabel.Size = new System.Drawing.Size(93, 13);
            this.appointmentTableLabel.TabIndex = 18;
            this.appointmentTableLabel.Text = "AppointmentTable";
            // 
            // updateAppointment
            // 
            this.updateAppointment.Location = new System.Drawing.Point(255, 249);
            this.updateAppointment.Name = "updateAppointment";
            this.updateAppointment.Size = new System.Drawing.Size(94, 73);
            this.updateAppointment.TabIndex = 19;
            this.updateAppointment.Text = "Update Appointment";
            this.updateAppointment.UseVisualStyleBackColor = true;
            this.updateAppointment.Click += new System.EventHandler(this.updateAppointment_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(145, 249);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(94, 73);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "Delete Appointment";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(368, 359);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(87, 32);
            this.closeButton.TabIndex = 21;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // cusRecButton
            // 
            this.cusRecButton.Location = new System.Drawing.Point(369, 249);
            this.cusRecButton.Name = "cusRecButton";
            this.cusRecButton.Size = new System.Drawing.Size(94, 73);
            this.cusRecButton.TabIndex = 22;
            this.cusRecButton.Text = "View Customer Records";
            this.cusRecButton.UseVisualStyleBackColor = true;
            this.cusRecButton.Click += new System.EventHandler(this.cusRecButton_Click);
            // 
            // AppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 403);
            this.Controls.Add(this.cusRecButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateAppointment);
            this.Controls.Add(this.appointmentTableLabel);
            this.Controls.Add(this.appointmentDGV);
            this.Controls.Add(this.addAppointmentButton);
            this.Name = "AppointmentsForm";
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.AppointmentsForm_Load);
           // ((System.ComponentModel.ISupportInitialize)(this.u05m2CDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private U05m2CDataSet2 u05m2CDataSet2;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
        //private U05m2CDataSet2TableAdapters.appointmentTableAdapter appointmentTableAdapter;
        //private U05m2CDataSet2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.DataGridView appointmentDGV;
        private System.Windows.Forms.Label appointmentTableLabel;
        private System.Windows.Forms.Button updateAppointment;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button cusRecButton;
    }
}