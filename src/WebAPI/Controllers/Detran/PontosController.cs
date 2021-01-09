using AutoMapper;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using DesignPatternSamples.WebAPI.Models;
using DesignPatternSamples.WebAPI.Models.Detran;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesignPatternSamples.WebAPI.Controllers.Detran
{
    [Route("api/Detran/[controller]")]
    [ApiController]
    public class PontosController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IDetranVerificadorPontosCarteiraService _DetranVerificadorPontosCarteiraService;

        public PontosController (IMapper mapper, IDetranVerificadorPontosCarteiraService detranVerificadorPontosCarteiraService)
        {
            _Mapper = mapper;
            _DetranVerificadorPontosCarteiraService = detranVerificadorPontosCarteiraService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResultModel<PontosCarteiraTotalModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery] CarteiraMotoristaModel model)
        {
            var pontos = await _DetranVerificadorPontosCarteiraService.ConsultarPontos(_Mapper.Map<CarteiraMotorista>(model));
            var result = new SuccessResultModel<PontosCarteiraTotalModel>(_Mapper.Map<PontosCarteiraTotalModel>(pontos));

            return Ok(result);
        }
    }
}
