using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET.LAB6._2
{
    public partial class LoadDataSetXml : Form
    {
        public LoadDataSetXml()
        {
            InitializeComponent();
        }

        DataSet NorthwindDataSet = new DataSet();

        private void LoadSchemaButton_Click(object sender, EventArgs e)
        {
            NorthwindDataSet.ReadXmlSchema("Northwind.xsd");
            CustomersGrid.DataSource = NorthwindDataSet.Tables["Customers"];
            OrdersGrid.DataSource = NorthwindDataSet.Tables["Orders"];
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            NorthwindDataSet.ReadXml("Northwind.xml");
        }
    }
}
