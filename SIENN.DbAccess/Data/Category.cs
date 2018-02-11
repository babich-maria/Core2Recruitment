using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIENN.DbAccess.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<ProductCategory> ProductCategory { get; } = new List<ProductCategory>();

    }
}
