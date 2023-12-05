using System;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace Atividade05
{
    public class Conexao
    {
        SqlConnection connection = new SqlConnection();

        public Conexao() {
            //Abrindo conexão com o banco de dados passando o usuario, senha, ip do banco e qual o nome do banco utilizado
            connection.ConnectionString = @"User ID=sa;Password=123casa;Data source=localhost\SQLEXPRESS;Initial Catalog=BOOTCAMP_GREGORIO;Persist Security Info=True;Timeout=120";

        }

        public SqlConnection Conectar()
        {
            //Abrindo conexão com o banco caso esteja fechada
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public void Desconectar()
        {
            //Fechando conexão com o banco caso esteja aberta
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }


    }
}
