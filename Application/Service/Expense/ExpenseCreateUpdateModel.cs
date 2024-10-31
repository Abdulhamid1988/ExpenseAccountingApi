namespace Application.Service.Expense;

public class ExpenseCreateUpdateModel
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public DateTime ExpenseDate { get; set; }
    public int ExpenseCategoryId { get; set; }
}