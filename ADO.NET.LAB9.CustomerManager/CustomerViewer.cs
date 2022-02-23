using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ADO.NET.LAB9.CustomerManager
{
    public partial class CustomerViewer : Form
    {
        SampleContext context = new SampleContext();
        byte[] Ph;

        public CustomerViewer()
        {
            InitializeComponent();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SampleContext>());

        }

        private void Output()
        {
            if (this.CustomerradioButton.Checked == true) GridView.DataSource = context.Customers.ToList();
            else if (this.OrderradioButton.Checked == true) GridView.DataSource = context.Orders.ToList();
            else if (this.ViporderradioButton.Checked == true) GridView.DataSource = context.VipOrders.ToList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    FirstName = this.textBoxname.Text,
                    LastName = this.textBoxlastname.Text,
                    Email = this.textBoxmail.Text,
                    Age = Int32.Parse(this.textBoxage.Text),
                    Orders = orderlistBox.SelectedItems.OfType<Order>().ToList(),
                    Photo = Ph
                };

                context.Customers.Add(customer);
                context.SaveChanges();
                Output();
                textBoxname.Text = String.Empty;
                textBoxmail.Text = String.Empty;
                textBoxage.Text = String.Empty;
                textBoxlastname.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.ToString());
            }
        }


        private void buttonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                Image bm = new Bitmap(diag.OpenFile());

                ImageConverter converter = new ImageConverter();
                Ph = (byte[])converter.ConvertTo(bm, typeof(byte[]));
            }
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            var query = from b in context.Customers
                        orderby b.FirstName
                        select b;
            customerList.DataSource = query.ToList();

            Output();
        }

        private void customerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CustomerViewer_Load(object sender, EventArgs e)
        {
            context.Orders.Add(new Order
            {
                ProductName = "Аудио", Quantity = 12, PurchaseDate = DateTime.Parse("12.01.2016")
            });

            context.Orders.Add(new Order
            {
                ProductName = "Видео", Quantity = 22, PurchaseDate = DateTime.Parse("10.01.2016")
            });

            context.VipOrders.Add(new VipOrder
            {
                ProductName = "Авто",
                Quantity = 101,
                PurchaseDate = DateTime.Parse("10.01.2016"),
                status = "Высокий"
            });


            context.SaveChanges();
            orderlistBox.DataSource = context.Orders.ToList();
        }

        private void orderlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView.CurrentRow == null) return;
            var customer = GridView.CurrentRow.DataBoundItem as Customer;
            if (customer == null) return;

            labelid.Text = Convert.ToString(customer.CustomerId);
            textBoxCustomer.Text = customer.ToString();
            textBoxname.Text = customer.FirstName;
            textBoxlastname.Text = customer.LastName;
            textBoxmail.Text = customer.Email;
            textBoxage.Text = Convert.ToString(customer.Age);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (labelid.Text == String.Empty) return;
            var id = Convert.ToInt32(labelid.Text);
            var customer = context.Customers.Find(id);
            if (customer == null) return;
            customer.FirstName = this.textBoxname.Text;
            customer.LastName = this.textBoxlastname.Text;
            customer.Email = this.textBoxmail.Text;
            customer.Age = Int32.Parse(this.textBoxage.Text);

            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();
            Output();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (labelid.Text == String.Empty) return;
            var id = Convert.ToInt32(labelid.Text);
            var customer = context.Customers.Find(id);
            context.Entry(customer).State = EntityState.Deleted;
            context.SaveChanges();
            Output();
        }
    }

    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [MaxLength(100)]
        public string Email { get; set; }

        [Range(8, 100)]
        public int Age { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
        public override string ToString()
        {
            string s = FirstName + ", электронный адрес: " + Email;
            return s;
        }
        // Ссылка на заказы
        public virtual List<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        // Ссылка на покупателя
        public Customer Customer { get; set; }
        public override string ToString()
        {
            string s = ProductName + " " + Quantity + "шт., дата: " +
            PurchaseDate;
            return s;
        }
    }

    public class SampleContext : DbContext
    {
        public SampleContext() : base("Blogging")
        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(30);
        }
        public DbSet<VipOrder> VipOrders { get; set; }
    }

    public class VipOrder : Order
    {
        public string status { get; set; }
    }
}
