using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UserLogInForm
{
    class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public static List<Appointment> Appointments = new List<Appointment>();
        
        static public int appointmentId;
        public Appointment() 
        { 
        }

        //set dateTimes and createdbys in constructor 
        public Appointment(int customerId, int userId, string title,
            string description, string location, string contact, string type, string url, DateTime start,
            DateTime end)
        {
            //DateTime utcNow = DateTime.UtcNow;
            DateTime createDate = DateTime.UtcNow;
            string createdBy = UserLoginForm1.userName;
            DateTime lastUpdate = DateTime.UtcNow;
            string lastUpdateBy = UserLoginForm1.userName;

            //var timeZone = UserLoginForm1.userTimeZone;
            //var diff = timeZone.BaseUtcOffset.TotalMinutes;

            //createDate = createDate.AddMinutes(diff);
            //lastUpdate = lastUpdate.AddMinutes(diff);
            //start = start.AddMinutes(diff);
            //end = end.AddMinutes(diff);
            //start = Convert.ToDateTime(start);
            //end = Convert.ToDateTime(end);

            CustomerId = customerId;
            UserId = userId;
            Title = title;
            Description = description;
            Location = location;
            Contact = contact;
            Type = type;
            URL = url;
            Start = start;
            End = end;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
        public void AddAppointmentToDataBase(Appointment appointment)
        {
            bool isPresent = false;
            for (int i = 0; i < Appointments.Count; i++)
            {
                if (Appointments[i].CustomerId == appointment.CustomerId && 
                    Appointments[i].UserId == appointment.UserId &&
                    Appointments[i].Title == appointment.Title &&
                    Appointments[i].Description == appointment.Description &&
                    Appointments[i].Location == appointment.Location &&
                    Appointments[i].Contact == appointment.Contact &&
                    Appointments[i].Type == appointment.Type &&
                    Appointments[i].URL == appointment.URL &&
                    Appointments[i].Start == appointment.Start &&
                    Appointments[i].End == appointment.End &&
                    Appointments[i].CreateDate == appointment.CreateDate &&
                    Appointments[i].CreatedBy == appointment.CreatedBy)
                {
                    AppointmentId = Appointments[i].AppointmentId;
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == false)
            {
                
                string sqlAddAppointment = $"INSERT INTO appointment " +
                $"(customerId, userId, title, description, location, contact, type, url, start, end, " +
                $"createDate, createdBy, lastUpdate, lastUpdateBy) " +
                $"VALUES (?appointment.CustomerId, ?appointment.UserId, ?appointment.Title, ?appointment.Description, " +
                $"?appointment.Location, ?appointment.Contact, ?appointment.Type, ?appointment.URL, " +
                $"?appointment.Start, ?appointment.End, ?appointment.CreateDate, ?appointment.CreatedBy, " +
                $"?appointment.LastUpdate, ?appointment.LastUpdateBy);";

                MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlAddAppointment, conn);
                cmd.Parameters.Add("?appointment.CustomerId", MySqlDbType.Int64).Value = appointment.CustomerId;
                cmd.Parameters.Add("?appointment.UserId", MySqlDbType.Int64).Value = appointment.UserId;
                cmd.Parameters.Add("?appointment.Title", MySqlDbType.VarChar).Value = appointment.Title;
                cmd.Parameters.Add("?appointment.Description", MySqlDbType.VarChar).Value = appointment.Description;
                cmd.Parameters.Add("?appointment.Location", MySqlDbType.VarChar).Value = appointment.Location;
                cmd.Parameters.Add("?appointment.Contact", MySqlDbType.VarChar).Value = appointment.Contact;
                cmd.Parameters.Add("?appointment.Type", MySqlDbType.VarChar).Value = appointment.Type;
                cmd.Parameters.Add("?appointment.URL", MySqlDbType.VarChar).Value = appointment.URL;
                cmd.Parameters.Add("?appointment.Start", MySqlDbType.DateTime).Value = appointment.Start;
                cmd.Parameters.Add("?appointment.End", MySqlDbType.DateTime).Value = appointment.End;
                cmd.Parameters.Add("?appointment.CreateDate", MySqlDbType.DateTime).Value = appointment.CreateDate;
                cmd.Parameters.Add("?appointment.CreatedBy", MySqlDbType.VarChar).Value = appointment.CreatedBy;
                cmd.Parameters.Add("?appointment.LastUpdate", MySqlDbType.Timestamp).Value = appointment.LastUpdate;
                cmd.Parameters.Add("?appointment.LastUpdateBy", MySqlDbType.VarChar).Value = appointment.LastUpdateBy;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
        static public void DeleteAppointment(int appointmentId)
        {
            string sqlDeleteAppointment = $"DELETE FROM appointment WHERE appointmentId = \"{appointmentId}\";";
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlDeleteAppointment, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            foreach (var a in Appointments)
            {
                if (a.AppointmentId == appointmentId)
                {
                    Appointments.Remove(a);
                    break;
                }
            }
        }
        static public void UpdateAppoinment(Appointment newAppointment, int oldAppointmentId)
        {
            var customerId = newAppointment.CustomerId;
            var userId = newAppointment.UserId;
            var title = newAppointment.Title;
            var description = newAppointment.Description;
            var location = newAppointment.Location;
            var contact = newAppointment.Contact;
            var type = newAppointment.Type;
            var url = newAppointment.URL;
            var start = newAppointment.Start;
            var end = newAppointment.End;
            var lastUpdate = newAppointment.LastUpdate;
            var lastUpdateBy = newAppointment.LastUpdateBy;

            string sqlCustomerUpdate = "UPDATE appointment " +
                "SET userId = ?appointment.UserId, " +
                "customerId = ?appointment.CustomerId, " +
                "title = ?appointment.Title, " +
                "description = ?appointment.Description, " +
                "location = ?appointment.Location, " +
                "contact = ?appointment.Contact, " +
                "type = ?appointment.Type, " +
                "url = ?appointment.URL, " +
                "start = ?appointment.Start, " +
                "end = ?appointment.End, " +
                "lastUpdate = ?appointment.LastUpdate, " +
                "lastUpdateBy = ?appointment.LastUpdateBy " +
                "WHERE appointmentId = ?appointmentId;";

            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlCustomerUpdate, conn);
            cmd.Parameters.Add("?appointment.CustomerId", MySqlDbType.Int64).Value = newAppointment.CustomerId;
            cmd.Parameters.Add("?appointment.UserId", MySqlDbType.Int64).Value = newAppointment.UserId;
            cmd.Parameters.Add("?appointment.Title", MySqlDbType.VarChar).Value = newAppointment.Title;
            cmd.Parameters.Add("?appointment.Description", MySqlDbType.VarChar).Value = newAppointment.Description;
            cmd.Parameters.Add("?appointment.Location", MySqlDbType.VarChar).Value = newAppointment.Location;
            cmd.Parameters.Add("?appointment.Contact", MySqlDbType.VarChar).Value = newAppointment.Contact;
            cmd.Parameters.Add("?appointment.Type", MySqlDbType.VarChar).Value = newAppointment.Type;
            cmd.Parameters.Add("?appointment.URL", MySqlDbType.VarChar).Value = newAppointment.URL;
            cmd.Parameters.Add("?appointment.Start", MySqlDbType.Timestamp).Value = newAppointment.Start;
            cmd.Parameters.Add("?appointment.End", MySqlDbType.Timestamp).Value = newAppointment.End;
            cmd.Parameters.Add("?appointment.LastUpdate", MySqlDbType.Timestamp).Value = newAppointment.LastUpdate;
            cmd.Parameters.Add("?appointment.LastUpdateBy", MySqlDbType.VarChar).Value = newAppointment.LastUpdateBy;
            cmd.Parameters.Add("?appointmentId", MySqlDbType.Int64).Value = oldAppointmentId;

            cmd.ExecuteNonQuery();
            conn.Close();
            for (int i = 0; i < Appointments.Count; i++)
            {
                if(Appointments[i].AppointmentId == appointmentId)
                {
                    Appointments[i].CustomerId = newAppointment.CustomerId;
                    Appointments[i].UserId = newAppointment.UserId;
                    Appointments[i].Title = newAppointment.Title;
                    Appointments[i].Description = newAppointment.Description;
                    Appointments[i].Location = newAppointment.Location;
                    Appointments[i].Contact = newAppointment.Contact;
                    Appointments[i].Type = newAppointment.Type;
                    Appointments[i].URL = newAppointment.URL;
                    Appointments[i].Start = newAppointment.Start;
                    Appointments[i].End = newAppointment.End;
                    Appointments[i].LastUpdate = DateTime.Now;
                    Appointments[i].LastUpdateBy = UserLoginForm1.userName;
                    break;
                }
            }
        }
        static public void AppointmentsListFill()
        {
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            string sqlQuery = "SELECT * FROM appointment";
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader dr = sqlCmd.ExecuteReader();

            foreach (var row in dr)
            {
                Appointment appointment = new Appointment();

                appointment.AppointmentId = int.Parse((dr["AppointmentId"]).ToString());
                appointment.CustomerId = int.Parse((dr["CustomerId"]).ToString());
                appointment.UserId = int.Parse((dr["UserId"]).ToString());
                appointment.Title = (dr["Title"]).ToString();
                appointment.Description = (dr["Description"]).ToString();
                appointment.Location = (dr["Location"]).ToString();
                appointment.Contact = (dr["Contact"]).ToString();
                appointment.Type = (dr["Type"]).ToString();
                appointment.URL = (dr["URL"]).ToString();
                appointment.Start = DateTime.Parse((dr["Start"]).ToString());
                appointment.End = DateTime.Parse((dr["End"]).ToString());
                appointment.CreateDate = DateTime.Parse((dr["CreateDate"]).ToString());
                appointment.CreatedBy = (dr["CreatedBy"].ToString());
                appointment.LastUpdate = DateTime.Parse((dr["LastUpdate"]).ToString());
                appointment.LastUpdateBy = (dr["LastUpdateBy"]).ToString();

                if (Appointments.Count == 0)
                {
                    appointmentId = appointment.AppointmentId;
                    Appointments.Add(appointment);
                }
                else
                {
                    bool isPresent = false;
                    for (int i = 0; i < Appointments.Count; i++)
                    {
                        if (Appointments[i].AppointmentId == appointment.AppointmentId)
                        {
                            isPresent = true;
                            break;
                        }
                        else
                        {
                            isPresent = false;
                        }
                    }
                    if (isPresent == false)
                    {
                        appointmentId = appointment.AppointmentId;
                        Appointments.Add(appointment);
                    }
                }
            }
            conn.Close();
        }
    }
}
