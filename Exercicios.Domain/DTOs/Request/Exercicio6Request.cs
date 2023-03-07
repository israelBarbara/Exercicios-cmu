using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCMU.Domain.DTOs.Request
{
    public class Exercicio6Request
    {
        [Required(ErrorMessage = "Por favor informe uma {0}")]
        public List<int> integers { get; set; }
        [Required(ErrorMessage = "Por favor informe uma {0}")]
        public int listNumber { get; set; }
    }
}
