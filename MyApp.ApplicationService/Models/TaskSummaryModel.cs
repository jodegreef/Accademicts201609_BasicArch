using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationService.Models
{
    public class TaskSummaryModel
    {
        public int CompletedCount { get; set; }

        public int UncompletedLowPercentage { get; set; }
        public int UncompletedMediumPercentage { get; set; }
        public int UncompletedHighPercentage { get; set; }

        public List<TaskModel> Top5HighPriorityTasks { get; set; }
    }
}
