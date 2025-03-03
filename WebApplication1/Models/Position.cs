namespace WebApplication1.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string PositionName { get; set; } = null!;
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
