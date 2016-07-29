using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework
{


    public class UnitOfWork : DbContext, IUnitOfWork
    {
        private MyAppContext _context;

        public UnitOfWork(MyAppContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }


    }
}
