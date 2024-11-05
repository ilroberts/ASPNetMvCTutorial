using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Web.Models
{
  
  public enum ExpenseCategory
  {
    [Description("Sustenance")]
    Food = 1,
    [Description("Accommodation")]
    Rent = 2,
    [Description("Utilities")]
    Utilities = 3,
    [Description("Travel")]
    Transportation = 4,
    [Description("Entertainment")]
    Entertainment = 5,
    [Description("Miscellaneous")]
    Other = 0
  }
  
  public class Expense
  {
    public int Id { get; set; }
    [Required] 
    [StringLength(100)]
    public string? Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    
    [Required]
    public ExpenseCategory Category { get; set; }
  }
}
