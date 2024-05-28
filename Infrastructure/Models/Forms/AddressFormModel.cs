using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Account
{
    public class AddressFormModel
    {
        [Required(ErrorMessage = "Adress is required")]
        public string Addressline_1 { get; set; } = null!;

        public string? Addressline_2 { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Postal code is required")]
        public string PostalCode { get; set; } = null!;

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = null!;
    }
}
