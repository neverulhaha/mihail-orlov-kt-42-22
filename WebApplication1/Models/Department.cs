using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime FoundationDate { get; set; }
        public int? HeadId { get; set; }

        [JsonIgnore]
        public Teacher? Head { get; set; }

        [JsonIgnore]
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
