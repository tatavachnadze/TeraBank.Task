using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TeraBank.Task.API.Configuration
{
    public static class DependencyConfiguration
    {
        public static void ConfigureDependency(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IIndividualService, IndividualService>();
            //builder.Services.AddScoped<ICityService, CityService>();

            builder.Services.AddDbContext<BankDbContext>(options => options.UseSqlServer(connectionString));
        }

    }
}
