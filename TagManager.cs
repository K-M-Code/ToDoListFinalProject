using System;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;

namespace ToDoListFinalProject
{
    public class TagManager
    {
        private DatabaseManager dbManager;

        public TagManager(DatabaseManager databaseManager)
        {
            dbManager = databaseManager;
        }

        public void AddTag(string tagName)
        {
            string query = $"INSERT INTO Tags (Name) VALUES ('{tagName}')";
            dbManager.ExecuteQuery(query);
        }
    }
}
