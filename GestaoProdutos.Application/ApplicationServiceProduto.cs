using GestaoProdutos.Application.Dtos.Paginacao;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Application.Interfaces;
using GestaoProdutos.Application.Interfaces.Mappers;
using GestaoProdutos.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace GestaoProdutos.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
	{
		private readonly IServiceProduto serviceProduto;
		private readonly IMapperProduto mapperProduto;
		private readonly IMapperFilterProduto mapperFilterProduto;

		public ApplicationServiceProduto(
			IServiceProduto serviceProduto, 
			IMapperProduto mapperProduto, 
			IMapperFilterProduto mapperFilterProduto
		)
		{
			this.serviceProduto = serviceProduto;
			this.mapperProduto = mapperProduto;
			this.mapperFilterProduto = mapperFilterProduto;
		}

		public int? Add(CreateUpdateProdutoDto createUpdateProdutoDto)
		{
			var produto = mapperProduto.MapperDtoToEntity(createUpdateProdutoDto);
			return serviceProduto.Add(produto);
		}

		public bool DeleteByCodigo(int codigo)
		{
			return serviceProduto.DeleteByCodigo(codigo);
		}

		public PaginacaoDto<ProdutoDto> Filter(FilterProdutoDto filterProdutoDto)
		{
			var filterProduto = mapperFilterProduto.MapperDtoToEntity(filterProdutoDto);

			var produtos = serviceProduto.Filter(filterProduto);

			int qtdeTotalItens = serviceProduto.Count(filterProduto);

			return mapperProduto.MapperPaginacaoProdutosDto(produtos, filterProdutoDto, qtdeTotalItens);
		}

		public ProdutoDto GetByCodigo(int codigo)
		{
			var produto = serviceProduto.GetByCodigo(codigo);
			return mapperProduto.MapperEntityToDto(produto);
		}

		public bool Update(int codigo, CreateUpdateProdutoDto createUpdateProdutoDto)
		{
			var produto = mapperProduto.MapperDtoToEntity(createUpdateProdutoDto);
			return serviceProduto.Update(codigo, produto);
		}
	}
}
