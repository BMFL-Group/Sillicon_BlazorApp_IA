using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Forms
{
    public class SignInFormModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember me", Order = 2)]
        public bool Remember { get; set; } = false;
    }
}
