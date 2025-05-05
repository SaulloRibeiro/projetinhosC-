using GerenciamentoLojaOnlineDesafio.Entities;
using MySql.Data.MySqlClient;

namespace GerenciamentoLojaOnlineDesafio.Repository{

    public class RoupaRepositorio{

        private DataBaseConnection _conexao;

        public RoupaRepositorio(){
            _conexao = new DataBaseConnection();
        }

        public void AddRoupa(Roupa roupa){
            string sql = "INSERT INTO produtos VALUES(null, @modelo, @marca, @cor, @tecido, @tamanho, @preco, @quantidade)";

            try{
                MySqlCommand mySqlCommand = new MySqlCommand(sql, _conexao.Conectar());
                mySqlCommand.Parameters.AddWithValue("@modelo", roupa.Modelo);
                mySqlCommand.Parameters.AddWithValue("@marca", roupa.Marca);
                mySqlCommand.Parameters.AddWithValue("@cor", roupa.Cor);
                mySqlCommand.Parameters.AddWithValue("@tecido", roupa.Tecido);
                mySqlCommand.Parameters.AddWithValue("@tamanho", roupa.Tamanho);
                mySqlCommand.Parameters.AddWithValue("@preco", roupa.Preco);
                mySqlCommand.Parameters.AddWithValue("@quantidade", roupa.Quantidade);
                mySqlCommand.ExecuteNonQuery();
            }
            catch(Exception e){
                throw new Exception("Erro ao adicionar produto: " + e.Message);
            }
            finally{
                _conexao.Desconectar();
            }
        }



    }
}