using Application.Service.ExpenseCategory;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesAccount.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpenseCategoryController : ControllerBase
{
    readonly IExpenseCategoryService _expenseCategoryService;
    public ExpenseCategoryController(IExpenseCategoryService expenseCategoryService)
    {
        _expenseCategoryService = expenseCategoryService;
    }
    [HttpPost("create")]
    public async Task<ActionResult<int>> CreateAsync(ExpenseCategoryModel data)
    {
        var newExpenseCategory = await _expenseCategoryService.CreateAsync(data);
        return Ok(newExpenseCategory);
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(ExpenseCategoryModel data)
    {
        await _expenseCategoryService.UpdateAsync(data);
        return Ok();
    }
    [HttpGet("detail/{id}")]
    public async Task<ActionResult<ExpenseCategoryModel>> DetailAsync(int id)
    {
        return Ok(await _expenseCategoryService.GetByIdAsync(id));
    }
    [HttpGet("list")]
    public async Task<ActionResult<ExpenseCategoryModel>> ListAsync()
    {
        return Ok(await _expenseCategoryService.GetAllAsync());
    }
    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _expenseCategoryService.DeleteAsync(id);
        return Ok();
    }
}