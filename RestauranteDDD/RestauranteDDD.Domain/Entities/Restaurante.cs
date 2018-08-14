using System.Collections.Generic;

namespace RestauranteDDD.Domain.Entities
{
    public class Restaurante
    {        
        public int RestauranteId { get; set; }
        public string Nome { get; set; }
        public ICollection<Prato> Pratos { get; set; }
        public void Update(Restaurante restaurante)
        {
            Nome = restaurante.Nome;
        }
    }
}