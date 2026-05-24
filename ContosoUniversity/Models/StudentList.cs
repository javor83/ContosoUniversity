using ContosoUniversity.DatabaseFolder;

namespace ContosoUniversity.Models
{
    public class StudentList(ContosoContext context) : IStudentList
    {
        //**************************************************************************
        SItem IStudentList.Element(int id)
        {
            SItem result = null;

            var q = context.Students.Where(x => x.Id == id).First();
            if (q != null)
            {
                result = new SItem()
                {
                    EnrollmentDate = q.Enrollmentdate,
                    FName = q.Fname,
                    LName = q.Lastname,
                    ID = q.Id
                };
            }


            return result;
        }

        //**************************************************************************
        async Task IStudentList.Update(SItem item)
        {
            var q = context.Students.Where(x => x.Id ==item.ID).First();
            if (q != null)
            {
                q.Fname = item.FName;
                q.Lastname = item.LName;
                q.Enrollmentdate = item.EnrollmentDate.Value;

                await context.SaveChangesAsync();
                    

            }

        }


        //**************************************************************************
        async Task IStudentList.Delete(int id)
        {
            var q = context.Students.Where(x => x.Id == id).First();
            if (q != null)
            {
                context.Students.Remove(q);
                await context.SaveChangesAsync();
            }
        }


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
