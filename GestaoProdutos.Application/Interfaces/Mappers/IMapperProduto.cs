using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Domain.Entities;
using System.Collections.Generic;

namespace GestaoProdutos.Application.Interfaces.Mappers
{
    public interface IMapperProduto
	{
		Produto MapperDtoToEntity(CreateUpdateProdutoDto createUpdateProdutoDto);
		
		IEnumerable<ProdutoDto> MapperListProdutosDto(IEnumerable<Produto> produtos);

		ProdutoDto MapperEntityToDto(Produto produto);
	}
}
