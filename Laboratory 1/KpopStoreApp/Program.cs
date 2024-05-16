using System.Data;
using Microsoft.Data.SqlClient;

namespace KpopStoreApp
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static string GetConnectionString()
        {
            // Modify connection string as needed
            return @"Data Source=DESKTOP-32D15JA\SQLEXPRESS;Initial Catalog=KpopStore;Integrated Security=True;TrustServerCertificate=true;";
        }
        static void Main()
        {
            string connectionString = GetConnectionString();
            try
            {
                // Test database connection
                TestDatabaseConnection(connectionString);


                ApplicationConfiguration.Initialize();


                Application.Run(new MainWindow(connectionString));
            }
            catch (Exception ex)
            {
                // Display error message and exit application
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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