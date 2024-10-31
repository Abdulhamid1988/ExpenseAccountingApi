namespace Application.Service.Expense;

public interface IExpenseService
{
    Task<int> CreateAsync(ExpenseCreateUpdateModel model);
    Task UpdateAsync(ExpenseCreateUpdateModel model);
    Task DeleteAsync(int id);
    Task<ExpenseRowModel> GetByIdAsync(int id);
    Task<List<ExpenseRowModel>> GetAllAsync(FilterModel filterModel);
}