namespace TopEntertainment.Ordenes.Domain.DTOs
{
    public class CompraOnView2DTO
    {
        public int id { get; set; }
        public DateTime FechaHora { get; set; }

        public int usuarioId { get; set; }

        public List<string> Comprobante { get; set; } = new List<string>();

       
        



    }
}