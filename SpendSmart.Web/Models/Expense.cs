using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Web.Models
{
  public class Expense
  {
    public int Id { get; set; }
    [Required]
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
  }
}
