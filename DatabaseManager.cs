using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ToDoListFinalProject
{
    public class DatabaseManager
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;
        private string port;

        public DatabaseManager()
        {
            Initialize();
        }

        // Initialize values
        private void Initialize()
        {
            // Update this with your MariaDB server details
            server = "localhost";
            port = "3306";
            database = "Database";
            username = "Username";
            password = "Password";

            string connectionString;
            connectionString = $"server={server};port={port};user={username};password={password};database={database};";
            //SAMPLE string ConnectionString = "server=localhost;user=Username;database=Database;port=3306;password=Password;";

            connection = new MySqlConnection(connectionString);
        }

        // Open connection to the database if not already open
        public void OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        // Close connection to the database
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Check if the connection is open
        public bool IsConnectionOpen()
        {
            try
            {
                OpenConnection(); // Ensure connection is open
                bool isOpen = connection.State == ConnectionState.Open;
                string message = isOpen ? "Connection is open." : "Connection is closed.";
                //MessageBox.Show(message);
                return isOpen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking connection state: " + ex.Message);
                return false;
            }
        }


        // Execute Queries on SQL
        public void ExecuteQuery(string query)
        {
            OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void ExecuteQueryWithParameters(string query, Dictionary<string, object> parameters)
        {
            OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                foreach (KeyValuePair<string, object> pair in parameters)
                {
                    cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                }
                cmd.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public DataTable ExecuteSelectQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error executing select query: " + ex.Message);
            }
            return dataTable;
        }

    }
}
