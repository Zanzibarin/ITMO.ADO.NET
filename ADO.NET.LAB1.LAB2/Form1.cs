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
using System.Data.Common;
using System.Configuration;



namespace ADO.NET.LAB1
{
   
    public partial class Form1 : Form
    {


        



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        SqlConnection connection = new SqlConnection();

        /*string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                                    Initial Catalog=Northwind; 
                                    Integrated Security=true";*/


        //Подключение к БД по имени соединения (имя указано в файле APP.config)
        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }

        string connectionString = GetConnectionStringByName("DBConnect.NorthwindConnectionString");



        //Изменение состояния элементов меню (доступен/недоступен) в зависимости от состояния подключения к БД
        private void Form1_StyleChanged(object sender, EventArgs e)
        {
            this.connection.StateChange += new StateChangeEventHandler(this.connection_StateChange);
        }

        private void connection_StateChange(object sender, StateChangeEventArgs e)
        {
            toolStripMenuItem1.Enabled = (e.CurrentState == ConnectionState.Closed);
            toolStripMenuItem3.Enabled = (e.CurrentState == ConnectionState.Closed);
            toolStripMenuItem2.Enabled = (e.CurrentState == ConnectionState.Open);
        }



        //Подключение к БД
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных " + connection.Database + " выполнено успешно " + "\nСервер: " + connection.DataSource);
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
            }

            catch (SqlException XcpSQL)//Вывод сообщения об ошибке с указанием источника ошибки
            {
                foreach (SqlError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message, "Источник ошибки: " + se.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Отключение от БД
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else
                MessageBox.Show("Соединение с базой данных уже закрыто");
        }



        //Асинхронное подключение к БД
        private async void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = connectionString;
                    await connection.OpenAsync();
                    MessageBox.Show("Соединение с базой данных " + connection.Database + " выполнено успешно " + "\nСервер: " + connection.DataSource);
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных");
            }

        }



        //Получение информации о параметрах соединения с БД
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    string str = String.Format("Name = {0}\nProviderName = {1}\nConnectionString = {2}", cs.Name, cs.ProviderName, cs.ConnectionString);
                    MessageBox.Show(str, "Параметры подключений");
                }
            }
        }

        //Получение информации от товарах из БД по клику
        private void quantityBtn_MouseClick(object sender, MouseEventArgs e)
        {
            using (connection)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    MessageBox.Show("Сначала подключитесь к базе");
                    return;
                }
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM Products";
                try
                {
                    int number = (int)command.ExecuteScalar();
                    label1.Text = number.ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //--------------------------------------------------------------------------------
        //Выполнение запросов через отдельный метод (формируется отдельное подключение)
        public class WorkWithDataBase
        {
            public static int ExecuteScalarMetod(string cs, string qv)
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = qv;
                    int number = (int)command.ExecuteScalar();
                    return number;
                }
            }
        }

        private void quantityTwoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int number = WorkWithDataBase.ExecuteScalarMetod(connectionString, "SELECT COUNT(*) FROM Products");
                label2.Text = number.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------



        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT ProductName, UnitPrice, QuantityPerUnit FROM Products", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem newItem = listView1.Items.Add(reader["ProductName"].ToString());
                        newItem.SubItems.Add(reader.GetDecimal(1).ToString());
                        newItem.SubItems.Add(reader["QuantityPerUnit"].ToString());
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void TransBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction sqlTran = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;

                try
                {
                    command.CommandText = "INSERT INTO Products (ProductName, UnitPrice, QuantityPerUnit) VALUES('Wrong size', 12, '1 boxes')";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Products (ProductName, UnitPrice, QuantityPerUnit) VALUES('Wrong color', 25, '100 ml')";
                    command.ExecuteNonQuery();
                    sqlTran.Commit();
                    MessageBox.Show("Строки записаны в базу данных");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    try
                    {
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        MessageBox.Show(exRollback.Message);
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
