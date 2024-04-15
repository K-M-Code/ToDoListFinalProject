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
        private ObservableCollection<Tag> tags;

        private DatabaseManager dbManager;
        private TaskManager taskManager;
        private TagManager tagManager;
        private TaskTagManager taskTagManager;

        public MainWindow()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            taskManager = new TaskManager(dbManager);
            tagManager = new TagManager(dbManager);
            taskTagManager = new TaskTagManager(dbManager);


            // Check if the connection is open
            dbManager.IsConnectionOpen();

            // Initialize tasks collection and populate the ListBox
            tasks = new ObservableCollection<Task>();
            lstTasks.ItemsSource = tasks;

            // Initialize tags collection and populate the ListBox
            tags = new ObservableCollection<Tag>();
            lstTags.ItemsSource = tags;

            TasksName.ItemsSource = tasks;
            TagsName.ItemsSource = tags;

            // Fetch tasks from the database and add them to the collection
            FetchTasks();
            FetchTags();
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
        private void FetchTags()
        {
            // Clear existing tasks
            tags.Clear();

            // Fetch tasks from the database
            List<Tag> fetchedTags = tagManager.GetTags();

            // Add fetched tasks to the collection
            foreach (var tag in fetchedTags)
            {
                tags.Add(tag);
            }
        }



        private void TagsTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstTasks.ItemsSource).Refresh();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            // Get the task associated with the checkbox
            CheckBox checkBox = (CheckBox)sender;
            Task task = (Task)checkBox.DataContext;

            // Toggle the completion status
            task.IsCompleted = checkBox.IsChecked ?? false;

            // Update the task in the database
            taskManager.UpdateTask(task);
        }


        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Set the ListBoxItem's IsEditing property to true when the TextBlock is clicked
            TextBlock textBlock = (TextBlock)sender;
            Task task = (Task)textBlock.DataContext;
            task.IsEditing = true;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Save changes when the TextBox loses focus
            TextBox textBox = (TextBox)sender;
            Task task = (Task)textBox.DataContext;

            // Update the task in the database
            taskManager.UpdateTask(task);
        }

        private void lstTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable editing mode when a task is selected
            if (lstTasks.SelectedItem != null)
            {
                Task selectedTask = (Task)lstTasks.SelectedItem;
                selectedTask.IsEditing = true;
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


        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            // Open the tag input dialog
            var tagInputDialog = new TagInputDialog();
            if (tagInputDialog.ShowDialog() == true)
            {
                // Add the tag using TagManager
                tagManager.AddTag(tagInputDialog.TagName);
            }
        }

        private void AddTaskToTag_Click(object sender, RoutedEventArgs e)
        {
            if (TasksName.SelectedItem is Task selectedTask && TagsName.SelectedItem is Tag selectedTag)
            {
                taskTagManager.AddTaskTag(selectedTask.TaskId, selectedTag.TagId);
            }
            else
            {
                MessageBox.Show("Please select both a task and a tag.");
            }
        }



    }
}