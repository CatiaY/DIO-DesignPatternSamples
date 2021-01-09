using System;
using System.Collections.Generic;

namespace DesignPatternSamples.Application.DTO
{
    [Serializable]
    public class PontosCarteiraTotal
    {
        public string CNH { get; set; }

        public IEnumerable<PontoCarteira> PontosCarteira { get; set; }       
    }
}
