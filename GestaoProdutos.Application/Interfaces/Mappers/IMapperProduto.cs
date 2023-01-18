using GestaoProdutos.Application.Dtos.Paginacao;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Domain.Entities;
using System.Collections.Generic;

namespace GestaoProdutos.Application.Interfaces.Mappers
{
    public interface IMapperProduto
	{
		Produto MapperDtoToEntity(CreateUpdateProdutoDto createUpdateProdutoDto);

		PaginacaoDto<ProdutoDto> MapperPaginacaoProdutosDto(
			IEnumerable<Produto> produtos, 
			FilterProdutoDto filterProdutoDto, 
			int qtdeTotalItens
		);

		ProdutoDto MapperEntityToDto(Produto produto);
	}
}
