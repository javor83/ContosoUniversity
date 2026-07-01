namespace ContosoUniversity.Models
{
    public class EnrollmentDateGroup
    {
        public string Letter { get; set; }

        public IEnumerable<SItem> Students { get; set; }


    }
}
