
using System.Data;

using Microsoft.Data.SqlClient;

namespace KpopStoreApp
{
    public partial class AddWindow : Form
    {
        private string connection_str;
        private string id_categ;
        private string id_product;
        private SqlDataAdapter da = new SqlDataAdapter();
        private DataRow category;

        private DataRow getCategoryData()
        {
            try
            {
                // Check if id_categ is valid
                if (string.IsNullOrEmpty(id_categ))
                {
                    Console.WriteLine("Error: id_categ is null or empty.");
                    return null;
                }

                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(connection_str))
                {
                    connection.Open();

                    string sqlQuery = "select * from ProductCategory where id_category = @id_category ;";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@id_category", id_categ);
                        adapter.Fill(dt);
                    }


                    // Check if any rows are returned
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0]; // Return the first row of the DataTable
                    }
                    else
                    {
                        Console.WriteLine("No data found for id_category: " + id_categ);
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.Message);
                return null;
            }
        }


        private string type;
        public AddWindow(string connection, string id_cat, string id_product,string type)
        {
            this.id_categ = id_cat;
            this.connection_str = connection;
            this.category = getCategoryData();
            InitializeComponent();
            setCategoryName();
            this.id_product = id_product;
            this.type= type;
            if(type =="add")
            {
                addButton.Text = "add";
                add_prod.Text = "Add New Product";
                return;
            }
            if(type =="update")
            {
                addButton.Text = "update";
                add_prod.Text = "Update Product with id" + id_product;
                setUpFields();
            }
            
        }

        private void setUpFields()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_str))
                {
                    connection.Open();

                    // Construct the SQL query
                    string query = "SELECT * FROM Product where id_product= "+id_product;
                    DataSet dataSet = new DataSet();
                    // Set up the SqlDataAdapter
                    da.SelectCommand = new SqlCommand(query, connection);
                    // Fill the DataSet with data from the database
                    da.Fill(dataSet, "Product");

                    // Assuming you have a TextBox named nameTxt, set its text to the name of the product
                    if (dataSet.Tables["Product"].Rows.Count > 0)
                    {
                        DataRow row = dataSet.Tables["Product"].Rows[0];
                        nameTxt.Text = row["product_Name"].ToString();
                        priceTxt.Text = row["price"].ToString();
                        versionTxt.Text = row["pr_version"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product not found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            

            
        }

        private void setCategoryName()
        {
            string name = category["categ_name"].ToString();
            string branch = category["branch_country"].ToString();
            string toSet = name + " " + branch;
            category_name.Text = toSet;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void addProduct()
        {
            string name = nameTxt.Text;
            float product_price = 0;
            try
            {
                product_price = float.Parse(priceTxt.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Price must contain only digits and one .!");
                return;

            }
            if (name == null || name.Length == 0)
            {
                MessageBox.Show("Name must contain at least a letter!");
                return;
            }


            string version = versionTxt.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_str))
                {
                    connection.Open();
                    da.InsertCommand = new SqlCommand("INSERT INTO Product (product_name,pr_version,price,id_category)" +
                                                      "VALUES (@name,@ver,@pr,@categ)", connection);
                    da.InsertCommand.Parameters.AddWithValue("@name", name);
                    da.InsertCommand.Parameters.AddWithValue("@ver", version);
                    da.InsertCommand.Parameters.AddWithValue("@pr", product_price);
                    da.InsertCommand.Parameters.AddWithValue("@categ", id_categ);
                    int rowCount = da.InsertCommand.ExecuteNonQuery();
                    if (rowCount == 1)
                    {
                        MessageBox.Show("Product @0 was inserted!", name);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong! Try again!");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }
        private void addProductClick(object sender, EventArgs e)
        {
            if(type=="add")
            {
                addProduct();
            }
            else
            {
                updateProduct();
            }
            
            
        }

        private void updateProduct()
        {
            string name = nameTxt.Text;
            float product_price = 0;
            try
            {
                product_price = float.Parse(priceTxt.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Price must contain only digits and one .!");
                return;

            }
            if (name == null || name.Length == 0)
            {
                MessageBox.Show("Name must contain at least a letter!");
                return;
            }


            string version = versionTxt.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_str))
                {
                    connection.Open();
                    string query = "UPDATE Product SET product_name = @name, pr_version = @ver, price = @pr " +
                  "WHERE id_product = @id_prod";
                    da.UpdateCommand= new SqlCommand(query, connection);
                    da.UpdateCommand.Parameters.AddWithValue("@name", name);
                    da.UpdateCommand.Parameters.AddWithValue("@ver", version);
                    da.UpdateCommand.Parameters.AddWithValue("@pr", product_price);
                    da.UpdateCommand.Parameters.AddWithValue("@id_prod", id_product);
                    int rowCount = da.UpdateCommand.ExecuteNonQuery();
                    if (rowCount == 1)
                    {
                        MessageBox.Show("Update was done!", name);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong! Try again!");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }

        private void clearFiledsClick(object sender, EventArgs e)
        {
            nameTxt.Text = "";
            versionTxt.Text = "";
            priceTxt.Text = "";
            
        }

        private void cancelAddClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
