using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Implementations
{
    public class DetranVerificadorPontosCarteiraService : IDetranVerificadorPontosCarteiraService
    {
        private readonly IDetranVerificadorPontosCarteiraFactory _Factory;
        
        public DetranVerificadorPontosCarteiraService(IDetranVerificadorPontosCarteiraFactory factory)
        {
            _Factory = factory;            
        }

        public Task<PontosCarteiraTotal> ConsultarPontos(CarteiraMotorista carteiraMotorista)
        {
            IDetranVerificadorPontosCarteiraRepository repository = _Factory.Create(carteiraMotorista.UF);
            return repository.ConsultarPontos(carteiraMotorista);
        }                
    }
}
