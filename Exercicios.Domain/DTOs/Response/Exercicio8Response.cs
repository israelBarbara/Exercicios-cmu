using ExerciciosCMU.Domain.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCMU.Domain.DTOs.Response
{
    public class Exercicio8Response
    {
        public int letraA { get; set; }
        public int letraB { get; set; }
        public int letraC { get; set; }
        public string letraD { get; set; }
        public IEnumerable<Veiculo> letraE { get; set; }
        public IEnumerable<Veiculo> letraF { get; set; }
        public IEnumerable<Veiculo> letraG { get; set; }
        public IEnumerable<Veiculo> letraH { get; set; }

    }
}
