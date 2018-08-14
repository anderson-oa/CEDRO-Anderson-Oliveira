namespace RestauranteDDD.Domain.Entities
{
    public class Prato
    {
        public int PratoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }        
        public void Update(Prato prato)
        {
            Nome = prato.Nome;
            Preco = prato.Preco;
            RestauranteId = prato.RestauranteId;
        }
    }
}