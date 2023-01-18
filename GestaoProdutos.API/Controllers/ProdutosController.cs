using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Application.Interfaces;
using GestaoProdutos.Application.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
		public ActionResult<IEnumerable<ProdutoDto>> GetAll(int pagina = 1, int itensPorPagina = 3)
		{
			var produtosDto = applicationServiceProduto.GetAll(pagina, itensPorPagina);
			return StatusCode(StatusCodes.Status200OK, produtosDto);
		}

		[HttpGet]
		[Route("{codigo}")]
		public ActionResult<ProdutoDto> Get(int codigo)
		{
			var produtoDto = applicationServiceProduto.GetByCodigo(codigo);

			if(produtoDto == null)
			{
				return StatusCode(StatusCodes.Status404NotFound);
			}

			return StatusCode(StatusCodes.Status200OK, produtoDto);
		}

		[HttpPost]
		[ValidateModel]
		public ActionResult<ProdutoDto> Post([FromBody] CreateUpdateProdutoDto createUpdateProdutoDto)
		{
			int? codigoCriado = applicationServiceProduto.Add(createUpdateProdutoDto);

			if (codigoCriado == null)
			{
				return StatusCode(StatusCodes.Status400BadRequest);
			}

			var produtoDtoCriado = applicationServiceProduto.GetByCodigo(codigoCriado.Value);

			if(produtoDtoCriado == null)
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
