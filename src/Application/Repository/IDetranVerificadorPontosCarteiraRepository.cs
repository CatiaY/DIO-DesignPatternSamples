using DesignPatternSamples.Application.DTO;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Repository
{
    public interface IDetranVerificadorPontosCarteiraRepository
    {
        Task<PontosCarteiraTotal> ConsultarPontos(CarteiraMotorista carteiraMotorista);
    }
}
