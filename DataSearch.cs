using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UserLogInForm
{
    class DataSearch
    {
        public static string connStr = "server=3.227.166.251;user id=U05m2C;database=U05m2C;password=53688545422;persistsecurityinfo=True";

        public static int TZDiff()
        {
            TimeZoneInfo userTimeZone = TimeZoneInfo.Local;
            string userTimeZoneId = userTimeZone.Id;

            var diff = 0;
            //My time zone
            if (userTimeZoneId == "Central Standard Time") // testing in this tz
            {
                diff = -300;
            }
            //London time zone
            else if (userTimeZoneId == "GMT Standard Time")
            {
                diff = 60;
            }
            //Phoenix time zone
            else if (userTimeZoneId == "Mountain Standard Time")
            {
                diff = 360;
            }
            //New York time zone
            else if (userTimeZoneId == "Eastern Standard Time")
            {
                diff = -240;
            }
            return diff;
        }
        //I have not used this method as of yet - see about replacing writen code with method
        //static public bool IsInDataBase(string dataMatch, string field, string table) 
        //{
        //    bool isInDataBase;

        //    MySqlConnection conn = new MySqlConnection(connStr);
        //    conn.Open();

        //    string sqlCheckData = $"SELECT \"{field}\" FROM \"{table}\" WHERE \"{field}\" = \"{dataMatch}\";";
        //    MySqlCommand cmdCheckData = new MySqlCommand(sqlCheckData, conn);
        //    using (MySqlDataReader rdrUserName = cmdCheckData.ExecuteReader())
        //    {
        //        if (rdrUserName.Read())
        //        {
        //            isInDataBase = true;
        //        }
        //        else
        //        {
        //            isInDataBase = false;
        //        }
        //        conn.Close();
        //    }
        //    return isInDataBase;
        //}

        //static public IReadOnlyCollection<TimeZoneInfo> timeZones;            
    }
}
