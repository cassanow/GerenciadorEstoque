namespace GerenciadorEstoque
{
    class Estoque
    {
        private IList<Produtos> _produtos = new List<Produtos>();
        public IEnumerable<Produtos> Produtos { get { return _produtos; } }

        public void AdicionarProduto(int iDProduto, string nomeProduto, int quantidadeProduto, decimal preço)
        {
            Console.WriteLine("Digite o ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            if (id < 0)
            {
                Console.WriteLine("Por favor digite um ID valido");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            if (nome == null)
            {
                Console.WriteLine("Por favor digite um nome");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Digite a quantidade do produto: ");
            int quantidade = int.Parse(Console.ReadLine());

            if (quantidade < 0)
            {
                Console.WriteLine("Digite uma quantidade válida");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Digite o preço do produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            if (preco < 0)
            {
                Console.WriteLine("Digite um preço válido");
                Console.WriteLine();
                return;
            }

            Produtos produto = new Produtos(id, nome, quantidade, preco);

            if (produto == null)
            {
                Console.WriteLine("Por favor digite um produto");
                Console.WriteLine();
                return;
            }
            else
            {
                _produtos.Add(produto);
            }
        }

        public void RemoverProduto(int IdProduto)
        {
            var produto = _produtos.FirstOrDefault(p => p.IDProduto == IdProduto);

            if (produto == null)
            {
                Console.WriteLine("Produto nao encontrado");
                Console.WriteLine();
                return;
            }
            else if (produto.QuantidadeProduto > 0)
            {
                Console.WriteLine("Produto não pode ser removido, pois ainda há unidades em estoque");
                Console.WriteLine();
                return;
            }
            else
            {
                _produtos.Remove(produto);
            }
        }

        public void EditarProduto(int IdProduto)
        {
            var produto = _produtos.FirstOrDefault(p => p.IDProduto == IdProduto);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado");
                Console.WriteLine();
                return;
            }
            else
            {
                int opc = 0;
                while (opc != 4)
                    {
                    Console.WriteLine("Deseja editar qual/quais dados do produto?");
                    Console.WriteLine("1 - Nome\n 2 - Quantidade\n 3 - Preço\n 4 - Voltar");
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("Qual vai ser o novo nome do produto?: ");
                            string novoNome = Console.ReadLine();
                            if (novoNome == null)
                            {
                                Console.WriteLine("Por favor, digite um nome");
                                return;
                            }
                            else
                            {
                                produto.novoNome(novoNome);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Qual vai ser a nova quantidade do produto?: ");
                            int novaQuantidade = int.Parse(Console.ReadLine());
                            if (novaQuantidade < 0)
                            {
                                Console.WriteLine("Por favor digite uma quantidade");
                                return;
                            }
                            else
                            {
                                produto.novaQuantidade(novaQuantidade);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Qual vai ser o novo preço do pedido?");
                            decimal novoPreco = decimal.Parse(Console.ReadLine());
                            if (novoPreco < 0)
                            {
                                Console.WriteLine("Por favor digite um preço valido");
                                return;
                            }
                            else
                            {
                                produto.novoPreco(novoPreco);   
                            }
                                break;
                        case 4:
                            Console.WriteLine("Voltando ao menu");
                            break;
                     
                    }
                }
            }
        }

        public void ListarProdutos()
        {
            foreach (var p in _produtos)
            {
                Console.WriteLine($"ID: {p.IDProduto}\nNome: {p.NomeProduto}\nQuantidade: {p.QuantidadeProduto}\nPreço: {p.Preço}");
                Console.WriteLine();
            }
            if (Produtos.Count() == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado");
                Console.WriteLine();
            }
        }
        public void Sair()
        {
            Console.WriteLine("Digite o diretório onde deseja salvar o arquivo:");
            string diretorio = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(diretorio))
            {
                Console.WriteLine("Diretório inválido. Saindo sem salvar.");
                return;
            }

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            string path = Path.Combine(diretorio, "ListaProdutos.txt");

            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (var p in _produtos)
                {
                    sw.WriteLine($"ID: {p.IDProduto}\nNome: {p.NomeProduto}\nQuantidade: {p.QuantidadeProduto}\nPreço: {p.Preço}");
                }
            }

            Console.WriteLine("Saindo do programa.... Produtos salvo com sucesso em " + path);
        }

    }
}

