using GestaoProdutos.Domain.Core.Interfaces.Repositories;
using GestaoProdutos.Domain.Entities;

namespace GestaoProdutos.Infrastructure.Data.Repositories
{
	public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
	{
	}
}
