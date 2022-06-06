

namespace TopEntertainment.Ordenes.Domain.Entities
{
    public class Compra
    {

        public int Id { get; set; }

        public int CarritoId { get; set; }

        public int UsuarioId { get; set; }

        public DateTime FechaHora { get; set; }

        public float ImporteFinal { get; set; }




    }
}