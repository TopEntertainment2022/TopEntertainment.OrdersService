using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Ordenes.Domain.Entities;
using TopEntertainment.Ordenes.Domain.DTOs;

namespace TopEntertainment.Ordenes.AccessData.Commands
{
    public interface ICompraDetalleRepository
    {

        CompraDetalle GetCompraDetalleByCompra(int id);

        CompraDetalle GetCompraDetalleByCarrito(int id);
        CompraDetalle GetCompraDetalleById(int id);

        List<CompraDetalle> GetAllCompraDetalles();
        void Add(CompraDetalle Compra);
       
        void Update(CompraDetalle Compra);
    }
}
