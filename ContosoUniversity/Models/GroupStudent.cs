using ContosoUniversity.DatabaseFolder;

namespace ContosoUniversity.Models
{
    public class GroupStudent(ContosoContext context) : IGroupStudent
    {



        IEnumerable<EnrollmentDateGroup> IGroupStudent.ReadStudents()
        {
            var query = from x in context.Students
                        group x by x.Lastname.Substring(0, 1).ToUpper() into gr_list
                        orderby gr_list.Key
                        select new EnrollmentDateGroup()
                        {
                            Letter = gr_list.Key,
                            Students = gr_list.Select
                            (
                                s =>
                                new SItem()
                                {
                                    EnrollmentDate = s.Enrollmentdate,
                                    ID = s.Id,
                                    FName = s.Fname,
                                    LName = s.Lastname
                                }
                            )
                        };
            return query;
        }
    }
}
