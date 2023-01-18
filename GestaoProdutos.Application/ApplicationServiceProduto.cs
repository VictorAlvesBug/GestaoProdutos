using GestaoProdutos.Application.Dtos;
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

		public bool Add(ProdutoDto produtoDto)
		{
			var produto = mapperProduto.MapperDtoToEntity(produtoDto);
			return serviceProduto.Add(produto);
		}

		public bool DeleteByCodigo(int codigo)
		{
			return serviceProduto.DeleteByCodigo(codigo);
		}

		public IEnumerable<ProdutoDto> GetAll()
		{
			var produtos = serviceProduto.GetAll();
			return mapperProduto.MapperListProdutosDto(produtos);
		}

		public ProdutoDto GetByCodigo(int codigo)
		{
			var produto = serviceProduto.GetByCodigo(codigo);
			return mapperProduto.MapperEntityToDto(produto);
		}

		public bool Update(ProdutoDto produtoDto)
		{
			var produto = mapperProduto.MapperDtoToEntity(produtoDto);
			return serviceProduto.Update(produto);
		}
	}
}
