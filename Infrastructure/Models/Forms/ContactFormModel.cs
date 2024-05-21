using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Forms
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Invalid name")]
        [MinLength(2, ErrorMessage = "Invalid name")]
        public string FullName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email")]
        [Required(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = null!;

        [MinLength(2, ErrorMessage = "Invalid first name")]
        public string Service { get; set; } = null!;

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Message is required")]
        [MinLength(10, ErrorMessage = "The message must contain at least 10 letters")]
        [MaxLength(1000)]
        public string Message { get; set; } = null!;
    }
}
