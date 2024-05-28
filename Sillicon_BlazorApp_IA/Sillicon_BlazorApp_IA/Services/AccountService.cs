using Infrastructure.Models.Forms;
using Microsoft.AspNetCore.Identity;
using Sillicon_BlazorApp_IA.Data;

namespace Sillicon_BlazorApp_IA.Services
{
    public class AccountService
    {
        private readonly SignInManager<ApplicationUser> _manager;
        private readonly ApplicationDbContext _context;
        public AccountService(SignInManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            _manager = manager;
            _context = context;
        }



    }
}
