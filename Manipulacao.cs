using System;
using System.Data.SqlClient;

namespace Atividade05
{
    public class Manipulacao
    {
        SqlDataReader Dr;

        //Representa um procedimento armazenado para execução em um banco de dados SQL Server.
        SqlCommand cmd = new SqlCommand();

        //Instanciando a classe conexao que criamos com os metodos para abrir e fechar conexao
        Conexao conexao = new Conexao();
        Validacao val = new Validacao();

        public void Cadastrar(Produto produto)
        {
            //fornecendo informações para adicionar um produto no banco de dados através da querry
            cmd.CommandText = "INSERT INTO PRODUTO (sCdProdutoERP, sDsProduto, nCdFamilia) VALUES(@sCdProdutoERP,@sDsProduto,@nCdFamilia)";
            //atribuindo valores aos campos da querry que já estão vinculados a um produto
            cmd.Parameters.AddWithValue("@sCdProdutoERP", produto.sCdProdutoERP);
            cmd.Parameters.AddWithValue("@sDsProduto", produto.sDsProduto);
            cmd.Parameters.AddWithValue("@nCdFamilia", produto.nCdFamilia);

            //tentando executar os comandos no banco de dados
            try
            {
                //abrindo conexão com o banco
                cmd.Connection = conexao.Conectar();
                //executando a querry enviada
                var i = cmd.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                //Caso de algum problema, pegar ele e mostrar um aviso de erro
                throw ex;
            }
            finally
            {
                //finalizar a tentativa(com ou sem erro) encerrando a conexão com o banco
                conexao.Desconectar();
            }
        }

        public void ListarProduto(string codigoERP)
        {
            //fornecendo informações para adicionar um produto no banco de dados através da querry
            String select = "Select * from Produto WHERE sCdProdutoERP =@CodigoERP";
            //atribuindo valores aos campos da querry que já estão vinculados a um produto
            cmd.Parameters.AddWithValue("@CodigoERP", codigoERP);
            cmd.CommandText = select;
            try
            {
                //abrindo conexão com o banco
                cmd.Connection = conexao.Conectar();
                var read = cmd.ExecuteReader();

                //verificando se o DataReader obteve algum registro
                if (read.Read())
                {
                    Console.WriteLine($"\nCdProdutoERP: {read[1]}\nDsProduto: {read[2]}\nCdFamilia: {read[3]}");
                }
                else
                {
                    //Caso não encontre um produto com aquele código ERP, retorna essa mensagem
                    Console.WriteLine("Nenhum produto encontrado");
                }
            }
            catch (SqlException ex)
            {
                //Caso de algum problema, pegar ele e mostrar um aviso de erro
                throw new Exception("Erro ao obter Cliente: " + ex.Message);
            }
            finally
            {
                //finalizar a tentativa(com ou sem erro) encerrando a conexão com o banco
                conexao.Desconectar();
            }
        }

        public void ListarTodos()
        {
            //fornecendo informações para adicionar um produto no banco de dados através da querry
            String select = "Select * from Produto";
            cmd.CommandText = select;

            try
            {
                //abrindo conexão com o banco
                cmd.Connection = conexao.Conectar();
                var read = cmd.ExecuteReader();

                //Recebendo todos os produtos que se encaixam na pesquisa
                while (read.Read())
                {
                    Console.WriteLine($"\nCdProdutoERP: {read[1]}\nDsProduto: {read[2]}\nCdFamilia: {read[3]}");
                }
            }
            catch (SqlException ex)
            {
                //Caso de algum problema, pegar ele e mostrar um aviso de erro
                throw ex;
            }
            finally
            {
                //finalizar a tentativa(com ou sem erro) encerrando a conexão com o banco
                conexao.Desconectar();
            }
        }

        public void AlterarProduto(Produto p, string codigoErpAntigo)
        {
            //Querry de inserção de dados no banco SQL
            cmd.CommandText = "UPDATE Produto SET sCdProdutoERP = @CodigoERP, sDsProduto = @sDsProduto, nCdFamilia = @nCdFamilia WHERE sCdProdutoERP =@codigoErpAntigo";
            //Declarando que vada variável vai receber uma informação do construtor, tanto parte do produto(p) como a string codigoErpAntigo
            cmd.Parameters.AddWithValue("@codigoErpAntigo", codigoErpAntigo);
            cmd.Parameters.AddWithValue("@CodigoERP", p.sCdProdutoERP);
            cmd.Parameters.AddWithValue("@sDsProduto", p.sDsProduto);
            cmd.Parameters.AddWithValue("@nCdFamilia", p.nCdFamilia);
            try
            {
                cmd.Connection = conexao.Conectar();
                var i = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                conexao.Desconectar();
            }

        }

        public void DeletarProduto(string codigoERP)
        {
            //Querry de inserção de dados no banco SQL
            cmd.CommandText = "DELETE FROM Produto WHERE sCdProdutoERP =@CodigoERP";
            cmd.Parameters.AddWithValue("@CodigoERP", codigoERP);
            //Declarando que vada variável vai receber uma informação
            try
            {
                //abrindo conexão com o banco
                cmd.Connection = conexao.Conectar();
                var i = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //Caso de algum problema, pegar ele e mostrar um aviso de erro
                throw ex;
            }
            finally
            {
                //finalizar a tentativa(com ou sem erro) encerrando a conexão com o banco
                conexao.Desconectar();
            }
        }


    }

}

