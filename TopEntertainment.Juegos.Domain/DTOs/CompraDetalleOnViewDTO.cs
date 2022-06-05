
namespace TopEntertainment.Ordenes.Domain.Entities
{
    public class CompraDetalleOnViewDTO
    {
      
        public int Id { get; set; } 
        public virtual JuegoCarritoOnViewDTO JuegoCarrito { get; set; }

        public float Precio { get; set; }
        public float Importe { get; set; }
    }
}