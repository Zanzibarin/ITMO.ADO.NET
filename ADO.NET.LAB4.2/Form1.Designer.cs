
namespace ADO.NET.LAB4._2
{
    partial class CreatingDataTable
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
            this.ChildTbleFillBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ParentTbleFillBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // ChildTbleFillBtn
            // 
            this.ChildTbleFillBtn.Location = new System.Drawing.Point(429, 23);
            this.ChildTbleFillBtn.Name = "ChildTbleFillBtn";
            this.ChildTbleFillBtn.Size = new System.Drawing.Size(359, 23);
            this.ChildTbleFillBtn.TabIndex = 0;
            this.ChildTbleFillBtn.Text = "Заполнить дочернюю таблицу";
            this.ChildTbleFillBtn.UseVisualStyleBackColor = true;
            this.ChildTbleFillBtn.Click += new System.EventHandler(this.ChildTbleFillBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(359, 226);
            this.dataGridView1.TabIndex = 1;
            // 
            // ParentTbleFillBtn
            // 
            this.ParentTbleFillBtn.Location = new System.Drawing.Point(12, 23);
            this.ParentTbleFillBtn.Name = "ParentTbleFillBtn";
            this.ParentTbleFillBtn.Size = new System.Drawing.Size(359, 23);
            this.ParentTbleFillBtn.TabIndex = 2;
            this.ParentTbleFillBtn.Text = "Заполнить основную таблицу";
            this.ParentTbleFillBtn.UseVisualStyleBackColor = true;
            this.ParentTbleFillBtn.Click += new System.EventHandler(this.ParentTbleFillBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(429, 65);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(359, 226);
            this.dataGridView2.TabIndex = 3;
            // 
            // CreatingDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 332);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.ParentTbleFillBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ChildTbleFillBtn);
            this.Name = "CreatingDataTable";
            this.Text = "CreatingDataTable";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChildTbleFillBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ParentTbleFillBtn;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}

