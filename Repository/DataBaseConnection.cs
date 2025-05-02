using MySql.Data.MySqlClient;

namespace GerenciamentoLojaOnlineDesafio.Repository{

    public class DataBaseConnection{
        //exeple: "server=127.0.0.1;uid=root;pwd=12345;database=test"
        
        private static string _servidor = "localhost";
        private static string _usuario = "root";
        private static string _senha = "root";
        private static string _bancoDeDados = "gerenciamento_loja_online";
        private string _stringConnection = $"server={_servidor};User ID={_usuario};database={_bancoDeDados};password={_senha}";
        private MySqlConnection _mySqlConnection = new MySqlConnection();

        public DataBaseConnection(){
            _mySqlConnection.ConnectionString = _stringConnection;
        }

        public MySqlConnection Conectar(){
            if(_mySqlConnection.State == System.Data.ConnectionState.Closed)
                _mySqlConnection.Open();
            
            return _mySqlConnection;
        }

        public void Desconectar(){
            if(_mySqlConnection.State == System.Data.ConnectionState.Closed)
                _mySqlConnection.Close();
        }
    }

}