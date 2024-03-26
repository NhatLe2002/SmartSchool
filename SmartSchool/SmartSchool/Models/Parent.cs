using System;
using System.Collections.Generic;

namespace SmartSchool.Models;

public partial class Parent
{
    public int ParentId { get; set; }

    public string? ParentName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Zalo { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
