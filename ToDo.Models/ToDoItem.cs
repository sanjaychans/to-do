using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoItem : Entity
    {
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public int PercentageCompleted { get; set; }
    }
}
