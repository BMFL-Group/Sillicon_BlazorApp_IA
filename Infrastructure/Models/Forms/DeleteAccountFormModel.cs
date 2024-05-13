using Business.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Forms
{
    public class DeleteAccountFormModel
    {
        [Display(Name = " Yes, I want to delete my account.", Order = 0)]
        [CheckboxRequired(ErrorMessage = "You must confirm")]
        public bool Delete { get; set; } = false;
    }
}
