using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UserLogInForm
{
    class Address
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        static public List<Address> Addresses = new List<Address>();

        static public int addressId;
        public Address()
        {

        }
        public Address(string address1, string address2, int cityId, string postalCode,
            string phone)
        {
            DateTime createDate = DateTime.Now;
            string createdBy = UserLoginForm1.userName;
            DateTime lastUpdate = DateTime.Now;
            string lastUpdateBy = UserLoginForm1.userName;

            Address1 = address1;
            Address2 = address2;
            CityId = cityId;
            PostalCode = postalCode;
            Phone = phone;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        public void AddAddressToDataBase(Address address)
        {
            bool isPresent = false;
            for (int i = 0; i < Addresses.Count; i++)
            {
                if (Addresses[i].Address1 == address.Address1 && Addresses[i].Address2 == address.Address2 && 
                    Addresses[i].CityId == address.CityId && Addresses[i].PostalCode == address.PostalCode && 
                    Addresses[i].Phone == address.Phone)
                {
                    AddressId = Addresses[i].AddressId;
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == false)
            {

                string sqlAddAddress = "INSERT INTO address (address, address2, cityId, postalCode, " +
                    "phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (?address.Address1, " +
                    "?address.Address2, ?address.CityId, ?address.PostalCode, ?address.Phone, ?address.CreateDate, " +
                    "?address.CreatedBy, ?address.LastUpdate, ?address.LastUpdateBy);";

                MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlAddAddress, conn);
                
                cmd.Parameters.Add("?address.Address1", MySqlDbType.VarChar).Value = address.Address1;
                cmd.Parameters.Add("?address.Address2", MySqlDbType.VarChar).Value = address.Address2;
                cmd.Parameters.Add("?address.CityId", MySqlDbType.Int64).Value = address.CityId;
                cmd.Parameters.Add("?address.PostalCode", MySqlDbType.VarChar).Value = address.PostalCode;
                cmd.Parameters.Add("?address.Phone", MySqlDbType.VarChar).Value = address.Phone;
                cmd.Parameters.Add("?address.CreateDate", MySqlDbType.DateTime).Value = address.CreateDate;
                cmd.Parameters.Add("?address.CreatedBy", MySqlDbType.VarChar).Value = address.CreatedBy;
                cmd.Parameters.Add("?address.LastUpdate", MySqlDbType.Timestamp).Value = address.LastUpdate;
                cmd.Parameters.Add("?address.LastUpdateBy", MySqlDbType.VarChar).Value = address.LastUpdateBy;
                cmd.ExecuteNonQuery();

                int addressId = 0;
                string sqlAddressId = $"SELECT addressId FROM address WHERE address = \"{address.Address1}\"" +
                    $"AND address2 = \"{address.Address2}\" AND cityId = \"{address.CityId}\"" +
                    $"AND postalCode = \"{address.PostalCode}\" AND phone = \"{address.Phone}\";";
                using (MySqlCommand cmd2 = new MySqlCommand(sqlAddressId, conn))
                {
                    addressId = (int)cmd2.ExecuteScalar();
                }
                AddressId = addressId;
                conn.Close();
            }
        }
        // UpdateAddress method args - new address - older address.addressId
        static public void UpdateAddress(Address newAddress/*, int oldAddressId*/)
        {
            // this method works!!!
            // 4/3/2020
            string address1 = newAddress.Address1;
            string address2 = newAddress.Address2;
            int cityId = newAddress.CityId;
            string postalCode = newAddress.PostalCode;
            string phone = newAddress.Phone;
            var lastUpdate = newAddress.LastUpdate;
            var lastUpdateBy = newAddress.LastUpdateBy;

            bool newAddressPresent = false;
            for(int i = 0; i < Addresses.Count; i++)
            {
                if(newAddress.Address1 == Addresses[i].Address1 && newAddress.Address2 == Addresses[i].Address2 && 
                    newAddress.CityId == Addresses[i].CityId && newAddress.PostalCode == Addresses[i].PostalCode && 
                    newAddress.Phone == Addresses[i].Phone)
                {
                    newAddress.AddressId = Addresses[i].AddressId;
                    newAddressPresent = true;
                    break;
                }
            }
            if(newAddressPresent == false)
            {
                newAddress.AddAddressToDataBase(newAddress);
                Addresses.Add(newAddress);
            }
        }
        static public void DeleteAddress(int addressId)
        {
            string sqlDeleteAddress = $"DELETE FROM address WHERE addressId = \"{addressId}\";";
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlDeleteAddress, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            foreach(var a in Addresses)
            {               
                if(a.AddressId == addressId)
                {
                    Addresses.Remove(a);
                    break;
                }
            }
        }
        static public void AddressesListFill()
        {
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            string sqlQuery = "SELECT * FROM address";
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader dr = sqlCmd.ExecuteReader();

            foreach (var row in dr)
            {
                Address address = new Address();

                address.AddressId = int.Parse((dr["AddressId"]).ToString());
                address.Address1 = (dr["Address"]).ToString();
                address.Address2 = (dr["Address2"]).ToString();
                address.CityId = int.Parse((dr["CityId"]).ToString());
                address.PostalCode = (dr["PostalCode"]).ToString();
                address.Phone = (dr["Phone"]).ToString();
                address.CreateDate = DateTime.Parse((dr["CreateDate"]).ToString());
                address.CreatedBy = (dr["CreatedBy"].ToString());
                address.LastUpdate = DateTime.Parse((dr["LastUpdate"]).ToString());
                address.LastUpdateBy = (dr["LastUpdateBy"]).ToString();

                if (Addresses.Count == 0)
                {
                    addressId = address.AddressId;
                    Addresses.Add(address);
                }
                else
                {
                    bool isPresent = false;
                    for (int i = 0; i < Addresses.Count; i++)
                    {
                        if (Addresses[i].AddressId == address.AddressId)
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
                        addressId = address.AddressId;
                        Addresses.Add(address);
                    }
                }
            }
            conn.Close();
        }
    }
}
