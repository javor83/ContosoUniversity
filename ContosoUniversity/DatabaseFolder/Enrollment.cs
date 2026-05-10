using System;
using System.Collections.Generic;

namespace ContosoUniversity.DatabaseFolder;

public partial class Enrollment
{
    public int Id { get; set; }

    public int? Studentid { get; set; }

    public int? Courceid { get; set; }

    public int Grade { get; set; }

    public virtual Cource? Cource { get; set; }

    public virtual Student? Student { get; set; }
}
