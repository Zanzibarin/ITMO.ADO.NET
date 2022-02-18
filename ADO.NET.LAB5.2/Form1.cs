using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET.LAB5._2
{
    public partial class DataBindingSimple : Form
    {
        public DataBindingSimple()
        {
            InitializeComponent();
        }

        private BindingSource productsBindingSource;

        private void DataBindingSimple_Load(object sender, EventArgs e)
        {
            productsTableAdapter1.Fill(northwindDataSet1.Products);
            productsBindingSource = new BindingSource(northwindDataSet1, "Products");

            ProductIDTextBox.DataBindings.Add("Text", productsBindingSource, "ProductID");
            ProductNameTextBox.DataBindings.Add("Text", productsBindingSource, "ProductName");
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            productsBindingSource.MovePrevious();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            productsBindingSource.MoveNext();
        }
    }
}
