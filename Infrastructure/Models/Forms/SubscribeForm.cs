
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Forms
{
    public class SubscribeForm
    {
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email")]
        [Required(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = null!;

        public bool Subscribe { get; set; } = false;

        public bool DarkMode { get; set; } = false;
    }
}
