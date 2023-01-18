using GestaoProdutos.Application.Dtos;
using GestaoProdutos.Application.Interfaces.Mappers;
using GestaoProdutos.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GestaoProdutos.Application.Mappers
{
	public class MapperProduto : IMapperProduto
	{
		public Produto MapperDtoToEntity(ProdutoDto produtoDto)
		{
			var produto = new Produto
			{
				Codigo = produtoDto.Codigo,
				Descricao = produtoDto.Descricao,
				DataFabricacao = produtoDto.DataFabricacao,
				DataValidade = produtoDto.DataValidade,
				CodigoFornecedor = produtoDto.CodigoFornecedor,
				DescricaoFornecedor = produtoDto.DescricaoFornecedor,
				CnpjFornecedor = produtoDto.CnpjFornecedor,
				IsAtivo = produtoDto.IsAtivo
			};

			return produto;
		}

		public ProdutoDto MapperEntityToDto(Produto produto)
		{
			var produtoDto = new ProdutoDto
			{
				Codigo = produto.Codigo,
				Descricao = produto.Descricao,
				DataFabricacao = produto.DataFabricacao,
				DataValidade = produto.DataValidade,
				CodigoFornecedor = produto.CodigoFornecedor,
				DescricaoFornecedor = produto.DescricaoFornecedor,
				CnpjFornecedor = produto.CnpjFornecedor,
				IsAtivo = produto.IsAtivo
			};

			return produtoDto;
		}

		public IEnumerable<ProdutoDto> MapperListProdutosDto(IEnumerable<Produto> produtos)
		{
			var produtosDto = produtos.Select(produto => MapperEntityToDto(produto));

			return produtosDto;
		}
	}
}
