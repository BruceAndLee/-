using MemberShipManage.Infrastructure.Factory.DataBase;
using System;
using System.Data.Entity;

namespace MemberShipManage.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public DbContext Context
        {
            get { return _context; }
        }

        public event EventHandler Disposed;

        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            Dispose(true);
        }
        public virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                if (disposing && !IsDisposed)
                {
                    _context.Dispose();
                    Disposed?.Invoke(this, EventArgs.Empty);
                    Disposed = null;
                    IsDisposed = true;
                    GC.SuppressFinalize(this);
                }
            }
        }

        public UnitOfWork(IDataBaseFactory dbFactory, string connectionString)
        {
            _context = dbFactory.Get(connectionString);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
