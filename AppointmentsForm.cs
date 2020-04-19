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
    public partial class AppointmentsForm : Form
    {
        static public int appointmentId;
        static public int userId;
        static public int customerId;
        static public string title;
        static public string description;
        static public string location;
        static public string contact;
        static public string type;
        static public string url;
        static public DateTime start;
        static public DateTime end;

        public AppointmentsForm()
        {
            InitializeComponent();
        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            var diff = DataSearch.TZDiff();
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            string sqlJoinTables = "SELECT customer.customerName, appointment.appointmentId, " +
                "appointment.customerId, appointment.userId, appointment.title, appointment.description," +
                " appointment.location, appointment.contact, appointment.type, appointment.url, " +
                $"DATE_ADD(appointment.start, INTERVAL {diff} MINUTE), " +
                $"DATE_ADD(appointment.end, INTERVAL {diff} MINUTE), " +
                $"DATE_ADD(appointment.createDate, INTERVAL {diff} MINUTE), " +
                "appointment.createdBy, " +
                $"DATE_ADD(appointment.lastUpdate, INTERVAL {diff} MINUTE), " +
                "appointment.lastUpdateBy " +
                "FROM customer INNER JOIN appointment " +
                "ON customer.customerId = appointment.customerId;";

            MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlJoinTables, conn);
            DataTable dataTable = new DataTable();
            mySqlData.Fill(dataTable);

            appointmentDGV.DataSource = dataTable;
            appointmentDGV.Columns[0].HeaderText = "Customer Name";
            appointmentDGV.Columns[1].HeaderText = "Appointment ID #";
            appointmentDGV.Columns[2].HeaderText = "Customer ID #";
            appointmentDGV.Columns[3].HeaderText = "User ID #";
            appointmentDGV.Columns[4].HeaderText = "Title";
            appointmentDGV.Columns[5].HeaderText = "Description";
            appointmentDGV.Columns[6].HeaderText = "Location";
            appointmentDGV.Columns[7].HeaderText = "Contact";
            appointmentDGV.Columns[8].HeaderText = "Type";
            appointmentDGV.Columns[9].HeaderText = "Url";
            appointmentDGV.Columns[10].HeaderText = "Start Date/Time";
            appointmentDGV.Columns[11].HeaderText = "End Date/Time";
            appointmentDGV.Columns[12].HeaderText = "Created Date";
            appointmentDGV.Columns[13].HeaderText = "Created By";
            appointmentDGV.Columns[14].HeaderText = "Last Update Date";
            appointmentDGV.Columns[15].HeaderText = "Last Updated By";

            conn.Close();
        }
        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            AddAppointmentForm addAppointmentForm = new AddAppointmentForm();
            addAppointmentForm.ShowDialog();

            AppointmentsForm_Load(sender, e);
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DGVCellClick();
            DialogResult dialogResult = MessageBox.Show("Appointment will be deleted from database permanently. \n Click 'Yes' to continue. \n Click 'No' to abort.",
                 "Delete Appointment?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Appointment.DeleteAppointment(appointmentId);
                MessageBox.Show("Appointment deleted");
                AppointmentsForm_Load(sender, e);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateAppointment_Click(object sender, EventArgs e)
        {
            DGVCellClick();
            for (int i = 0; i < Appointment.Appointments.Count; i++)
            {
                if (Appointment.Appointments[i].AppointmentId == appointmentId)
                {
                    userId = Appointment.Appointments[i].UserId;
                    customerId = Appointment.Appointments[i].CustomerId;
                    title = Appointment.Appointments[i].Title;
                    description = Appointment.Appointments[i].Description;
                    location = Appointment.Appointments[i].Location;
                    contact = Appointment.Appointments[i].Contact;
                    type = Appointment.Appointments[i].Type;
                    url = Appointment.Appointments[i].URL;
                    start = Appointment.Appointments[i].Start;
                    end = Appointment.Appointments[i].End;
                }
            }
            UpdateAppointmentForm updateAppointmentForm = new UpdateAppointmentForm();
            updateAppointmentForm.ShowDialog();

            AppointmentsForm_Load(sender, e);
        }

        private void cusRecButton_Click(object sender, EventArgs e)
        {
            DGVCellClick();
            for(int i = 0; i < Customer.Customers.Count; i++)
            {
                if(Customer.Customers[i].CustomerId == customerId)
                {
                    CustomerDisplayForm customerDisplayForm = new CustomerDisplayForm();
                    customerDisplayForm.ShowDialog();
                    break;
                }
            }
        }
        public void DGVCellClick()
        {
            if (appointmentDGV.SelectedRows.Count > 0)
            {
                int selectedrowindex = appointmentDGV.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = appointmentDGV.Rows[selectedrowindex];
                customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
                appointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);
            }
        }
    }
}
