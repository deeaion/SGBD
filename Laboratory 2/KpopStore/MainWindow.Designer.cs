using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KpopStore
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
         this.label1 = new System.Windows.Forms.Label();
         this.dataGridCategories = new System.Windows.Forms.DataGridView();
         this.dataGridProducts = new System.Windows.Forms.DataGridView();
         this.AddButton = new System.Windows.Forms.Button();
         this.RemoveButton = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.Update = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridCategories)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(128, 20);
         this.label1.TabIndex = 0;
         this.label1.Text = "Products in store";
         // 
         // dataGridCategories
         // 
         this.dataGridCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridCategories.GridColor = System.Drawing.Color.RosyBrown;
         this.dataGridCategories.Location = new System.Drawing.Point(25, 116);
         this.dataGridCategories.Name = "dataGridCategories";
         this.dataGridCategories.RowHeadersWidth = 62;
         this.dataGridCategories.Size = new System.Drawing.Size(567, 745);
         this.dataGridCategories.TabIndex = 1;
         this.dataGridCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.loadProductsCoressponding);
         this.dataGridCategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.loadProductsCoressponding);
         // 
         // dataGridProducts
         // 
         this.dataGridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridProducts.Location = new System.Drawing.Point(609, 158);
         this.dataGridProducts.Name = "dataGridProducts";
         this.dataGridProducts.RowHeadersWidth = 62;
         this.dataGridProducts.Size = new System.Drawing.Size(668, 661);
         this.dataGridProducts.TabIndex = 2;
         // 
         // AddButton
         // 
         this.AddButton.AccessibleName = "AddButton";
         this.AddButton.Location = new System.Drawing.Point(1283, 283);
         this.AddButton.Name = "AddButton";
         this.AddButton.Size = new System.Drawing.Size(112, 34);
         this.AddButton.TabIndex = 3;
         this.AddButton.Text = "Add";
         this.AddButton.UseVisualStyleBackColor = true;
         this.AddButton.Visible = false;
         this.AddButton.Click += new System.EventHandler(this.add_button_Click);
         // 
         // RemoveButton
         // 
         this.RemoveButton.Location = new System.Drawing.Point(1283, 343);
         this.RemoveButton.Name = "RemoveButton";
         this.RemoveButton.Size = new System.Drawing.Size(112, 40);
         this.RemoveButton.TabIndex = 4;
         this.RemoveButton.Text = "Remove";
         this.RemoveButton.UseVisualStyleBackColor = true;
         this.RemoveButton.Visible = false;
         this.RemoveButton.Click += new System.EventHandler(this.removeButton_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(129, 60);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(73, 20);
         this.label2.TabIndex = 5;
         this.label2.Text = "Category";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(609, 128);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(84, 27);
         this.label3.TabIndex = 6;
         this.label3.Text = "Products";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(1082, 836);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(112, 34);
         this.button1.TabIndex = 7;
         this.button1.Text = "UpdateTab";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.updateTablesButtonclicked);
         // 
         // Update
         // 
         this.Update.Location = new System.Drawing.Point(1283, 409);
         this.Update.Name = "Update";
         this.Update.Size = new System.Drawing.Size(112, 34);
         this.Update.TabIndex = 8;
         this.Update.Text = "Update";
         this.Update.UseVisualStyleBackColor = true;
         this.Update.Click += new System.EventHandler(this.update_click);
         // 
         // MainWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.ClientSize = new System.Drawing.Size(1419, 951);
         this.Controls.Add(this.Update);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.RemoveButton);
         this.Controls.Add(this.AddButton);
         this.Controls.Add(this.dataGridProducts);
         this.Controls.Add(this.dataGridCategories);
         this.Controls.Add(this.label1);
         this.Location = new System.Drawing.Point(15, 15);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "MainWindow";
         ((System.ComponentModel.ISupportInitialize)(this.dataGridCategories)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();
     }

        #endregion
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridCategories;
        private System.Windows.Forms.DataGridView dataGridProducts;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Update;
    }
}