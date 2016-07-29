using MyApp.ApplicationService.Models;
using MyApp.Domain;
using MyApp.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationService
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public IReadOnlyList<TaskDetailModel> GetTasks()
        {
            return _taskRepository.GetAll()
                .Select(x => new TaskDetailModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Completed = x.IsCompleted,
                    Priority = (int)x.Priority
                })
                .ToList();
        }


        public void CreateNewTask(Guid id, string title)
        {
            var task = new Domain.Task(id, title);
            _taskRepository.Add(task);
            _taskRepository.SaveChanges();
            
        }

        public void DecreasePriority(Guid taskId)
        {
            var task = _taskRepository.GetById(taskId);

            task.DecreasePriority();
            _taskRepository.SaveChanges();
        }

        public void IncreatePriority(Guid taskId)
        {
            var task = _taskRepository.GetById(taskId);
            task.IncreasePriority();
            _taskRepository.SaveChanges();
        }

        public TaskDetailModel GetTaskDetail(Guid taskId)
        {
            return _taskRepository.GetAll()
              .Select(x => new TaskDetailModel
              {
                  Id = x.Id,
                  Title = x.Title,
                  Completed = x.IsCompleted,
                  Priority = (int)x.Priority
              })
              .SingleOrDefault(x => x.Id == taskId);
        }

        public void Delete(Guid taskId)
        {
            var task = _taskRepository.GetById(taskId);
            _taskRepository.Delete(task);
        }

        public void Complete(Guid taskId)
        {
            var task = _taskRepository.GetById(taskId);
            task.Complete();
            _taskRepository.SaveChanges();

        }
    }
}
