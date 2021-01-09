using DesignPatternSamples.Application.DTO;
using System.Collections.Generic;

namespace DesignPatternSamples.WebAPI.Models.Detran
{
    public class PontosCarteiraTotalModel
    {
        public string CNH { get; set; }

        public IEnumerable<PontoCarteira> PontosCarteira { get; set; }

        public int Total { get; set; }
    }
}
