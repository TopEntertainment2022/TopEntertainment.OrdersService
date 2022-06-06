
using TopEntertainment.Ordenes.Domain.Entities;
using TopEntertainment.Ordenes.AccessData.Commands;
using TopEntertainment.Ordenes.Domain.DTOs;

namespace TopEntertainment.Ordenes.AccessData.Commands
{
    public class CompraRepository : ICompraRepository
    {
        private readonly OrdenesContext _context;

        public CompraRepository(OrdenesContext context)
        {
            _context = context;
        }
        public void Add(Compra compra)
        {
           _context.Add(compra);
            _context.SaveChanges();
        }

        public List<Compra> GetAllCompras()
        {
            return _context.Compras.ToList();
        }

        public Compra GetCompraById(int id)
        {
            return _context.Compras.FirstOrDefault(c => c.Id == id);
        }

        public Compra GetCompraByImport(int import)
        {
            return _context.Compras.SingleOrDefault(p => p.ImporteFinal == import);
        }

        public void Update(Compra compra)
        {
            _context.Update(compra);
            _context.SaveChanges();        }
    }
}
