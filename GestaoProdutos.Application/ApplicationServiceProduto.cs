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

		public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapperProduto mapperProduto)
		{
			this.serviceProduto = serviceProduto;
			this.mapperProduto = mapperProduto;
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

		public IEnumerable<ProdutoDto> GetAll(int pagina, int itensPorPagina)
		{
			var produtos = serviceProduto.GetAll(pagina, itensPorPagina);
			return mapperProduto.MapperListProdutosDto(produtos);
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
