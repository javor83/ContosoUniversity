using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class IStudentList
    {


    }

    public class StudentItem
    {
        public int? ID { get; set; }


        [Required]
        public string? FName { get; set; }

        [Required]
        public string? LName { get; set; }

        [Required]
        public DateTime? EnrollmentDate { get; set; }

        public string PrintDate()
        {
            return this.EnrollmentDate.ToString("dd.MMM.yyyy");
        }

    }

}
