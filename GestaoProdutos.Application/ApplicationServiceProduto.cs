using AutoMapper;
using GestaoProdutos.Application.Dtos.Paginacao;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Application.Interfaces;
using GestaoProdutos.Domain.Core.Interfaces.Services;
using GestaoProdutos.Domain.Entities;
using GestaoProdutos.Domain.Filters;
using System.Collections.Generic;

namespace GestaoProdutos.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
	{
		private readonly IServiceProduto serviceProduto;
		private readonly IMapper mapper;

		public ApplicationServiceProduto(
			IServiceProduto serviceProduto,
			IMapper mapper
		)
		{
			this.serviceProduto = serviceProduto;
			this.mapper = mapper;
		}

		public int? Add(CreateUpdateProdutoDto createUpdateProdutoDto)
		{
			var produto = mapper.Map<CreateUpdateProdutoDto, Produto>(createUpdateProdutoDto);
			return serviceProduto.Add(produto);
		}

		public bool DeleteByCodigo(int codigo)
		{
			return serviceProduto.DeleteByCodigo(codigo);
		}

		public PaginacaoDto<ProdutoDto> Filter(FilterProdutoDto filterProdutoDto)
		{
			var filterProduto = mapper.Map<FilterProdutoDto, FilterProduto>(filterProdutoDto);

			var produtos = serviceProduto.Filter(filterProduto);

			int qtdeTotalItens = serviceProduto.Count(filterProduto);

			var produtosDto = mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoDto>>(produtos);

			return new PaginacaoDto<ProdutoDto>
			{
				Pagina = filterProdutoDto.Pagina,
				QtdeItensPorPagina = filterProdutoDto.QtdeItensPorPagina,
				QtdeTotalItens = qtdeTotalItens,
				Lista = produtosDto
			};
		}

		public ProdutoDto GetByCodigo(int codigo)
		{
			var produto = serviceProduto.GetByCodigo(codigo);
			return mapper.Map<Produto, ProdutoDto>(produto);
		}

		public bool Update(int codigo, CreateUpdateProdutoDto createUpdateProdutoDto)
		{
			var produto = mapper.Map<CreateUpdateProdutoDto, Produto>(createUpdateProdutoDto);
			return serviceProduto.Update(codigo, produto);
		}
	}
}
