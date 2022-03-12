namespace EShop.Infrastructure.Extensions
{
    using Data;
    using Data.Seeder;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<ApplicationDbContext>();

            dbContext?.Database.Migrate();

            var seeder = new Seeder(dbContext);
            seeder.Seed();

            return app;
        }
    }
}
