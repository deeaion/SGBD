using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KpopStore
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static string GetConnectionString()
        {
            // Modify connection string as needed
            return
                ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        }

        [STAThread]
        static void Main()
        {
            try
            {
                string connectionString = GetConnectionString();
                TestDatabaseConnection(connectionString);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow(connectionString));
            }
            catch (Exception ex)
            {
                // Display error message and exit application
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }

        }

        private static void TestDatabaseConnection(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connectionString);
                connection.Close();
            }
        }
    }
}