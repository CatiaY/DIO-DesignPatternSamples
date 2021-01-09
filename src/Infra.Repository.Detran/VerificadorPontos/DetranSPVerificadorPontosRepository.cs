using DesignPatternSamples.Application.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran.VerificadorPontos
{
    public class DetranSPVerificadorPontosRepository : DetranVerificadorPontosRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;
        private readonly int[] _pontos = { 3, 4, 5, 7};

        public DetranSPVerificadorPontosRepository(ILogger<DetranPEVerificadorPontosRepository> logger)
        {
            _Logger = logger;
        }
        
        protected override Task<PontosCarteiraTotal> PadronizarResultado(string html, string cnh)
        {
            _Logger.LogDebug($"Padronizando o Resultado {html}.");
            return Task.FromResult<PontosCarteiraTotal> (new PontosCarteiraTotal()
            {
                CNH = cnh,
                PontosCarteira = new List<PontoCarteira>
                {
                    new PontoCarteira()
                    {
                        Ponto = _pontos[new Random().Next(0, _pontos.Length - 1)],
                        DataPonto = RandomDay()
                    },
                    new PontoCarteira()
                    {
                        Ponto = _pontos[new Random().Next(0, _pontos.Length - 1)],
                        DataPonto = RandomDay()
                    }
                }
            });            
        }

        protected override Task<string> RealizarAcesso(CarteiraMotorista carteiraMotorista)
        {
            //Task.Delay(5000).Wait(); //Deixando o serviço mais lento para evidenciar o uso do CACHE.
            _Logger.LogDebug($"Consultando pontos da carteira de motorista de {carteiraMotorista.Nome} para o estado de {carteiraMotorista.UF}.");
            return Task.FromResult($"CONTEUDO DO SITE DO DETRAN/{carteiraMotorista.UF}");
        }
    }
}
