using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Data
{
    public class TaskModel
    {
        [Required(ErrorMessage = "Task name is required")]
        [MinLength(10, ErrorMessage = "Minumum lenght must be 10")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Task content is required")]
        public string TaskContent { get; set; }

        [Range(1, 5, ErrorMessage = "Priority must be 1-5 range")]
        public int Priority { get; set; }

        [Range(1, 3, ErrorMessage = "Status must be 1-3 range")]
        public int Status { get; set; }

    }
}
