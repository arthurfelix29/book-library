using BookLibrary.Services.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
		   .SetBasePath(builder.Environment.ContentRootPath)
		   .AddJsonFile("appsettings.json", true, true)
		   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
		   .AddEnvironmentVariables();

builder.Services
		   .AddDependencyInjection()
		   .AddPersistence(builder.Configuration)
		   .AddAutoMapper()
		   .AddVersioning()
		   .AddSwaggerVersioning()
		   .AddEndpointsApiExplorer()
		   .AddSwaggerGen()
		   .AddControllers()
		   .AddJson();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app
	 .UseSwagger()
	 .UseSwaggerUI()
	 .UseDeveloperExceptionPage();
}

app
  .UseHttpsRedirection()
  .UseSwaggerWithVersioning()
  .UseAuthorization();

app.MapControllers();
app.Run();