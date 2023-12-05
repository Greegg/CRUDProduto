using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade05
{
    public class Crud
    {

        Produto produto = new();
        Validacao val = new();
        string codigoErp;
        string i;
        public void CadastrarProduto()
        {
            Manipulacao mp = new();

            //Pegando informações do código ERP em string e verificando se não está null
            do
            {
                Console.WriteLine("Informe o código ERP do produto");
                i = Console.ReadLine();
            } while (!val.ValidacaoNumero(i));
            produto.sCdProdutoERP = i;

            //Pegando informações da descrição do produto em string e verificando se não está null
            do
            {
                Console.WriteLine("\nInforme a descrição do produto");
                i = Console.ReadLine();
            } while (!val.ValidacaoTexto(i));
            produto.sDsProduto = i;

            //Pegando valor do código da familia e validando se é uma string que pdoe ser convertida em numerico
            do
            {
                Console.WriteLine("\nInforme o código da familia do produto");
                i = Console.ReadLine();
            } while (!val.ValidacaoNumero(i));
            produto.nCdFamilia = int.Parse(i);


            //Enviando os dados salvos na classe produto para a classe de manipulação
            mp.Cadastrar(produto);
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        public void ListarTodosProdutos()
        {
            //Recebendo a lista de todos os produtos que existem no banco de dados de forma asc
            Manipulacao mp = new Manipulacao();
            mp.ListarTodos();
        }

        public void ListarProdutoErp()
        {
            //Recebendo a lista de todos os produtos que existem no banco de dados de forma asc
            Manipulacao mp = new Manipulacao();
            do
            {
                Console.WriteLine("Informe o código ERP do produto que deseja excluir");
                i = Console.ReadLine();
            } while (!val.ValidacaoNumero(i));
            codigoErp = i;

            mp.ListarProduto(i);
        }

        public void AlterarProduto()
        {
            Manipulacao mp = new Manipulacao();

            //Pegando informações do código ERP em string e verificando se não está null
            do
            {
                Console.WriteLine("Informe o código ERP do produto que deseja alterar");
                i = Console.ReadLine();
            } while (!val.ValidacaoNumero(i));
            codigoErp = i;

            //Pegando informações do código ERP em string e verificando se não está null
            do
            {
                Console.WriteLine("Informe o novo código ERP do produto");
                i = Console.ReadLine();
            } while (!val.ValidacaoNumero(i));
            produto.sCdProdutoERP = i;

            //Pegando valor do código da familia e validando se é uma string que pdoe ser convertida em numerico
            do
            {
                Console.WriteLine("Informe a nova descrição do produto");
                i = Console.ReadLine();
            } while (!val.ValidacaoTexto(i));
            produto.sDsProduto = i;

            //Pegando valor do código da familia e validando se é uma string que pdoe ser convertida em numerico
            do
            {
                Console.WriteLine("Informe o código da familia do produto");
                i = Console.ReadLine();
            } while (!val.ValidacaoNumero(i));
            produto.nCdFamilia = int.Parse(i);

            //Enviando os dados salvos na classe produto para a classe de manipulação
            mp.AlterarProduto(produto, codigoErp);
            Console.WriteLine("Produto alterado com sucesso!");
        }

        public void DeletarProduto()
        {
            Manipulacao mp = new Manipulacao();

            //Pegando informações do código ERP em string e verificando se não está null
            do
            {
                Console.WriteLine("Informe o código ERP do produto que deseja excluir");
                i = Console.ReadLine();
            } while (!val.ValidacaoNumero(i));
            if (val.ValidacaoDeletar(i))
            {
                string codigoErp = i;
                //Enviando os dados salvos na classe produto para a classe de manipulação
                mp.DeletarProduto(codigoErp);
                Console.WriteLine("Produto excluido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado");
            }



        }






    }


}
