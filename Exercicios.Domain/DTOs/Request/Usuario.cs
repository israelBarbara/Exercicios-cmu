using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCMU.Domain.DTOs.Request
{
    public class Usuario
    {
        public string Email { get; }
        public string Nome { get;  }
        public Guid Senha { get; }

        public Usuario(string email, string nome)
        {
            Email = email;
            Nome = nome;
            Senha = Guid.NewGuid();
        }
    }
}
