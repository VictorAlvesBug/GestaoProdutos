using AutoMapper;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GestaoProdutos.Application.Mappers
{
	public class ProdutoMap : Profile
	{
		public ProdutoMap()
		{
			CreateMap<Produto, ProdutoDto>()
			   .ForMember(destino => destino.DataFabricacao, origem
				   => origem.MapFrom(c =>
					   (c.DataFabricacao == null)
					   ? null
					   : c.DataFabricacao.Value.ToString("dd/MM/yyyy")
					)
				)
			   .ForMember(destino => destino.DataValidade, origem
				   => origem.MapFrom(c =>
					   (c.DataValidade == null)
					   ? null
					   : c.DataValidade.Value.ToString("dd/MM/yyyy")
					)
				)
			   .ForMember(destino => destino.CnpjFornecedor, origem
				   => origem.MapFrom(c =>
						(c.CnpjFornecedor == null)
						? null
						: (
							(c.CnpjFornecedor.Length != 14)
							? c.CnpjFornecedor
							: new Regex(@"^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$")
								.Replace(c.CnpjFornecedor, "$1.$2.$3/$4-$5")
						)
					)
				);

			CreateMap<CreateUpdateProdutoDto, Produto>()
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
