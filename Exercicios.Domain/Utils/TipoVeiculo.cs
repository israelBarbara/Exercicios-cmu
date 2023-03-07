using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCMU.Domain.Utils
{
    public enum TipoVeiculo
    {
        [Description("VAN")]
        VAN = 1,
        [Description("CARRO")]
        CARRO = 2,
        [Description("MOTO")]
        MOTO = 3,
    }
}
