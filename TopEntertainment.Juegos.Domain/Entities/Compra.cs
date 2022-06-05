

namespace TopEntertainment.Ordenes.Domain.Entities
{
    public class Compra
    {
        public int Id { get; set; } 

        public int UsuarioId { get; set; }

        public DateTime FechaHora { get; set; }

        public string Comprobante { get; set; }
        public float Importe { get; set; }


        public virtual CompraDetalle compradetalle{ get; set; }


    }
}