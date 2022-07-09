namespace TopEntertainment.Ordenes.Domain.Entities
{
    public class Carro
    {
        public Guid Id { get; set; }
        // public List<int> juegosId { get; set; }

        public int usuarioId { get; set; }

        public float importe { get; set; }
    }
}
