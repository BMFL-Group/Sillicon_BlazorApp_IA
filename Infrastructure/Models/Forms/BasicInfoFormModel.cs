using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Account
{
    public class BasicInfoFormModel
    {
        [Required(ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Invalid last name")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email")]
        [Required(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "phone is required")]
        public string Phone { get; set; } = null!;

        [DataType(DataType.MultilineText)]
        public string? Bio { get; set; }

        public bool IsExternalAccount { get; set; }
    }
}
