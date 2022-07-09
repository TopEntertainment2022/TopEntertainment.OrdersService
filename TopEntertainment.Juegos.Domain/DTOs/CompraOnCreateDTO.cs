namespace TopEntertainment.Ordenes.Domain.DTOs
{
    public class CompraOnCreateDTO
    {
        public int UsuarioId { get; set; }

        public DateTime FechaHora { get; set; }
        public float Importe { get; set; }


    }
}