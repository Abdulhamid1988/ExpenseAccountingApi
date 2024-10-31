using Application.Service.ExpenseCategory;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class ExpenseCategoryService : IExpenseCategoryService
{
    private readonly ApplicationDbContext _dbContext;

    public ExpenseCategoryService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(ExpenseCategoryModel model)
    {
        var entity = new ExpenseCategory()
        {
            Name = model.Name
        };
         _dbContext.ExpenseCategories.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateAsync(ExpenseCategoryModel model)
    {
        var entity = await _dbContext.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == model.Id);
        if(entity == null)
            throw new Exception("Entity not found");
        entity.Name = model.Name;
        _dbContext.ExpenseCategories.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null)
            throw new Exception("Entity not found");
        _dbContext.ExpenseCategories.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ExpenseCategoryModel> GetByIdAsync(int id)
    {
        var entity = await _dbContext.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null)
            throw new Exception("Entity not found");
        return new ExpenseCategoryModel()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public async Task<List<ExpenseCategoryModel>> GetAllAsync()
    {
        var query = _dbContext.ExpenseCategories.Select(x => new ExpenseCategoryModel()
        {
            Id = x.Id,
            Name = x.Name
        });
        var result = await query.ToListAsync();
        return result;
    }
}