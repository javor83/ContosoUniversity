using ContosoUniversity.DatabaseFolder;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public interface IStudentList
    {
        IEnumerable<SItem> ReadStudents();

        Task Insert(SItem item);

    }

}
