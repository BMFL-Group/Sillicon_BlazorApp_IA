using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

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
    public int LengthInHours { get; set; }

    public int Rating { get; set; } = 0;

    public int NumberOfReviews { get; set; } = 0;

    public int NumberOfLikes { get; set; } = 0;

    //public string CourseDescription { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Category { get; set; }

    //public int ContentId { get; set; }
    //public CourseContentModel Content { get; set; } = new();
       
    //public virtual ICollection<ProgramDetailsModel> ProgramDetails { get; set; } = new List<ProgramDetailsModel>();
    //public virtual ICollection<CourseIncludesModel> Includes { get; set; } = new List<CourseIncludesModel>();

}
