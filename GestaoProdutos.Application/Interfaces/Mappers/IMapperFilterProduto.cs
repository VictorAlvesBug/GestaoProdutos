using GestaoProdutos.Application.Dtos.Paginacao;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Domain.Entities;
using GestaoProdutos.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProdutos.Application.Interfaces.Mappers
{
	public interface IMapperFilterProduto
	{
		FilterProduto MapperDtoToEntity(FilterProdutoDto filterProdutoDto);
	}
}
