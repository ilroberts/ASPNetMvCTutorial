using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SpendSmart.Web.Models;

public class ExpenseViewModel
{
    public int Id { get; set; }
        
    [Required]
    [StringLength(100)]
    public string? Description { get; set; } = string.Empty;
        
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
    public decimal Amount { get; set; }
        
    [Required]
    public DateTime Date { get; set; }
        
    [Required]
    public ExpenseCategory Category { get; set; }

    // Property to hold the list of expense categories with descriptions
    public List<SelectListItem> ExpenseCategories { get; set; } = new();
}