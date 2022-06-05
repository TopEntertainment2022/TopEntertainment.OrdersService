using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Ordenes.Domain.Entities;
using TopEntertainment.Ordenes.Domain.DTOs;

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
