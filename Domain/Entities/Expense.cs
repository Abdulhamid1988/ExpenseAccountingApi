namespace Domain.Entities;

public class Expense : BaseEntity
{
    public string Description { get; set; }
    public int ExpenseCategoryId { get; set; }
    public decimal Cost { get; set; }
    public DateTime ExpenseDate { get; set; }
    public ExpenseCategory ExpenseCategory { get; set; }
    
}