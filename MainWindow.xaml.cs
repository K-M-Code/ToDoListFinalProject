using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Collections.ObjectModel;



namespace ToDoListFinalProject
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> tasks;

        private DatabaseManager dbManager;
        private TaskManager taskManager;


        public MainWindow()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            taskManager = new TaskManager(dbManager);

            // Check if the connection is open
            dbManager.IsConnectionOpen();

            // Initialize tasks collection and populate the ListBox
            tasks = new ObservableCollection<Task>();
            lstTasks.ItemsSource = tasks;

            // Fetch tasks from the database and add them to the collection
            FetchTasks();

        }

        private void FetchTasks()
        {
            // Clear existing tasks
            tasks.Clear();

            // Fetch tasks from the database
            List<Task> fetchedTasks = taskManager.GetTasks();

            // Add fetched tasks to the collection
            foreach (var task in fetchedTasks)
            {
                tasks.Add(task);
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            // Create a new task with the description from the TextBox
            Task newTask = new Task
            {
                Title = txtTaskTag.Text,
                IsCompleted = false
            };

            // Add the task to the database
            taskManager.AddTask(newTask);

            // Fetch updated tasks from the database and refresh the ListBox
            FetchTasks();

            // Optionally, you can clear the TextBox after adding the task
            txtTaskTag.Clear();
        }
    }
}
