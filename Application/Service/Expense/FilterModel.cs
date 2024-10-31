using Application.Common.Models;

namespace Application.Service.Expense;

public class FilterModel
{
    public int[] ExpenseCategoryIdArr { get; set; }
    public DateTimeRangeModel? DateRange { get; set; }
}