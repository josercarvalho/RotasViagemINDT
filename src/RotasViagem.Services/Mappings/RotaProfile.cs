using AutoMapper;
using RotasViagem.Domain.Entities;
using RotasViagem.Services.DTOs;

namespace RotasViagem.Services.Mappings
{
    public class RotaProfile : Profile
    {
        public RotaProfile()
        {
            CreateMap<Rota, RotaResponse>().ReverseMap();
            CreateMap<RotaCreateRequest, Rota>().ReverseMap();
        }
    }
}
