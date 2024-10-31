using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal static class DefaultExpenseCategory
{
    public static void DefaultExpenseCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseCategory>().HasData(
            new ExpenseCategory
            {
                Id = 1,
                Name = "Oziq-ovqat",
            },
            new ExpenseCategory
            {
                Id = 2,
                Name = "Transport",
            },
            new ExpenseCategory
            {
                Id = 3,
                Name = "Mobil aloqa",
            },
            new ExpenseCategory
            {
                Id = 4,
                Name = "Internet",
            },
            new ExpenseCategory
            {
                Id = 5,
                Name = "O'yin-kulgi",
            });
        modelBuilder.Entity<Expense>().HasData(
            new Expense
            {
                Id = 1,
                Description = "Fast food sotib olishga",
                Cost = 10000,
                ExpenseDate = DateTime.Now.ToUniversalTime(),
                ExpenseCategoryId = 1
            },
            new Expense
            {
                Id = 2,
                Description = "Metroda chipta sotib olish",
                Cost = 5000,
                ExpenseDate = DateTime.Now.ToUniversalTime(),
                ExpenseCategoryId = 2
            }, 
            new Expense
            {
                Id = 3,
                Description = "Telegram uchun to'lov",
                Cost = 1000,
                ExpenseDate = DateTime.Now.ToUniversalTime(),
                ExpenseCategoryId = 3
            },
            new Expense
            {
                Id = 4,
                Description = "PUBG o'ynash uchun",
                Cost = 2000,
                ExpenseDate = DateTime.Now.ToUniversalTime(),
                ExpenseCategoryId = 4
            },
            new Expense
            {
                Id = 5,
                Description = "Konsertga bilet sotib olish",
                Cost = 1000,
                ExpenseDate = DateTime.Now.ToUniversalTime(),
                ExpenseCategoryId = 5
            });
    }
}