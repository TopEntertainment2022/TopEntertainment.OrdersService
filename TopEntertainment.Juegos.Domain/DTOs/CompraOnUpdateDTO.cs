namespace TopEntertainment.Ordenes.Domain.DTOs
{
    public class CompraOnUpdateDTO
    {
        public int id { get; set; }

        public DateTime FechaHora { get; set; }

        public int usuarioId { get; set; }

        public string Comprobante { get; set; }
        public float Importe { get; set; }

        public CompraDetalleOnCreateDTO CompraDetalle { get; set; }
       
        



    }
}