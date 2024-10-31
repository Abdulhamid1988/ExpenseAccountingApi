using Infrastructure.Persistence;

namespace ExpensesAccount;

public static class ConfigureServices
{
    public static IServiceCollection AddConfigureService(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ApplicationDbContextInitializer>();
        return services;
    }
}