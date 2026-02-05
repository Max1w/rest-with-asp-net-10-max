using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithASPNET10.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
				var connectionString = configuration[
					key: "MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];

				if (string.IsNullOrEmpty(connectionString))
					throw new ArgumentNullException(
						paramName: "MSSQLServerSQLConnectionString", 
						message: "Connection string for MSSQL Server is not configured.");
				
				try
				{
					using var evolveConnection = new SqlConnection(connectionString);
					var evolve = new Evolve(
						evolveConnection, 
						msg => Log.Information(msg)
					){
						Locations = new[] { "db/migrations", "db/dataset" },
						IsEraseDisabled = true
					};
					evolve.Migrate();
				}
				catch (Exception ex)
				{
					Log.Error(ex, "An error ocurred while migration the database.");
					throw;
				}
			}

            return services;
		}
    }
}
