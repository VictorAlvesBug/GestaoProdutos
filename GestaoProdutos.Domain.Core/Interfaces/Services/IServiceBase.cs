using GestaoProdutos.Domain.Core.Interfaces.Filters;
using System.Collections.Generic;

namespace GestaoProdutos.Domain.Core.Interfaces.Services
{
	public interface IServiceBase<TEntity> where TEntity : class
	{
		int? Add(TEntity entity);
		bool Update(int codigo, TEntity entity);
		bool DeleteByCodigo(int codigo);
		IEnumerable<TEntity> Filter(IFilterBase<TEntity> filter);
		int Count(IFilterBase<TEntity> filter);
		TEntity GetByCodigo(int codigo);
	}
}
