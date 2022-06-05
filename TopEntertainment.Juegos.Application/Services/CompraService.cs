using AutoMapper;
using TopEntertainment.Ordenes.AccessData.Commands;
using TopEntertainment.Ordenes.Domain.Entities;
using TopEntertainment.Ordenes.Domain.DTOs;

namespace TopEntertainment.Ordenes.Application.Services
{
    public interface ICompraService
    {
        Compra GetCompraById(int id);
        Compra GetCompraByImport(int import);

        List<Compra> GetAllCompras();
        Compra  Add(CompraOnCreateDTO Compra);

        void Update(CompraOnView2DTO Compra);
    }
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _repository;
        private readonly ICompraDetalleRepository _compraDetalleRepository;
        private readonly ICarritoRepository _carritoRepository;
        private readonly IMapper _mapper;
        public CompraService(ICompraRepository repository, IMapper mapper, ICompraDetalleRepository repo, ICarritoRepository carrito
            )
        {
            _repository = repository;
            _mapper = mapper;
            _compraDetalleRepository = repo;
            _carritoRepository = carrito;
        }

        public Compra Add(CompraOnCreateDTO compra)
        {
            try
            {
                var CompraDetalle = new CompraDetalle
                {
                    Importe = compra.Importe,
                    //  aca deberia pedir el precio del carrito,buscando algun carrito por algún valor.
                };

               
                
                var compraMap = _mapper.Map<Compra>(compra);
                CompraDetalle.Compra = compraMap;
                compraMap.compradetalle = CompraDetalle;

                _repository.Add(compraMap);
                var test = _repository.GetCompraById(compraMap.Id);
                compraMap.compradetalle.JuegoCarrito = _carritoRepository.GetCarritoPorID(test.Id);
                _repository.Update(compraMap);
                return _repository.GetCompraById(compraMap.Id);
            }
            catch (Exception )
            {
                return  null;
            }
        }

        public List<Compra> GetAllCompras()
        {
            List<Compra> test = _repository.GetAllCompras();
            foreach(var c in test)
            {
                c.compradetalle = _compraDetalleRepository.GetCompraDetalleById(c.Id);
            }
            return test;
        }

        public Compra GetCompraById(int id)
        {
            Compra prueba = _repository.GetCompraById(id);
            if (prueba == null)
            {
                return null;
            }
            prueba.compradetalle = _compraDetalleRepository.GetCompraDetalleById(id);
            return _repository.GetCompraById(id);
        }

        public Compra GetCompraByImport(int import)
        {
            return _repository.GetCompraByImport(import);        }

        public void Update(CompraOnView2DTO compra)
        {
            var compraMap = _mapper.Map<Compra>(compra);
            compraMap.compradetalle = _compraDetalleRepository.GetCompraDetalleById(compraMap.Id);

             _repository.Update(compraMap);
        }
    }
}
