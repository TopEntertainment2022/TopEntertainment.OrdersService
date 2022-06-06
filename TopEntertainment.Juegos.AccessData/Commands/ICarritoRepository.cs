using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Ordenes.Domain.DTOs;
using TopEntertainment.Ordenes.Domain.Entities;

namespace TopEntertainment.Ordenes.AccessData.Commands
{
    public interface ICarritoRepository
    {
        Carrito GetCarritoById(int id);

        public JuegoCarrito GetCarritoPorID(int id);
        void AddCarrito(int cliente);
        List<Carrito> tenerTodosLosCarritos();
        List<JuegoCarrito> tenerJuegoCarrito(int id);
        void addJuego(int id, CarritoJuegoDTO carritoDetalle);
        void modificarCantidad(JuegoCarrito juego, int cantidad);
        void eliminarJuego(JuegoCarrito juego);
        void Update(Carrito Carrito);
        JuegoCarrito GetJuegoPorProducto(int idProducto, int idCarricto);
        Carrito estaClienteIn(int IdCliente);

        Carrito getCarritoPendienteById(int id);

        Carrito getCarritoIndividual(int id);
    }
}
