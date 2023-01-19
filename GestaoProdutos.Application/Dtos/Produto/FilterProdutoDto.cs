using GestaoProdutos.Domain.Core.Interfaces.Filters;
using System;

namespace GestaoProdutos.Application.Dtos.Produto
{
    public class FilterProdutoDto : IFilterProduto
    {
        public int Pagina { get; set; }
        public int QtdeItensPorPagina { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
    }
}
