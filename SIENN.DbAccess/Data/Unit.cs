using System;
using System.ComponentModel.DataAnnotations;

namespace SIENN.DbAccess.Data
{
    public class Unit
    {
        [Key]
        public int TypeId { get; set; }
        [Required]
        [MaxLength(100)]

      //  [Index(IsUnique = true)]  
      //TODO add somehow Constraint
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
