using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Ordenes.AccessData.Commands;
using TopEntertainment.Ordenes.Domain.DTOs;
using TopEntertainment.Ordenes.Domain.Entities;

namespace TopEntertainment.Ordenes.Application.Services
{
    public interface ICarritoService
    {
        Carrito GetCarritoById(int id);

        void AddCarrito(int cliente);

        void addJuegoCarrito(CarritoJuegoDTO carritoDetalle);
        void modificarCantidad(int cantidad, int idProducto, int idCliente);
        void eliminarJuegoCarrito(int idCliente, int idProducto);
        CarritoCompletoDTO carritoCompleto(int idCliente);

        List<Carrito> obtenerCarrito();

    }
    public class CarritoService: ICarritoService
    {
        private readonly ICarritoRepository _repository;
        // private readonly ICarritoService _querie;
        public CarritoService(ICarritoRepository repository)//, ICarritoService querie)
        {
            _repository = repository;
            // _querie = querie;
        }
        public void AddCarrito(int cliente)
        {
            var confirmacion = _repository.estaClienteIn(cliente);
            if (confirmacion != null)
            {
                throw new FormatException();
            }
            else
            {
                _repository.AddCarrito(cliente);
            }
            
        }

        public void addJuegoCarrito(CarritoJuegoDTO carritoDetalle)
        {
            //var juego = _repository.GetCarritoById(carritoDetalle.UsuarioId);
            var juego = _repository.getCarritoPendienteById(carritoDetalle.UsuarioId);
            var comprobar = _repository.GetJuegoPorProducto(carritoDetalle.ProductoId, juego.Id);
            if(comprobar != null )
            {
                throw new FormatException();
            }
            else
            {
                _repository.addJuego(juego.Id, carritoDetalle);
            }

           // _repository.addJuego(juego.Id, carritoDetalle);
        }

        public void eliminarJuegoCarrito(int idCliente, int idProducto)
        {
            //var carrito = _repository.GetCarritoById(idCliente);
            var carrito = _repository.getCarritoPendienteById(idCliente);
            var juego = _repository.GetJuegoPorProducto(idProducto, carrito.Id);

            _repository.eliminarJuego(juego);
        }

        public Carrito GetCarritoById(int id)
        {
            return _repository.GetCarritoById(id);
        }

        public void modificarCantidad(int cantidad, int idProducto, int idCliente)
        {
            //var carrito = _repository.GetCarritoById(idCliente);
            var carrito = _repository.getCarritoPendienteById(idCliente);
            var juego = _repository.GetJuegoPorProducto(idProducto, carrito.Id);
            _repository.modificarCantidad(juego, cantidad);
        }

        public CarritoCompletoDTO carritoCompleto(int idCliente)
        {
            //var carrito = _repository.GetCarritoById(idCliente);
            var carrito = _repository.getCarritoPendienteById(idCliente);
            var juego = _repository.tenerJuegoCarrito(carrito.Id);
            List<JuegoCompletoDTO> juegoTotal = new List<JuegoCompletoDTO>();
            foreach (JuegoCarrito iterador in juego)
            {
                JuegoCompletoDTO juegoAgregar = new JuegoCompletoDTO() { ProductoId = iterador.ProductoId, Cantidad = iterador.Cantidad };
                juegoTotal.Add(juegoAgregar);
            }
            CarritoCompletoDTO carritoCompleto = new CarritoCompletoDTO() { Id = carrito.Id, UsuarioId = carrito.UsuarioId, EstadoID = carrito.EstadoID, Juegos = juegoTotal };
            return carritoCompleto;

        }
        public List<Carrito> obtenerCarrito()
        {
            return _repository.tenerTodosLosCarritos();
        }

    }
}
