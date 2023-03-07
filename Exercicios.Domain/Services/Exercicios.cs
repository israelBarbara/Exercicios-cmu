using ExerciciosCMU.Domain.Interfaces;
using ExerciciosCMU.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciciosCMU.Domain.Extensions;
using System.Net;
using System.Text.RegularExpressions;
using ExerciciosCMU.Domain.DTOs.Request;
using ExerciciosCMU.Domain.DTOs.Response;
using System.Globalization;

namespace ExerciciosCMU.Domain.Services
{
    public class Exercicios : IExercicios
    {
        public APIMessage FiltraTerminadasEmA(List<string> array)// Exercicio 1;
        {
            List<string> list = new List<string>();
            try
            {                               
                if (array == null) return new APIMessage(HttpStatusCode.BadRequest, "", "Lista invalida");
                list = array.Where(a => a.ToLower().RemoverAcentuacao().EndsWith("a")).ToList();
                return new APIMessage(HttpStatusCode.OK, list);
            }
            catch(Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }

        public APIMessage ContaAparicoes(string frase, string palavra)// Exercicio 2
        {
            try
            {
                if(frase == null ) return new APIMessage(HttpStatusCode.BadRequest, "frase invalida" );
                if(palavra == null ) return new APIMessage(HttpStatusCode.BadRequest, "palavra invalida");
                int ocorrencias = Regex.Matches(frase, palavra).Count;
                return new APIMessage(HttpStatusCode.OK, ocorrencias);
            }
            catch (Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public APIMessage ContaDias(string data1, string data2)// Exercicio 3
        {
            try
            {
                if(data1 == null || data2 == null) throw new Exception("data(s) inválidas");
                if (data1.Contains("/") || data2.Contains("/")) throw new Exception("data(s) inválidas");

                DateTime _data1 = Convert.ToDateTime(data1);
                DateTime _data2 = Convert.ToDateTime(data2);
                int dias = 0;

                if(_data1 > _data2)
                {
                    dias = (_data1 - _data2).Days;
                }
                else if(_data1 < _data2)
                {
                    dias = (_data2 - _data1).Days;
                }

                return new APIMessage(HttpStatusCode.OK, dias);

            }
            catch(Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public APIMessage OrdenaUsuario(List<Usuario> usuarios)// Exercicio 4
        {
            try
            {
                List<string> duplicates = usuarios.GroupBy(x => x.Nome)
                           .Where(g => g.Count() > 1)
                           .Select(y => y.Key)
                           .ToList();

                if (duplicates.Count > 0) throw new Exception("Existem Usuario(s) duplicados");
                List<Usuario> usuariosOrdenados = usuarios.OrderBy(x => x.Nome).ToList();
                return new APIMessage(HttpStatusCode.OK, usuariosOrdenados);

            }
            catch (Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public APIMessage IdentificaDuplicados(List<Usuario> usuarios)// Exercicio 5
        {
            try
            {
                if(usuarios == null) return new APIMessage(HttpStatusCode.BadRequest, "Lista inválida");
                var duplicates = usuarios.GroupBy(x => x.Nome)
                    .SelectMany(y => y.Skip(1)).ToList();

                return new APIMessage(HttpStatusCode.OK, duplicates);

            }
            catch (Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public APIMessage QuebraLista(List<int> array,int listNumber)// Exercicio 6
        {
            try
            {
                if (listNumber <= 0) return new APIMessage(HttpStatusCode.BadRequest, "Numero divisor ser maior que 0");
                List<List<int>> listas = new List<List<int>>();

                for (int i = 0; i < array.Count; i += listNumber)
                {
                    listas.Add(array.GetRange(i, Math.Min(listNumber, array.Count - i)));
                }

                return new APIMessage(HttpStatusCode.OK, listas);
            }
            catch(Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        public APIMessage FrotaVeiculos(IEnumerable<Veiculo> frotas)
        {

            try
            {
                int letraA = frotas.Where(x => x.Cod_frota == 1).Count();
                int letraB = frotas.Where(x => x.Portas_simples == 4).Where(y => y.Tipo == (int)TipoVeiculo.CARRO).Count();
                int letraC = frotas.Where(x => x.Cod_frota == 1).Sum(y => y.Lugares);
                double letraD = frotas.Where(x => x.Cod_frota == 2).Average(y => y.Km_rodados);
                IEnumerable<Veiculo> letraE = frotas.Where(x => x.Cod_frota == 1).OrderByDescending(y => y.Ano).Take(2).ToList();
                IEnumerable<Veiculo> letraF = frotas.Where(x => x.Cod_frota == 2).OrderByDescending(y => y.Km_rodados).Take(2).ToList();
                IEnumerable<Veiculo> letraG = frotas.OrderBy(y => y.Ano).Take(1).ToList();
                IEnumerable<Veiculo> letraH = new List<Veiculo>();

                var query = frotas.Where(x => x.Tipo == (int)TipoVeiculo.VAN)
                                  .GroupBy(p => p.Cod_frota)
                                  .Select(g => new { Frota = g.Key, vans = g.Count() }).OrderByDescending(z => z.vans).FirstOrDefault();
                if (query != null)
                {
                    letraH = frotas.Where(x => x.Cod_frota == query.Frota).ToList();
                }


                Exercicio8Response ex8Response = new Exercicio8Response
                {
                    letraA = letraA,
                    letraB = letraB,
                    letraC = letraC,
                    letraD = String.Format("{0:F1}", letraD),
                    letraE = letraE,
                    letraF = letraF,
                    letraG = letraG,
                    letraH = letraH
                };

                return new APIMessage(HttpStatusCode.OK, ex8Response);
            }
            catch(Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        public IEnumerable<Veiculo> PopularVeiculos()
        {
            List<Veiculo> frota = new List<Veiculo>();
            frota.Add(new Veiculo(1, "Ford Transit", 97080, 2, 1, 1, (int)TipoVeiculo.VAN, 2008));
            frota.Add(new Veiculo(2, "Citroën Jumper", 95000, 2, 1, 1, (int)TipoVeiculo.VAN, 2008));
            frota.Add(new Veiculo(3, "Citroën Jumper", 17000, 2, 1, 1,  (int)TipoVeiculo.VAN, 2012));
            frota.Add(new Veiculo(4, "Citroën Jumper", 0, 2, 1, 1,  (int)TipoVeiculo.VAN, 2023));
            frota.Add(new Veiculo(5, "Fiat Ducato", 15000, 4, 1, 1,  (int)TipoVeiculo.VAN, 2006));
            frota.Add(new Veiculo(6, "Fiat Palio", 15000, 2, 0, 1,  (int)TipoVeiculo.CARRO, 2009));
            frota.Add(new Veiculo(7, "Fiat Palio", 25080, 2, 0, 1,  (int)TipoVeiculo.CARRO, 2009));
            frota.Add(new Veiculo(8, "Ford Ká", 76560, 4, 0, 1,  (int)TipoVeiculo.CARRO, 2015));
            frota.Add(new Veiculo(9, "Chevrolet Onix", 15000, 4, 0, 1, (int)TipoVeiculo.CARRO, 2010));
            frota.Add(new Veiculo(10, "Yamaha Flup", 0, 0, 0, 1, (int)TipoVeiculo.MOTO, 2023));

            frota.Add(new Veiculo(11, "Ford Transit", 65000, 2, 1, 2,  (int)TipoVeiculo.VAN, 2018));
            frota.Add(new Veiculo(12, "Fiat Ducato", 15400, 2, 1, 2,  (int)TipoVeiculo.VAN, 2007));
            frota.Add(new Veiculo(13, "Fiat Palio", 35000, 2, 0, 2,  (int)TipoVeiculo.CARRO, 2019));
            frota.Add(new Veiculo(14, "Chevrolet Onix", 65000, 4, 0, 2,  (int)TipoVeiculo.CARRO, 2012));
            frota.Add(new Veiculo(15, "Yamaha Flup", 0, 0, 0, 2,  (int)TipoVeiculo.MOTO, 2023));
            frota.Add(new Veiculo(16, "Yamaha Flup", 10000, 0, 0, 2, (int)TipoVeiculo.MOTO, 2023));
            frota.Add(new Veiculo(17, "Yamaha Flup", 5500, 0, 0, 2,  (int)TipoVeiculo.MOTO, 2022));
            frota.Add(new Veiculo(18, "Honda CB300", 0, 0, 0, 2, (int)TipoVeiculo.MOTO, 2023));
            return frota;
        }
    }
}
