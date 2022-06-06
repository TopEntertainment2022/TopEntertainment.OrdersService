using AutoMapper;
using TopEntertainment.Ordenes.Domain.DTOs;
using TopEntertainment.Ordenes.Domain.Entities;

namespace TopEntertainment.Ordenes.Presentation.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Compra, CompraOnCreateDTO>().ReverseMap();
            CreateMap<Compra, CompraOnViewDTO>().ReverseMap();
            CreateMap<Compra, CompraOnView2DTO>().ReverseMap();

        }
    }
}
