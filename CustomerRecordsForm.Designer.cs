namespace UserLogInForm
{
    partial class CustomerRecordsForm
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
            this.u05m2CDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cusRecSearchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchByComboBox = new System.Windows.Forms.ComboBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addNewCusButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.DGV2label = new System.Windows.Forms.Label();
            this.DGV1label = new System.Windows.Forms.Label();
            this.selectLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.u05m2CDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // cusRecSearchButton
            // 
            this.cusRecSearchButton.Location = new System.Drawing.Point(13, 231);
            this.cusRecSearchButton.Name = "cusRecSearchButton";
            this.cusRecSearchButton.Size = new System.Drawing.Size(75, 23);
            this.cusRecSearchButton.TabIndex = 1;
            this.cusRecSearchButton.Text = "Search";
            this.cusRecSearchButton.UseVisualStyleBackColor = true;
            this.cusRecSearchButton.Click += new System.EventHandler(this.cusRecSearchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(94, 234);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(165, 20);
            this.searchTextBox.TabIndex = 2;
            // 
            // searchByComboBox
            // 
            this.searchByComboBox.FormattingEnabled = true;
            this.searchByComboBox.Items.AddRange(new object[] {
            "Customer Name",
            "Customer Address",
            "Customer Phone Number"});
            this.searchByComboBox.Location = new System.Drawing.Point(356, 234);
            this.searchByComboBox.Name = "searchByComboBox";
            this.searchByComboBox.Size = new System.Drawing.Size(121, 21);
            this.searchByComboBox.TabIndex = 3;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(285, 241);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(56, 13);
            this.searchLabel.TabIndex = 4;
            this.searchLabel.Text = "Search By";
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(43, 34);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(434, 150);
            this.dgv1.TabIndex = 5;
            this.dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellDoubleClick);
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(43, 298);
            this.dgv2.MultiSelect = false;
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(434, 123);
            this.dgv2.TabIndex = 6;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(197, 463);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(132, 23);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(197, 492);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(132, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addNewCusButton
            // 
            this.addNewCusButton.Location = new System.Drawing.Point(143, 523);
            this.addNewCusButton.Name = "addNewCusButton";
            this.addNewCusButton.Size = new System.Drawing.Size(239, 23);
            this.addNewCusButton.TabIndex = 9;
            this.addNewCusButton.Text = "Add New Customer";
            this.addNewCusButton.UseVisualStyleBackColor = true;
            this.addNewCusButton.Click += new System.EventHandler(this.addNewCusButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(435, 523);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Close";
            this.exitButton.UseVisualStyleBackColor = true;
            //this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // DGV2label
            // 
            this.DGV2label.AutoSize = true;
            this.DGV2label.Location = new System.Drawing.Point(235, 282);
            this.DGV2label.Name = "DGV2label";
            this.DGV2label.Size = new System.Drawing.Size(0, 13);
            this.DGV2label.TabIndex = 11;
            // 
            // DGV1label
            // 
            this.DGV1label.AutoSize = true;
            this.DGV1label.Location = new System.Drawing.Point(162, 18);
            this.DGV1label.Name = "DGV1label";
            this.DGV1label.Size = new System.Drawing.Size(203, 13);
            this.DGV1label.TabIndex = 12;
            this.DGV1label.Text = "Customers / Addresses / Phone Numbers";
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(224, 424);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(0, 13);
            this.selectLabel.TabIndex = 13;
            // 
            // CustomerRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 552);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.DGV1label);
            this.Controls.Add(this.DGV2label);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.addNewCusButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchByComboBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.cusRecSearchButton);
            this.Name = "CustomerRecordsForm";
            this.Text = "Customer Records";
            this.Load += new System.EventHandler(this.CustomerRecordsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.u05m2CDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //private U05m2CDataSet1TableAdapters.addressTableAdapter addressTableAdapter;
        private System.Windows.Forms.BindingSource u05m2CDataSet1BindingSource;
        //private U05m2CDataSet1 u05m2CDataSet1;
        private System.Windows.Forms.Button cusRecSearchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox searchByComboBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addNewCusButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label DGV2label;
        private System.Windows.Forms.Label DGV1label;
        private System.Windows.Forms.Label selectLabel;
    }
}