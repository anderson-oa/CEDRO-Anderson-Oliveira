using System;

namespace RestauranteDDD.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Deletar(TEntity obj);
    }
}