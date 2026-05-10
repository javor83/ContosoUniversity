using System;
using System.Collections.Generic;

namespace ContosoUniversity.DatabaseFolder;

public partial class Student
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime Enrollmentdate { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
