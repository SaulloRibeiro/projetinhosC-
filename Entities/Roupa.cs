using System.Globalization;
using System.Text;

namespace GerenciamentoLojaOnlineDesafio.Entities{
    public class Roupa{

        public int Id {get; private set;}
        public string Modelo {get; set;}
        public double Preco {get; set;}
        public string Cor {get; set;}
        public string Tecido {get; set;}
        public string Marca {get; set;}
        public int Quantidade {get; set;}
        public string Tamanho{get; set;}
        public string Codigo{get; private set;} = "XXXXX";
    
        public Roupa(){}

        public Roupa(string modelo, double preco, string cor, string tecido, string marca, int quantidade, string tamanho ){
            Modelo = modelo;
            Preco = preco;
            Cor = cor;
            Tecido = tecido;
            Marca = marca;
            Quantidade = quantidade;
            Tamanho = tamanho;
        }

        public Roupa(int id, string modelo, double preco, string cor, string tecido, string marca, int quantidade,string tamanho, string codigo){
            Id = id;
            Modelo = modelo;
            Preco = preco;
            Cor = cor;
            Tecido = tecido;
            Marca = marca;
            Quantidade = quantidade;
            Tamanho = tamanho;
            Codigo = codigo;
        }

        public override string ToString(){
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Nome: {Modelo}");
            sb.AppendLine($"Cor: {Cor}");
            sb.AppendLine($"Tamaho: {Tamanho}");
            sb.AppendLine($"Tecido: {Tecido}");
            sb.AppendLine($"Marca: {Marca}");
            sb.AppendLine($"Preco: R${Preco.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Quatidade estoque: {Quantidade}");
            sb.AppendLine($"Codigo produto: {Codigo}");
            return sb.ToString();
        }
    }

    
}