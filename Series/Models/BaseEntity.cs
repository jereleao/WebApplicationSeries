namespace Series.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}