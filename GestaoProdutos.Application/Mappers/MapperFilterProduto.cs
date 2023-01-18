using GestaoProdutos.Application.Dtos.Paginacao;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Application.Interfaces.Mappers;
using GestaoProdutos.Domain.Entities;
using GestaoProdutos.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GestaoProdutos.Application.Mappers
{
	public class MapperFilterProduto : IMapperFilterProduto
	{
		public FilterProduto MapperDtoToEntity(FilterProdutoDto filterProdutoDto)
		{
			if (filterProdutoDto == null)
			{
				return null;
			}

			string cnpjFornecedorSemMascara = null;

			if (filterProdutoDto.CnpjFornecedor != null)
			{
				cnpjFornecedorSemMascara = filterProdutoDto.CnpjFornecedor
					.Replace(".", "")
					.Replace("/", "")
					.Replace("-", "");
			}

			var filterProduto = new FilterProduto
			{
				Pagina = filterProdutoDto.Pagina,
				QtdeItensPorPagina = filterProdutoDto.QtdeItensPorPagina,
				Descricao = filterProdutoDto.Descricao,
				DataFabricacao = filterProdutoDto.DataFabricacao,
				DataValidade = filterProdutoDto.DataValidade,
				CodigoFornecedor = filterProdutoDto.CodigoFornecedor,
				CnpjFornecedor = cnpjFornecedorSemMascara,
			};

			return filterProduto;
		}
	}
}
