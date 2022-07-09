using TopEntertainment.Ordenes.Domain.Entities;

namespace TopEntertainment.Ordenes.AccessData.Commands
{
    public interface ICompraRepository
    {

        Compra GetCompraById(int id);
        Compra GetCompraByImport(int import);
        void Add(Compra Compra);

        public List<Compra> GetAllCompras();
        void Update(Compra Compra);
    }
}
