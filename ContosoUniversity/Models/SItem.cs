using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ContosoUniversity.Models
{
    public class SItem
    {
        public int? ID { get; set; }
        //**********************************************************************

        /*
         *    public const string StundentsFName = "Име";
        public const string  = "Фамилия";
        public const string StundentsEDate = "Стартова дата";
         */
        [Required(AllowEmptyStrings =false,ErrorMessage =captions.ReqField)]
        [Display(Name =captions.StundentsFName)]
        public string? FName { get; set; }
        //**********************************************************************

       
        [Required(AllowEmptyStrings = false, ErrorMessage = captions.ReqField)]
        [Display(Name = captions.StundentsLName)]
        public string? LName { get; set; }
        //**********************************************************************

        [Required(AllowEmptyStrings = false, ErrorMessage = captions.ReqField)]
        [Display(Name = captions.StundentsEDate)]
        public DateTime? EnrollmentDate { get; set; }
        //**********************************************************************

        public string? PrintDate()
        {
            return
                Convert.ToString(this.EnrollmentDate, new CultureInfo("bg-bg"));
                
        }
        //**********************************************************************

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
        //**********************************************************************
    }
}
