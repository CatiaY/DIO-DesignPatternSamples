using AutoMapper;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.WebAPI.Models.Detran;
using System.Linq;

namespace DesignPatternSamples.WebAPI.Mapper
{
    public class DetranMapper : Profile
    {
        public DetranMapper()
        {
            CreateMap<VeiculoModel, Veiculo>();
            CreateMap<DebitoVeiculo, DebitoVeiculoModel>();

            CreateMap<CarteiraMotoristaModel, CarteiraMotorista>();
            
            CreateMap<PontosCarteiraTotal, PontosCarteiraTotalModel>()
                .ForMember(destination => destination.Total,
                opt => opt.MapFrom(src => src.PontosCarteira.Sum(p => p.Ponto)));            
        }
    }
}
