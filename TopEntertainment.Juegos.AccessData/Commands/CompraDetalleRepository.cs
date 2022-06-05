
using TopEntertainment.Ordenes.Domain.Entities;
using TopEntertainment.Ordenes.AccessData.Commands;
using TopEntertainment.Ordenes.Domain.DTOs;

namespace TopEntertainment.Ordenes.AccessData.Commands
{
    public class CompraDetalleRepository : ICompraDetalleRepository
    {
        private readonly OrdenesContext _context;

        public CompraDetalleRepository(OrdenesContext context)
        {
            _context = context;
        }
        public void Add(CompraDetalle compra)
        {
           _context.Add(compra);
            _context.SaveChanges();
        }

        public List<CompraDetalle> GetAllCompraDetalles()
        {
            return _context.CompraDetalles.ToList();
        }

        public CompraDetalle GetCompraDetalleByCarrito(int id)
        {
            return _context.CompraDetalles.FirstOrDefault(c => c.JuegoCarrito.Id == id);
        }

        public CompraDetalle GetCompraDetalleByCompra(int id)
        {
            return _context.CompraDetalles.FirstOrDefault(c => c.Compra.Id == id);
        }

        public CompraDetalle GetCompraDetalleById(int id)
        {
            return _context.CompraDetalles.FirstOrDefault(c => c.Id == id);
        }

    
        public void Update(CompraDetalle compra)
        {
            _context.Update(compra);
            _context.SaveChanges();
        }
    }
}
