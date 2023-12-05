using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade05
{
    internal class Validacao
    {

        public bool ValidacaoNumero(string s)
        {
            //Declarando variavel local
            int n;
            //Recebendo um resultado bool se conseguimos ou não(true ou false) converter em numerico
            bool isNumeric = int.TryParse(s, out n);
            if (!isNumeric)
            {
                //Caso não consiga converter, vai retornar false
                return false;
            }
            else
            {
                //Caso consiga, vai retornar true
                return true;
            }
        }

        public bool ValidacaoTexto(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                //caso não for nulo ou vazio, vai retornar falso
                return false;
            }
            else
            {
                //Caso for nulo ou vazio, vai retornar verdadeiro
                return true;
            }
        }

        public bool ValidacaoDeletar(string codigoERP)
        {
            Conexao conexao = new Conexao();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader Dr;

            //fornecendo informações para adicionar um produto no banco de dados através da querry
            String select = "Select * from Produto WHERE sCdProdutoErp =@CodigoERP";
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
                    return true;
                }
                else
                {
                    return false;
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
    }
}
