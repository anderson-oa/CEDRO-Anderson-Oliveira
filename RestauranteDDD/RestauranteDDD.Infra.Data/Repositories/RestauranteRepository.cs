using System.Collections.Generic;
using System.Linq;
using RestauranteDDD.Domain.Entities;
using RestauranteDDD.Domain.Interfaces.Repositories;
using RestauranteDDD.Infra.Data.Context;

namespace RestauranteDDD.Infra.Data.Repositories
{
    public class RestauranteRepository : BaseRepository<Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(MainContext mainContext) : base(mainContext)
        {

        }

        public Restaurante ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<Restaurante> ObterTodos()
        {           
            return DbSet.OrderBy(o => o.Nome);
        }
    }
}