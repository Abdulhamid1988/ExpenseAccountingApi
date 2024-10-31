using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Expense> Expenses { get; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; }
}