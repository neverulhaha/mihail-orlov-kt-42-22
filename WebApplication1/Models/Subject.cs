namespace WebApplication1.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Workload> Workloads { get; set; } = new List<Workload>();
    }
}
