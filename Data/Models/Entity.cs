namespace WebApplication7.Data.Models
{
    public abstract class Entity
    {
        public required int Id { get; set; }
        public required DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
