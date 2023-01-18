using GestaoProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProdutos.Domain.Core.Interfaces.Filters
{
	public interface IFilterProduto : IFilterBase<Produto>
	{
		public string Descricao { get; set; }
		public DateTime? DataFabricacao { get; set; }
		public DateTime? DataValidade { get; set; }
		public int? CodigoFornecedor { get; set; }
		public string CnpjFornecedor { get; set; }
	}
}
