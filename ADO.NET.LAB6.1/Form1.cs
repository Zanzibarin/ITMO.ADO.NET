using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET.LAB6._1
{
    public partial class SavingDataSetXml : Form
    {
        public SavingDataSetXml()
        {
            InitializeComponent();
        }

        private void FillDataSetButton_Click(object sender, EventArgs e)
        {
            CustomersAdapter.Fill(northwindDataSet1.Customers);
            OrdersAdapter.Fill(northwindDataSet1.Orders);
            CustomersGrid.DataSource = northwindDataSet1.Customers;
        }

        private void SaveXmlDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                northwindDataSet1.WriteXml("Northwind.xml");
                MessageBox.Show("Data saved as XML Data");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveXmlSchemaButton_Click(object sender, EventArgs e)
        {
            try
            {
                northwindDataSet1.WriteXmlSchema("Northwind.xsd");
                MessageBox.Show("Schema saved as XML Schema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
