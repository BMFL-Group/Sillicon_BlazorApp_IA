
namespace Infrastructure.Models
{
    public class ClientUserModel
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? ProfileImg { get; set; }
    }
}
