using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserLogInForm
{
    public partial class CustomerDisplayForm : Form
    {
        public CustomerDisplayForm()
        {
            InitializeComponent();
        }

        private void CustomerDisplayForm_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < Customer.Customers.Count; i++)
            {
                if(AppointmentsForm.customerId == Customer.Customers[i].CustomerId)
                {
                    customerIdLabel2.Text = Customer.Customers[i].CustomerId.ToString();
                    customerNameLabel2.Text = Customer.Customers[i].CustomerName;
                    addressIdLabel2.Text = Customer.Customers[i].AddressId.ToString();
                    createDateLabel2.Text = Customer.Customers[i].CreateDate.ToString();
                    createdByLabel2.Text = Customer.Customers[i].CreatedBy;
                    lastUpdateLabel2.Text = Customer.Customers[i].LastUpdate.ToString();
                    lastUpdateByLabel2.Text = Customer.Customers[i].LastUpdateBy;

                    if(Customer.Customers[i].Active == 1)
                    {
                        activeLabel2.Text = "True";
                    }
                    else
                    {
                        activeLabel2.Text = "False";
                    }                    
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
