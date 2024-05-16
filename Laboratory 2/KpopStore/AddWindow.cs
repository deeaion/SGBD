using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KpopStore
{
    public partial class AddWindow : Form
    {
        private string connection_str;
        private string id_parent;
        private string id_child;
        private SqlDataAdapter da = new SqlDataAdapter();
        private DataRow parent;
        private static List<string> childColumns = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
        private static List<string> childColTypes=new List<string>(ConfigurationManager.AppSettings["ChildColumnTypes"].Split(','));
        private static List<string> childColAtr= new List<string>(ConfigurationManager.AppSettings["ChildColumnAttributes"].Split(','));
        
        private static string insertChild=ConfigurationManager.AppSettings["ChildInsertQuery"];
        private static string updateChild=ConfigurationManager.AppSettings["ChildUpdateQuery"];
        
        
        private static string parentTable = ConfigurationManager.AppSettings["ParentTableName"];
        private static string childTable = ConfigurationManager.AppSettings["ChildTableName"];
        
        private static string parentId= ConfigurationManager.AppSettings["ParentTableId"];
        private static string childId = ConfigurationManager.AppSettings["ChildTableId"];
        private static string childForeignKey = ConfigurationManager.AppSettings["ChildToParentId"];
        private List<Label> labels = new List<Label>();
        private List<TextBox> textBoxes = new List<TextBox>();
        private void CreateDynamicFields()
        {
            

            // Assuming your group box is named 'attributesGroupBox'
            GroupBox box = this.groupBox1;

            int yPos = 20;
            for (int i = 0; i < childColumns.Count; i++)
            {
                Label label = new Label
                {
                    Text = childColumns[i],
                    Name = childColumns[i],
                    Location = new Point(10, yPos),
                    Size = new Size(80, 20),
                    TextAlign = ContentAlignment.MiddleRight
                };

                TextBox textBox = new TextBox
                {
                    Name = childColumns[i],
                    Location = new Point(100, yPos),
                    Size = new Size(150, 20)
                };
                labels.Add(label);
                textBoxes.Add(textBox);
                // Adding the controls to the GroupBox instead of the form directly
                box.Controls.Add(label);
                box.Controls.Add(textBox);
        
                yPos += 30; // Increment the yPos for the next control
            }
            
        }

        private DataRow getParentData()
        {
            try
            {
                if (string.IsNullOrEmpty(id_parent))
                {
                    Console.WriteLine($"Error: {parentId} is null or empty.");
                    return null;
                }

                DataTable dt = new DataTable();
                using (SqlConnection connection=new SqlConnection(connection_str))
                {
                    connection.Open();

                    string sqlQuery = ConfigurationManager.AppSettings["ParentSelectQuery"];

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue(ConfigurationManager.AppSettings["ParentIdAtr"], id_parent);
                        adapter.Fill(dt);
                    }


                    // Check if any rows are returned
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0]; // Return the first row of the DataTable
                    }
                    else
                    {
                        Console.WriteLine($"No data found for {parentTable}: " + id_parent);
                        return null;
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private string type;
        
        private void setAll()
        {
            setParentName();
            CreateDynamicFields();
        }
        public AddWindow(string connection, string id_parent, string id_child,string type)
        {
            this.id_parent = id_parent;
            this.connection_str = connection;
            this.parent = getParentData();
            InitializeComponent();
            setAll();
            this.id_child = id_child;
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
                add_prod.Text = $"Update {childTable} with id" + id_child;
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
                    string query = ConfigurationManager.AppSettings["SelectChildQuery"];
                    DataSet dataSet = new DataSet();
                    // Set up the SqlDataAdapter
                    da.SelectCommand = new SqlCommand(query, connection);
                    da.SelectCommand.Parameters.AddWithValue(ConfigurationManager.AppSettings["ChildTableAtr"], id_child);
                    // Fill the DataSet with data from the database
                    da.Fill(dataSet, childTable);

                    // Assuming you have a TextBox named nameTxt, set its text to the name of the product
                    if (dataSet.Tables[childTable].Rows.Count > 0)
                    {
                        DataRow row = dataSet.Tables[childTable].Rows[0];
                        foreach (var textBox in textBoxes)
                        {
                            textBox.Text = row[textBox.Name].ToString();
                        }
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

        private void setParentName()
        {
            string name = childColumns[0];
            category_name.Text = name;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private List<Object> ValidateParams()
        {
            List<Object> values = new List<object>();
            int i = 0;
            foreach (var textBox in textBoxes)
            {
                string val = textBox.Text;
                if (val == null || val.Length == 0)
                {
                    MessageBox.Show("All fields must be filled!");
                    return null;
                }

                string type = childColTypes[i];
                if (type == "int")
                {
                    try
                    {
                        int.Parse(val);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Field must be an integer!");
                        return null;
                    }
                }

                if (type == "float")
                {
                    try
                    {
                        float.Parse(val);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Field must be a float!");
                        return null;
                    }
                }

                values.Add(textBox.Text);
            }

            return values;

        }
        private void addChild()
        {
          List<Object> values = ValidateParams();
          int i;

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_str))
                {
                    connection.Open();
                    da.InsertCommand = new SqlCommand(insertChild, connection);
                    var atr=ConfigurationManager.AppSettings["ParentIdAtr"];
                    da.InsertCommand.Parameters.AddWithValue(atr, id_parent);

                    for(i = 0;i<childColAtr.Count;i++)
                    {
                        da.InsertCommand.Parameters.AddWithValue(childColAtr[i], values[i]);
                    }
                    int rowCount = da.InsertCommand.ExecuteNonQuery();
                    if (rowCount == 1)
                    {
                        MessageBox.Show($"{childTable} item was added!");
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
                addChild();
            }
            else
            {
               updateChildA();
            }
            
            
        }

        private void updateChildA()
        {
            
            List<Object> values = ValidateParams();

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_str))
                {
                    connection.Open();
                    string query = updateChild;
                    da.UpdateCommand = new SqlCommand(query, connection);
                    for (int i = 0; i < childColAtr.Count; i++)
                    {
                        da.UpdateCommand.Parameters.AddWithValue(childColAtr[i], values[i]);
                    }
                    da.UpdateCommand.Parameters.AddWithValue(ConfigurationManager.AppSettings["ChildTableAtr"], id_child);
                    int rowCount = da.UpdateCommand.ExecuteNonQuery();
                    if (rowCount == 1)
                    {
                        MessageBox.Show("Update was done!");
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
            foreach (var textBox in textBoxes)
            {
                textBox.Text = "";
            }
            
        }

        private void cancelAddClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}