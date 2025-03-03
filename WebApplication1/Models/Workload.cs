namespace WebApplication1.Models
{
    public class Workload
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public int Hours { get; set; }
    }
}
