using GestaoProdutos.Application.Dtos.Paginacao;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Application.Interfaces;
using GestaoProdutos.Application.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GestaoProdutos.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProdutosController : ControllerBase
	{
		private readonly IApplicationServiceProduto applicationServiceProduto;

		public ProdutosController(IApplicationServiceProduto applicationServiceProduto)
		{
			this.applicationServiceProduto = applicationServiceProduto;
		}

		[HttpGet]
		public ActionResult<PaginacaoDto<ProdutoDto>> Filter(
			int pagina = 1,
			int qtdeItensPorPagina = 10,
			string descricao = null,
			DateTime? dataFabricacao = null,
			DateTime? dataValidade = null,
			int? codigoFornecedor = null,
			string descricaoFornecedor = null,
			string cnpjFornecedor = null

		)
		{
			var filterProdutoDto = new FilterProdutoDto
			{
				Pagina = pagina,
				QtdeItensPorPagina = qtdeItensPorPagina,
				Descricao = descricao,
				DataFabricacao = dataFabricacao,
				DataValidade = dataValidade,
				CodigoFornecedor = codigoFornecedor,
				DescricaoFornecedor = descricaoFornecedor,
				CnpjFornecedor = cnpjFornecedor
			};

			var paginacaoProdutosDto = applicationServiceProduto.Filter(filterProdutoDto);
			return StatusCode(StatusCodes.Status200OK, paginacaoProdutosDto);
		}

		[HttpGet]
		[Route("{codigo}")]
		public ActionResult<ProdutoDto> Get(int codigo)
		{
			var produtoDto = applicationServiceProduto.GetByCodigo(codigo);

			if (produtoDto == null)
			{
				return StatusCode(StatusCodes.Status404NotFound);
			}

			return StatusCode(StatusCodes.Status200OK, produtoDto);
		}

		[HttpPost]
		[ValidateModel]
		public ActionResult<ProdutoDto> Post([FromBody] CreateUpdateProdutoDto createUpdateProdutoDto)
		{
			if (!createUpdateProdutoDto.IsValido(out ModelStateDictionary modelState))
			{
				return new ValidationFailedResult(modelState);
			}

			int? codigoCriado = applicationServiceProduto.Add(createUpdateProdutoDto);

			if (codigoCriado == null)
			{
				return StatusCode(StatusCodes.Status400BadRequest);
			}

			var produtoDtoCriado = applicationServiceProduto.GetByCodigo(codigoCriado.Value);

			if (produtoDtoCriado == null)
			{
				return StatusCode(StatusCodes.Status404NotFound);
			}

			return StatusCode(StatusCodes.Status201Created, produtoDtoCriado);
		}

		[HttpPut]
		[Route("{codigo}")]
		[ValidateModel]
		public ActionResult<ProdutoDto> Put(int codigo, [FromBody] CreateUpdateProdutoDto createUpdateProdutoDto)
		{
			if (!createUpdateProdutoDto.IsValido(out ModelStateDictionary modelState))
			{
				return new ValidationFailedResult(modelState);
			}

			if (applicationServiceProduto.Update(codigo, createUpdateProdutoDto))
			{
				return StatusCode(StatusCodes.Status200OK);
			}

			return StatusCode(StatusCodes.Status400BadRequest);
		}

		[HttpDelete]
		[Route("{codigo}")]
		public ActionResult<ProdutoDto> Delete(int codigo)
		{
			if (applicationServiceProduto.DeleteByCodigo(codigo))
			{
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return StatusCode(StatusCodes.Status400BadRequest);
		}
	}
}
