using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopEntertainment.Ordenes.Domain.DTOs
{
    public class CarritoCompletoDTO
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int EstadoID { get; set; }

        public List<JuegoCompletoDTO> Juegos { get; set; }
    }
}
