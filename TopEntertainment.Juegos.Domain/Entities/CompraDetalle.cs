
namespace TopEntertainment.Ordenes.Domain.Entities
{
    public class CompraDetalle
    {
      
        public int Id { get; set; } 
        public virtual JuegoCarrito JuegoCarrito { get; set; }

        public Compra Compra { get; set; }
        public float Precio { get; set; }
        public float Importe { get; set; }
    }
}