using Microsoft.EntityFrameworkCore;
using SpendSmart.Web.Models;

namespace SpendSmart.Web.Persistence
{
  public class ExpensesDbContext : DbContext
  {
    public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options)
    {
    }
    public DbSet<Expense> Expenses { get; set; }
  }
}
