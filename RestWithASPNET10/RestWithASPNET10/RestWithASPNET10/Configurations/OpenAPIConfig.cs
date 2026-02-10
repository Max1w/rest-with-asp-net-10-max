using Microsoft.OpenApi;

namespace RestWithASPNET10.Configurations
{
    public static class OpenAPIConfig
    {
        private static readonly string _appName = "ASP.NET 2026 API's from 0 to Azure and GCP with .Net 10, Docker and Kubernetes";
        private static readonly string _appDescription = $"API RESTful developed in course {_appName}";

        public static IServiceCollection AddOpenAPI(
            this IServiceCollection services)
        {
            services.AddSingleton(new OpenApiInfo
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
            return services;
		}
	}
}
