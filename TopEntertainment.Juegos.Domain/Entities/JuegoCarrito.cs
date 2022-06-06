using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopEntertainment.Ordenes.Domain.Entities
{
    public class JuegoCarrito
    {
        public int Id { get; set; }

        public int CarritoID { get; set; }

        public int ProductoId { get; set; }


        public int Cantidad { get; set; }

      //  public CompraDetalle Compradetalle { get; set; }

        public virtual Carrito Carrito { get; set; }
    }
}
