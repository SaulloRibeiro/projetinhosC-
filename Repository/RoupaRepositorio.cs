using GerenciamentoLojaOnlineDesafio.Entities;
using MySql.Data.MySqlClient;

namespace GerenciamentoLojaOnlineDesafio.Repository{

    public class RoupaRepositorio{

        private DataBaseConnection _conexao;

        public RoupaRepositorio(){
            _conexao = new DataBaseConnection();
        }

        public void AddRoupa(Roupa roupa){
            string sql = "INSERT INTO produtos VALUES(null, @modelo, @marca, @cor, @tecido, @tamanho, @preco, @quantidade, @codigo)";

            try{
                MySqlCommand mySqlCommand = new MySqlCommand(sql, _conexao.Conectar());
                mySqlCommand.Parameters.AddWithValue("@modelo", roupa.Modelo);
                mySqlCommand.Parameters.AddWithValue("@marca", roupa.Marca);
                mySqlCommand.Parameters.AddWithValue("@cor", roupa.Cor);
                mySqlCommand.Parameters.AddWithValue("@tecido", roupa.Tecido);
                mySqlCommand.Parameters.AddWithValue("@tamanho", roupa.Tamanho);
                mySqlCommand.Parameters.AddWithValue("@preco", roupa.Preco);
                mySqlCommand.Parameters.AddWithValue("@quantidade", roupa.Quantidade);
                mySqlCommand.Parameters.AddWithValue("@codigo", roupa.Codigo);
                mySqlCommand.ExecuteNonQuery();
            }
            catch(Exception e){
                throw new Exception("Erro ao adicionar produto: " + e.Message);
            }
            finally{
                _conexao.Desconectar();
            }
        }

        public void RemoverRoupa(Roupa roupa){
            string sql = "DELETE FROM produtos WHERE codigo_produto = @codigo";

            try{
                MySqlCommand mySqlCommand = new MySqlCommand(sql, _conexao.Conectar());
                mySqlCommand.Parameters.AddWithValue("@codigo", roupa.Codigo);
                mySqlCommand.ExecuteNonQuery();
            }
            catch(Exception e){
                throw new Exception("Erro ao deletar produto: " + e.Message);
            }
            finally{
                _conexao.Desconectar();
            }

        }

        public List<Roupa> ListarTodasRoupasDoBancoDados(){
            List<Roupa> roupas = new List<Roupa>();
            string sql = "SELECT * FROM produtos";

            try{
                MySqlCommand mySqlCommand = new MySqlCommand(sql, _conexao.Conectar());
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while(mySqlDataReader.Read()){
                    int id = mySqlDataReader.GetInt32("id_produto");
                    string modelo = mySqlDataReader.GetString("modelo_produto");
                    string marca = mySqlDataReader.GetString("marca_produto");
                    string cor = mySqlDataReader.GetString("cor_produto");
                    string tecido = mySqlDataReader.GetString("tecido_produto");
                    string tamanho = mySqlDataReader.GetString("tamanho_produto");
                    double preco = mySqlDataReader.GetDouble("preco_produto");
                    int quantidade = mySqlDataReader.GetInt32("quantidade_produto");
                    string codigo = mySqlDataReader.GetString("codigo_produto");
                    roupas.Add(new Roupa(id, modelo, preco, cor, tecido, marca, quantidade, tamanho,codigo));
                }
                mySqlDataReader.Close();
            }
            catch(Exception e){
                throw new Exception("Erro! nao foi possivel buscar os produtos no banco de dados: "+ e.Message);
            }
            finally{
                _conexao.Desconectar();
            }

            return roupas;

        }

        public Roupa BuscarRoupaPorIdECodigoProduto(int idProduto, string codigoProduto){
            string sql = "SELECT * FROM produtos WHERE id_produto = @id and codigo_produto = @codigoproduto";
        
            try{
                MySqlCommand mySqlCommand = new MySqlCommand(sql, _conexao.Conectar());
                mySqlCommand.Parameters.AddWithValue("@id", idProduto);
                mySqlCommand.Parameters.AddWithValue("@codigoproduto", codigoProduto);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if(mySqlDataReader.Read()){
                    Roupa roupa = new Roupa(
                        mySqlDataReader.GetInt32("id_produto"),
                        mySqlDataReader.GetString("modelo_produto"),
                        mySqlDataReader.GetDouble("preco_produto"),
                        mySqlDataReader.GetString("cor_produto"),
                        mySqlDataReader.GetString("tecido_produto"),
                        mySqlDataReader.GetString("marca_produto"),
                        mySqlDataReader.GetInt32("quantidade_produto"),
                        mySqlDataReader.GetString("tamanho_produto"),
                        mySqlDataReader.GetString("codigo_produto")
                    ); 
                    mySqlDataReader.Close();
                    return roupa;       
                }
                    // return new Roupa(id, modelo, preco, cor, tecido, marca, quantidade, tamanho, codigo);
            }
            catch(Exception e){
                throw new Exception("ERRO! não foi possivel encontrar produto: " + e.Message);
            }
            finally{
                _conexao.Desconectar();
            }

            return null;

        }

        public void EditarProduto(Roupa roupa, int idProduto, string codigoProduto){
            string sql = @"UPDATE produtos SET modelo_produto = @modelo, 
                           marca_produto = @marca, cor_produto = @cor, 
                           tecido_produto = @tecido, tamanho_produto = @tamanho,
                           preco_produto = @preco, quantidade_produto = @quantidade
                           where id_produto = @id and codigo_produto = @Codigoproduto";

            try{
                MySqlCommand mySqlCommand = new MySqlCommand(sql, _conexao.Conectar());
                mySqlCommand.Parameters.AddWithValue("@modelo", roupa.Modelo);
                mySqlCommand.Parameters.AddWithValue("@marca", roupa.Marca);
                mySqlCommand.Parameters.AddWithValue("@cor", roupa.Cor);
                mySqlCommand.Parameters.AddWithValue("@tecido", roupa.Tecido);
                mySqlCommand.Parameters.AddWithValue("@tamanho", roupa.Tamanho);
                mySqlCommand.Parameters.AddWithValue("@preco", roupa.Preco);
                mySqlCommand.Parameters.AddWithValue("@quantidade", roupa.Quantidade);
                mySqlCommand.Parameters.AddWithValue("@id", idProduto);
                mySqlCommand.Parameters.AddWithValue("@Codigoproduto", codigoProduto);
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