using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoProdutos.Application.Dtos.Produto
{
    public class CreateUpdateProdutoDto
	{
        [Required(ErrorMessage = "Informe a descrição do produto")]
        [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "A descrição do produto deve ter de 3 a 255 caracteres")]
        public string Descricao { get; set; }

        public DateTime? DataFabricacao { get; set; }

        public DateTime? DataValidade { get; set; }

        public int? CodigoFornecedor { get; set; }


		[StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "A descrição do fornecedor deve ter de 3 a 255 caracteres")]
		public string DescricaoFornecedor { get; set; }


		[RegularExpression(@"^(\d{14}|\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2})$", ErrorMessage = "Informe um CNPJ válido para o fornecedor")]
		public string CnpjFornecedor { get; set; }
    }
}
