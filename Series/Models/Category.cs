using System.ComponentModel.DataAnnotations;

namespace Series.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
