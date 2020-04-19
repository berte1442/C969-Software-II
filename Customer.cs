using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UserLogInForm
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public byte Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        static public List<Customer> Customers = new List<Customer>();
        public Customer()
        {

            //byte active = 1;

            //DateTime createDate = DateTime.Now;
            //string createdBy = UserLoginForm1.userName;
            //DateTime lastUpdate = DateTime.Now;
            //string lastUpdateBy = UserLoginForm1.userName;

            //Active = active;
            //CreateDate = createDate;
            //CreatedBy = createdBy;
            //LastUpdate = lastUpdate;
            //LastUpdateBy = lastUpdateBy;
        }

        public Customer(string customerName, int addressId)
        {
            byte active = 1;  // active is a bool variable - byte used to convert to bit in sql
            DateTime createDate = DateTime.Now;
            string createdBy = UserLoginForm1.userName;
            DateTime lastUpdate = DateTime.Now;
            string lastUpdateBy = UserLoginForm1.userName;
            
            CustomerName = customerName;
            AddressId = addressId;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy; 
           
        }
        public void AddCustomerToDataBase(Customer customer)
        {
            bool isPresent = false;
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].CustomerName == customer.CustomerName && Customers[i].AddressId == customer.AddressId)
                {
                    this.CustomerId = Customers[i].CustomerId;
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == false)
            {
                string sqlAddCustomer = "INSERT INTO customer (customerName, addressId, active," +
                    "createDate, createdBy, lastUpdate, lastUpdateBy)" +
                    "VALUES( ?customer.CustomerName, ?customer.AddressId, ?customer.Active, ?customer.CreateDate, " +
                   "?customer.CreatedBy, ?customer.LastUpdate, ?customer.LastUpdateBy);";
                     
                MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlAddCustomer, conn);
                cmd.Parameters.Add("?customer.CustomerName", MySqlDbType.VarChar).Value = customer.CustomerName;
                cmd.Parameters.Add("?customer.AddressId", MySqlDbType.Int64).Value = customer.AddressId;
                cmd.Parameters.Add("?customer.Active", MySqlDbType.Bit).Value = customer.Active;
                cmd.Parameters.Add("?customer.CreateDate", MySqlDbType.DateTime).Value = customer.CreateDate;
                cmd.Parameters.Add("?customer.CreatedBy", MySqlDbType.VarChar).Value = customer.CreatedBy;
                cmd.Parameters.Add("?customer.LastUpdate", MySqlDbType.Timestamp).Value = customer.LastUpdate;
                cmd.Parameters.Add("?customer.LastUpdateBy", MySqlDbType.VarChar).Value = customer.LastUpdateBy;

                cmd.ExecuteNonQuery();

                int customerId = 0;
                string sqlCustomerId = $"SELECT customerId FROM customer WHERE customerName = \"{customer.CustomerName}\"" +
                    $"AND addressId = \"{customer.AddressId}\";";
                using (MySqlCommand cmd2 = new MySqlCommand(sqlCustomerId, conn))
                {
                    customerId = (int)cmd2.ExecuteScalar();
                }
                CustomerId = customerId;
                conn.Close();               
            }
        }
        // UpdateCustomer method args - new customer - older customerId
        static public void UpdateCustomer(Customer newCustomer, int oldCustomerId)//, string customerName)
        {
            // this method did not update properly
            // 4/1/2020
            var customerName = newCustomer.CustomerName;
            var addressId = newCustomer.AddressId;
            var active = newCustomer.Active;
            var lastUpdate = newCustomer.LastUpdate;
            var lastUpdateBy = newCustomer.LastUpdateBy;

            string sqlCustomerUpdate = "UPDATE customer " +
                "SET customerName = ?customer.CustomerName, " +
                "addressId = ?customer.AddressId, " +
                "active = ?customer.Active, " +
                "lastUpdate = ?customer.LastUpdate, " +
                "customer.lastUpdateBy = ?customer.LastUpdateBy " +
                "WHERE customerId = ?customerId;";

            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlCustomerUpdate, conn);
            cmd.Parameters.Add("?customer.CustomerName", MySqlDbType.VarChar).Value = newCustomer.CustomerName;
            cmd.Parameters.Add("?customer.AddressId", MySqlDbType.Int64).Value = newCustomer.AddressId;
            cmd.Parameters.Add("?customer.Active", MySqlDbType.Byte).Value = newCustomer.Active;
            cmd.Parameters.Add("?customer.LastUpdate", MySqlDbType.Timestamp).Value = newCustomer.LastUpdate;
            cmd.Parameters.Add("?customer.LastUpdateBy", MySqlDbType.VarChar).Value = newCustomer.LastUpdateBy;
            cmd.Parameters.Add("?customerId", MySqlDbType.Int64).Value = oldCustomerId;

            cmd.ExecuteNonQuery();
            conn.Close();

            for(int i = 0; i < Customers.Count; i++)
            {
                if(Customers[i].CustomerId == oldCustomerId)
                {
                    Customers[i].CustomerName = customerName;
                    Customers[i].AddressId = addressId;
                    Customers[i].Active = active;
                    Customers[i].LastUpdate = lastUpdate;
                    Customers[i].LastUpdateBy = lastUpdateBy;

                    break;
                }
            }
            
        }
        static public void DeleteCustomer(int customerId)
        {
            string sqlDeleteCustomer = $"DELETE FROM customer WHERE customerId = \"{customerId}\";";
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlDeleteCustomer, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            foreach (var c in Customers)
            {
                if (c.CustomerId == customerId)
                {
                    Customers.Remove(c);
                    break;
                }
            }
        }
        static public void CustomersListFill()
        {
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            string sqlQuery = "SELECT * FROM customer";  
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader dr = sqlCmd.ExecuteReader();

            foreach(var row in dr) 
            {
                Customer customer = new Customer();

                customer.CustomerId = int.Parse((dr["CustomerId"]).ToString());
                customer.CustomerName = (dr["CustomerName"]).ToString();
                customer.AddressId = int.Parse((dr["AddressId"]).ToString());
                customer.Active = Convert.ToByte(dr["Active"]);  //input string error here
                customer.CreateDate = DateTime.Parse((dr["CreateDate"]).ToString());
                customer.CreatedBy = (dr["CreatedBy"].ToString());
                customer.LastUpdate = DateTime.Parse((dr["LastUpdate"]).ToString());
                customer.LastUpdateBy = (dr["LastUpdateBy"]).ToString();

                if (Customers.Count == 0)
                {
                    Customers.Add(customer);
                }
                else
                {
                    bool isPresent = false;
                    for (int i = 0; i < Customers.Count; i++)
                    {
                        if (Customers[i].CustomerId == customer.CustomerId)
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
                        Customers.Add(customer);
                    }
                }
            }
            conn.Close();
        }
    }
}
