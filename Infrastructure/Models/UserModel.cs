
namespace Infrastructure.Models;

public class UserModel
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Biography { get; set; }

    public int? AddressId { get; set; }

    public AddressModel? Address { get; set; }

    public bool IsExternalAccount { get; set; } = false;

    public string ProfileImageUrl { get; set; } = null!;
}
