using System.ComponentModel.DataAnnotations;

namespace SIENN.DbAccess.Data
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
