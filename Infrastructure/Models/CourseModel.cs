using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;
public class Course
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Ingress { get; set; } = null!;
    public string ImageUri { get; set; } = null!;
    public string AltText { get; set; } = null!;
    public bool BestSeller { get; set; } = false;
    public bool IsDigital { get; set; } = true;
    public string[]? Categories { get; set; }
    public string Currency { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public string LengthInHours { get; set; } = null!;
    public int RatingInPercentage { get; set; }
    public int NumberOfReviews { get; set; }
    public int NumberOfLikes { get; set; }
    public virtual List<Author>? Authors { get; set; }
    public virtual Content? Content { get; set; }
    public virtual ProgramDetails? ProgramDetails { get; set; }
}

public class Author
{
    public string Name { get; set; } = null!;
}

public class Content
{
    public string? Description { get; set; }
    public string[]? Courseincludes { get; set; }
    public virtual List<ProgramDetails>? ProgramDetails { get; set; }
}

public class ProgramDetails
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string[]? Description { get; set; }
}

public class Data
{
    public CourseResult? GetCourses { get; set; } = new();

    public Course? GetCourseById { get; set; } = new();
}

public class GraphQLResponse
{
    public Data Data { get; set; } = new();
}

public class CourseModel
{
    [Key]
    [Required]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Author { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Required]
    public string AltText { get; set; } = null!;

    public bool BestSeller { get; set; } = false;

    [Required]
    public string Currency { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    [Required]
    public string LengthInHours { get; set; } = null!;

    public int Rating { get; set; } = 0;

    public int NumberOfReviews { get; set; } = 0;

    public int NumberOfLikes { get; set; } = 0;

    public int? CategoryId { get; set; }

    public CategoryModel Category { get; set; } = new();

    public string CourseDescription { get; set; } = null!;

    public int CourseContentId { get; set; }
    public CourseContentModel CourseContent { get; set; } = new();

    public virtual ICollection<ProgramDetailsModel> ProgramDetails { get; set; } = new List<ProgramDetailsModel>();
    public virtual ICollection<CourseIncludesModel> CourseIncludes { get; set; } = new List<CourseIncludesModel>();
}
