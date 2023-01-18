using Dapper;
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
		private List<string> ListarPropriedades()
		{
			return typeof(TEntity).GetProperties()
				.Select(propriedade => propriedade.Name)
				.ToList();
		}

		public int? Add(TEntity entity)
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

		public IEnumerable<TEntity> GetAll()
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
							IsAtivo = 1;
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

		public TEntity GetByCodigo(int codigo)
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
							Codigo = @Codigo;
						";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.QueryFirstOrDefault<TEntity>(query, new { Codigo = codigo });
				}
			}
			catch (Exception ex) { throw ex; }
		}

		public bool DeleteByCodigo(int codigo)
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
							Codigo = @Codigo;
						";

				using (var connection = ConnectionFactory.Conexao("master"))
				{
					return connection.Execute(query, new { Codigo = codigo }) > 0;
				}
			}
			catch (Exception ex) { throw ex; }
		}

		public bool Update(int codigo, TEntity entity)
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
							Codigo = {codigo};
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
