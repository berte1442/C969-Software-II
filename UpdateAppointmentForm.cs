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
    public partial class UpdateAppointmentForm : Form
    {
        static int appointmentIdMod;
        static int userId;
        static int customerIdMod;
        static string titleMod;
        static string descriptionMod;
        static string locationMod;
        static string contactMod;
        static string typeMod;
        static string urlMod;
        static DateTime startMod;
        static DateTime endMod;

        public UpdateAppointmentForm()
        {

            InitializeComponent();
            //lambda expression used to clear textboxes when resetButton is clicked
            resetButton.Click += (s, e) =>
             {
                 customerIdTextBox.Clear();
                 titleTextBox.Clear();
                 descriptionRichTextBox.Clear();
                 locationTextBox.Clear();
                 contactTextBox.Clear();
                 typeTextBox.Clear();
                 urlTextBox.Clear();
                 startComboBox.SelectedIndex = 0;
                 endComboBox.SelectedIndex = 0;
             };
            //lamba expression for closing form
            closeButton.Click += (s, e) => Close();            
            //lamba expression for setting customerIdTextBob.Text upon double click in DGV
            customerDGV.CellMouseDoubleClick += (s, e) =>
            {
                int customerId = 0;
                if (customerDGV.SelectedRows.Count > 0)
                {
                    int selectedrowindex = customerDGV.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = customerDGV.Rows[selectedrowindex];
                    customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
                }
                customerIdTextBox.Text = customerId.ToString();               
            };
        }

        private void UpdateAppointmentForm_Load(object sender, EventArgs e)
        {
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
            appointmentIdMod = AppointmentsForm.appointmentId;
            userId = AppointmentsForm.userId;
            customerIdMod = int.Parse(customerIdTextBox.Text = AppointmentsForm.customerId.ToString());
            titleMod = titleTextBox.Text = AppointmentsForm.title;
            descriptionMod = descriptionRichTextBox.Text = AppointmentsForm.description;
            locationMod = locationTextBox.Text = AppointmentsForm.location;
            contactMod = contactTextBox.Text = AppointmentsForm.contact;
            typeMod = typeTextBox.Text = AppointmentsForm.type;
            urlMod = urlTextBox.Text = AppointmentsForm.url;
            startMod = Convert.ToDateTime(AppointmentsForm.start.ToString());
            endMod = Convert.ToDateTime(AppointmentsForm.end.ToString());

            startDateTimePicker.Value = startMod.Date;
            endDateTimePicker.Value = endMod.Date;
            startComboBox.Text = startMod.ToString("hh:mm:ss tt");
            endComboBox.Text = endMod.ToString("hh:mm:ss tt");
        }
        private void updateButton_Click(object sender, EventArgs e)
        {

            int customerId = int.Parse(customerIdTextBox.Text);
            // consider allow changing of userId as to change user in appointment
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
                DateTime start = Convert.ToDateTime(startDate + " " + startTime);
                DateTime end = Convert.ToDateTime(endDate + " " + endTime);

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
                        try
                        {
                            foreach (var a in Appointment.Appointments)
                            {
                                if ((a.AppointmentId != AppointmentsForm.appointmentId) && ((userId == a.UserId) 
                                    && (start >= a.Start && start < a.End) ||
                                    (end > a.Start && end <= a.End)))
                                {
                                    throw new Exception("Conflict in schedule");
                                }
                            }
                            try
                            {

                                Appointment newAppointment = new Appointment(customerId, userId, title,
                                    description, location, contact, type, url, start, end);  // this will be the new appointment
                                Appointment.UpdateAppoinment(newAppointment, appointmentIdMod);

                                MessageBox.Show("Appointment updated");
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
            //DateTime start = Convert.ToDateTime(startDate + " " + startTime);
            //DateTime end = Convert.ToDateTime(endDate + " " + endTime);
        }
    }
}
