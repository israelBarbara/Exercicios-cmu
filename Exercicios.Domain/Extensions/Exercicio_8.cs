using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCMU.Domain.Extensions
{
    public class Exercicio_8
    {
        public static int QuantidadeLugar(int tipoVeiculo)
        {
            if (tipoVeiculo == 1) return 12; //VAN
            if (tipoVeiculo == 2) return 5;  //CARRO
            if (tipoVeiculo == 3) return 2;  //MOTO
            return 0;
        }
    }
}
