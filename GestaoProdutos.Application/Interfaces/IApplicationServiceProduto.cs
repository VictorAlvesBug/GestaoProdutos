using GestaoProdutos.Application.Dtos.Paginacao;
using GestaoProdutos.Application.Dtos.Produto;
using System.Collections.Generic;

namespace GestaoProdutos.Application.Interfaces
{
    public interface IApplicationServiceProduto
	{
		int? Add(CreateUpdateProdutoDto createUpdateProdutoDto);
		bool Update(int codigo, CreateUpdateProdutoDto createUpdateProdutoDto);
		bool DeleteByCodigo(int codigo);
		PaginacaoDto<ProdutoDto> Filter(FilterProdutoDto filterProdutoDto);
		ProdutoDto GetByCodigo(int codigo);
	}
}
