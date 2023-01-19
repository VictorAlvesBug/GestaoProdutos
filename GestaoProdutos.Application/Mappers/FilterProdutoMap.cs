using AutoMapper;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Domain.Entities;
using GestaoProdutos.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GestaoProdutos.Application.Mappers
{
	public class FilterProdutoMap : Profile
	{
		public FilterProdutoMap()
		{
			CreateMap<FilterProdutoDto, FilterProduto>()
			   .ForMember(destino => destino.CnpjFornecedor, origem
				   => origem.MapFrom(c =>
						(c.CnpjFornecedor == null)
						? null
						: (
							c.CnpjFornecedor
								.Replace(".", "")
								.Replace("/", "")
								.Replace("-", "")
						)
					)
				);
		}
	}
}
