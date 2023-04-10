using System.Collections.Generic;
using System.Reflection;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Module> Modules { get; set; }
}
