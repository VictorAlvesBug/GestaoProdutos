using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProdutos.Domain.Core.Interfaces.Filters
{
	public interface IFilterBase<TEntity> where TEntity : class
	{
		public int Pagina { get; set; }
		public int QtdeItensPorPagina { get; set; }
	}
}
