namespace Atividade05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manipulacao mp = new Manipulacao();
            Produto produto = new();
            Crud crud = new();
            Validacao validacao = new();
            bool finish = false;
            while (!finish)
            {
                Console.WriteLine("\nDigite a opção desejada");
                Console.WriteLine("1 - Listar todos os produtos");
                Console.WriteLine("2 - Procurar por código ERP do produtos");
                Console.WriteLine("3 - Cadastrar Produtos");
                Console.WriteLine("4 - Alterar dados do produto");
                Console.WriteLine("5 - Excluir um produto");
                Console.WriteLine("6 - Sair\n");

                string s = Console.ReadLine();

                if (validacao.ValidacaoNumero(s))
                {
                    int i = int.Parse(s);
                    switch (i)
                    {
                        case 1:
                            crud.ListarTodosProdutos();
                            break;
                        case 2:
                            crud.ListarProdutoErp();
                            break;
                        case 3:
                            crud.CadastrarProduto();
                            break;
                        case 4:
                            crud.AlterarProduto();
                            break;
                        case 5:
                            crud.DeletarProduto();
                            break;
                        case 6:
                            finish = true;
                            break;

                    }
                }
            }


        }
    }
}