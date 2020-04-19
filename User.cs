using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace UserLogInForm
{
    class User
    {
        public User()
        {

        }
        public User(string userName, string password)
        {

            byte active = 1;
            DateTime createDate = DateTime.Now;
            string createdBy = UserLoginForm1.userName;
            DateTime lastUpdate = DateTime.Now;
            string lastUpdateBy = UserLoginForm1.userName;

            UserName = userName;
            Password = password;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        static public List<User> Users = new List<User>();

        public void AddUserToDataBase(User user)
        {
            bool isPresent = false;
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName == user.UserName && Users[i].Password == user.Password)
                {
                    UserId = Users[i].UserId;
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == false)
            {
                string sqlAddUser = "INSERT INTO user (userName, password, " +
                    "active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (?user.UserName, ?user.Password, ?user.Active, ?user.CreateDate, " +
                "?user.CreatedBy, ?user.LastUpdate, ?user.LastUpdateBy);";

                MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlAddUser, conn);

                cmd.Parameters.Add("?user.UserName", MySqlDbType.VarChar).Value = user.UserName;
                cmd.Parameters.Add("?user.Password", MySqlDbType.VarChar).Value = user.Password;
                cmd.Parameters.Add("?user.Active", MySqlDbType.Bit).Value = user.Active;
                cmd.Parameters.Add("?user.CreateDate", MySqlDbType.DateTime).Value = user.CreateDate;
                cmd.Parameters.Add("?user.CreatedBy", MySqlDbType.VarChar).Value = user.CreatedBy;
                cmd.Parameters.Add("?user.LastUpdate", MySqlDbType.Timestamp).Value = user.LastUpdate;
                cmd.Parameters.Add("?user.LastUpdateBy", MySqlDbType.VarChar).Value = user.LastUpdateBy;

                cmd.ExecuteNonQuery();

                int userId = 0;
                string sqlUserId = $"SELECT userId FROM user WHERE userName = \"{user.UserName}\"" +
                    $"AND password = \"{user.Password}\";";
                using (MySqlCommand cmd2 = new MySqlCommand(sqlUserId, conn))
                {
                    userId = (int)cmd2.ExecuteScalar();
                }
                UserId = userId;
                conn.Close();
            }
        }
        static public void UsersListFill()
        {
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            string sqlQuery = "SELECT * FROM user";
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader dr = sqlCmd.ExecuteReader();

            foreach (var row in dr)
            {
                User user = new User();

                user.UserId = int.Parse((dr["UserId"]).ToString());
                user.UserName = (dr["UserName"]).ToString();
                user.Password = (dr["Password"]).ToString();
                user.Active = Convert.ToByte(dr["Active"]);  
                user.CreateDate = DateTime.Parse((dr["CreateDate"]).ToString());
                user.CreatedBy = (dr["CreatedBy"].ToString());
                user.LastUpdate = DateTime.Parse((dr["LastUpdate"]).ToString());
                user.LastUpdateBy = (dr["LastUpdateBy"]).ToString();

                if (Users.Count == 0)
                {
                    Users.Add(user);
                }
                else
                {
                    bool isPresent = false;
                    for (int i = 0; i < Users.Count; i++)
                    {
                        if (Users[i].UserId == user.UserId)
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
                        Users.Add(user);
                    }
                }
            }
            conn.Close();
        }
    }
}
