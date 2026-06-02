using ContosoUniversity.DatabaseFolder;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public interface IStudentList
    {
        IEnumerable<SItem> ReadStudents();

        Task Insert(SItem item);

        Task Delete(int id);

        SItem Element(int id);

        Task Update(SItem item);

        GradeDetails Details(int id);

    }

}
