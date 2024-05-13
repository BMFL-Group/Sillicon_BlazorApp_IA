using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class ProgramDetailsModel()
{
    [Key]
    public int Íd { get; set; }
    public int CourseId { get; set; }
    public virtual CourseModel Course { get; set; } = new();
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}
