using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopEntertainment.Ordenes.Domain.DTOs
{
    public class CarritoJuegoDTO
    {
        public int UsuarioId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }
    }
}
