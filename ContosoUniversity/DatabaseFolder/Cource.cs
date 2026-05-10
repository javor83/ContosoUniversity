using System;
using System.Collections.Generic;

namespace ContosoUniversity.DatabaseFolder;

public partial class Cource
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Credits { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
