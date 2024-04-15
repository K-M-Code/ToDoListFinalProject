using System;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;
using System.ComponentModel;
using System.Threading.Tasks;


namespace ToDoListFinalProject
{
    public class Tag : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int tagId;
        public int TagId
        {
            get { return tagId; }
            set
            {
                tagId = value;
                OnPropertyChanged(nameof(TagId));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

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


        public List<Tag> GetTags()
        {
            List<Tag> tags = new List<Tag>();

            // Fetch tasks from the database
            string query = "SELECT TagId, Name FROM Tags";
            DataTable dataTable = dbManager.ExecuteSelectQuery(query);

            // Populate Task objects from the fetched data
            foreach (DataRow row in dataTable.Rows)
            {
                Tag tag = new Tag
                {
                    TagId = Convert.ToInt32(row["TagId"]),
                    Name = row["Name"].ToString(),
                };
                tags.Add(tag);
            }

            return tags;
        }
    }
}
