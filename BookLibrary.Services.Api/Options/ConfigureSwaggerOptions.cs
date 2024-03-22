using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BookLibrary.Services.Api.Options
{
	public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider _provider;

		public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

		public void Configure(SwaggerGenOptions options)
		{
			foreach (var description in _provider.ApiVersionDescriptions)
			{
				options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
				options.EnableAnnotations();
			}
		}

		public void Configure(string name, SwaggerGenOptions options) => Configure(options);

		private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
		{
			var info = new OpenApiInfo
			{
				Version = description.ApiVersion.ToString(),
				Title = "Book Library",
				Description = "Book Library Management",
				Contact = new OpenApiContact
				{
					Name = "Arthur Félix",
					Email = "thursilva@hotmail.com",
					Url = new Uri("https://www.linkedin.com/in/arthurfelix")
				}
			};

			if (description.IsDeprecated)
				info.Description += " This API version is deprecated.";

			return info;
		}
	}
}