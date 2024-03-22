using Asp.Versioning.ApiExplorer;

namespace BookLibrary.Services.Api.Extensions
{
	public static class AppBuilderExtensions
	{
		public static IApplicationBuilder UseSwaggerWithVersioning(this IApplicationBuilder app)
		{
			var services = app.ApplicationServices;
			var provider = services.GetRequiredService<IApiVersionDescriptionProvider>();

			app.UseSwagger();

			app.UseSwaggerUI(options =>
			{
				foreach (var description in provider.ApiVersionDescriptions)
					options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
			});

			return app;
		}
	}
}