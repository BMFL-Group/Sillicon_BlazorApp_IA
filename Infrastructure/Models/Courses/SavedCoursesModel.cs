namespace Infrastructure.Models.Courses;

public class SavedCoursesModel
{
    public int? Id { get; set; }
    public string CourseId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public bool HasJoined { get; set; }
    public bool IsBookmarked { get; set; }
}
