using Infrastructure.Models.Forms;
using Microsoft.AspNetCore.Identity;
using Sillicon_BlazorApp_IA.Data;

namespace Sillicon_BlazorApp_IA.Services
{
    public class AccountService
    {
        private readonly SignInManager<ApplicationUser> _manager;
        public AccountService(SignInManager<ApplicationUser> manager)
        {
            _manager = manager;
        }

        public ApplicationUser? ActiveUser { get; set; }

        public async Task<ApplicationUser> GetUserInfo()
        {
            if (ActiveUser != null)
            {
                var info = new ApplicationUser
                {
                    FirstName = ActiveUser!.FirstName,
                    LastName = ActiveUser.LastName,
                    Email = ActiveUser.Email,
                    PhoneNumber = ActiveUser.PhoneNumber,
                    Biography = ActiveUser.Biography
                };

                return info;
            }
            return null!;
        }
    }
}
