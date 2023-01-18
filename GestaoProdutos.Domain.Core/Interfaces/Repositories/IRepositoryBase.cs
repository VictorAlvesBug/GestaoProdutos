﻿using System.Collections.Generic;

namespace GestaoProdutos.Domain.Core.Interfaces.Repositories
{
	public interface IRepositoryBase<TEntity> where TEntity : class
	{
		int? Add(TEntity entity);
		bool Update(int codigo, TEntity entity);
		bool DeleteByCodigo(int codigo);
		IEnumerable<TEntity> GetAll();
		TEntity GetByCodigo(int codigo);
	}
}
