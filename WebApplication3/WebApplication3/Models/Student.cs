using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Student
    {
        [Key]
        public int std_id { get; set; }
        public string std_name { get; set; }
        public string std_email { get; set; }

    }
}
