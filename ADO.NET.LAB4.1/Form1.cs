using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET.LAB4
{
    public partial class DatasetDesigner : Form
    {
        public DatasetDesigner()
        {
            InitializeComponent();
        }



        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            NorthwindDataSet NorthwindDataset1 = new NorthwindDataSet();
            NorthwindDataSetTableAdapters.CustomersTableAdapter CustomersTableAdapter1 = new NorthwindDataSetTableAdapters.CustomersTableAdapter();
            CustomersTableAdapter1.Fill(NorthwindDataset1.Customers);
            foreach (NorthwindDataSet.CustomersRow NWCustomer in
            NorthwindDataset1.Customers.Rows)
            {
                CustomersListBox.Items.Add(NWCustomer.CompanyName);
            }
        }

        private void CustomersListBox_Click(object sender, EventArgs e)
        {

        }
    }
}
