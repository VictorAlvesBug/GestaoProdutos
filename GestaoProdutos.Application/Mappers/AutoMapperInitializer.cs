using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoProdutos.Application.Mappers
{
	public static class AutoMapperInitializer
	{
		public static void Initialize(IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new ProdutoMap());
				mc.AddProfile(new FilterProdutoMap());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}
	}
}
