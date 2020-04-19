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
    public partial class CalenderForm : Form
    {
        static public DateTime dateSelected = DateTime.Now;
        static public int month = dateSelected.Month;
        static public int year = dateSelected.Year;
        public int dayOfMonth = dateSelected.Day;
        public int dayOfWeek = (int)dateSelected.DayOfWeek;
        public int weekMinus = 0;
        public int weekAdd = 0;
        public DateTime monthSelectionMin;
        public DateTime monthSelectionMax;
        public DateTime weekSelectionMin;
        public DateTime weekSelectionMax;

        bool weekSelected = false;
        bool monthSelected = false;
        bool firstLoad = true;
        public CalenderForm()
        {
            InitializeComponent();
        }
        public void DateSelected()
        {
            monthCalendar1.MaxSelectionCount = 1;
            dateSelected = Convert.ToDateTime(monthCalendar1.SelectionRange.Start.ToString());
            month = dateSelected.Month;
            dayOfWeek = (int)dateSelected.DayOfWeek;
            dayOfMonth = (int)dateSelected.Day;
            year = dateSelected.Year;
            int monthMaxDay = Calender.MonthMaxDay(dateSelected);
            monthSelectionMin = Convert.ToDateTime($"{month}/1/{year} 12:00:00 AM");
            monthSelectionMax = Convert.ToDateTime($"{month}/{monthMaxDay}/{year} 11:59:59 PM");
            weekMinus = Calender.WeekCalenderDayMinus(dateSelected);
            weekAdd = Calender.WeekCalenderDayAdd(dateSelected);
            weekSelectionMin = dateSelected.AddDays(-weekMinus);
            weekSelectionMax = dateSelected.AddDays(weekAdd);
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateSelected();
            TotalAppointmentCount();
        }

        public void CalenderForm_Load(object sender, EventArgs e)
        {
            foreach(var a in Appointment.Appointments)
            {
                if(a.Type != null && a.Type != "" && !typesComboBox.Items.Contains(a.Type))
                {
                    typesComboBox.Items.Add(a.Type);
                }                
            }
            foreach(var u in User.Users)
            {
                if (!userIdComboBox.Items.Contains(u.UserId))
                {
                    userIdComboBox.Items.Add(u.UserId);
                }
               
            }
            string sqlQuery;
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            DataTable dataTable = new DataTable();
            if (firstLoad == true)
            {
                sqlQuery = "Select start, end, appointmentId, customerId, userId, title, " +
                    "description, location, contact, type, url, createDate, createdBy, " +
                    "lastUpdate, lastUpdateBy  FROM appointment;";
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlQuery, conn);
                mySqlData.Fill(dataTable);

                dgvLabel.Text = "All appointments on schedule";               
            }
            else if (firstLoad == false && monthSelected == true)
            {
                sqlQuery = $"SELECT start, end, appointmentId, customerId, userId, title, " +
                    "description, location, contact, type, url, createDate, createdBy, " +
                    "lastUpdate, lastUpdateBy FROM appointment WHERE start >= ?monthSelectionMin " +
                $"AND start <= ?monthSelectionMax;";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                cmd.Parameters.Add("?monthSelectionMin", MySqlDbType.DateTime).Value = monthSelectionMin;
                cmd.Parameters.Add("?monthSelectionMax", MySqlDbType.DateTime).Value = monthSelectionMax;
                cmd.ExecuteNonQuery();
     
                dataTable.Load(cmd.ExecuteReader());
                string month = dateSelected.ToString("MMMM");
                dgvLabel.Text = $"Appointments for month of {month}";
            }
            else if (firstLoad == false && weekSelected == true)
            {
                sqlQuery = "SELECT start, end, appointmentId, customerId, userId, title, " +
                    "description, location, contact, type, url, createDate, createdBy, " +
                    "lastUpdate, lastUpdateBy FROM appointment WHERE start >= ?weekSelectionMin " +
                    "AND start <= ?weekSelectionMax;";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                cmd.Parameters.Add("?dateSelected", MySqlDbType.DateTime).Value = dateSelected;
                cmd.Parameters.Add("?weekSelectionMin", MySqlDbType.DateTime).Value = weekSelectionMin;
                cmd.Parameters.Add("?weekSelectionMax", MySqlDbType.DateTime).Value = weekSelectionMax;

                cmd.ExecuteNonQuery();

                dataTable.Load(cmd.ExecuteReader());
                dgvLabel.Text = $"{weekSelectionMin} - {weekSelectionMax}";
            }
            
            calenderDGV.DataSource = dataTable;
            calenderDGV.Sort(calenderDGV.Columns[0], ListSortDirection.Ascending);
            weekRadioButton.Checked = false;
            monthRadioButton.Checked = false;
            conn.Close();
            calenderDGV.Columns[0].HeaderText = "Start Time";
            calenderDGV.Columns[1].HeaderText = "End Time";
            calenderDGV.Columns[2].HeaderText = "Appointment ID #";
            calenderDGV.Columns[3].HeaderText = "Customer ID #";
            calenderDGV.Columns[4].HeaderText = "User ID #";
            calenderDGV.Columns[5].HeaderText = "Title";
            calenderDGV.Columns[6].HeaderText = "Description";
            calenderDGV.Columns[7].HeaderText = "Location";
            calenderDGV.Columns[8].HeaderText = "Contact";
            calenderDGV.Columns[9].HeaderText = "Type";
            calenderDGV.Columns[10].HeaderText = "URL";
            calenderDGV.Columns[11].HeaderText = "Created Date/Time";
            calenderDGV.Columns[12].HeaderText = "Created By";
            calenderDGV.Columns[13].HeaderText = "Last Updated Date/Time";
            calenderDGV.Columns[14].HeaderText = "Last Updated By";













            TotalAppointmentCount();
        }
        public void TotalAppointmentCount()
        {
            int counter = 0;
            foreach (var a in Appointment.Appointments)
            {
                if (a.Start.Month == month && a.End < DateTime.Now)
                {
                    counter++;
                }
            }
            totalAppNumLabel.Text = Convert.ToString(counter);
            comAppLabel.Text =($"Total Appointments \n" +
                $" completed in \n {dateSelected.ToString("MMMM")}");
        }

        private void weekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(firstLoad == true)
            {
                DateSelected();
            }
            firstLoad = false;
            monthSelected = false;
            weekSelected = true;
            CalenderForm_Load(sender, e);
        }
        private void monthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(firstLoad == true)
            {
                DateSelected();
            }
            firstLoad = false;
            weekSelected = false;
            monthSelected = true;
            CalenderForm_Load(sender, e);
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void typesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void typesButton_Click(object sender, EventArgs e)
        {
            DateSelected();
            List<string> types = new List<string>();

            var type = typesComboBox.Text;
            if (typesComboBox.SelectedIndex > -1)
            {
                foreach (var a in Appointment.Appointments)
                {
                    if (a.Type == type && a.Start.Month == month)
                    {
                        types.Add(a.Type);
                    }
                }
                MessageBox.Show($"{types.Count} {type} appointments scheduled for {dateSelected.ToString("MMMM")}.");
            }
            else
            {
                MessageBox.Show("Select appointment type.");
            }
        }

        private void userIdEnterButton_Click(object sender, EventArgs e)
        {
            bool scheduleFound = false;
            foreach (var a in Appointment.Appointments)
            {
                // only one user in database  
                // must add new user in order to test code
                string sqlQuery = "";
                DataTable dataTable = new DataTable();
                try
                {
                    if (a.UserId == int.Parse(userIdComboBox.Text))
                    {

                        MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                        conn.Open();
                        sqlQuery = "Select start, end, appointmentId, customerId, userId, title, " +
                                "description, location, contact, type, url, createDate, createdBy, " +
                                "lastUpdate, lastUpdateBy  FROM appointment " +
                                $"WHERE userId = {a.UserId};";
                        MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlQuery, conn);
                        mySqlData.Fill(dataTable);

                        conn.Close();
                        scheduleFound = true;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("User ID selected is not valid");
                    break;
                }            
                calenderDGV.DataSource = dataTable;
                string userName = "";
                bool userFound = false;
                foreach (var u in User.Users)
                {
                    if (a.UserId == u.UserId)
                    {
                        userName = u.UserName;
                        userFound = true;
                        break;
                    }
                }
                dgvLabel.Text = $"{userName}'s appointment schedule.";
                if (userFound == true && scheduleFound == true)
                {
                    break;
                }
            }
        }
        private void totalAppNumLabel_Click(object sender, EventArgs e)
        {

        }
    }
}