using GerenciamentoLojaOnlineDesafio.Entities;
using MySql.Data.MySqlClient;

namespace GerenciamentoLojaOnlineDesafio.Repository{

    public class ClienteRepositorio{

        private DataBaseConnection _mySqlConnection;

        public ClienteRepositorio(){
            _mySqlConnection = new DataBaseConnection();
        }

        public void AddCliente(Cliente cliente){
            string sql = $"INSERT INTO clientes VALUES(NULL, @nome, @cpf, @telefone, @email, @endereco)";

            try{
                MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection.Conectar());
                mySqlCommand.Parameters.AddWithValue("@nome", cliente.Nome);
                mySqlCommand.Parameters.AddWithValue("@cpf", cliente.Cpf);
                mySqlCommand.Parameters.AddWithValue("@telefone", cliente.Telefone);
                mySqlCommand.Parameters.AddWithValue("@email", cliente.Email);
                mySqlCommand.Parameters.AddWithValue("@endereco", cliente.Endereco);

                mySqlCommand.ExecuteNonQuery();

            }
            catch(Exception e){
                throw new Exception("Deu merda pra caralho " + e.Message);
            }
            finally{
                _mySqlConnection.Desconectar();
            }
        }

        public void UpDateCliente(Cliente cliente, string cpfDocliente){
            string sql = "UPDATE clientes SET nome_cliente = @nome, cpf_cliente = @cpf,telefone_cliente = @telefone, email_cliente = @email, endereco_cliente = @endereco where cpf_cliente = @cpfDoCliente";
            
            try{
                MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection.Conectar());
                mySqlCommand.Parameters.AddWithValue("@nome", cliente.Nome);
                mySqlCommand.Parameters.AddWithValue("@cpf", cliente.Cpf);
                mySqlCommand.Parameters.AddWithValue("@telefone", cliente.Telefone);
                mySqlCommand.Parameters.AddWithValue("@email", cliente.Email);
                mySqlCommand.Parameters.AddWithValue("@endereco", cliente.Endereco);
                mySqlCommand.Parameters.AddWithValue("cpfDoCliente", cpfDocliente);

                mySqlCommand.ExecuteNonQuery();

            }
            catch(Exception e){
                throw new Exception("Deu merda pra caralho " + e.Message);
            }
            finally{
                _mySqlConnection.Desconectar();
            }
        }


        public List<Cliente> GetTodosClientesDoBancoDeDados(){
            List<Cliente> clientes = new List<Cliente>();
            string sql = "SELECT * FROM clientes";

            try{
                MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection.Conectar());
                MySqlDataReader dados = mySqlCommand.ExecuteReader();
            
                while(dados.Read()){
                    string nome = dados.GetString("nome_cliente");
                    string cpf = dados.GetString("cpf_cliente");
                    string telefone = dados.GetString("telefone_cliente");
                    string email = dados.GetString("email_cliente");
                    string endereco = dados.GetString("endereco_cliente");
                    
                    clientes.Add(new Cliente(nome, cpf, telefone, email, endereco));
                }

                dados.Close();   
            }

            catch(Exception e){
                throw new Exception("Deu merda: " + e.Message);
            }   
            finally{
                _mySqlConnection.Desconectar();
            }

            return clientes;
        }
        
        public Cliente GetClinteDoBancoDeDados(string cpfCliente){
            string slq = "select * from clientes where cpf_cliente = @cpf";
            Cliente cliente = null;

            try{
                MySqlCommand mySqlCommand = new MySqlCommand(slq, _mySqlConnection.Conectar());
                mySqlCommand.Parameters.AddWithValue("@cpf", cpfCliente);

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                
                while(mySqlDataReader.Read()){
                    string nome = mySqlDataReader.GetString("nome_cliente");
                    string cpf = mySqlDataReader.GetString("cpf_cliente");
                    string telefone = mySqlDataReader.GetString("telefone_cliente");
                    string email = mySqlDataReader.GetString("email_cliente");
                    string endereco = mySqlDataReader.GetString("endereco_cliente");

                    cliente = new Cliente(nome, cpf, telefone, email, endereco);
                }
            }
            catch(Exception e){
                throw new Exception("Deu merda: " + e.Message);
            }
            finally{
                _mySqlConnection.Desconectar();
            }

            return cliente;
        }

    }

}