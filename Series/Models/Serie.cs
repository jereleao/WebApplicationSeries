using System.ComponentModel.DataAnnotations;

namespace Series.Models
{
    public class Serie : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
