using GerenciamentoLojaOnlineDesafio.Entities;
using GerenciamentoLojaOnlineDesafio.Repository;

public class Program{
    public static void Main(string[] args){
        
        string nome = "Saullo Ribeiro Barbosa Santos";
        string cpf = "00000000000";
        string email = "teste00000@gmail.com";
        string telefone = "XXXXXXXXXXX";
        string endereco = "R.Teste, 34, Sao Paulo";


        string nome2 = "Lucas Ribeiro";
        string cpf2 = "22222222222";
        string email2 = "lucasgostoso@gmail.com";
        string telefone2 = "88888888888";
        string endereco2 = "R.Puta Que Pariu, 120, Taboao da serra";

        Cliente clienteTeste = new Cliente(nome, cpf, telefone , email, endereco);
        Cliente clienteTeste2 = new Cliente(nome2, cpf2, telefone2, email2, endereco2);
        // Console.WriteLine(clienteTeste);

        try{
            ClienteRepositorio c = new ClienteRepositorio();
            foreach(Cliente cl in c.GetTodosClientesDoBancoDeDados()){
                Console.WriteLine(cl);
            }
                     
            foreach(Cliente cl in c.GetTodosClientesDoBancoDeDados()){
                Console.WriteLine(cl);
            }

            Console.WriteLine($"{c.GetClinteDoBancoDeDados(cpf2)}");
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }


        Console.ReadLine();//para não fechar o terminal
    }
}