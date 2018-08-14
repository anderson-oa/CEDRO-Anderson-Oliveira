using RestauranteDDD.Domain.Interfaces;
using System;

namespace RestauranteDDD.Infra.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _mainContext;

        private bool _disposed;

        public UnitOfWork(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _mainContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _mainContext.Dispose();                
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}