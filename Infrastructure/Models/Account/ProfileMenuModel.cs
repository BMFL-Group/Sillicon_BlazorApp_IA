
namespace Infrastructure.Models.Account
{
    public class ProfileMenuModel
    {
        public string? Image { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public List<ProfileMenuLinkModel> Links = [
            new() { Link = new() { Page ="/accountdetails", Text = "Account details" }, Symbol="fa-regular fa-gear" },
            new() { Link = new() { Page ="/security", Text = "Security" }, Symbol = "fa-regular fa-lock" },
            new() { Link = new() { Page ="/notifications", Text = "Notifications" }, Symbol="fa-light fa-bell" },
            new() { Link = new() { Page ="/messages", Text = "Messages" }, Symbol = "fa-regular fa-message" },
            new() { Link = new() { Page="/savedcourses", Text = "Saved courses" }, Symbol = "fa-regular fa-bookmark" },
            new() { Link = new() { Page="/signin", Text = "Sign out" }, Symbol = "fa-solid fa-right-from-bracket fa-flip-horizontal" }
        ];
    }
}
