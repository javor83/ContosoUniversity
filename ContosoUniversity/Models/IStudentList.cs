using ContosoUniversity.DatabaseFolder;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public interface IStudentList
    {
        IEnumerable<SItem> ReadStudents(string sOrder);

        Task Insert(SItem item);

        Task Delete(int id);

        SItem Element(int id);

        Task Update(SItem item);

        GradeDetails Details(int id);

        string NextOrderType(string sOrder, string order_asc, string order_desc);

    }

}
