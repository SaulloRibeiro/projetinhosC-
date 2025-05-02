using System.Text;

namespace GerenciamentoLojaOnlineDesafio.Entities{

    public class Cliente{

        public string Nome {get; set;} = string.Empty;
        public string Cpf {get; private set;} = string.Empty;
        public string Telefone {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string Endereco {get; set;} = string.Empty;

        public Cliente(){}
        public Cliente(string nome, string cpf, string telefone ,string email, string endereco){
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }

        public override string ToString(){
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nome: {Nome}");
            sb.AppendLine($"Cpf: {Cpf}");
            sb.AppendLine($"Telefone: {Telefone}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Endereco: {Endereco}");
            return sb.ToString();

        }

    }

}