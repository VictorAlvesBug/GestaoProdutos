using GestaoProdutos.Domain.Core.Interfaces.Repositories;
using GestaoProdutos.Domain.Core.Interfaces.Services;
using GestaoProdutos.Domain.Entities;

namespace GestaoProdutos.Domain.Services
{
	public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
	{
		private readonly IRepositoryProduto repositoryProduto;

		public ServiceProduto(IRepositoryProduto repositoryProduto)
			: base(repositoryProduto) 
		{
			this.repositoryProduto = repositoryProduto;	
		}
	}
}
