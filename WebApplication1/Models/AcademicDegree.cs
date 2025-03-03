namespace WebApplication1.Models
{
    public class AcademicDegree
    {
        public int Id { get; set; }
        public string DegreeName { get; set; } = null!;
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
