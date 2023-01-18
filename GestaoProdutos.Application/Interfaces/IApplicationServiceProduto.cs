using GestaoProdutos.Application.Dtos.Produto;
using System.Collections.Generic;

namespace GestaoProdutos.Application.Interfaces
{
    public interface IApplicationServiceProduto
	{
		int? Add(CreateUpdateProdutoDto createUpdateProdutoDto);
		bool Update(int codigo, CreateUpdateProdutoDto createUpdateProdutoDto);
		bool DeleteByCodigo(int codigo);
		IEnumerable<ProdutoDto> GetAll(int pagina, int itensPorPagina);
		ProdutoDto GetByCodigo(int codigo);
	}
}
