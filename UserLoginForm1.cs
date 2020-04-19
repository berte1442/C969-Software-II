using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.IO;


namespace UserLogInForm
{
    public partial class UserLoginForm1 : Form
    {
        bool isEn = true;

        public static string userName;
        public static string password;
        //public static TimeZoneInfo userTimeZone = TimeZoneInfo.Local;
        //public static string userTimeZoneId = userTimeZone.Id;

        public UserLoginForm1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(userTimeZone));
            //DataSearch.timeZones = TimeZoneInfo.GetSystemTimeZones();
            //// verify following string args to ensure strings are accurate
            ////lambda expressions used to create timezone variables to compare against user timezone
            //var pheonixStandard = DataSearch.timeZones.FirstOrDefault(n => n.Id.ToLower().Contains("us mountain standard time"));
            ////var pheonix = DataSearch.timeZones.FirstOrDefault(n => n.Id.ToLower().Contains(""));
            //var londonSummer = DataSearch.timeZones.FirstOrDefault(n => n.Id.ToLower().Contains("british summer time"));
            ////var london = DataSearch.timeZones.FirstOrDefault(n => n.Id.ToLower().Contains(""));
            //var newYorkStandard = DataSearch.timeZones.FirstOrDefault(n => n.Id.ToLower().Contains("eastern standard time"));
            //var newYorkDaylight = DataSearch.timeZones.FirstOrDefault(n => n.Id.ToLower().Contains("eastern daylight time"));

            //TimeZoneInfo localTime = TimeZoneInfo.Local;

            //if(localTime.Id.ToLower() == pheonixStandard.Id)
            //{
            //    userTimeZone = pheonixStandard;
            //}
            //else if(localTime.Id.ToLower() == newYorkStandard.Id)
            //{
            //    userTimeZone = newYorkStandard;
            //}
            //else if (localTime.Id.ToLower() == newYorkDaylight.Id)
            //{
            //    userTimeZone = newYorkDaylight;
            //}
            //else if(localTime.Id.ToLower() == londonSummer.Id)
            //{
            //    userTimeZone = londonSummer;
            //}
            // following code determines user's system language
            // and sets login form accordingly - English/Spanish
            CultureInfo ci = CultureInfo.CurrentCulture;

            if (ci.EnglishName.Contains("Spanish"))
            {
                isEn = false;
                
                Text = Languages.Spanish.userLogin;
                userNameLabel.Text = Languages.Spanish.userName;
                passwordLabel.Text = Languages.Spanish.password;
                loginButton.Text = Languages.Spanish.login;
            }           
        }
        public static void Log(string userName, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine($"username  :{userName}");
            w.WriteLine("-------------------------------");
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;            
            password = passwordTextBox.Text;

            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            string sqlUserName = $"SELECT userName FROM user WHERE userName = \"{userName}\";";  // use this sytax for queries containing variables
            MySqlCommand cmdUserName = new MySqlCommand(sqlUserName, conn);
            using (MySqlDataReader rdrUserName = cmdUserName.ExecuteReader())
            {
                if (rdrUserName.Read())
                {
                    rdrUserName.Close();
                    string sqlPassword = $"SELECT password FROM user WHERE password = \"{password}\";";  // use this sytax for queries containing variables
                    MySqlCommand cmdPassword = new MySqlCommand(sqlPassword, conn);
                    using (MySqlDataReader rdrPassword = cmdPassword.ExecuteReader())
                    {
                        if (rdrPassword.Read())
                        {
                            userNameTextBox.Clear();
                            passwordTextBox.Clear();                    
                            using(StreamWriter w = File.AppendText("UserLog.txt"))
                            {
                                Log(userName, w);
                            }
                            OptionsForm optionsForm = new OptionsForm();
                            optionsForm.ShowDialog();                            
                        }
                        else
                        {
                            if (isEn == true)
                            {
                                MessageBox.Show(Languages.English.incorrect);
                            }
                            else
                            {
                                MessageBox.Show(Languages.Spanish.incorrect);
                            }
                        }
                    }
                }
                else
                {
                    if (isEn == true)
                    {
                        MessageBox.Show(Languages.English.incorrect);
                    }
                    else
                    {
                        MessageBox.Show(Languages.Spanish.incorrect);
                    }
                    rdrUserName.Close();
                }
                conn.Close();
            }
        }
    }
}

/* spanish translation
 * 
 * Username             Nombre de usuario
 * Password             Contraseña
 * Login                Iniciar sesión
 * User Login           Inicio de sesión de usuario
 * Access granted       Acceso permitido
 */


