using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Models.Context;

namespace RestWithASPNET10.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(
            this IServiceCollection services, 
            IConfiguration configuration
        )
        {
            var connectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
            
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("MSSQLServerSQLConnectionString", "Connection string for MSSQL Server is not configured.");
			
            services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
		}
	}
}
