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
        string IStudentList.NextOrderType(string sOrder, string order_asc, string order_desc)
        {
            string result = string.Empty;

            if (sOrder == string.Empty)
            {
                result = order_asc;
            }
            else

                if (sOrder.Equals(order_asc, StringComparison.OrdinalIgnoreCase))
                {
                    result = order_desc;

                }
                else
                    if (sOrder.Equals(order_desc, StringComparison.OrdinalIgnoreCase))
                    {
                        result = order_asc;

                    }

            return result;
        }

        //**************************************************************************
        IEnumerable<SItem> IStudentList.ReadStudents(string sOrder)
        {
            var query = context.Students.Select(x => new SItem()
            {
                ID = x.Id,
                FName = x.Fname,
                LName = x.Lastname,
                EnrollmentDate = x.Enrollmentdate

            });


            var result_fname = (this as IStudentList).NextOrderType(sOrder, enum_SortStudentOrder.fname_asc, enum_SortStudentOrder.fname_desc);
            var result_lname = (this as IStudentList).NextOrderType(sOrder, enum_SortStudentOrder.lname_asc, enum_SortStudentOrder.lname_desc);
            var result_edate = (this as IStudentList).NextOrderType(sOrder, enum_SortStudentOrder.edate_asc, enum_SortStudentOrder.edate_desc);
            var result_id = (this as IStudentList).NextOrderType(sOrder, enum_SortStudentOrder.id_asc, enum_SortStudentOrder.id_desc);
            if (result_fname!=string.Empty)
            {
                switch (result_fname)
                {
                    case enum_SortStudentOrder.fname_asc:
                        query = query.OrderBy(x => x.FName);
                        break;
                    case enum_SortStudentOrder.fname_desc:
                        query = query.OrderByDescending(x => x.FName);
                        break;
                }
            }
            else
                if (result_lname!= string.Empty)
                {
                    switch (result_lname)
                    {
                        case enum_SortStudentOrder.lname_asc:
                            query = query.OrderBy(x => x.LName);
                            break;
                        case enum_SortStudentOrder.lname_desc:
                            query = query.OrderByDescending(x => x.LName);
                            break;
                    }

                }
                else
                    if (result_edate != string.Empty)
                    {
                        switch (result_edate)
                        {
                            case enum_SortStudentOrder.edate_asc:
                                query = query.OrderBy(x => x.EnrollmentDate);
                                break;
                            case enum_SortStudentOrder.edate_desc:
                                query = query.OrderByDescending(x => x.EnrollmentDate);
                                break;
                        }
                    }
                    else
                        if (result_id != string.Empty)
                        {
                            switch (result_id)
                            {
                                case enum_SortStudentOrder.id_asc:
                                    query = query.OrderBy(x => x.ID);
                                    break;
                                case enum_SortStudentOrder.id_desc:
                                    query = query.OrderByDescending(x => x.ID);
                                    break;
                            }
                        }



            return query;
        }

        //**************************************************************************


    }
}
