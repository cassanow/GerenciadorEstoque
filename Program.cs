using GerenciadorEstoque;

class Program
{
    enum Opcao { Adicionar = 1, Editar, Remover, Listar, Sair }
    static void Main(string[] args)
    {
        Estoque estoque = new Estoque();
        int opc = 0;
        while (opc != 5)
        {
            Console.WriteLine("Escolha uma das opções abaixo: ");
            Console.WriteLine();
            Console.WriteLine("1 --- Adicionar um produto");
            Console.WriteLine("2 --- Editar um produto");
            Console.WriteLine("3 --- Remover um produto");
            Console.WriteLine("4 --- Listar todos os produtos");
            Console.WriteLine("5 --- Sair");
            opc = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Opcao opcao = (Opcao)opc; 

            switch (opc)
            {
                case 1:
                    int id = 0;
                    string nome = "";
                    int quantidade = 0;
                    decimal preco = 0;
                    estoque.AdicionarProduto(id,nome, quantidade, preco);
                    break;
                case 2:
                    Console.WriteLine("Digite o ID do produto que deseja editar");
                    id = int.Parse(Console.ReadLine());
                    estoque.EditarProduto(id);
                    break;
                case 3:
                    Console.WriteLine("Digite o ID do produto que deseja remover");
                    id = int.Parse(Console.ReadLine());
                    estoque.RemoverProduto(id);
                    break;
                case 4:
                    estoque.ListarProdutos();  
                    break;
                case 5:
                    estoque.Sair(); 
                    break;
            }
        }
    }
}