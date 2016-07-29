using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public interface ITaskRepository
    {
        IQueryable<Task> GetAll();
        Task GetById(Guid id);
        void Add(Task task);
        void Delete(Task task);
        void SaveChanges();
    }
}
