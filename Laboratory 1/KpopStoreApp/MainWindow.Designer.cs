using Microsoft.Data.SqlClient;
using System.Data;

namespace KpopStoreApp
{
    partial class MainWindow
    {   

      
        
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dataGridCategories = new DataGridView();
            dataGridProducts = new DataGridView();
            AddButton = new Button();
            RemoveButton = new Button();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            Update = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridCategories).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 0;
            label1.Text = "Products in store";
            label1.Click += label1_Click;
            // 
            // dataGridCategories
            // 
            dataGridCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCategories.GridColor = Color.RosyBrown;
            dataGridCategories.Location = new Point(25, 116);
            dataGridCategories.Name = "dataGridCategories";
            dataGridCategories.RowHeadersWidth = 62;
            dataGridCategories.Size = new Size(468, 568);
            dataGridCategories.TabIndex = 1;
            dataGridCategories.CellClick += loadProductsCoressponding;
            dataGridCategories.CellContentClick += loadProductsCoressponding;
            // 
            // dataGridProducts
            // 
            dataGridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProducts.Location = new Point(531, 138);
            dataGridProducts.Name = "dataGridProducts";
            dataGridProducts.RowHeadersWidth = 62;
            dataGridProducts.Size = new Size(509, 453);
            dataGridProducts.TabIndex = 2;
            // 
            // AddButton
            // 
            AddButton.AccessibleName = "AddButton";
            AddButton.Location = new Point(1069, 215);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(112, 34);
            AddButton.TabIndex = 3;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Visible = false;
            AddButton.Click += add_button_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.Location = new Point(1069, 277);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(112, 40);
            RemoveButton.TabIndex = 4;
            RemoveButton.Text = "Remove";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Visible = false;
            RemoveButton.Click += removeButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 60);
            label2.Name = "label2";
            label2.Size = new Size(84, 25);
            label2.TabIndex = 5;
            label2.Text = "Category";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(795, 36);
            label3.Name = "label3";
            label3.Size = new Size(84, 27);
            label3.TabIndex = 6;
            label3.Text = "Products";
            // 
            // button1
            // 
            button1.Location = new Point(991, 637);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 7;
            button1.Text = "UpdateTab";
            button1.UseVisualStyleBackColor = true;
            button1.Click += updateTablesButtonclicked;
            // 
            // Update
            // 
            Update.Location = new Point(1069, 346);
            Update.Name = "Update";
            Update.Size = new Size(112, 34);
            Update.TabIndex = 8;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += update_click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            ClientSize = new Size(1202, 764);
            Controls.Add(Update);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(RemoveButton);
            Controls.Add(AddButton);
            Controls.Add(dataGridProducts);
            Controls.Add(dataGridCategories);
            Controls.Add(label1);
            Name = "MainWindow";
            Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)dataGridCategories).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridCategories;
        private DataGridView dataGridProducts;
        private Button AddButton;
        private Button RemoveButton;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button Update;
    }
}
