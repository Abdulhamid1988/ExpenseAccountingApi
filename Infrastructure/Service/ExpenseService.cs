using Application.Service.Expense;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Service;

public class ExpenseService : IExpenseService
{
    private readonly ApplicationDbContext _dbContext;
    public ExpenseService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(ExpenseCreateUpdateModel model)
    {
        var entity = new Expense
        {
            Description = model.Description,
            Cost = model.Cost,
            ExpenseDate = model.ExpenseDate,
            ExpenseCategoryId = model.ExpenseCategoryId
        };
        _dbContext.Expenses.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateAsync(ExpenseCreateUpdateModel model)
    {
        var entity = await _dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == model.Id);
        if (entity == null)
            throw new Exception("Entity not found");
        entity.Description = model.Description;
        entity.Cost = model.Cost;
        entity.ExpenseDate = model.ExpenseDate;
        entity.ExpenseCategoryId = model.ExpenseCategoryId;
        _dbContext.Expenses.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            throw new Exception("Entity not found");
        _dbContext.Expenses.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ExpenseRowModel> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            throw new Exception("Entity not found");
        return new ExpenseRowModel()
        {
            Id = entity.Id,
            Description = entity.Description,
            Cost = entity.Cost,
            ExpenseDate = entity.ExpenseDate,
            ExpenseCategoryId = entity.ExpenseCategoryId,
            ExpenseCategoryName = entity.ExpenseCategory.Name
        };
    }

    public async Task<List<ExpenseRowModel>> GetAllAsync(FilterModel filterModel)
    {
        var query =  _dbContext.Expenses.Where(x=> 
            (filterModel.ExpenseCategoryIdArr == null 
             || !filterModel.ExpenseCategoryIdArr.Any() 
             || filterModel.ExpenseCategoryIdArr.Contains(x.ExpenseCategoryId))
             && (filterModel.DateRange == null || (filterModel.DateRange.From == null || filterModel.DateRange.From <= x.ExpenseDate) 
             && (filterModel.DateRange.To == null || filterModel.DateRange.To >= x.ExpenseDate)))
            .Select(x => new ExpenseRowModel
        {
            Id = x.Id,
            Description = x.Description,
            Cost = x.Cost,
            ExpenseDate = x.ExpenseDate,
            ExpenseCategoryId = x.ExpenseCategoryId,
            ExpenseCategoryName = x.ExpenseCategory.Name
        });
        var result = await query.ToListAsync();
        return result;
    }
}