using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProdutos.Domain.Filters
{
	public class FilterBase<TEntity> where TEntity : class
	{
		public int Pagina { get; set; }
		public int QtdeItensPorPagina { get; set; }
	}
}
