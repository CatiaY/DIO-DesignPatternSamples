using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;
using Workbench.IDistributedCache.Extensions;


namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificadorPontosCarteiraDecoratorCache : IDetranVerificadorPontosCarteiraService
    {        
        private readonly IDetranVerificadorPontosCarteiraService _Inner;
        private readonly IDistributedCache _Cache;

        public DetranVerificadorPontosCarteiraDecoratorCache (
            IDetranVerificadorPontosCarteiraService inner,
            IDistributedCache cache)
        {
            _Inner = inner;
            _Cache = cache;
        }

        public Task<PontosCarteiraTotal> ConsultarPontos(CarteiraMotorista carteiraMotorista)
        {           
            return Task.FromResult(_Cache.GetOrCreate<PontosCarteiraTotal>($"{carteiraMotorista.UF}_{carteiraMotorista.Nome}_{carteiraMotorista.CPF}_{carteiraMotorista.CNH}", 
                () => _Inner.ConsultarPontos(carteiraMotorista).Result));
        }        
    }
}
