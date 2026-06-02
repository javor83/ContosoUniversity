using ContosoUniversity.DatabaseFolder;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Models
{
    public class StudentList(ContosoContext context) : IStudentList
    {

        //**************************************************************************
        GradeDetails IStudentList.Details(int id)
        {
            GradeDetails result = null;

            var query = context.Students
                        .Include(enrollment => enrollment.Enrollments).
                            ThenInclude(cr => cr.Cource).Where(x => x.Id == id).First();
            if (query != null)
            {
                result = new GradeDetails()
                {
                    FName = query.Fname,
                    LName = query.Lastname,
                    EnrollmentDate = query.Enrollmentdate
                };
                foreach (var x in query.Enrollments)
                {
                    result.CourseTitles.Add
                        (
                            new GradeDetails_CourseTitle()
                            {

                                CourseTitle = x.Cource.Title,
                                GradeValue = (enum_Grades)x.Grade
                            }
                        );
                    
                }
            }


            return result;
        }

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
