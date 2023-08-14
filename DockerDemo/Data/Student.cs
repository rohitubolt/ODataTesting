using System.ComponentModel.DataAnnotations;

namespace DockerDemo.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? FatherName { get; set; }
        [StringLength(50)]
        public string? MotherName { get; set; }
        public int? Age { get; set; }
    }
    public class UserViewModel
    {
        public string? FullName { get; set; }
      
        public string? MotherName { get; set; }
        public int? Age { get; set; }
    }
}
