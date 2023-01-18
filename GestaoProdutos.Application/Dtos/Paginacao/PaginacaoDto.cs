using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProdutos.Application.Dtos.Paginacao
{
	public class PaginacaoDto<TEntity> where TEntity : class
	{
		public int Pagina { get; set; }
		public int QtdeItensPorPagina { get; set; }
		public int QtdeTotalItens { get; set; }
		public int QtdePaginas
		{
			get
			{
				return Convert.ToInt32(Math.Ceiling(QtdeTotalItens / (double)QtdeItensPorPagina));
			}
		}
		public IEnumerable<TEntity> Lista { get; set; }
	}
}
