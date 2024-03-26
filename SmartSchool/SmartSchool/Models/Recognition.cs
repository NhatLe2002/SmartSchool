using System;
using System.Collections.Generic;

namespace SmartSchool.Models;

public partial class Recognition
{
    public int RecognitionId { get; set; }

    public DateTime? DateTime { get; set; }

    public bool? Status { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
