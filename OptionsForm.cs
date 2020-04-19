using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserLogInForm
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            Customer.CustomersListFill();
            Address.AddressesListFill();
            City.CitiesListFill();
            Country.CountriesListFill();
            Appointment.AppointmentsListFill();
            User.UsersListFill();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Program?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }       
        }
        private void cusRecsButton_Click(object sender, EventArgs e)
        {
            CustomerRecordsForm customerRecordsForm = new CustomerRecordsForm();
            customerRecordsForm.ShowDialog();
        }

        private void viewCalButton_Click(object sender, EventArgs e)
        {
            CalenderForm calenderForm = new CalenderForm();
            calenderForm.ShowDialog();
        }

        private void appointmentsButton_Click(object sender, EventArgs e)
        {
            AppointmentsForm appointmentsForm = new AppointmentsForm();
            appointmentsForm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int userId = 0;

            for(int i = 0; i < User.Users.Count; i++)
            {
                if(User.Users[i].UserName == UserLoginForm1.userName)
                {
                    userId = User.Users[i].UserId;
                }
            }

            for (int i = 0; i < Appointment.Appointments.Count; i++)
            {
                
                DateTime test = Appointment.Appointments[i].Start;
                DateTime alert = test.AddMinutes(-15);
                
                if (alert > now && 
                    alert < now.AddMilliseconds(1000)
                    && Appointment.Appointments[i].UserId == userId)
                {
                    MessageBox.Show($"Appointment schedule for {UserLoginForm1.userName} " +
                        $"at {Appointment.Appointments[i].Start}", "Appointment Reminder");                   
                }
            }
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            NewUserForm newUserForm = new NewUserForm();
            newUserForm.ShowDialog();
        }
    }
}
