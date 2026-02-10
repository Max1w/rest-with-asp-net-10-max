using Microsoft.OpenApi;

namespace RestWithASPNET10.Configurations
{
	public static class SwaggerConfig
	{
		private static readonly string _appName = "ASP.NET 2026 API's from 0 to Azure and GCP with .Net 10, Docker and Kubernetes";
		private static readonly string _appDescription = $"API RESTful developed in course {_appName}";

		public static IServiceCollection AddSwagger(
			this IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = _appName,
					Version = "v1",
					Description = _appDescription,
					Contact = new OpenApiContact
					{
						Name = "Ernandes Jr",
						Url = new Uri("https://github.com/Max1w/rest-with-asp-net-10-max")
					}
				});

				options.CustomSchemaIds(static x => x.FullName);
			});
			return services;
		}

		public static IApplicationBuilder UseSwaggerSpecification(
			this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
				options.RoutePrefix = "swagger-ui";
				options.DocumentTitle = _appName;
			});;
			return app;
		}
	}
}
