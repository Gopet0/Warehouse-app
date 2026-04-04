using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models
{
    public class StockTransaction
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; } // "stock_in" or "stock_out"

        [Required]
        public int Quantity { get; set; }

        [Display(Name = "Supplier")]
        public int? SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
