using System;

namespace GestaoProdutos.Application.Dtos.Produto
{
    public class ProdutoDto
    {
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public string DataFabricacao { get; set; }
        public string DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
    }
}
