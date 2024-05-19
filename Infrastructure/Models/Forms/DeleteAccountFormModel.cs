
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Forms
{
    public class DeleteAccountFormModel
    {
        [Required(ErrorMessage = "Invalid password")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Invalid password")]
        public string Delete { get; set; } = null!;
    }
}
