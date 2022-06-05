using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopEntertainment.Ordenes.Domain.Entities
{
    public class JuegoCarritoOnViewDTO
    {
        public int Id { get; set; }

        public int CarritoID { get; set; }

        public int ProductoId { get; set; }


        public int Cantidad { get; set; }


    }
}
