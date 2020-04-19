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

    public partial class UpdateCustomerForm : Form
    {
        string customerNameMod;
        string address1Mod;
        string cityMod;
        string countryMod;
        string address2Mod;
        string postalCodeMod;
        string phoneNumMod;
        public UpdateCustomerForm()
        {
            InitializeComponent();
            closeButton.Click += (s, e) => Close();
            //lambda expression used to clear textboxes when resetButton is clicked
            resetButton.Click += (s, e) =>
                {
                    custNameTextBox.Clear();
                    addressTextBox.Clear();
                    cityTextBox.Clear();
                    countryTextBox.Clear();
                    address2TextBox.Clear();
                    postalTextBox.Clear();
                    phoneNumTextBox.Clear();
                };

        }

        private void UpdateCustomerForm_Load(object sender, EventArgs e)
        {
            customerNameMod = custNameTextBox.Text = CustomerRecordsForm.customerName;
            address1Mod = addressTextBox.Text = CustomerRecordsForm.address1;
            address2Mod = address2TextBox.Text = CustomerRecordsForm.address2;
            cityMod = cityTextBox.Text = CustomerRecordsForm.city;
            postalCodeMod = postalTextBox.Text = CustomerRecordsForm.postalCode;
            countryMod = countryTextBox.Text = CustomerRecordsForm.country;
            phoneNumMod = phoneNumTextBox.Text = CustomerRecordsForm.phone;
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var customerName = custNameTextBox.Text;
            var address1 = addressTextBox.Text;
            var address2 = address2TextBox.Text;
            var city = cityTextBox.Text;
            var postalCode = postalTextBox.Text;
            var country = countryTextBox.Text;
            var phoneNum = phoneNumTextBox.Text;
            var dateTime = DateTime.Now;
            var lastUpdateBy = UserLoginForm1.userName;

            //determines if any changes were made to customer details
            if(customerName == customerNameMod && address1 == address1Mod && address2 == address2Mod && city == cityMod && 
                postalCode == postalCodeMod && country == countryMod && phoneNum == phoneNumMod)
            {
                // not sure if this closing form properly
                Close();
            }
            else
            {
                //creates country object set to original country used for customer details
                Country oldCountry = new Country(countryMod);
                for (int i = 0; i < Country.Countries.Count; i++)
                {
                    if (Country.Countries[i].CountryName == countryMod)
                    {
                        oldCountry.CountryId = Country.Countries[i].CountryId;
                        break;
                    }
                }
                //creates city object set to original cityy used for customer details
                City oldCity = new City(cityMod, oldCountry.CountryId);
                for (int i = 0; i < City.Cities.Count; i++)
                {
                    if (City.Cities[i].CityName == cityMod && City.Cities[i].CountryId
                        == oldCountry.CountryId)
                    {
                        oldCity.CityId = City.Cities[i].CityId;
                        break;
                    }
                }
                //creates address object set to original address used for customer details
                Address oldAddress = new Address(address1Mod, address2Mod, oldCity.CityId,
                    postalCodeMod, phoneNumMod);
                for (int i = 0; i < Address.Addresses.Count; i++)
                {
                    if (Address.Addresses[i].Address1 == address1Mod && Address.Addresses[i].Address2 ==
                        address2Mod && Address.Addresses[i].CityId == oldCity.CityId &&
                        Address.Addresses[i].PostalCode == postalCodeMod && Address.Addresses[i].Phone
                        == phoneNumMod)
                    {
                        oldAddress.AddressId = Address.Addresses[i].AddressId;
                        break;
                    }
                }
                //creates customer object set to original customer used for customer details
                Customer oldCustomer = new Customer(customerNameMod, oldAddress.AddressId);
                for (int i = 0; i < Customer.Customers.Count; i++)
                {
                    if (Customer.Customers[i].CustomerName == customerNameMod &&
                        Customer.Customers[i].AddressId == oldAddress.AddressId)
                    {
                        oldCustomer.CustomerId = Customer.Customers[i].CustomerId;
                    }
                }
                //creates country object set to new country used for customer details
                Country newCountry = new Country(country);
                //determines if country has been changed
                if (newCountry.CountryName != oldCountry.CountryName)
                {
                    Country.UpdateCountry(newCountry/*, oldCountry.CountryId*/);
                }
                else
                {
                    //sets newCountry.CountryId if country has not changed
                    newCountry.CountryId = oldCountry.CountryId;
                }
                //creates city object set to new city used for customer details
                City newCity = new City(city, newCountry.CountryId);
                //determines if city has been changed // this will be true if country has changed
                if (newCity.CityName != oldCity.CityName || newCity.CountryId != oldCity.CountryId)
                {
                    City.UpdateCity(newCity/*, oldCity.CityId*/);
                }
                else
                {
                    //sets newCity.CityId if city has not changed
                    newCity.CityId = oldCity.CityId;
                }
                //creates address object set to new address used for customer details
                Address newAddress = new Address(address1, address2, newCity.CityId, postalCode, phoneNum);
                //determines if address has changed // this will be true if city has changed // always true if country changed
                if (newAddress.Address1 != oldAddress.Address1 || newAddress.Address2 != oldAddress.Address2 ||
                     newAddress.CityId != oldAddress.CityId || newAddress.PostalCode != oldAddress.PostalCode ||
                     newAddress.Phone != oldAddress.Phone)
                {
                    Address.UpdateAddress(newAddress/*, oldAddress.AddressId*/);
                }
                else
                {
                    //sets newAddress.AddressId if address has not changed
                    newAddress.AddressId = oldAddress.AddressId;
                }
                //creates ccustomer object set to new customer used for customer details
                Customer newCustomer = new Customer(customerName, newAddress.AddressId);
                //determines if customer has changed // this will be true if address has changed // always true if country and/or city have changed
                if (newCustomer.CustomerName != oldCustomer.CustomerName || newCustomer.AddressId != oldCustomer.AddressId)
                {
                    Customer.UpdateCustomer(newCustomer, oldCustomer.CustomerId);
                }

                //determines if address is associated with any other customers
                // deletes address if no longer needed
                bool addressPresent = false;
                for(int i = 0; i < Customer.Customers.Count; i++)
                {
                    int addressCounter = 0;
                    if(Customer.Customers[i].AddressId == oldAddress.AddressId)
                    {
                        addressCounter++;
                    }
                    if(addressCounter > 0) // unsure if 1 is correct
                    {
                        addressPresent = true;
                        break;
                    }
                }
                if(addressPresent == false)
                {
                    Address.DeleteAddress(oldAddress.AddressId);
                }
                //determiens if city is associated with any other addresses
                //deletes city if no longer needed
                bool cityPresent = false;
                for(int i = 0; i < Address.Addresses.Count; i++)
                {
                    int cityCounter = 0;
                    if(Address.Addresses[i].CityId == oldCity.CityId)
                    {
                        cityCounter++;
                    }
                    if((addressPresent == false && cityCounter > 0) || 
                        addressPresent == true) 
                    {
                        cityPresent = true;
                        break;
                    }
                }
                if(cityPresent == false)
                {
                    City.DeleteCity(oldCity.CityId);
                }
                //determines if country is associated with any other cities
                // deletes country if no longer needed 
                bool countryPresent = false;
                for (int i = 0; i < City.Cities.Count; i++)
                {
                    int countryCounter = 0;
                    if(City.Cities[i].CountryId == oldCountry.CountryId)
                    {
                        countryCounter++;
                    }
                    if((cityPresent == false && countryCounter > 0) || 
                        cityPresent == true)
                    {
                        countryPresent = true;
                        break;
                    }                   
                }
                if(countryPresent == false)
                {
                    Country.DeleteCountry(oldCountry.CountryId);
                }


                MessageBox.Show("Customer updated successfully");

                // following checks list counts to ensure they are in line with database rows

                //int cusListCount = Customer.Customers.Count;
                //int addListCount = Address.Addresses.Count;
                //int citListCount = City.Cities.Count;
                //int couListcount = Country.Countries.Count;

                Close();
            }                     
        }
    }
}
