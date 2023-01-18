using GestaoProdutos.Application.Dtos;
using GestaoProdutos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoProdutos.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProdutosController : ControllerBase
	{
		// https://www.youtube.com/watch?v=plS-rf2UIPI
		// 2:13:45

		private readonly IApplicationServiceProduto applicationServiceProduto;

		public ProdutosController(IApplicationServiceProduto applicationServiceProduto)
		{
			this.applicationServiceProduto = applicationServiceProduto;
		}

		[HttpGet]
		public IEnumerable<ProdutoDto> GetAll()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new ProdutoDto
			{
				Codigo = index
			});
		}
	}
}
