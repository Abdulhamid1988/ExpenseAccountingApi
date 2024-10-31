using Application.Service.Expense;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesAccount.Controllers;

public class ExpenseController : ControllerBase
{
    readonly IExpenseService _expenseService;
    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }
    [HttpPost("create")]
    public async Task<ActionResult<int>> CreateAsync(ExpenseCreateUpdateModel data)
    {
        var newExpense = await _expenseService.CreateAsync(data);
        return Ok(newExpense);
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(ExpenseCreateUpdateModel data)
    {
        await _expenseService.UpdateAsync(data);
        return Ok();
    }
    [HttpGet("detail/{id}")]
    public async Task<ActionResult<ExpenseRowModel>> DetailAsync(int id)
    {
        return Ok(await _expenseService.GetByIdAsync(id));
    }
    [HttpGet("list")]
    public async Task<ActionResult<ExpenseRowModel>> GetListAsync(FilterModel filterModel)
    {
        return Ok(await _expenseService.GetAllAsync(filterModel));
    }
    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _expenseService.DeleteAsync(id);
        return Ok();
    }
}