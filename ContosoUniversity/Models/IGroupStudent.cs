namespace ContosoUniversity.Models
{
    public interface IGroupStudent
    {
        IEnumerable<EnrollmentDateGroup> ReadStudents();
    }
}
