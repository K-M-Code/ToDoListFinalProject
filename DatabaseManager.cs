﻿using System;
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

        // Open connection to the database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
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
            if (OpenConnection())
            {
                bool isOpen = connection.State == ConnectionState.Open;
                string message = isOpen ? "Connection is open." : "Connection is closed.";
                MessageBox.Show(message);
                return isOpen;
            }
            else
            {
                MessageBox.Show("Connection failed to open.");
                return false;
            }
        }

        // Execute Queries on SQL
        public void ExecuteQuery(string query)
        {
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}