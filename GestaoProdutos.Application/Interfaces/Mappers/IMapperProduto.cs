using GestaoProdutos.Application.Dtos;
using GestaoProdutos.Domain.Entities;
using System.Collections.Generic;

namespace GestaoProdutos.Application.Interfaces.Mappers
{
	public interface IMapperProduto
	{
		Produto MapperDtoToEntity(ProdutoDto produtoDto);
		
		IEnumerable<ProdutoDto> MapperListProdutosDto(IEnumerable<Produto> produtos);

		ProdutoDto MapperEntityToDto(Produto produto);
	}
}
