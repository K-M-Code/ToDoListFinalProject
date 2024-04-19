using System.Windows;

namespace ToDoListFinalProject
{
    public partial class TagInputDialog : Window
    {
        //public string TagName { get; private set; }
        //private TagManager tagManager;
        //private DatabaseManager dbManager;

        public TagInputDialog()
        {
            //InitializeComponent();
            //dbManager = new DatabaseManager();
            //tagManager = new TagManager(dbManager);
        }

        // Define the OK_Click event handler
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            //// Check if txtTagName.Text is not blank
            //if (!string.IsNullOrWhiteSpace(txtTagName.Text))
            //{
            //    TagName = txtTagName.Text;
            //    tagManager.AddTag(TagName);
            //}

            //Close();
        }


        // Define the Cancel_Click event handler
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //// Optionally handle cancel action here, such as setting TagName to null
            //TagName = null;
            //Close();
        }
    }
}
