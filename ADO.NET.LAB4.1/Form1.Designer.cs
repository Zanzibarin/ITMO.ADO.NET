﻿
namespace ADO.NET.LAB4
{
    partial class DatasetDesigner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetCustomersButton = new System.Windows.Forms.Button();
            this.CustomersListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // GetCustomersButton
            // 
            this.GetCustomersButton.Location = new System.Drawing.Point(38, 32);
            this.GetCustomersButton.Name = "GetCustomersButton";
            this.GetCustomersButton.Size = new System.Drawing.Size(200, 23);
            this.GetCustomersButton.TabIndex = 0;
            this.GetCustomersButton.Text = "Get Customers";
            this.GetCustomersButton.UseVisualStyleBackColor = true;
            this.GetCustomersButton.Click += new System.EventHandler(this.GetCustomersButton_Click);
            // 
            // CustomersListBox
            // 
            this.CustomersListBox.FormattingEnabled = true;
            this.CustomersListBox.Location = new System.Drawing.Point(38, 82);
            this.CustomersListBox.Name = "CustomersListBox";
            this.CustomersListBox.Size = new System.Drawing.Size(200, 238);
            this.CustomersListBox.TabIndex = 1;
            this.CustomersListBox.Click += new System.EventHandler(this.CustomersListBox_Click);
            // 
            // DatasetDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CustomersListBox);
            this.Controls.Add(this.GetCustomersButton);
            this.Name = "DatasetDesigner";
            this.Text = "DatasetDesigner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetCustomersButton;
        private System.Windows.Forms.ListBox CustomersListBox;
    }
}

