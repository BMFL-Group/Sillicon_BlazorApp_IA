
namespace Infrastructure.Models.Account
{
    public class VerifyCodeAndEmailModel
    {
        public string Email { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
