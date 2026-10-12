using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RetailFlow.Models;
public class Product
{
    public int Id { get; set; }
    [Required, StringLength(100)] [Display(Name = "Product name")]
    public string Name { get; set; } = string.Empty;
    [Required, StringLength(60)] public string Category { get; set; } = string.Empty;
    [Range(0, 1000000)] public int Quantity { get; set; }
    [Range(typeof(decimal), "0.01", "99999999")] [Column(TypeName = "decimal(18,2)")] [Display(Name = "Unit price")]
    public decimal UnitPrice { get; set; }
    [StringLength(500)] public string? Description { get; set; }
    [Display(Name = "Last updated")] public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    [NotMapped] [Display(Name = "Stock value")] public decimal StockValue => Quantity * UnitPrice;
}
