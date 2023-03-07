using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCMU.Domain.DTOs.Request
{
    public class Exercicio2Request
    {
        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Frase { get; set; }

        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Palavra { get; set; }
    }
}
