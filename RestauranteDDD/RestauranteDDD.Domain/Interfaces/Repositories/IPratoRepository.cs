using RestauranteDDD.Domain.Entities;
using System.Collections.Generic;

namespace RestauranteDDD.Domain.Interfaces.Repositories
{
    public interface IPratoRepository : IBaseRepository<Prato>
    {
        Prato ObterPorId(int id);
        IEnumerable<Prato> ObterTodos();
    }
}