using ExerciciosCMU.Domain.Extensions;

namespace ExerciciosCMU.Domain.DTOs.Request
{
    public class Veiculo
    {
        public int Cod_veiculo { get; set; }
        public string Nome { get; set; }
        public int Km_rodados { get; set; }
        public int Portas_simples { get; set; }
        public int Portas_correr { get; set; }
        public int Cod_frota { get; set; }
        public int Lugares { get; set; }      
        public int Tipo { get; set; }
        public int Ano { get; set; }    

        public Veiculo(int cod_veiculo,string nome, int km_rodados,int portas_simples,int portas_correr,int cod_frota,int tipo,int ano)
        {
            Cod_veiculo = cod_veiculo;
            Nome = nome;
            Km_rodados = km_rodados;
            Portas_simples = portas_simples;
            Portas_correr = portas_correr;
            Cod_frota = cod_frota;
            Lugares = Exercicio_8.QuantidadeLugar(tipo);
            Tipo = tipo;
            Ano = ano;
        }
    }
}
