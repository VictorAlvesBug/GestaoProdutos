using Autofac;

namespace GestaoProdutos.Infrastructure.CrossCutting.IOC
{
	public class ModuleIOC : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			ConfigurationIOC.Load(builder);
		}
	}
}
