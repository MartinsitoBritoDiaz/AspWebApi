using System.ComponentModel.DataAnnotations;

namespace Web_API.Modals
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
