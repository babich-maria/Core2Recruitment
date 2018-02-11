using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIENN.DbAccess.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
      
        public bool IsAvailable { get; set; }
        public DateTime DeliveryDate { get; set; }

        public ICollection<ProductCategory> ProductCategory { get; set; }  = new List<ProductCategory>();

        [Required]
        public Type Type { get; set; }
        [Required]
        public Unit Unit { get; set; }

    }
}
