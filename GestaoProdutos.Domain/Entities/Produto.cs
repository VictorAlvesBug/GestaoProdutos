using System;

namespace GestaoProdutos.Domain.Entities
{
	public class Produto
	{
		public int? Codigo { get; set; }
		public string Descricao { get; set; }
		public DateTime? DataFabricacao { get; set; }
		public DateTime? DataValidade { get; set; }
		public int? CodigoFornecedor { get; set; }
		public string DescricaoFornecedor { get; set; }
		public string CnpjFornecedor { get; set; }
		public bool IsAtivo { get; set; }
	}
}
