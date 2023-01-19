using GestaoProdutos.Domain.Core.Interfaces.Filters;
using GestaoProdutos.Domain.Core.Interfaces.Repositories;
using GestaoProdutos.Domain.Entities;
using GestaoProdutos.Infrastructure.Data.ConnectionFactories;
using static Dapper.SqlMapper;
using System.Collections.Generic;
using System;
using GestaoProdutos.Domain.Filters;

namespace GestaoProdutos.Infrastructure.Data.Repositories
{
	public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
	{
		public override IEnumerable<Produto> Filter(IFilterBase<Produto> filter)
		{
			try
			{
				string nomeEntity = typeof(Produto).Name;

				List<string> listaPropriedades = ListarPropriedades();

				string strListaPropriedades = string.Join(",", listaPropriedades);

				int qtdeItensPular = (filter.Pagina - 1) * filter.QtdeItensPorPagina;

				string query = $@"
						SELECT 
							{strListaPropriedades}
						FROM
							{nomeEntity}
						WHERE
							IsAtivo = 1
							AND 
							(
								@Descricao IS NULL 
								OR Descricao LIKE CONCAT('%', @Descricao, '%')
							)
							AND 
							(
								@DataFabricacao IS NULL 
								OR DataFabricacao = CONVERT(DATE, @DataFabricacao)
							)
							AND 
							(
								@DataValidade IS NULL 
								OR DataValidade = CONVERT(DATE, @DataValidade)
							)
							AND 
							(
								@CodigoFornecedor IS NULL 
								OR CodigoFornecedor = @CodigoFornecedor
							)
							AND 
							(
								@DescricaoFornecedor IS NULL 
								OR DescricaoFornecedor LIKE CONCAT('%', @DescricaoFornecedor, '%')
							)
							AND 
							(
								@CnpjFornecedor IS NULL 
								OR CnpjFornecedor = @CnpjFornecedor
							)
						ORDER BY
							Codigo
						OFFSET {qtdeItensPular} ROWS 
						FETCH NEXT {filter.QtdeItensPorPagina} ROWS ONLY;
						
				";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.Query<Produto>(query, filter as FilterProduto);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override int Count(IFilterBase<Produto> filter)
		{
			try
			{
				string nomeEntity = typeof(Produto).Name;

				string query = $@"
						SELECT 
							COUNT(*)
						FROM
							{nomeEntity}
						WHERE
							IsAtivo = 1
							AND 
							(
								@Descricao IS NULL 
								OR Descricao LIKE CONCAT('%', @Descricao, '%')
							)
							AND 
							(
								@DataFabricacao IS NULL 
								OR DataFabricacao = CONVERT(DATE, @DataFabricacao)
							)
							AND 
							(
								@DataValidade IS NULL 
								OR DataValidade = CONVERT(DATE, @DataValidade)
							)
							AND 
							(
								@CodigoFornecedor IS NULL 
								OR CodigoFornecedor = @CodigoFornecedor
							)
							AND 
							(
								@DescricaoFornecedor IS NULL 
								OR DescricaoFornecedor LIKE CONCAT('%', @DescricaoFornecedor, '%')
							)
							AND 
							(
								@CnpjFornecedor IS NULL 
								OR CnpjFornecedor = @CnpjFornecedor
							);
						";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.QueryFirstOrDefault<int>(query, filter as FilterProduto);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
