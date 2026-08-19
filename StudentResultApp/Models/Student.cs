using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentResultApp.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [Column("student_id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("enrollment_date")]
        public DateTime EnrollmentDate { get; set; }

        [Column("gpa")]
        public decimal GPA { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}".Trim();

        [NotMapped]
        public string StudentNumber => Id.ToString();

        [NotMapped]
        public string Module { get; set; } = string.Empty;

        [NotMapped]
        public double Mark { get; set; }

        [NotMapped]
        public string GetResult()
        {
            return Mark >= 50 ? "Pass" : "Fail";
        }
    }
}
