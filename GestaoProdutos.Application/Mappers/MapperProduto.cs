using GestaoProdutos.Application.Dtos.Paginacao;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Application.Interfaces.Mappers;
using GestaoProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GestaoProdutos.Application.Mappers
{
	public class MapperProduto : IMapperProduto
	{
		public Produto MapperDtoToEntity(CreateUpdateProdutoDto createUpdateProdutoDto)
		{
			if (createUpdateProdutoDto == null)
			{
				return null;
			}

			string cnpjFornecedorSemMascara = null;

			if (createUpdateProdutoDto.CnpjFornecedor != null)
			{
				cnpjFornecedorSemMascara = createUpdateProdutoDto.CnpjFornecedor
					.Replace(".", "")
					.Replace("/", "")
					.Replace("-", "");
			}

			var produto = new Produto
			{
				Descricao = createUpdateProdutoDto.Descricao,
				DataFabricacao = createUpdateProdutoDto.DataFabricacao,
				DataValidade = createUpdateProdutoDto.DataValidade,
				CodigoFornecedor = createUpdateProdutoDto.CodigoFornecedor,
				DescricaoFornecedor = createUpdateProdutoDto.DescricaoFornecedor,
				CnpjFornecedor = cnpjFornecedorSemMascara
			};

			return produto;
		}

		public ProdutoDto MapperEntityToDto(Produto produto)
		{
			if (produto == null)
			{
				return null;
			}

			string cnpjFornecedorComMascara = null;

			if (produto.CnpjFornecedor != null)
			{
				if (produto.CnpjFornecedor.Length == 14)
				{
					var pattern = @"^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$";
					var regExp = new Regex(pattern);
					cnpjFornecedorComMascara = regExp.Replace(produto.CnpjFornecedor, "$1.$2.$3/$4-$5");
				}
				else
				{
					cnpjFornecedorComMascara = produto.CnpjFornecedor;
				}
			}

			string dataFabricacao = null;

			if (produto.DataFabricacao != null && produto.DataFabricacao != DateTime.MinValue)
			{
				dataFabricacao = produto.DataFabricacao?.ToString("dd/MM/yyyy");
			}

			string dataValidade = null;

			if (produto.DataValidade != null && produto.DataValidade != DateTime.MinValue)
			{
				dataValidade = produto.DataValidade?.ToString("dd/MM/yyyy");
			}

			var produtoDto = new ProdutoDto
			{
				Codigo = produto.Codigo,
				Descricao = produto.Descricao,
				DataFabricacao = dataFabricacao,
				DataValidade = dataValidade,
				CodigoFornecedor = produto.CodigoFornecedor,
				DescricaoFornecedor = produto.DescricaoFornecedor,
				CnpjFornecedor = cnpjFornecedorComMascara
			};

			return produtoDto;
		}

		public PaginacaoDto<ProdutoDto> MapperPaginacaoProdutosDto(
			IEnumerable<Produto> produtos,
			FilterProdutoDto filterProdutoDto, 
			int qtdeTotalItens)
		{
			if (produtos == null)
			{
				return new PaginacaoDto<ProdutoDto>
				{
					Pagina = filterProdutoDto.Pagina,
					QtdeItensPorPagina = filterProdutoDto.QtdeItensPorPagina,
					QtdeTotalItens = qtdeTotalItens,
					Lista = new List<ProdutoDto>()
				};
			}

			var produtosDto = produtos.Select(produto => MapperEntityToDto(produto));

			return new PaginacaoDto<ProdutoDto>
			{
				Pagina = filterProdutoDto.Pagina,
				QtdeItensPorPagina = filterProdutoDto.QtdeItensPorPagina,
				QtdeTotalItens = qtdeTotalItens,
				Lista = produtosDto
			};
		}
	}
}
