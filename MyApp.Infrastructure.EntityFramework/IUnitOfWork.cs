using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework
{
    public interface IUnitOfWork
    {
        int Commit();
        IDbSet<T> Set<T>() where T : class;
    }
}
