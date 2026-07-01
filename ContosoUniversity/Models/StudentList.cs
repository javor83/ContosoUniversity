using ContosoUniversity.DatabaseFolder;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ContosoUniversity.Models
{
    public class StudentList(ContosoContext context) : IStudentList
    {

        //**************************************************************************
        GradeDetails IStudentList.Details(int id)
        {
            GradeDetails result = null;

            var query = context.Students.Where(x => x.Id == id)
                        .Include(enrollment => enrollment.Enrollments).
                            ThenInclude(cr => cr.Cource).First();
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
        IEnumerable<SItem> IStudentList.ReadStudents(VDSort sOrder)
        {
            IQueryable<Student> query = context.Students;

           

            if (sOrder.Filter != string.Empty)
            {
                query = query.Where
                    (
                        x => 
                        x.Fname.Contains(sOrder.Filter)
                        ||
                        x.Lastname.Contains(sOrder.Filter)
                    );
            }



            if (sOrder.Column == enum_ColumnStudent.ID)
            {
                switch (sOrder.Order)
                {
                    case enum_SortType.Asc:
                        query = query.OrderBy(x => x.Id);
                        break;
                    case enum_SortType.Desc:
                        query = query.OrderByDescending(x => x.Id);
                        break;
                }
            }
            else
                if (sOrder.Column == enum_ColumnStudent.FName)
                {
                    switch (sOrder.Order)
                    {
                        case enum_SortType.Asc:
                            query = query.OrderBy(x => x.Fname);
                            break;
                        case enum_SortType.Desc:
                            query = query.OrderByDescending(x => x.Fname);
                            break;
                    }
                }
                else
                    if (sOrder.Column == enum_ColumnStudent.LName)
                    {
                        switch (sOrder.Order)
                        {
                            case enum_SortType.Asc:
                                query = query.OrderBy(x => x.Lastname);
                                break;
                            case enum_SortType.Desc:
                                query = query.OrderByDescending(x => x.Lastname);
                                break;
                        }
                    }
                    else
                        if (sOrder.Column == enum_ColumnStudent.EDate)
                        {
                            switch (sOrder.Order)
                            {
                                case enum_SortType.Asc:
                                    query = query.OrderBy(x => x.Enrollmentdate);
                                    break;
                                case enum_SortType.Desc:
                                    query = query.OrderByDescending(x => x.Enrollmentdate);
                                    break;
                            }
                        }

            IEnumerable<SItem> result = query.Select(x => new SItem()
            {
                ID = x.Id,
                FName = x.Fname,
                LName = x.Lastname,
                EnrollmentDate = x.Enrollmentdate

            });

            return result;
        }

        //**************************************************************************


    }
}
