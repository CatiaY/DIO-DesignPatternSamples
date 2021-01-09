using System;

namespace DesignPatternSamples.Application.DTO
{
    [Serializable]
    public class PontoCarteira
    {        
        public int Ponto { get; set; }
        public DateTime DataPonto { get; set; }
    }
}
