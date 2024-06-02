
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Forms
{
    public class ConfirmPasswordChangeForm
    {
        [Required]
        [MinLength(6, ErrorMessage = "Invalid code")]
        [MaxLength(6, ErrorMessage = "Invalid code")]

        public string Code { get; set; } = null!;
    }
}
