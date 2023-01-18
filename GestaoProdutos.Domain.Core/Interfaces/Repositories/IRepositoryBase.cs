using System.Collections.Generic;

namespace GestaoProdutos.Domain.Core.Interfaces.Repositories
{
	public interface IRepositoryBase<TEntity> where TEntity : class
	{
		bool Add(TEntity entity);
		bool Update(TEntity entity);
		bool DeleteByCodigo(int codigo);
		IEnumerable<TEntity> GetAll();
		TEntity GetByCodigo(int codigo);
	}
}
