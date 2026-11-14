using Microsoft.EntityFrameworkCore;
using ReadingDiary.Infrastructure.Data;

namespace ReadingDiary.Web.Configuration;

public static class DbContextFactoryConfiguration
{
    public static IServiceCollection AddDataBase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<ReadingDiaryDbContext>(
            options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Scoped);

        return services;
    }

    public static IApplicationBuilder UseDataBase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ReadingDiaryDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();

        return app;
    }
}
