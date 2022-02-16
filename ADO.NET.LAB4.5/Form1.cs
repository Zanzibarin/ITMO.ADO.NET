﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ADO.NET.LAB4._5
{
    public partial class WorkingDataTable : Form
    {
        public WorkingDataTable()
        {
            InitializeComponent();
        }

        private void WorkingDataTable_Load(object sender, EventArgs e)
        {
            CustomersDataGridView.DataSource = northwindDataSet1.Customers;
            CustomersDataGridView.MultiSelect = false;
            CustomersDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            CustomersDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void FillTableButton_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Fill(northwindDataSet1.Customers);
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            NorthwindDataSet.CustomersRow NewRow = (NorthwindDataSet.CustomersRow)northwindDataSet1.Customers.NewRow();

            NewRow.CustomerID = "WINGT";
            NewRow.CompanyName = "Wingtip Toys";
            NewRow.ContactName = "Steve Lasker";
            NewRow.ContactTitle = "CEO";
            NewRow.Address = "1234 Main Street";
            NewRow.City = "Buffalo";
            NewRow.Region = "NY";
            NewRow.PostalCode = "98052";
            NewRow.Country = "USA";
            NewRow.Phone = "206-555-0111";
            NewRow.Fax = "206-555-0112";

            try
            {
                northwindDataSet1.Customers.Rows.Add(NewRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Row Failed");
            }
        }

        private NorthwindDataSet.CustomersRow GetSelectedRow()
        {
            String SelectedCustomerID =
            CustomersDataGridView.CurrentRow.Cells["CustomerID"].Value.ToString();
            NorthwindDataSet.CustomersRow SelectedRow =
            northwindDataSet1.Customers.FindByCustomerID(SelectedCustomerID);

            return SelectedRow;
        }

        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            GetSelectedRow().Delete();
        }

        private void UpdateRowVersionDisplay()
        {
            try
            {
                CurrentDRVTextBox.Text =
                GetSelectedRow()[CustomersDataGridView.CurrentCell.OwningColumn.Name,
                DataRowVersion.Current].ToString();
            }
            catch (Exception ex)
            {
                CurrentDRVTextBox.Text = ex.Message;
            }

            try
            {
                OriginalDRVTextBox.Text =
                GetSelectedRow()[CustomersDataGridView.CurrentCell.OwningColumn.Name,
                DataRowVersion.Original].ToString();
            }
            catch (Exception ex)
            {
                OriginalDRVTextBox.Text = ex.Message;
            }

            RowStateTextBox.Text = GetSelectedRow().RowState.ToString();

        }

        private void UpdateValueButton_Click(object sender, EventArgs e)
        {
            GetSelectedRow()[CustomersDataGridView.CurrentCell.OwningColumn.Name] = CellValueTextBox.Text;
            UpdateRowVersionDisplay();
        }

        private void CustomersDataGridView_Click(object sender, EventArgs e)
        {
            CellValueTextBox.Text = CustomersDataGridView.CurrentCell.Value.ToString();
            UpdateRowVersionDisplay();
        }

        private void CellValueTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AcceptChangesButton_Click(object sender, EventArgs e)
        {
            GetSelectedRow().AcceptChanges();
            UpdateRowVersionDisplay();
        }

        private void RejectChangesButton_Click(object sender, EventArgs e)
        {
            GetSelectedRow().RejectChanges();
            UpdateRowVersionDisplay();
        }

       
    }
}