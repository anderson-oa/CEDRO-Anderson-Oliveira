using RestauranteDDD.Domain.Entities;
using System.Collections.Generic;

namespace RestauranteDDD.Domain.Interfaces.Repositories
{
    public interface IRestauranteRepository : IBaseRepository<Restaurante>
    {
        Restaurante ObterPorId(int id);
        IEnumerable<Restaurante> ObterTodos();
    }
}