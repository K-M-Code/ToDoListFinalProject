using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



namespace ToDoListFinalProject
{
    public partial class MainWindow : Window
    {
        TodoContext todoContext;
        public MainWindow()
        {
            todoContext = new TodoContext();
            InitializeComponent();

            LoadTodos();
            LoadSortedTodos();
        }

        private void LoadTodos()
        {
            TodosListBox.Items.Clear();
            TodosListBox.ItemsSource = null;

            // fetch todos from the database
            List<Todo> todos = todoContext.Todos.Where(todo => todo.IsDeleted.Equals(false)).ToList();

            // Add fetched tasks to the collection
            foreach (var todo in todos)
            {
                ListBoxItem item = new ListBoxItem();
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;

                CheckBox checkBox = new CheckBox();
                checkBox.Content = todo.Title;
                checkBox.IsChecked = todo.IsCompleted;

                Button deleteButton = new Button();
                deleteButton.Content = "Delete";
                deleteButton.Click += (sender, e) =>
                {
                    todo.IsDeleted = true;
                    todoContext.Update(todo);
                    todoContext.SaveChanges();
                    LoadTodos();
                    LoadSortedTodos();
                };

                checkBox.Checked += (sender, e) =>
                {
                    todo.IsCompleted = true;
                    todoContext.Update(todo);
                    todoContext.SaveChanges();
                    LoadTodos();
                    LoadSortedTodos();
                };

                checkBox.Unchecked += (sender, e) =>
                {
                    todo.IsCompleted = false;
                    todoContext.Update(todo);
                    todoContext.SaveChanges();
                    LoadTodos();
                    LoadSortedTodos();
                };

                panel.Children.Add(checkBox);
                panel.Children.Add(deleteButton);

                if (todo.IsImportant)
                {
                    checkBox.Content += "!";
                }
                if (todo.IsCompleted) 
                {
                    panel.Background = new SolidColorBrush(Colors.Green);
                }
                if (!todo.IsCompleted)
                {
                    panel.Background = new SolidColorBrush(Colors.Transparent);
                }

                item.Content = panel;
                
                TodosListBox.Items.Add(item);
               
            }
        }
        private void LoadSortedTodos()
        {
            ImportantTodosListBox.ItemsSource = null;
            CompletedTodosListBox.ItemsSource = null;
            DeletedTodosListBox.ItemsSource = null;


            List<Todo> importantTodos = todoContext.Todos.Where(todo => todo.IsImportant).ToList();

            List<Todo> completedTodos = todoContext.Todos.Where(todo => todo.IsCompleted).ToList();

            List<Todo> deletedTodos = todoContext.Todos.Where(todo => todo.IsDeleted).ToList();

            ImportantTodosListBox.ItemsSource = importantTodos;
            CompletedTodosListBox.ItemsSource = completedTodos;
            DeletedTodosListBox.ItemsSource= deletedTodos;

        }

        private void AddNewTodo_Click(object sender, RoutedEventArgs e)
        {
            String todo = taskTextBox.Text;
            bool isImportant = importantCheckBox.IsChecked ?? false;

            if(!string.IsNullOrEmpty(todo))
            {
                Todo toBeSaved = new Todo();
                toBeSaved.Title = todo;
                toBeSaved.IsImportant = isImportant;
                toBeSaved.IsDeleted = false;
                toBeSaved.Description = "";

                todoContext.Add(toBeSaved);
                todoContext.SaveChanges();
                MessageBox.Show("Todo successfully added");
                taskTextBox.Text = "";
                importantCheckBox.IsChecked = false;
                LoadTodos();
                LoadSortedTodos();
            }
        }
    }
}