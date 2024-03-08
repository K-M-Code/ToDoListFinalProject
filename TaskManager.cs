using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace ToDoListFinalProject
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class TaskManager
    {
        private DatabaseManager dbManager;

        public TaskManager(DatabaseManager databaseManager)
        {
            dbManager = databaseManager;
        }

        public void AddTask(Task Task)
        {
            string query = $"INSERT INTO Tasks (Title, IsCompleted) VALUES ('{Task.Title}', '{(Task.IsCompleted ? 1 : 0)}')";
            dbManager.ExecuteQuery(query);
        }

        public List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();

            // Fetch tasks from the database
            string query = "SELECT TaskId, Title, IsCompleted FROM Tasks"; 
            DataTable dataTable = dbManager.ExecuteSelectQuery(query);

            // Populate Task objects from the fetched data
            foreach (DataRow row in dataTable.Rows)
            {
                Task task = new Task
                {
                    TaskId = Convert.ToInt32(row["TaskId"]),
                    Title = row["Title"].ToString(),
                    IsCompleted = Convert.ToBoolean(row["IsCompleted"])
                };
                tasks.Add(task);
            }

            return tasks;
        }


    }
}
