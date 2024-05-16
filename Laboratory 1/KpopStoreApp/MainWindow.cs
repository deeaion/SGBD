using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace KpopStoreApp
{

    public partial class MainWindow : Form
    {
        private string connection_string;
        private SqlDataAdapter da = new SqlDataAdapter();

        BindingSource bindingSourceCateg = new BindingSource();
        BindingSource bindingSourceProd = new BindingSource();
        DataSet dsCategories = new DataSet();
        DataSet dsProducts = new DataSet();

        public MainWindow(string connection_string)
        {
            this.connection_string = connection_string;
            InitializeComponent();
            updateTablesButtonclicked(null, null);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.SelectedCells.Count == 0)
            {
                MessageBox.Show("At least one product must be selected");
                return;
            }

            List<string> ids_of_row_selected = new List<string>();
            foreach (DataGridViewRow row in dataGridProducts.SelectedRows)
            {
                string prod_id = row.Cells["id_product"].Value.ToString();
                ids_of_row_selected.Add(prod_id); // Add prod_id to the list
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    string command = "Delete from Product where id_product= @id";
                    foreach (var id in ids_of_row_selected)
                    {
                        da.DeleteCommand = new SqlCommand(command, connection);
                        da.DeleteCommand.Parameters.AddWithValue("@id", id);
                        da.DeleteCommand.ExecuteNonQuery();
                    }
                    dsProducts.Clear();
                    string id_cat = dataGridCategories.Rows[dataGridCategories.SelectedCells[0].RowIndex].Cells["id_category"].Value.ToString();

                    da.SelectCommand = new SqlCommand("SELECT * FROM Product where id_category= " + id_cat, connection);
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
                MessageBox.Show("A Category must be selected before trying to add a product!");
                return;
            }

            if (dataGridCategories.SelectedCells.Count > 1)
            {
                MessageBox.Show("A single category must be selected in order to add a Product!");
                return;
            }
            //I will transfer the connection such as the category name+branch
            DataGridViewRow selectedRow = dataGridCategories.Rows[dataGridCategories.SelectedCells[0].RowIndex];
            string id_categ = selectedRow.Cells["id_category"].Value.ToString();
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
                    string query = "SELECT * FROM ProductCategory";

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
                    dataGridProducts.DataSource = dsProducts.Tables[0];
                    return;
                }


                if (dataGridCategories.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    // Retrieve the id_category from the selected row
                    string id_category = dataGridCategories.Rows[e.RowIndex].Cells["id_category"].Value.ToString();

                    // Open a new database connection
                    using (SqlConnection connection = new SqlConnection(connection_string))
                    {
                        connection.Open();
                        string query = "SELECT * FROM Product WHERE id_category = @id_cat";
                        da.SelectCommand = new SqlCommand(query, connection);
                        da.SelectCommand.Parameters.AddWithValue("@id_cat", id_category);
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
                MessageBox.Show("A Category must be selected before trying to update a product!");
                return;
            }

            if (dataGridCategories.SelectedCells.Count > 1)
            {
                MessageBox.Show("A single category must be selected in order to update a Product!");
                return;
            }
            if(dataGridProducts.SelectedCells.Count == 0)
            {
                MessageBox.Show("A single product must be selected in order to update!");
                return;
            }
            //I will transfer the connection such as the category name+branch
            DataGridViewRow selectedRow = dataGridCategories.Rows[dataGridCategories.SelectedCells[0].RowIndex];
            string id_categ = selectedRow.Cells["id_category"].Value.ToString();
            DataGridViewRow selectedRowProd = dataGridProducts.Rows[dataGridProducts.SelectedCells[0].RowIndex];
            string id_prod = selectedRowProd.Cells["id_product"].Value.ToString();

            AddWindow addWindow = new AddWindow(connection_string, id_categ, id_prod, "update");
            addWindow.ShowDialog();
        }
    }
}
