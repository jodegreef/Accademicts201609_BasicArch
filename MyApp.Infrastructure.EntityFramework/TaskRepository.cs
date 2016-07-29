using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IUnitOfWork _uow;

        public TaskRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("uow");

            _uow = uow;
        }

        public IQueryable<Domain.Task> GetAll()
        {
            return _uow.Set<Domain.Task>();
        }

        public Domain.Task GetById(Guid id)
        {
            return _uow.Set<Domain.Task>().Find(id);
        }

        public void Add(Domain.Task task)
        {
            _uow.Set<Domain.Task>().Add(task);
        }

        public void Delete(Domain.Task task)
        {
            _uow.Set<Domain.Task>().Remove(task);
        }

        public void SaveChanges()
        {
            _uow.Commit();
        }
    }

}
