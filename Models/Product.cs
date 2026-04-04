using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public string Category { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Min Quantity")]
        public int MinQuantity { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Warehouse Location")]
        public string WarehouseLocation { get; set; }

        public string Description { get; set; }
    }
}
