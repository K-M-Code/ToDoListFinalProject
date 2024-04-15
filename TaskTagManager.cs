using System;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoListFinalProject
{

    public class TaskTagManager
    {
        private DatabaseManager dbManager;

        public TaskTagManager(DatabaseManager databaseManager)
        {
            dbManager = databaseManager;
        }
        public void AddTaskTag(int taskId, int tagId)
        {
            string query = "INSERT INTO TaskTags (TaskId, TagId) VALUES (@TaskId, @TagId);";
            var parameters = new Dictionary<string, object>
        {
            {"@TaskId", taskId},
            {"@TagId", tagId}
        };

            dbManager.ExecuteQueryWithParameters(query, parameters);
        }


    }

}