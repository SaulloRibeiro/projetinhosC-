using System.Text;

namespace GerenciamentoLojaOnlineDesafio.Entities{

    public class Pedido{

        public DateTime MomentoPedido {get; set;}
        public Cliente Cliente {get; set;}
        public List<Roupa> Produtos {get; set;} = new List<Roupa>();
        

        public Pedido(){}
        public Pedido(DateTime momentoPedido, Cliente cliente){
            MomentoPedido = momentoPedido;
            Cliente = cliente;
        }


        public void AddProduto(Roupa produto){
            Produtos.Add(produto);
        }

        public void RemoverProduto(Roupa produto){
            Produtos.Remove(produto);
        }

    
        public string Relatorio(){
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Data e hora do pedido: {MomentoPedido.ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine($"Nome do cliente: {Cliente.Nome}");
            sb.AppendLine($"Telefone do cliente: {Cliente.Telefone}");

            foreach(Roupa p in Produtos){
                sb.AppendLine($"Produto: " );
                sb.AppendLine($"");
                sb.AppendLine($"");
            }


            return sb.ToString();





        }
    }




}