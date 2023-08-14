using System.ComponentModel.DataAnnotations;

namespace DockerDemo.Data
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        [StringLength(100)]
        public string? SchoolName { get; set;}
        [StringLength(250)]
        public string? Address { get; set;}
        [StringLength(15)]
        public string? ContactNo { get; set;}
    }
}
