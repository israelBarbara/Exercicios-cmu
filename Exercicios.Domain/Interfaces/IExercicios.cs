using ExerciciosCMU.Domain.DTOs.Request;
using ExerciciosCMU.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCMU.Domain.Interfaces
{
    public interface IExercicios
    {
        public APIMessage FiltraTerminadasEmA(List<string> array);

        public APIMessage ContaAparicoes(string frase, string palavra);

        public APIMessage ContaDias(string data1, string data2);

        public APIMessage OrdenaUsuario(List<Usuario> usuarios);

        public APIMessage IdentificaDuplicados(List<Usuario> usuarios);

        public APIMessage QuebraLista(List<int> array, int listNumber);

        public APIMessage FrotaVeiculos(IEnumerable<Veiculo> frotas);

        public IEnumerable<Veiculo> PopularVeiculos();


    }
}
