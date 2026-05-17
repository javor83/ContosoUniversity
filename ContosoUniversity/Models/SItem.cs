using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ContosoUniversity.Models
{
    public class SItem
    {
        public int? ID { get; set; }


        [Required]
        public string? FName { get; set; }

        [Required]
        public string? LName { get; set; }

        [Required]
        public DateTime? EnrollmentDate { get; set; }

        public string? PrintDate()
        {
            return
                Convert.ToString(this.EnrollmentDate, new CultureInfo("bg-bg"));
                
        }


        public static SItem Empty()
        {
            return new SItem()
            {
                ID = 0,
                FName = "",
                LName = "",
                EnrollmentDate = DateTime.Today
            };
        }

    }
}
