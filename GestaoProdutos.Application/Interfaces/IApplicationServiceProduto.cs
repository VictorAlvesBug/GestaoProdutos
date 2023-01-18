using GestaoProdutos.Application.Dtos;
using System.Collections.Generic;

namespace GestaoProdutos.Application.Interfaces
{
	public interface IApplicationServiceProduto
	{
		bool Add(ProdutoDto produtoDto);
		bool Update(ProdutoDto produtoDto);
		bool DeleteByCodigo(int codigo);
		IEnumerable<ProdutoDto> GetAll();
		ProdutoDto GetByCodigo(int codigo);
	}
}
