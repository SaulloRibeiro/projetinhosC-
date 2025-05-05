using GerenciamentoLojaOnlineDesafio.Entities;
using GerenciamentoLojaOnlineDesafio.Entities.enums;
using GerenciamentoLojaOnlineDesafio.Repository;

public class Program{
    //metodo main para testar a classe clienteRespositorio
    // public static void Main(string[] args){
        
    //     string nome = "Saullo Ribeiro Barbosa Santos";
    //     string cpf = "00000000000";
    //     string email = "teste00000@gmail.com";
    //     string telefone = "XXXXXXXXXXX";
    //     string endereco = "R.Teste, 34, Sao Paulo";


    //     string nome2 = "Lucas Ribeiro";
    //     string cpf2 = "22222222222";
    //     string email2 = "lucasgostoso@gmail.com";
    //     string telefone2 = "88888888888";
    //     string endereco2 = "R.Puta Que Pariu, 120, Taboao da serra";

    //     Cliente clienteTeste = new Cliente(nome, cpf, telefone , email, endereco);
    //     Cliente clienteTeste2 = new Cliente(nome2, cpf2, telefone2, email2, endereco2);
    //     // Console.WriteLine(clienteTeste);

    //     try{
    //         ClienteRepositorio c = new ClienteRepositorio();
    //         foreach(Cliente cl in c.GetTodosClientesDoBancoDeDados()){
    //             Console.WriteLine(cl);
    //         }
                     
    //         foreach(Cliente cl in c.GetTodosClientesDoBancoDeDados()){
    //             Console.WriteLine(cl);
    //         }

    //         Console.WriteLine($"{c.GetClinteDoBancoDeDados(cpf2)}");
    //     }
    //     catch(Exception e){
    //         Console.WriteLine(e.Message);
    //     }


    //     Console.ReadLine();//para não fechar o terminal
    // }

    public static void Main(string[] args){
        
        string modelo = "jaqueta jeans-fly";
        string marca = "oaacle";
        string tecido = "jeans-liso";
        string cor = "azul-cizentado";
        Tamanho tamanho = Tamanho.P;
        Tamanho tamanho2 = Tamanho.M;
        Tamanho tamanho3 = Tamanho.G;
        Tamanho tamanho4 = Tamanho.GG;
        double preco = 120.99;
        int quantidade = 100;
        
        Roupa roupa1 = new Roupa(modelo, preco, cor, tecido, marca, quantidade, tamanho.ToString());
        Roupa roupa2 = new Roupa(modelo, preco, cor, tecido, marca, quantidade, tamanho2.ToString());
        Roupa roupa3 = new Roupa(modelo, preco, cor, tecido, marca, quantidade, tamanho3.ToString());
        Roupa roupa4 = new Roupa(modelo, preco, cor, tecido, marca, quantidade, tamanho4.ToString());

        try{
            RoupaRepositorio rr = new RoupaRepositorio();

            rr.AddRoupa(roupa1);
            rr.AddRoupa(roupa2);
            rr.AddRoupa(roupa3);
            rr.AddRoupa(roupa4);

            Console.WriteLine("Roupas adicionadas com sucesso!");
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }

    }

}