using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationService.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
    }
}
