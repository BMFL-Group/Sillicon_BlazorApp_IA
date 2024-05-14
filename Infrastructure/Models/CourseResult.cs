namespace Infrastructure.Models;

public class CourseResult
{
    public Pagination Pagination { get; set; } = new();

    public IEnumerable<CourseModel> ReturnCourses { get; set; } = [];

    public CategoryModel Category { get; set; } = new();
}
