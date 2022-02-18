using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET.LAB5._3
{
    public partial class DataBindingComplex : Form
    {
        public DataBindingComplex()
        {
            InitializeComponent();
        }

        private void BindGridButton_Click(object sender, EventArgs e)
        {
            BindingSource productsBindingSource = new BindingSource(northwindDataSet1, "Products");
            ProductsGrid.DataSource = productsBindingSource;
            bindingNavigator1.BindingSource = productsBindingSource;
            productsTableAdapter1.Fill(northwindDataSet1.Products);
        }
    }
}
