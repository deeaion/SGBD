using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KpopStore
{
    public partial class MainWindow : Form
    {
        private string connection_string;
        private SqlDataAdapter da = new SqlDataAdapter();

        BindingSource bindingSourceCateg = new BindingSource();
        BindingSource bindingSourceProd = new BindingSource();
        DataSet dsCategories = new DataSet();
        private static string parentTable = ConfigurationManager.AppSettings["ParentTableName"];
        private static string childTable = ConfigurationManager.AppSettings["ChildTableName"];
        
        private static string parentId= ConfigurationManager.AppSettings["ParentTableId"];
        private static string childId = ConfigurationManager.AppSettings["ChildTableId"];
        private static string childForeignKey = ConfigurationManager.AppSettings["ChildToParentId"];
        

        private static string deleteChild=ConfigurationManager.AppSettings["ChildDeleteQuery"];
        private static string selectChild=ConfigurationManager.AppSettings["ChildSelectQuery"];
        
        private static string childIdAtr=ConfigurationManager.AppSettings["ChildTableAtr"];
        
        
        DataSet dsProducts = new DataSet();

        public MainWindow(string connection_string)
        {
            this.connection_string = connection_string;
            
            InitializeComponent();
            label2.Text = parentTable;
            label3.Text = childTable;
            label1.Text=parentTable+"&"+childTable;
            updateTablesButtonclicked(null, null);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.SelectedCells.Count == 0)
            {
                MessageBox.Show("At least one must be selected");
                return;
            }

            List<string> ids_of_row_selected = new List<string>();
            foreach (DataGridViewRow row in dataGridProducts.SelectedRows)
            {
                string child_id = row.Cells[childId].Value.ToString();
                ids_of_row_selected.Add(child_id); // Add prod_id to the list
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    string command = deleteChild;
                    foreach (var id in ids_of_row_selected)
                    {
                        da.DeleteCommand = new SqlCommand(command, connection);
                        da.DeleteCommand.Parameters.AddWithValue(childIdAtr, id);
                        da.DeleteCommand.ExecuteNonQuery();
                    }
                    dsProducts.Clear();
                    string id_cat = dataGridCategories.Rows[dataGridCategories.SelectedCells[0].RowIndex].Cells[parentId].Value.ToString();

                    da.SelectCommand = new SqlCommand(selectChild, connection);
                    da.SelectCommand.Parameters.AddWithValue(childForeignKey, id_cat);
                    da.Fill(dsProducts);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (dataGridCategories.SelectedCells.Count == 0)
            {
                MessageBox.Show($"A {parentTable} must be selected before trying to add a {childTable}!");
                return;
            }

            if (dataGridCategories.SelectedCells.Count > 1)
            {
                MessageBox.Show($"A single {parentTable} must be selected in order to add a {childTable}!");
                return;
            }
            //I will transfer the connection such as the category name+branch
            DataGridViewRow selectedRow = dataGridCategories.Rows[dataGridCategories.SelectedCells[0].RowIndex];
            string id_categ = selectedRow.Cells[parentId].Value.ToString();
            AddWindow addWindow = new AddWindow(connection_string, id_categ,null,"add");
            addWindow.ShowDialog();
        }

        private void updateTablesButtonclicked(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();

                    // Construct the SQL query
                    string query = ConfigurationManager.AppSettings["ParentSelectAllQuery"];

                    // Set up the SqlDataAdapter
                    da.SelectCommand = new SqlCommand(query, connection);

                    // Clear the existing dataset and fill it with the new data
                    dsCategories.Clear();
                    da.Fill(dsCategories);

                    // Set the datasource for the DataGridView and BindingSource
                    dataGridCategories.DataSource = dsCategories.Tables[0];
                    bindingSourceCateg.DataSource = dsCategories.Tables[0];
                    bindingSourceCateg.MoveLast(); // Move to the last record in the BindingSource
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void loadProductsCoressponding(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex == 0)
                {
                    dsProducts.Clear();
                    //dataGridProducts.DataSource = dsProducts.Tables[0];
                    return;
                }


                if (dataGridCategories.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    // Retrieve the id_category from the selected row
                    DataGridViewRow selectedRow = dataGridCategories.Rows[dataGridCategories.SelectedCells[0].RowIndex];
                    string id_category = dataGridCategories.Rows[e.RowIndex].Cells[parentId].Value.ToString();

                    // Open a new database connection
                    using (SqlConnection connection = new SqlConnection(connection_string))
                    {
                        connection.Open();
                        string query = selectChild;
                        da.SelectCommand = new SqlCommand(query, connection);
                        da.SelectCommand.Parameters.AddWithValue(childForeignKey, id_category);
                        dsProducts.Clear();
                        da.Fill(dsProducts);
                        AddButton.Visible = true;
                        RemoveButton.Visible = dsProducts.Tables[0].Rows.Count >= 1;
                        dataGridProducts.DataSource = dsProducts.Tables[0];
                        bindingSourceProd.DataSource = dsProducts.Tables[0];
                    }



                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_click(object sender, EventArgs e)
        {
            if (dataGridCategories.SelectedCells.Count == 0)
            {
                MessageBox.Show($"A {parentTable} must be selected before trying to update a {childTable}!");
                return;
            }

            if (dataGridCategories.SelectedCells.Count > 1)
            {
                MessageBox.Show($"A single {parentTable} must be selected in order to update a {childTable}!");
                return;
            }
            if(dataGridProducts.SelectedCells.Count == 0)
            {
                MessageBox.Show($"A single {childTable} must be selected in order to update!");
                return;
            }
            //I will transfer the connection such as the category name+branch
            DataGridViewRow selectedRow = dataGridCategories.Rows[dataGridCategories.SelectedCells[0].RowIndex];
            string id_categ = selectedRow.Cells[childForeignKey].Value.ToString();
            DataGridViewRow selectedRowProd = dataGridProducts.Rows[dataGridProducts.SelectedCells[0].RowIndex];
            string id_prod = selectedRowProd.Cells[childId].Value.ToString();

            AddWindow addWindow = new AddWindow(connection_string, id_categ, id_prod, "update");
            addWindow.ShowDialog();
        }
    }
}