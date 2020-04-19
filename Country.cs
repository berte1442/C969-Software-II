using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UserLogInForm
{
    class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        static public List<Country> Countries = new List<Country>();

        static public int countryId;
        public Country()
        {

        }
        public Country(string country)
        {
            DateTime createDate = DateTime.Now;
            string createdBy = UserLoginForm1.userName;
            DateTime lastUpdate = DateTime.Now;
            string lastUpdateBy = UserLoginForm1.userName;
            
            CountryName = country;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;            
        }

        public void AddCountryToDataBase(Country country)
        {
            bool isPresent = false;
            for(int i = 0; i < Countries.Count; i++)
            {
                if(Countries[i].CountryName == country.CountryName)
                {
                    CountryId = Countries[i].CountryId;
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == false)
            {
                string sqlAddCountry = "INSERT INTO country (country, createDate, createdBy" +
                    ", lastUpdate, lastUpdateBy) VALUES (?country.CountryName, " +
                    "?country.CreateDate, ?country.CreatedBy, ?country.LastUpdate, " +
                    "?country.LastUpdateBy);";

                MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlAddCountry, conn);
                cmd.Parameters.Add("?country.CountryName", MySqlDbType.VarChar).Value = country.CountryName;
                cmd.Parameters.Add("?country.CreateDate", MySqlDbType.DateTime).Value = country.CreateDate;
                cmd.Parameters.Add("?country.CreatedBy", MySqlDbType.VarChar).Value = country.CreatedBy;
                cmd.Parameters.Add("?country.LastUpdate", MySqlDbType.Timestamp).Value = country.LastUpdate;
                cmd.Parameters.Add("?country.LastUpdateBy", MySqlDbType.VarChar).Value = country.LastUpdateBy;
                cmd.ExecuteNonQuery();

                int countryId = 0;
                string sqlCountryId = $"SELECT countryId FROM country WHERE country = \"{country.CountryName}\";";
                using (MySqlCommand cmd2 = new MySqlCommand(sqlCountryId, conn))
                {
                    countryId = (int)cmd2.ExecuteScalar();
                }
                CountryId = countryId;

                conn.Close();
            }
        }
        //updateCountry args - new country - old countryId
        static public void UpdateCountry(Country newCountry/*, int oldCountryId*/)
        {
            //method works!!!
            //4/3/2020
            var countryName = newCountry.CountryName;
            var lastUpdate = newCountry.LastUpdate;
            var lastUpdateBy = newCountry.LastUpdateBy;

            bool newCountryPresent = false;
            for (int i = 0; i < Countries.Count; i++)
            {
                if(newCountry.CountryName == Countries[i].CountryName)
                {
                    newCountry.CountryId = Countries[i].CountryId;
                    newCountryPresent = true;
                    break;
                }
            }
            if(newCountryPresent == false)
            {
                newCountry.AddCountryToDataBase(newCountry);
                Countries.Add(newCountry);
            }
        }
        static public void DeleteCountry(int countryId)
        {
            string sqlDeleteCountry = $"DELETE FROM country WHERE countryId = \"{countryId}\";";
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlDeleteCountry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            foreach (var c in Countries)
            {
                if (c.CountryId == countryId)
                {
                    Countries.Remove(c);
                    break;
                }
            }            
        }
        static public void CountriesListFill()
        {
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            string sqlQuery = "SELECT * FROM country";
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader dr = sqlCmd.ExecuteReader();

            //Countries.Clear();

            foreach (var row in dr)
            {
                Country country = new Country();

                country.CountryId = int.Parse((dr["CountryId"]).ToString());
                country.CountryName = (dr["Country"]).ToString();
                country.CreateDate = DateTime.Parse((dr["CreateDate"]).ToString());
                country.CreatedBy = (dr["CreatedBy"].ToString());
                country.LastUpdate = DateTime.Parse((dr["LastUpdate"]).ToString());
                country.LastUpdateBy = (dr["LastUpdateBy"]).ToString();

                if(Countries.Count == 0)
                {
                    countryId = country.CountryId;
                    Countries.Add(country);
                }
                else
                {
                    bool isPresent = false;
                    for (int i = 0; i < Countries.Count; i++)
                    {                        
                        if(Countries[i].CountryId == country.CountryId)
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
                        countryId = country.CountryId;
                        Countries.Add(country);
                    }
                }                             
            }
            conn.Close();
        }
    }
}

