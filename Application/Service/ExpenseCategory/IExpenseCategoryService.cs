namespace Application.Service.ExpenseCategory;

public interface IExpenseCategoryService
{
    Task<int> CreateAsync(ExpenseCategoryModel model);
    Task UpdateAsync(ExpenseCategoryModel model);
    Task DeleteAsync(int id);
    Task<ExpenseCategoryModel> GetByIdAsync(int id);
    Task<List<ExpenseCategoryModel>> GetAllAsync();
}