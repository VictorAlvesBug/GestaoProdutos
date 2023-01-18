﻿using GestaoProdutos.Domain.Core.Interfaces.Repositories;
using GestaoProdutos.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace GestaoProdutos.Domain.Services
{
	public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
	{
		private readonly IRepositoryBase<TEntity> repository;

		public ServiceBase(IRepositoryBase<TEntity> repository)
		{
			this.repository = repository;
		}

		public bool Add(TEntity entity)
		{
			return repository.Add(entity);
		}

		public bool DeleteByCodigo(int codigo)
		{
			return repository.DeleteByCodigo(codigo);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return repository.GetAll();
		}

		public TEntity GetByCodigo(int codigo)
		{
			return repository.GetByCodigo(codigo);
		}

		public bool Update(TEntity entity)
		{
			return repository.Update(entity);
		}
	}
}