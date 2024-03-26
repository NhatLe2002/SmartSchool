using System;
using System.Collections.Generic;

namespace SmartSchool.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Image { get; set; }

    public int? ParentId { get; set; }

    public virtual Parent? Parent { get; set; }

    public virtual ICollection<Recognition> Recognitions { get; set; } = new List<Recognition>();
}
