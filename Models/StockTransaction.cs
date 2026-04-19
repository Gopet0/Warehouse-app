using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models
{
    public class StockTransaction
    {
        public int Id { get; set; }

        [Display(Name = "Product")]
        [Range(1, int.MaxValue, ErrorMessage = "Select a product.")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        

       
        [Display(Name = "Type")]
        public string Type { get; set; } // "stock_in" or "stock_out"

        [Range(1, 1_000_000, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Display(Name = "Supplier")]
        public int? SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public string Notes { get; set; } = string.Empty;

        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
