using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class CourseContentModel()
{
    [Key]
    public int Id { get; set; }
    public string[] Strings { get; set; } = null!;
}
