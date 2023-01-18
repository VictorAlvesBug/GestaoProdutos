using System.Collections.Generic;

namespace GestaoProdutos.Domain.Core.Interfaces.Services
{
	public interface IServiceBase<TEntity> where TEntity : class
	{
		bool Add(TEntity entity);
		bool Update(TEntity entity);
		bool DeleteByCodigo(int codigo);
		IEnumerable<TEntity> GetAll();
		TEntity GetByCodigo(int codigo);
	}
}
