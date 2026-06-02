namespace ContosoUniversity.Models
{
    public class GradeDetails
    {

        public string FName { get; set; }
        public string LName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public List<GradeDetails_CourseTitle> CourseTitles { get; set; } = new List<GradeDetails_CourseTitle>();

    }

   
}
