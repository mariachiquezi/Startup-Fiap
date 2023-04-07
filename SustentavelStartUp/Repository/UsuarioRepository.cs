using Oracle.ManagedDataAccess.Client;
using SustentavelStartUp.Models;

namespace SustentavelStartUp.Repository
{
    public class UsuarioRepository
    {
        private string? connectionString;
        private OracleConnection? connection;

        public UsuarioRepository()
        {
            connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("DatabaseConnection");

            connection = new OracleConnection(connectionString);
        }



        public IList<UsuarioModel> Listar()
        {
            var lista = new List<UsuarioModel>();

            using (connection)
            {
                var query = "SELECT CD_USUARIO, NM_USUARIO, DS_EMAIL, NM_TELEFONE FROM TB_USUARIO";

                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    UsuarioModel usuario = new UsuarioModel();
                    usuario.IdUsuario = Convert.ToInt32(dataReader["CD_USUARIO"]);
                    usuario.NomeUsuario = dataReader["NM_USUARIO"].ToString();
                    usuario.Email = dataReader["DS_EMAIL"].ToString();
                    usuario.Telefone = dataReader["NM_TELEFONE"].ToString();

                    // Adiciona o modelo da lista
                    lista.Add(usuario);
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return lista;

        }

        public UsuarioModel Consultar(int id)
        {
            var usuario = new UsuarioModel();

            using (connection)
            {
                var query = "SELECT CD_USUARIO, NM_USUARIO, DS_EMAIL, NM_TELEFONE FROM TB_USUARIO WHERE CD_USUARIO = :ID ";

                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add("ID", id);

                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    // Recupera os dados
                    usuario.IdUsuario = Convert.ToInt32(dataReader["CD_USUARIO"]);
                    usuario.NomeUsuario = dataReader["NM_USUARIO"].ToString();
                    usuario.Email = dataReader["DS_EMAIL"].ToString();
                    usuario.Telefone = dataReader["NM_TELEFONE"].ToString();
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna o objeto representante

            return usuario;
        }

        public void Inserir(UsuarioModel usuario)
        {
            using (connection)
            {
                String query = "INSERT INTO TB_USUARIO ( NM_USUARIO,DS_EMAIL, NM_TELEFONE ) VALUES ( :nome, :cpf, :telefone) ";

                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("nome", usuario.NomeUsuario);
                command.Parameters.Add("cpf", usuario.Email);
                command.Parameters.Add("telefone", usuario.Telefone);

                command.ExecuteNonQuery();
                connection.Close();

            }

        }

        public void Alterar(UsuarioModel usuario)
        {
            using (connection)
            {
                String query = "UPDATE TB_USUARIO SET NM_USUARIO = :nome, DS_EMAIL = :cpf, NM_TELEFONE = :telefone  WHERE CD_USUARIO = :id ";

                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("nome", usuario.NomeUsuario);
                command.Parameters.Add("cpf", usuario.Email);
                command.Parameters.Add("telefone", usuario.Telefone);


                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Excluir(int id)
        {
            using (connection)
            {
                String query = "DELETE TB_USUARIO WHERE CD_USUARIO = :id ";

                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("id", id);


                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
