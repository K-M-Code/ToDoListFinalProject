//using System;
//using System.ComponentModel;
//using System.Data;
//using MySql.Data.MySqlClient;


//namespace ToDoListFinalProject
//{
//    public class Task : INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler PropertyChanged;

//        private int taskId;
//        public int TaskId
//        {
//            get { return taskId; }
//            set
//            {
//                taskId = value;
//                OnPropertyChanged(nameof(TaskId));
//            }
//        }

//        private string title;
//        public string Title
//        {
//            get { return title; }
//            set
//            {
//                title = value;
//                OnPropertyChanged(nameof(Title));
//            }
//        }

//        private bool isCompleted;
//        public bool IsCompleted
//        {
//            get { return isCompleted; }
//            set
//            {
//                isCompleted = value;
//                OnPropertyChanged(nameof(IsCompleted));
//            }
//        }

//        private bool isEditing;
//        public bool IsEditing
//        {
//            get { return isEditing; }
//            set
//            {
//                isEditing = value;
//                OnPropertyChanged(nameof(IsEditing));
//            }
//        }

//        protected void OnPropertyChanged(string propertyName)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }


//    public class TaskManager
//    {
//        //private DatabaseManager dbManager;

//        //public TaskManager(DatabaseManager databaseManager)
//        //{
//        //    dbManager = databaseManager;
//        //}

//        public void AddTask(Task Task)
//        {
//            string query = $"INSERT INTO Tasks (Title, IsCompleted) VALUES ('{Task.Title}', '{(Task.IsCompleted ? 1 : 0)}')";
//            dbManager.ExecuteQuery(query);
//        }

//        public void UpdateTaskCompletion(int taskId, bool isCompleted)
//        {
//            string query = $"UPDATE Tasks SET IsCompleted = {(isCompleted ? 1 : 0)} WHERE TaskId = {taskId}";
//            dbManager.ExecuteQuery(query);
//        }

//        public void UpdateTask(Task task)
//        {
//            string query = $"UPDATE Tasks SET Title='{task.Title}', IsCompleted={(task.IsCompleted ? 1 : 0)} WHERE TaskId={task.TaskId}";
//            dbManager.ExecuteQuery(query);
//        }


//        public List<Task> GetTasks()
//        {
//            List<Task> tasks = new List<Task>();

//            // Fetch tasks from the database
//            string query = "SELECT TaskId, Title, IsCompleted FROM Tasks"; 
//            DataTable dataTable = dbManager.ExecuteSelectQuery(query);

//            // Populate Task objects from the fetched data
//            foreach (DataRow row in dataTable.Rows)
//            {
//                Task task = new Task
//                {
//                    TaskId = Convert.ToInt32(row["TaskId"]),
//                    Title = row["Title"].ToString(),
//                    IsCompleted = Convert.ToBoolean(row["IsCompleted"])
//                };
//                tasks.Add(task);
//            }

//            return tasks;
//        }


//    }
//}
