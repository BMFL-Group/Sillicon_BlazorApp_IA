using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Forms
{
    public class NotificationsFormModel
    {
        [Required(ErrorMessage = "Invalid password")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Invalid password")]
        public string Email { get; set; } = null!;

        public bool Subscribe { get; set; } = false;

        public bool DarkMode { get; set; } = false;
    }
}
