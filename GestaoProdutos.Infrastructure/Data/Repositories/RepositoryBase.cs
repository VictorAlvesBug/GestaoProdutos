using Dapper;
using GestaoProdutos.Application.Dtos.Produto;
using GestaoProdutos.Domain.Core.Interfaces.Filters;
using GestaoProdutos.Domain.Core.Interfaces.Repositories;
using GestaoProdutos.Infrastructure.Data.ConnectionFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using static Dapper.SqlMapper;

namespace GestaoProdutos.Infrastructure.Data.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		public List<string> ListarPropriedades()
		{
			return typeof(TEntity).GetProperties()
				.Select(propriedade => propriedade.Name)
				.ToList();
		}

		public virtual int? Add(TEntity entity)
		{
			try
			{
				string nomeEntity = typeof(TEntity).Name;

				List<string> listaPropriedades = ListarPropriedades();

				listaPropriedades.Remove("Codigo");
				listaPropriedades.Remove("IsAtivo");

				string strListaPropriedades = string.Join(",", listaPropriedades);
				string strListaVariaveis = string.Join(",", listaPropriedades.Select(propriedade => $"@{propriedade}"));

				string query = $@"
						INSERT INTO {nomeEntity}
							({strListaPropriedades})
						VALUES
							({strListaVariaveis});
						SELECT SCOPE_IDENTITY();
						";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.QueryFirstOrDefault<int?>(query, entity);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual IEnumerable<TEntity> Filter(IFilterBase<TEntity> filter)
		{
			try
			{
				string nomeEntity = typeof(TEntity).Name;

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
						ORDER BY
							Codigo
						OFFSET {qtdeItensPular} ROWS 
						FETCH NEXT {filter.QtdeItensPorPagina} ROWS ONLY;
						";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.Query<TEntity>(query);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual int Count(IFilterBase<TEntity> filter)
		{
			try
			{
				string nomeEntity = typeof(TEntity).Name;

				string query = $@"
						SELECT 
							COUNT(*)
						FROM
							{nomeEntity}
						WHERE
							IsAtivo = 1;
						";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.QueryFirstOrDefault<int>(query);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual TEntity GetByCodigo(int codigo)
		{
			try
			{
				string nomeEntity = typeof(TEntity).Name;

				List<string> listaPropriedades = ListarPropriedades();

				string strListaPropriedades = string.Join(",", listaPropriedades);

				string query = $@"
						SELECT 
							{strListaPropriedades}
						FROM
							{nomeEntity}
						WHERE
							Codigo = @Codigo
							AND IsAtivo = 1;
						";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.QueryFirstOrDefault<TEntity>(query, new { Codigo = codigo });
				}
			}
			catch (Exception ex) { throw ex; }
		}

		public virtual bool DeleteByCodigo(int codigo)
		{
			try
			{
				string nomeEntity = typeof(TEntity).Name;

				string query = $@"
						UPDATE 
							{nomeEntity}
						SET
							IsAtivo = 0
						WHERE
							Codigo = @Codigo
							AND IsAtivo = 1;
						";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.Execute(query, new { Codigo = codigo }) > 0;
				}
			}
			catch (Exception ex) { throw ex; }
		}

		public virtual bool Update(int codigo, TEntity entity)
		{
			try
			{
				string nomeEntity = typeof(TEntity).Name;

				List<string> listaPropriedades = ListarPropriedades();

				listaPropriedades.Remove("Codigo");
				listaPropriedades.Remove("IsAtivo");

				string strListaParesPropriedadeVariavel = string
					.Join(",", listaPropriedades.Select(propriedade => $"{propriedade} = @{propriedade}"));

				string query = $@"
						UPDATE 
							{nomeEntity}
						SET
							{strListaParesPropriedadeVariavel}
						WHERE
							Codigo = {codigo}
							AND IsAtivo = 1;
						";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.Execute(query, entity) > 0;
				}
			}
			catch (Exception ex) { throw ex; }
		}
	}
}
