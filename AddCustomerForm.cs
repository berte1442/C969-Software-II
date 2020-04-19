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
    /// <summary>
    /// 
    /// </summary>
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
            //Lambda expression for closing form
            closeButton.Click += (s, e) => Close();
            //Lambda expression for clearing text boxes in form
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

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {            
            var customerName = custNameTextBox.Text;
            var address1 = addressTextBox.Text;
            var address2 = address2TextBox.Text;
            var city = cityTextBox.Text;
            var postalCode = postalTextBox.Text;
            var countryName = countryTextBox.Text;
            var phoneNum = phoneNumTextBox.Text;

            Country country1 = new Country(countryName);
            country1.AddCountryToDataBase(country1);
            Country.CountriesListFill();

            City city1 = new City(city, country1.CountryId);
            city1.AddCityToDataBase(city1);
            City.CitiesListFill();

            Address address = new Address(address1, address2, city1.CityId, postalCode, phoneNum);
            address.AddAddressToDataBase(address);
            Address.AddressesListFill();

            Customer customer = new Customer(customerName, address.AddressId);
            customer.AddCustomerToDataBase(customer);  
            Customer.CustomersListFill();

            MessageBox.Show("Customer Successfully Stored In Database");

            this.Close();
        }
    }
}
