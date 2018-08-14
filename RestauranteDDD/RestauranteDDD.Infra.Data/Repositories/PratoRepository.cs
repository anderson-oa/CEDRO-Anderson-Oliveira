using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestauranteDDD.Domain.Entities;
using RestauranteDDD.Domain.Interfaces.Repositories;
using RestauranteDDD.Infra.Data.Context;

namespace RestauranteDDD.Infra.Data.Repositories
{
    public class PratoRepository : BaseRepository<Prato>, IPratoRepository
    {
        public PratoRepository(MainContext mainContext) : base(mainContext)
        {

        }

        public Prato ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<Prato> ObterTodos()
        {
            return DbSet.Include(p => p.Restaurante)
                        .OrderBy(o => o.Nome)
                        .ThenBy(t => t.Preco);
        }
    }
}