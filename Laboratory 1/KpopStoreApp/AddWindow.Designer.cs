namespace KpopStoreApp
{
    partial class AddWindow
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
            add_prod = new Label();
            label1 = new Label();
            category_name = new Label();
            groupBox1 = new GroupBox();
            cancelButton = new Button();
            clearButton = new Button();
            label6 = new Label();
            addButton = new Button();
            priceTxt = new TextBox();
            versionTxt = new TextBox();
            nameTxt = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // add_prod
            // 
            add_prod.AutoSize = true;
            add_prod.Location = new Point(170, 31);
            add_prod.Name = "add_prod";
            add_prod.Size = new Size(153, 25);
            add_prod.TabIndex = 0;
            add_prod.Text = "Add New Product";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 71);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 1;
            label1.Text = "Category:";
            // 
            // category_name
            // 
            category_name.AccessibleName = "category_name";
            category_name.AutoSize = true;
            category_name.Location = new Point(356, 71);
            category_name.Name = "category_name";
            category_name.Size = new Size(59, 25);
            category_name.TabIndex = 2;
            category_name.Text = "Name";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cancelButton);
            groupBox1.Controls.Add(clearButton);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(addButton);
            groupBox1.Controls.Add(priceTxt);
            groupBox1.Controls.Add(versionTxt);
            groupBox1.Controls.Add(nameTxt);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(73, 120);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(367, 333);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Attributes";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(230, 275);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 34);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelAddClick;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(33, 276);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(112, 34);
            clearButton.TabIndex = 9;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearFiledsClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 237);
            label6.Name = "label6";
            label6.Size = new Size(177, 25);
            label6.TabIndex = 8;
            label6.Text = "Changed Your mind?";
            // 
            // addButton
            // 
            addButton.Location = new Point(124, 182);
            addButton.Name = "addButton";
            addButton.Size = new Size(112, 34);
            addButton.TabIndex = 7;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addProductClick;
            // 
            // priceTxt
            // 
            priceTxt.Location = new Point(89, 121);
            priceTxt.Name = "priceTxt";
            priceTxt.Size = new Size(253, 31);
            priceTxt.TabIndex = 6;
            // 
            // versionTxt
            // 
            versionTxt.Location = new Point(87, 87);
            versionTxt.Name = "versionTxt";
            versionTxt.Size = new Size(255, 31);
            versionTxt.TabIndex = 5;
            // 
            // nameTxt
            // 
            nameTxt.Location = new Point(89, 49);
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(253, 31);
            nameTxt.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 124);
            label5.Name = "label5";
            label5.Size = new Size(53, 25);
            label5.TabIndex = 3;
            label5.Text = "Price:";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 87);
            label4.Name = "label4";
            label4.Size = new Size(74, 25);
            label4.TabIndex = 2;
            label4.Text = "Version:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(152, 154);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 1;
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 51);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 0;
            label2.Text = "Name:";
            // 
            // AddWindow
            // 
            AcceptButton = addButton;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 499);
            Controls.Add(groupBox1);
            Controls.Add(category_name);
            Controls.Add(label1);
            Controls.Add(add_prod);
            Name = "AddWindow";
            Text = "AddWindow";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label add_prod;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button addButton;
        private TextBox priceTxt;
        private TextBox versionTxt;
        private TextBox nameTxt;
        private Button cancelButton;
        private Button clearButton;
        protected Label category_name;
    }
}