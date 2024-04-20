using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoListFinalProject
{
    [Table("todos")]
    public class Todo
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Required]
        [Column("is_completed")]
        public bool IsCompleted { get; set; }
        [Required]
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Required]
        [Column("is_important")]
        public bool IsImportant { get; set; }
    }
}
