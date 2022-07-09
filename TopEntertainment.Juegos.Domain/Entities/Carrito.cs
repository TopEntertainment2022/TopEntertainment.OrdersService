
namespace TopEntertainment.Ordenes.Domain.Entities
{
    public class Carrito
    {
        public Carrito()
        {
            Carritos = new HashSet<JuegoCarrito>();
        }
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int EstadoID { get; set; }

        public virtual EstadoDetalle estado { get; set; }
        public ICollection<JuegoCarrito> Carritos { get; set; }
    }
}
