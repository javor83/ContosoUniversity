using ContosoUniversity.DatabaseFolder;

namespace ContosoUniversity.Models
{
    public class StudentList(ContosoContext context) : IStudentList
    {

        //**************************************************************************

        async Task IStudentList.Insert(SItem item)
        {
            context.Students.Add
                 (
                     new Student()
                     {
                         Enrollmentdate = item.EnrollmentDate.Value,
                         Fname = item.FName,
                         Lastname = item.LName
                     }
                 );
            await context.SaveChangesAsync();
        }

        //**************************************************************************
        IEnumerable <SItem> IStudentList.ReadStudents()
        {
            return context.Students.Select(x => new SItem()
            {
                ID = x.Id,
                FName = x.Fname,
                LName = x.Lastname,
                EnrollmentDate = x.Enrollmentdate

            }).OrderBy(x => x.FName).ThenBy(x => x.LName);
        }

        //**************************************************************************


    }
}
