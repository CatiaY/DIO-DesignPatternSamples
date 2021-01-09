using DesignPatternSamples.Application.DTO;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Services
{
    public interface IDetranVerificadorPontosCarteiraService
    {
        Task<PontosCarteiraTotal> ConsultarPontos(CarteiraMotorista carteiraMotorista);
    }
}
