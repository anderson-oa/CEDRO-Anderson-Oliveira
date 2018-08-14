using Microsoft.EntityFrameworkCore;
using RestauranteDDD.Domain.Interfaces.Repositories;
using RestauranteDDD.Infra.Data.Context;
using System;

namespace RestauranteDDD.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected MainContext Db;

        protected DbSet<TEntity> DbSet;

        public BaseRepository(MainContext mainContext)
        {
            Db = mainContext;
            DbSet = Db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Deletar(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}