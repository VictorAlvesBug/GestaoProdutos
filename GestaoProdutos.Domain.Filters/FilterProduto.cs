using GestaoProdutos.Domain.Core.Interfaces.Filters;
using GestaoProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProdutos.Domain.Filters
{
	public class FilterProduto : FilterBase<Produto>, IFilterProduto
	{
		public string Descricao { get; set; }
		public DateTime? DataFabricacao { get; set; }
		public DateTime? DataValidade { get; set; }
		public int? CodigoFornecedor { get; set; }
		public string CnpjFornecedor { get; set; }
	}
}
