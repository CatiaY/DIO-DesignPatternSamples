using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using System;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran.VerificadorPontos
{
    public abstract class DetranVerificadorPontosRepositoryCrawlerBase : IDetranVerificadorPontosCarteiraRepository
    {
        protected DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(new Random().Next(range));
        }

        public async Task<PontosCarteiraTotal> ConsultarPontos(CarteiraMotorista carteiraMotorista)
        {
            var html = await RealizarAcesso(carteiraMotorista);
            return await PadronizarResultado(html, carteiraMotorista.CNH);
        }               

        protected abstract Task<string> RealizarAcesso(CarteiraMotorista carteiraMotorista);
        protected abstract Task<PontosCarteiraTotal> PadronizarResultado(string html, string cnh);        
    }
}
