using AutoMapper;
using TopEntertainment.Ordenes.AccessData.Commands;
using TopEntertainment.Ordenes.Domain.Entities;
using TopEntertainment.Ordenes.Domain.DTOs;

namespace TopEntertainment.Ordenes.Application.Services
{
    public interface ICompraDetalleService
    {
        CompraDetalle GetCompraById(int id);
        CompraDetalle GetCompraByImport(int import);

        List<CompraDetalle> GetAllCompras();
        CompraDetalle Add(CompraDetalleOnCreateDTO Compra);

        void Update(Compra Compra);
    }
    public class CompraDetalleService : ICompraDetalleService
    {
        private readonly ICompraDetalleRepository _repository;
        private readonly IMapper _mapper;
        public CompraDetalleService(ICompraDetalleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CompraDetalle Add(CompraDetalleOnCreateDTO Compra)
        {
            try
            {
                var compraDetalleMap = _mapper.Map<CompraDetalle>(Compra);
                _repository.Add(compraDetalleMap);
                return compraDetalleMap;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CompraDetalle> GetAllCompras()
        {
            return _repository.GetAllCompraDetalles();
        }

        public CompraDetalle GetCompraById(int id)
        {
            throw new NotImplementedException();
        }

        public CompraDetalle GetCompraByImport(int import)
        {
            throw new NotImplementedException();
        }

        public void Update(Compra Compra)
        {
            throw new NotImplementedException();
        }
    }
}
