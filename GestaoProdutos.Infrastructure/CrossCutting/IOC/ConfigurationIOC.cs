using Autofac;
using GestaoProdutos.Application;
using GestaoProdutos.Application.Interfaces;
using GestaoProdutos.Application.Interfaces.Mappers;
using GestaoProdutos.Application.Mappers;
using GestaoProdutos.Domain.Core.Interfaces.ConnectionFactories;
using GestaoProdutos.Domain.Core.Interfaces.Repositories;
using GestaoProdutos.Domain.Core.Interfaces.Services;
using GestaoProdutos.Domain.Services;
using GestaoProdutos.Infrastructure.Data.ConnectionFactories;
using GestaoProdutos.Infrastructure.Data.Repositories;

namespace GestaoProdutos.Infrastructure.CrossCutting.IOC
{
	public class ConfigurationIOC
	{
		public static void Load(ContainerBuilder builder)
		{
			#region IOC
			builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();

			builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>();

			builder.RegisterType<ServiceProduto>().As<IServiceProduto>();

			builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();

			builder.RegisterType<MapperProduto>().As<IMapperProduto>();

			builder.RegisterType<MapperFilterProduto>().As<IMapperFilterProduto>();
			#endregion
		}
	}
}
