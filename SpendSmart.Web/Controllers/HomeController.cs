using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpendSmart.Web.Models;
using SpendSmart.Web.Persistence;

namespace SpendSmart.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ExpensesDbContext _context;

    public HomeController(ILogger<HomeController> logger, ExpensesDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Expenses()
    {
        var allExpenses = _context.Expenses.ToList();

        var totalExpenses = allExpenses.Sum(e => e.Amount);
        ViewBag.Expenses = totalExpenses;

        return View(allExpenses);
    }


    public IActionResult CreateEditExpense(int? id)
    {
        if (id != null)
        {
            var expense = _context.Expenses.SingleOrDefault(e => e.Id == id);
            return View(expense);
        }
        return View();
    }

    public IActionResult DeleteExpenseItem(int id)
    {
        var expense = _context.Expenses.SingleOrDefault(e => e.Id == id);
        _context.Expenses.Remove(expense);
        _context.SaveChanges();
        return RedirectToAction("Expenses");
    }

    public IActionResult CreateEditExpenseForm(ExpenseViewModel model)
    {

        if (model.Id != 0)
        {
            var expense = _context.Expenses.SingleOrDefault(e => e.Id == model.Id);
            expense.Description = model.Description;
            expense.Amount = model.Amount;
            expense.Date = model.Date;
            expense.Category = model.Category;
            _context.Expenses.Update(expense);
        }
        else
        {
            var expense = new Expense
            {
                Description = model.Description,
                Amount = model.Amount,
                Date = model.Date,
                Category = model.Category
            };
            _context.Expenses.Add(expense);
        }
        _context.SaveChanges();
        return RedirectToAction("Expenses");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
