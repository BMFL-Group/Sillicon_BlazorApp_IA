using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Forms
{
    public class SecurityFormModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Invalid password")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Invalid password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Invalid Password")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Invalid password")]
        public string NewPassword { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Passwords must match")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords did not match!")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
