using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KpopStore
{
    partial class AddWindow
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
            this.add_prod = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.category_name = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // add_prod
            // 
            this.add_prod.AutoSize = true;
            this.add_prod.Location = new System.Drawing.Point(170, 31);
            this.add_prod.Name = "add_prod";
            this.add_prod.Size = new System.Drawing.Size(132, 20);
            this.add_prod.TabIndex = 0;
            this.add_prod.Text = "Add New Product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category:";
            // 
            // category_name
            // 
            this.category_name.AccessibleName = "category_name";
            this.category_name.AutoSize = true;
            this.category_name.Location = new System.Drawing.Point(356, 71);
            this.category_name.Name = "category_name";
            this.category_name.Size = new System.Drawing.Size(51, 20);
            this.category_name.TabIndex = 2;
            this.category_name.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(73, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 333);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(387, 565);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 34);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(86, 476);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(112, 34);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 572);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Changed Your mind?";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(313, 480);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 30);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addProductClick);
            // 
            // AddWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 618);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.category_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add_prod);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddWindow";
            this.Text = "AddWindow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button addButton;

        #endregion
        private Label add_prod;
        private Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button clearButton;
        protected Label category_name;
    }
}