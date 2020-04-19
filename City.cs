using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UserLogInForm
{
    class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        static public List<City> Cities = new List<City>();

        static public int cityId; 
        public City()
        {

        }
        public City(string cityName, int countryId)
        {
            DateTime createDate = DateTime.Now;
            string createdBy = UserLoginForm1.userName;
            DateTime lastUpdate = DateTime.Now;
            string lastUpdateBy = UserLoginForm1.userName;

            CityName = cityName;
            CountryId = countryId;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        public void AddCityToDataBase(City city)
        {
            bool isPresent = false;
            for (int i = 0; i < Cities.Count; i++)
            {
                if (Cities[i].CityName == city.CityName && Cities[i].CountryId == city.CountryId)
                {
                    CityId = Cities[i].CityId;
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == false)
            {
                string sqlAddCity = "INSERT INTO city (city, countryId, createDate, " +
                    "createdBy, lastUpdate, lastUpdateBy) VALUES (?city.CityName, " +
                    "?city.CountryId, ?city.CreateDate, ?city.CreatedBy, ?city.LastUpdate, " +
                    "?city.LastUpdateBy);";

                MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlAddCity, conn);
                cmd.Parameters.Add("?city.CityName", MySqlDbType.VarChar).Value = city.CityName;
                cmd.Parameters.Add("?city.CountryId", MySqlDbType.Int64).Value = city.CountryId;
                cmd.Parameters.Add("?city.CreateDate", MySqlDbType.DateTime).Value = city.CreateDate;
                cmd.Parameters.Add("?city.CreatedBy", MySqlDbType.VarChar).Value = city.CreatedBy;
                cmd.Parameters.Add("?city.LastUpdate", MySqlDbType.Timestamp).Value = city.LastUpdate;
                cmd.Parameters.Add("?city.LastUpdateBy", MySqlDbType.VarChar).Value = city.LastUpdateBy;
                cmd.ExecuteNonQuery();

                int cityId = 0;
                string sqlCityId = $"SELECT cityId FROM city WHERE city = \"{city.CityName}\"" +
                    $"AND countryId = \"{city.CountryId}\";";
                using (MySqlCommand cmd2 = new MySqlCommand(sqlCityId, conn))
                {
                    cityId = (int)cmd2.ExecuteScalar();
                }
                CityId = cityId;

                conn.Close();
            }
        }
        // updatecity args - new city, old cityId
        static public void UpdateCity(City newCity/*, int oldCityId*/)
        {
            // this method works!!!
            // 4/3/2020
            var cityName = newCity.CityName;
            var countryId = newCity.CountryId;
            var lastUpdate = newCity.LastUpdate;
            var lastUpdateBy = newCity.LastUpdateBy;

            bool newCityPresent = false;
            for (int i = 0; i < Cities.Count; i++)
            {
                if(newCity.CityName == Cities[i].CityName && newCity.CountryId == Cities[i].CountryId)
                {
                    newCity.CityId = Cities[i].CityId;
                    newCityPresent = true;
                    break;
                }
            }
            if(newCityPresent == false)
            {
                newCity.AddCityToDataBase(newCity);
                Cities.Add(newCity);
            }
        }
        static public void DeleteCity(int cityId)
        {
            string sqlDeleteCity = $"DELETE FROM city WHERE cityId = \"{cityId}\";";
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlDeleteCity, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            foreach (var c in Cities)
            {
                if (c.CityId == cityId)
                {
                    Cities.Remove(c);
                    break;
                }
            }
        }
        static public void CitiesListFill()
        {
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            string sqlQuery = "SELECT * FROM city";
            MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader dr = sqlCmd.ExecuteReader();

            foreach (var row in dr)
            {
                City city = new City();

                city.CityId = int.Parse((dr["CityId"]).ToString());
                city.CityName = (dr["City"]).ToString();
                city.CountryId = int.Parse((dr["CountryId"]).ToString());
                city.CreateDate = DateTime.Parse((dr["CreateDate"]).ToString());
                city.CreatedBy = (dr["CreatedBy"].ToString());
                city.LastUpdate = DateTime.Parse((dr["LastUpdate"]).ToString());
                city.LastUpdateBy = (dr["LastUpdateBy"]).ToString();

                if (Cities.Count == 0)
                {
                    cityId = city.CityId;
                    Cities.Add(city);
                }
                else
                {
                    bool isPresent = false;
                    for (int i = 0; i < Cities.Count; i++)
                    {
                        if (Cities[i].CityId == city.CityId)
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
                        cityId = city.CityId;
                        Cities.Add(city);
                    }
                }
            }
            conn.Close();
        }
    }
}
