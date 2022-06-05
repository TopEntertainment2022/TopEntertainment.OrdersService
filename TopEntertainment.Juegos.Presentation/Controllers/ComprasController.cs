using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Ordenes.Application.Services;
using TopEntertainment.Ordenes.Domain.Entities;
using TopEntertainment.Ordenes.Domain.DTOs;

namespace TopEntertainment.Ordenes.Presentation.Controllers
{
    [Route("Api/Compras")]
    [ApiController] 
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _service;
        private readonly IMapper _mapper;

        public ComprasController(ICompraService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(CompraOnView2DTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllCompras()
        {
            try
            {
                
                List<Compra> CompraEntity = _service.GetAllCompras();
                List<CompraOnView2DTO> compraMapeada = new List<CompraOnView2DTO>();
                foreach (var compra in CompraEntity)
                {
                    var clienteMappeado = _mapper.Map<CompraOnView2DTO>(compra);
                    compraMapeada.Add(clienteMappeado);
                }
                if (compraMapeada != null)
                {
                    return new JsonResult(compraMapeada) { StatusCode = 200 };
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CompraOnView2DTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCompraById(int id)
        {
            try
            {
                var CompraEntity = _service.GetCompraById(id);

                if(CompraEntity != null)
                {
                    var clienteMappeado = _mapper.Map<CompraOnView2DTO>(CompraEntity);
                    return new JsonResult(clienteMappeado) { StatusCode = 200};
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(CompraOnView2DTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCompra([FromBody] CompraOnView2DTO compra)
        {
            try
            {
                _service.Update(compra);


                return StatusCode(200," compra actualizada ");
                

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");

            }
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(CompraOnViewDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCompra([FromBody] CompraOnCreateDTO compra)
        {
            try
            {
                var ClienteCreado = _service.Add(compra);
                if (ClienteCreado == null)
                {
                    return NotFound();
                }
                var clienteMappeado = _mapper.Map<CompraOnViewDTO>(ClienteCreado);
                return StatusCode(201," compra Creada ");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

   


        
    }
}