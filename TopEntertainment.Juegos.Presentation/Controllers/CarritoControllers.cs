using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Ordenes.Application.Services;
using TopEntertainment.Ordenes.Domain.Entities;
using TopEntertainment.Ordenes.Domain.DTOs;

namespace TopEntertainment.Ordenes.Presentation.Controllers
{
    [Route("Api/Carrito")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _service;


        public CarritoController(ICarritoService service)
        {
            _service = service;
        }
        /*

        [HttpGet("/CarritoPorId/")]
        public IActionResult GetCarritoById(int id)
        {
            try
            {
                var CarritoEntity = _service.GetCarritoById(id);

                if (CarritoEntity != null)
                {
                    return new JsonResult(CarritoEntity) { StatusCode = 200 };
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        */
        [HttpPost("A�adirJuego")]
        [ProducesResponseType(typeof(CarritoJuegoDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostJuegoCarrito([FromBody] CarritoJuegoDTO Carrito)
        {
            try
            {
                _service.addJuegoCarrito(Carrito);
                return StatusCode(200, "Juego a�adido correctamente");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CrearCarritoCliente/{idCliente}")]
        public IActionResult PostCarrito(int idCliente)
        {
            try
            {
                _service.AddCarrito(idCliente);
                return StatusCode(200, "Carrito creado correctamente");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("EliminarJuego")]
        public IActionResult EliminarProductos(int idCliente, int idProducto)
        {
            try
            {
                _service.eliminarJuegoCarrito(idCliente, idProducto);
                return StatusCode(200, "Juego eliminado correctamente");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("ActualizarCantidadJuego")]
        public IActionResult actualizarCantidad(int cantidad, int idProducto, int idCliente)
        {

            try
            {
                _service.modificarCantidad(cantidad, idProducto, idCliente);
                return StatusCode(200, "Cantidad actualizada correctamente");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            //return StatusCode(200, "Cantidad actualizada correctamente");
        }

        [HttpGet("ObtenerCarrito")]

        public IActionResult obtenerCarritoCompleto(int id)
        {
            try
            {
                var carrito = _service.carritoCompleto(id);
                if (carrito != null)
                {
                    return new JsonResult(carrito) { StatusCode = 200 };

                }
                return NotFound();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}