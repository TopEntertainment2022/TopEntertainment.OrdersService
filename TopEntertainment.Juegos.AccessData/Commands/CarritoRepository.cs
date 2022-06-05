using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Ordenes.Domain.DTOs;
using TopEntertainment.Ordenes.Domain.Entities;

namespace TopEntertainment.Ordenes.AccessData.Commands
{
    public class CarritoRepository:ICarritoRepository
    {

            private readonly OrdenesContext _context;

            public CarritoRepository(OrdenesContext context)
            {
                _context = context;
            }

            public void Add(Carrito Carrito)
            {
                _context.Add(Carrito);
                _context.SaveChanges();
            }
            public List<Carrito> tenerTodosLosCarritos()
            {
                return _context.Carritos.ToList();
            }
            public Carrito GetCarritoById(int id)
            {
                var carritoDev = (from carrito in _context.Carritos
                                  where carrito.UsuarioId == id
                                  select carrito).FirstOrDefault();

                return carritoDev;
            }
            /*
            public List<JuegoCarrito> getCarritoDetalleById(int id)
            {
                var carritoDev = (from carrito in _context.JuegoCarrito
                                  where carrito.Id == id
                                  select carrito).ToList();
            }
            */
            public void Update(Carrito Carrito)
            {
                throw new NotImplementedException();
            }

            public void AddCarrito(int cliente)
            {
                Carrito carrito = new Carrito() { UsuarioId = cliente, EstadoID = 1 };
                Add(carrito);

            }

            public void addJuego(int id, CarritoJuegoDTO CarritoJuegoDTO)
            {
                JuegoCarrito juego = new JuegoCarrito() { CarritoID = id, ProductoId = CarritoJuegoDTO.ProductoId, Cantidad = CarritoJuegoDTO.Cantidad , Compradetalle = new CompraDetalle()};
                _context.Add(juego);
                _context.SaveChanges();
            }
            public JuegoCarrito GetJuegoPorProducto(int idProducto, int idCarricto)
            {
                var carritoJuego = (from juego in _context.JuegoCarrito
                                    where juego.ProductoId == idProducto || juego.Id == idCarricto
                                    select juego).FirstOrDefault();

                return carritoJuego;
            }


        public JuegoCarrito GetCarritoPorID(int id)
        {

            return _context.JuegoCarrito.FirstOrDefault(c => c.Carrito.Id == id);
        }
        public void modificarCantidad(JuegoCarrito juego, int cantidad)
            {
                var juegoVar = juego;
                juegoVar.Cantidad = cantidad;
                _context.Update(juegoVar);
                _context.SaveChanges();
            }

            public void eliminarJuego(JuegoCarrito juego)
            {
                _context.Remove(juego);
                _context.SaveChanges();
            }

            public List<JuegoCarrito> tenerJuegoCarrito(int id)
            {
                var carritoJuego = (from JuegoCarrito in _context.JuegoCarrito
                                    where JuegoCarrito.CarritoID == id
                                    select JuegoCarrito).ToList();
                return carritoJuego;
            }
        
    }
}
