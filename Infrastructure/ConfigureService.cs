using Application.Interfaces;
using Application.Service.Expense;
using Application.Service.ExpenseCategory;
using Infrastructure.Persistence;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureService
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<ApplicationDbContext>(options =>
    {
      options.UseNpgsql(connectionString: configuration.GetConnectionString("DefaultConnection"));
    });
    services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
    services.AddScoped<IExpenseService, ExpenseService>();
    services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
    return services;
  }
}