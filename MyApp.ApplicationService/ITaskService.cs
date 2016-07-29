using MyApp.ApplicationService.Models;
using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationService
{
    public interface ITaskService
    {
        IReadOnlyList<TaskDetailModel> GetTasks();
        TaskDetailModel GetTaskDetail(Guid taskId);
        void CreateNewTask(Guid id, string title);
        void DecreasePriority(Guid taskId);
        void IncreatePriority(Guid taskId);
        void Delete(Guid taskId);
        void Complete(Guid taskId);
    }
}
