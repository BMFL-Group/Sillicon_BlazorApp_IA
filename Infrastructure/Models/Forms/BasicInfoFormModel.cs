using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Account
{
    public class BasicInfoFormModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Invalid first name, minimum of two characters")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(2, ErrorMessage = "Invalid last name, minimum of two characters")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email")]
        [Required(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; } 

        [DataType(DataType.MultilineText)]
        public string? Bio { get; set; }

        public bool IsExternalAccount { get; set; }
    }
}
