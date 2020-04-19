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
    public partial class CustomerRecordsForm : Form
    {
        static public string customerName = "";
        static public string address1 = "";
        static public string address2 = "";
        static public string city = "";
        static public string postalCode = "";
        static public string country = "";
        static public string phone = "";
        public string searchType;
        public string searchItem;
        public string sqlCommand;
        public CustomerRecordsForm()
        {
            InitializeComponent();
            //lambda expression for closing form
            exitButton.Click += (s, e) => this.Close();            
        }
        public static string sqlJoinTables;
        private void CustomerRecordsForm_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            sqlJoinTables = $"SELECT customer.customerName, address.address, address.address2, city.city, country.country, address.phone " +
                                  "FROM customer INNER JOIN address " +
                                  "ON customer.addressId = address.addressId " +
                                  "INNER JOIN city " +
                                  "ON city.cityId = address.cityId " +
                                  "INNER JOIN country " +
                                  "ON country.countryId = city.countryId;";

            MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlJoinTables, conn);
            DataTable dataTable = new DataTable();
            mySqlData.Fill(dataTable);

            dgv1.DataSource = dataTable;
            dgv1.Columns[0].HeaderText = "Customer Name";
            dgv1.Columns[1].HeaderText = "Address 1";
            dgv1.Columns[2].HeaderText = "Address 2";
            dgv1.Columns[3].HeaderText = "City";
            dgv1.Columns[4].HeaderText = "Country";
            dgv1.Columns[5].HeaderText = "Phone";

            conn.Close();

            searchTextBox.Clear();
            searchByComboBox.SelectedIndex = -1;

            DataTable blankTable = new DataTable();
            dgv2.DataSource = blankTable;
        }
        private void cusRecSearchButton_Click(object sender, EventArgs e)
        {
            // good opportunity for exception handling here
            searchItem = searchTextBox.Text;
            bool searchBySelected = true;

            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            string sqlCommand = "";

            if (searchByComboBox.Text == "Customer Name")
            {
                DGV2label.Text = "Customer Table";
                selectLabel.Text = "Select Customer";

                searchType = searchByComboBox.Text;

                string customerName = searchItem;

                sqlCommand = $"SELECT * FROM customer WHERE customerName = \"{customerName}\";";
            }
            else if (searchByComboBox.Text == "Customer Address")
            {
                DGV2label.Text = "Address Table";
                selectLabel.Text = "Select Address";

                searchType = searchByComboBox.Text;

                string customerAddress = searchItem;

                sqlCommand = $"SELECT * FROM address WHERE address  = \"{customerAddress}\" OR address2 = \"{customerAddress}\";";
            }
            else if (searchByComboBox.Text == "Customer Phone Number")
            {
                DGV2label.Text = "Address Table";
                selectLabel.Text = "Select Address / Phone Number";

                searchType = searchByComboBox.Text;

                string phoneNum = searchItem;

                sqlCommand = $"SELECT * FROM address WHERE phone  = \"{phoneNum}\";";
            }
            else
            {
                searchBySelected = false;
                MessageBox.Show("Select 'Search By' option to perform search");
            }

            if (searchBySelected == true)
            {
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);
                using (MySqlDataReader rdrCommand = cmd.ExecuteReader())
                {
                    if (rdrCommand.Read())
                    {
                        rdrCommand.Close();
                        MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlCommand, conn);
                        DataTable dataTable = new DataTable();
                        mySqlData.Fill(dataTable);

                        dgv2.DataSource = dataTable;
                        dgv2.Columns[0].HeaderText = "Customer ID #";
                        dgv2.Columns[1].HeaderText = "Customer Name";
                        dgv2.Columns[2].HeaderText = "Address ID #";
                        dgv2.Columns[3].HeaderText = "Active";
                        dgv2.Columns[4].HeaderText = "Created Date/Time";
                        dgv2.Columns[5].HeaderText = "Created By";
                        dgv2.Columns[6].HeaderText = "Last Updated Date/Time";
                        dgv2.Columns[7].HeaderText = "Last Updated By";
                    }
                    else
                    {
                        MessageBox.Show("Customer not found in database");
                    }
                }
            }
            conn.Close();
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            int customerId = 0;
            int addressId = 0;
            int cityId = 0;
            int countryId = 0;
            bool searchActive = true;
            if (searchType == "Customer Name")
            {
                if (dgv2.SelectedRows.Count > 0)
                {
                    int selectedrowindex = dgv2.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgv2.Rows[selectedrowindex];
                    customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
                    addressId = Convert.ToInt32(selectedRow.Cells["addressId"].Value);

                    for (int i = 0; i < Customer.Customers.Count; i++)
                    {
                        if (customerId == Customer.Customers[i].CustomerId)
                        {
                            customerName = Customer.Customers[i].CustomerName;
                        }
                    }
                    for (int i = 0; i < Address.Addresses.Count; i++)
                    {
                        if (addressId == Address.Addresses[i].AddressId)
                        {
                            address1 = Address.Addresses[i].Address1;
                            address2 = Address.Addresses[i].Address2;
                            postalCode = Address.Addresses[i].PostalCode;
                            phone = Address.Addresses[i].Phone;
                            cityId = Address.Addresses[i].CityId;
                        }
                    }
                    for (int i = 0; i < City.Cities.Count; i++)
                    {
                        if (cityId == City.Cities[i].CityId)
                        {
                            city = City.Cities[i].CityName;
                            countryId = City.Cities[i].CountryId;
                        }
                    }
                    for (int i = 0; i < Country.Countries.Count; i++)
                    {
                        if (countryId == Country.Countries[i].CountryId)
                        {
                            country = Country.Countries[i].CountryName;
                        }
                    }
                }
            }
            else if (searchType == "Customer Address" || searchType == "Customer Phone Number")
            {
                if (dgv2.SelectedRows.Count > 0)
                {
                    int selectedrowindex = dgv2.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgv2.Rows[selectedrowindex];
                    addressId = Convert.ToInt32(selectedRow.Cells["addressId"].Value);

                    string sqlCommand = $"SELECT * FROM customer WHERE addressId = \"{addressId}\";";
                    MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);
                    using (MySqlDataReader rdrCommand = cmd.ExecuteReader())
                    {
                        if (rdrCommand.Read())
                        {
                            rdrCommand.Close();
                            MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlCommand, conn);
                            DataTable dataTable = new DataTable();
                            mySqlData.Fill(dataTable);

                            dgv2.DataSource = dataTable;
                            dgv2.Columns[0].HeaderText = "Customer ID #";
                            dgv2.Columns[1].HeaderText = "Customer Name";
                            dgv2.Columns[2].HeaderText = "Address ID #";
                            dgv2.Columns[3].HeaderText = "Active";
                            dgv2.Columns[4].HeaderText = "Created Date/Time";
                            dgv2.Columns[5].HeaderText = "Created By";
                            dgv2.Columns[6].HeaderText = "Last Updated Date/Time";
                            dgv2.Columns[7].HeaderText = "Last Updated By";

                            searchActive = false;

                            selectLabel.Text = "Select Customer";
                            DGV2label.Text = "Customer Table";

                            searchType = "Customer Name";

                            MessageBox.Show("Select customer from table then select 'Update' to continue");
                        }
                    }
                    conn.Close();
                }
            }
            else if (searchType == "")
            {
                MessageBox.Show("Use search option to select customer / address / phone number.");
                searchActive = false;
            }
            if (searchActive == true)
            {
                UpdateCustomerForm updateCustomerForm = new UpdateCustomerForm();
                updateCustomerForm.ShowDialog();

                MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                conn.Open();

                MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlJoinTables, conn);
                DataTable dataTable = new DataTable();
                mySqlData.Fill(dataTable);

                dgv1.DataSource = dataTable;

                DataTable blankTable = new DataTable();
                dgv2.DataSource = blankTable;
                conn.Close();

                searchByComboBox.SelectedIndex = -1;

                searchTextBox.Clear();
            }
        }
        private void addNewCusButton_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
            
            MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
            conn.Open();

            MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlJoinTables, conn);
            DataTable dataTable = new DataTable();
            mySqlData.Fill(dataTable);

            dgv1.DataSource = dataTable;

            conn.Close();
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            bool searchActive = true;
            int customerId = 0;
            int addressId = 0;

            if (searchByComboBox.Text == "Customer Name")
            {     
                if (dgv2.SelectedRows.Count > 0)
                {
                    int selectedrowindex = dgv2.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgv2.Rows[selectedrowindex];
                    customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
                    addressId = Convert.ToInt32(selectedRow.Cells["addressId"].Value);
                }
            }
            else if(searchByComboBox.Text == "Customer Address" || searchByComboBox.Text == "Customer Phone Number")
            {
                if (dgv2.SelectedRows.Count > 0)
                {
                    int selectedrowindex = dgv2.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgv2.Rows[selectedrowindex];
                    addressId = Convert.ToInt32(selectedRow.Cells["addressId"].Value);

                    for(int i = 0; i < Customer.Customers.Count; i++)
                    {
                        if(Customer.Customers[i].AddressId == addressId)
                        {
                            customerId = Customer.Customers[i].CustomerId;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Use search option to select customer / address / phone number.");
                searchActive = false;
            }
            if (searchActive == true)
            {
                DialogResult dialogResult = MessageBox.Show("Customer(s) will be deleted from database permanently. \n Click 'Yes' to continue. \n Click 'No' to abort.",
                 "Delete Customer?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Customer.DeleteCustomer(customerId);                    

                    bool addressAssociated = false;
                    for (int i = 0; i < Customer.Customers.Count; i++)
                    {
                        if (Customer.Customers[i].AddressId == addressId)
                        {
                            addressAssociated = true;
                            break;
                        }
                    }
                    if (addressAssociated == false)
                    {
                        Address.DeleteAddress(addressId);
                    }
                    MessageBox.Show("Customer Deleted Successfully");
                }
                MySqlConnection conn = new MySqlConnection(DataSearch.connStr);
                conn.Open();
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(sqlJoinTables, conn);
                DataTable dataTable = new DataTable();
                mySqlData.Fill(dataTable);

                dgv1.DataSource = dataTable;

                if (searchByComboBox.Text == "Customer Name")
                {
                    sqlCommand = $"SELECT * FROM customer WHERE customerId  = \"{customerId}\";";
                }
                else
                {
                    sqlCommand = $"SELECT * FROM address WHERE addressID = \"{addressId}\";";
                }
                MySqlDataAdapter mySqlData2 = new MySqlDataAdapter(sqlCommand, conn);
                DataTable dataTable2 = new DataTable();
                mySqlData2.Fill(dataTable2);

                dgv2.DataSource = dataTable2;

                conn.Close();

                searchByComboBox.SelectedIndex = -1;

                searchTextBox.Clear();
            }
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string customerName = "";
            if (dgv1.SelectedRows.Count > 0)
            {
                int selectedrowindex = dgv1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgv1.Rows[selectedrowindex];
                customerName = selectedRow.Cells["customerName"].Value.ToString();
            }
            searchTextBox.Text = customerName;
            searchByComboBox.SelectedIndex = 0;
            cusRecSearchButton_Click(sender, e);
        }
    }
}