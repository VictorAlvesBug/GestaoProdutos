using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GestaoProdutos.Application.Dtos.Produto
{
    public class CreateUpdateProdutoDto
	{
        [Required(ErrorMessage = "Informe a descrição do produto")]
        [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "A descrição do produto deve ter de 3 a 255 caracteres")]
        public string Descricao { get; set; }

        public DateTime? DataFabricacao { get; set; }

        public DateTime? DataValidade { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "O código do fornecedor é inválido")]
        public int? CodigoFornecedor { get; set; }


		[StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "A descrição do fornecedor deve ter de 3 a 255 caracteres")]
		public string DescricaoFornecedor { get; set; }


		[RegularExpression(@"^(\d{14}|\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2})$", ErrorMessage = "Informe um CNPJ válido para o fornecedor")]
		public string CnpjFornecedor { get; set; }

        public bool IsValido(out ModelStateDictionary modelState)
        {
			modelState = new ModelStateDictionary();

			#region Validação das Datas
			bool informouApenasDataFabricacao = DataFabricacao != null && DataValidade == null;
			bool informouApenasDataValidade = DataFabricacao == null && DataValidade != null;
			bool dataValidadeAnteriorDataFabricacao = DataFabricacao != null && DataValidade != null && DataValidade <= DataFabricacao;

            if (informouApenasDataFabricacao)
            {
				modelState.AddModelError("DataValidade", "Informe também a data de validade");
			}
            else if (informouApenasDataValidade)
			{
				modelState.AddModelError("DataFabricacao", "Informe também a data de fabricação");
			}
			else if(dataValidadeAnteriorDataFabricacao)
			{
				modelState.AddModelError("DataValidade", "A data de validade deve ser após a data de fabricação");
			}
			#endregion

			#region Validação dos dados do Fornecedor 
			bool informouDadosFornecedorParcialmente =
				   (CodigoFornecedor == null && DescricaoFornecedor == null && CnpjFornecedor != null)
				|| (CodigoFornecedor == null && DescricaoFornecedor != null && CnpjFornecedor == null)
				|| (CodigoFornecedor != null && DescricaoFornecedor == null && CnpjFornecedor == null)
				|| (CodigoFornecedor == null && DescricaoFornecedor != null && CnpjFornecedor != null)
				|| (CodigoFornecedor != null && DescricaoFornecedor == null && CnpjFornecedor != null)
				|| (CodigoFornecedor != null && DescricaoFornecedor != null && CnpjFornecedor == null);

			if (informouDadosFornecedorParcialmente)
			{
				modelState.AddModelError("CodigoFornecedor", "Informe todos os dados do fornecedor");
			}
			#endregion

			return modelState.IsValid;
        }
    }
}
