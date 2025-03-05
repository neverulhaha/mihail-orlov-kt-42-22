namespace WebApplication1.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? DegreeId { get; set; }
        public AcademicDegree? Degree { get; set; }
        public int? PositionId { get; set; }
        public Position? Position { get; set; }
        public ICollection<Workload> Workloads { get; set; } = new List<Workload>();
    }
}
