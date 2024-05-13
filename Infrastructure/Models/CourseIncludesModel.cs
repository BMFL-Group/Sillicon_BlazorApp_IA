using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class CourseIncludesModel()
{
    [Key]
    public int Id { get; set; }
    public int CourseId { get; set; }
    public virtual CourseModel Course { get; set; } = new();
    public string FaCode { get; set; } = null!;
    public string Description { get; set; } = null!;
}
