using System;

namespace ToDoListFinalProject.Model
{

    namespace Todo
    {
        //Entity
        public class Todo
        {
            private Guid Id { get; set; }
            private String Title { get; set; }
            private Boolean IsImportant { get; set; }
            private Boolean IsCompleted { get; set; }
            private Boolean IsDeleted { get; set; }


            public Todo(string title, bool isImportant)
            {
                Id= Guid.NewGuid();
                Title = title;
                IsCompleted = isImportant;
                IsCompleted = false;
                IsDeleted = false;
            }
        }
    }

}
