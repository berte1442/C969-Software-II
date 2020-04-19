using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace UserLogInForm
{
    public partial class AddAppointmentForm : Form
    {

        public AddAppointmentForm()
        {
            InitializeComponent();
            closeButton.Click += (s, e) => Close();            
        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            startDateTimePicker.Value = DateTime.Today;
            endDateTimePicker.Value = DateTime.Today;
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            string sqlCustomer = "SELECT customerName, customerId FROM customer;";

            MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlCustomer, conn);
            DataTable dataTable = new DataTable();
            mySqlData.Fill(dataTable);

            customerDGV.DataSource = dataTable;
            customerDGV.Columns[0].HeaderText = "Customer Name";
            customerDGV.Columns[1].HeaderText = "Customer ID #";


            conn.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string sqlUserId = $"SELECT userId FROM user WHERE userName = \"{UserLoginForm1.userName}\";";
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlUserId, conn);
            int userId = (int)cmd.ExecuteScalar();
            conn.Close();

            int customerId = int.Parse(customerIdTextBox.Text);
            string title = titleTextBox.Text;
            string description = descriptionRichTextBox.Text;
            string location = locationTextBox.Text;
            string contact = contactTextBox.Text;
            string type = typeTextBox.Text;
            string url = urlTextBox.Text;
            string startDate = startDateTimePicker.Value.ToShortDateString();  
            string endDate = endDateTimePicker.Value.ToShortDateString();      
            string startTime = startComboBox.Text;
            string endTime = endComboBox.Text;
            try
            {
                DateTime start = Convert.ToDateTime(startDate + " " + startTime);// add timezone and daylight savings features
                DateTime end = Convert.ToDateTime(endDate + " " + endTime);//.ToLocalTime();// add timezone and daylight savings features

                DateTime openHour = Convert.ToDateTime("8:00:00 AM");
                DateTime closeHour = Convert.ToDateTime("5:00:00 PM");

                try
                {
                    if (start.TimeOfDay < openHour.TimeOfDay || start.TimeOfDay > closeHour.TimeOfDay
                        || end.TimeOfDay < openHour.TimeOfDay || end.TimeOfDay > closeHour.TimeOfDay 
                        || start.Date != end.Date)
                    {
                        throw new Exception("Outside of business hours");
                    }
                    try
                    {
                        if (start < DateTime.Now || start >= end)
                        {
                            throw new Exception("Improper date/time selection");
                        }
                        start = start.ToUniversalTime();
                        end = end.ToUniversalTime();
                        Appointment appointment = new Appointment(customerId, userId, title,
                            description, location, contact, type, url, start, end);
                        try
                        {
                            foreach (var a in Appointment.Appointments)
                            {
                                if ((userId == a.UserId) && ((start >= a.Start && start < a.End) ||
                                    (end > a.Start && end <= a.End)))
                                {
                                    throw new Exception("Conflict in schedule");
                                }
                            }
                            try
                            {
                                appointment.AddAppointmentToDataBase(appointment);
                                Appointment.AppointmentsListFill();

                                MessageBox.Show("Appointment scheduled");
                                this.Close();
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("Appointment could not be successfully saved. " +
                                    "Verify Customer ID input is correct.", "Error code " + ex.Number.ToString());
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Appointment time unavailable.  Please reselect appointment " +
                                "times");
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Appointment time selections are invalid.  Please reselect " +
                            "appointment times.");
                    }
                }
                catch
                {
                    MessageBox.Show("Business hours are between 8:00 AM - 5:00 PM.Please schedule " +
                            "appointment within business hours");
                }
            }
            catch
            {
                MessageBox.Show("Invaled time input");
            }
        }                       

        private void customerDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int customerId = 0;
            if (customerDGV.SelectedRows.Count > 0)
            {
                int selectedrowindex = customerDGV.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = customerDGV.Rows[selectedrowindex];
                customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
            }
            customerIdTextBox.Text = customerId.ToString();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            customerIdTextBox.Clear();
            titleTextBox.Clear();
            locationTextBox.Clear();
            contactTextBox.Clear();
            typeTextBox.Clear();
            urlTextBox.Clear();
            descriptionRichTextBox.Clear();
            startComboBox.Text = "";
            endComboBox.Text = "";
        }
    }
}
