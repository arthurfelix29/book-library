using Asp.Versioning;
using BookLibrary.Application.AutoMapper;
using BookLibrary.Infra.CrossCutting.IoC;
using BookLibrary.Infra.Data.Contexts;
using BookLibrary.Services.Api.Options;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Api.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
			=> InjectorBootStrapper.RegisterServices(services);

		public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
			=> services.AddDbContext<BookLibraryContext>(options => options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("BookLibraryDB")), ServiceLifetime.Singleton);

		public static IServiceCollection AddAutoMapper(this IServiceCollection services)
			=> services.AddAutoMapper(typeof(DomainToDtoMappingProfile), typeof(DtoToDomainMappingProfile));

		public static IServiceCollection AddVersioning(this IServiceCollection services)
		{
			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true;
			})
			.AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			return services;
		}

		public static IServiceCollection AddSwaggerVersioning(this IServiceCollection services)
		{
			services.AddSwaggerGen();
			services.ConfigureOptions<ConfigureSwaggerOptions>();

			return services;
		}
	}
}