using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ADO.NET.LAB4._3
{
    public partial class DataAdapterProgram : Form
    {
        public DataAdapterProgram()
        {
            InitializeComponent();
            SqlDataAdapter1.Fill(NorthwindDataset, "Customers");
            dataGridView1.DataSource = NorthwindDataset.Tables["Customers"];
        }

        static SqlConnection NorthwindConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=northwind;Integrated Security=True");
        static string query = "SELECT * FROM Customers";

        static SqlDataAdapter SqlDataAdapter1 = new SqlDataAdapter(query, NorthwindConnection);

        DataSet NorthwindDataset = new DataSet("Northwind");

        SqlCommandBuilder commands = new SqlCommandBuilder(SqlDataAdapter1);

        private void button1_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["Customers"]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow CustRow = NorthwindDataset.Tables["Customers"].NewRow();
            Object[] CustRecord = {"AAAAA", "Alfreds Futterkiste", 
                "Maria Anders", "Sales Representative", "Obere Str. 57", 
                "Berlin", null, "12209", "Germany", "030-0074321","030-0076545"};
            
            CustRow.ItemArray = CustRecord;
            NorthwindDataset.Tables["Customers"].Rows.Add(CustRow);

            SqlDataAdapter1.Update(NorthwindDataset.Tables["Customers"]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            var index = dataGridView1.CurrentRow.Index;
            NorthwindDataset.Tables["Customers"].Rows[index].Delete();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["Customers"]);

        }
    }
}
