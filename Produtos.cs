namespace GerenciadorEstoque
{
    class Produtos
    {
        public Produtos(int iDProduto, string nomeProduto, int quantidadeProduto, decimal preço)
        {
            IDProduto = iDProduto;
            NomeProduto = nomeProduto;
            QuantidadeProduto = quantidadeProduto;
            Preço = preço;
        }

        public int IDProduto { get; private set; }
        public string NomeProduto { get; private set; }
        public int QuantidadeProduto { get; private set; }
        public decimal Preço { get; private set; }

        public void novoNome(string novoNome)
        {
            NomeProduto = novoNome;
        }

        public void novaQuantidade(int novaQuantidade)
        {
            QuantidadeProduto = novaQuantidade;
        }

        public void novoPreco(decimal novoPreco)
        {
            Preço = novoPreco;  
        }
    }
}
 