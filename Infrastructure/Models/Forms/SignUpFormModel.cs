using Business.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Forms
{
    public class SignUpFormModel
    {
        [Required(ErrorMessage = "Invalid first name")]
        [MinLength(2, ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Invalid last name")]
        [MinLength(2, ErrorMessage = "Invalid last name")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email")]
        [Required(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Invalid password")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Invalid password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Passwords must match")]
        [Compare(nameof(Password), ErrorMessage = "Passwords did not match!")]
        public string ConfirmPassword { get; set; } = null!;

        [CheckboxRequired(ErrorMessage = "You must accept the terms and conditions to proceed.")]
        public bool Terms { get; set; } = false;
    }
}
