
namespace TopEntertainment.Ordenes.Domain.Entities
{
    public class EstadoDetalle
    {
        public int Id { get; set; }

        public int Estado { get; set; }

        public ICollection<Carrito> carritosEstado { get; set; }
    }
}
