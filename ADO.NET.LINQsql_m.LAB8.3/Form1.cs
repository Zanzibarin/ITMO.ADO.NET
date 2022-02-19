using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ADO.NET.LINQsql_m.LAB8._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new DataClassesProcDataContext();
            foreach (var r in db.Ten_Most_Expensive_Products())
            {
                ListViewItem item =
                listView1.Items.Add(r.TenMostExpensiveProducts.ToString());
                item.SubItems.Add(r.UnitPrice.ToString());
            }

        }
    }
}
