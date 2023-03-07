using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCMU.Domain.DTOs.Request
{
    public class Exercicio3Request
    {
        [Required(ErrorMessage = "Por favor informe uma {0}")]
        public string data1 { get; set; }
        [Required(ErrorMessage = "Por favor informe uma {0}")]
        public string data2 { get; set; }
    }
}
