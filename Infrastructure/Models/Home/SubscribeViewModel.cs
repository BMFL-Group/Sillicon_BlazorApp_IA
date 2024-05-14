using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Home;

public class SubscribeViewModel
{
    public string Id = "subscribe";
    public string Title { get; set; } = null!;
    public ImageModel Image { get; set; } = new();
    public string Subheading { get; set; } = null!;
    public SubscribeModel Subscribe { get; set; } = new();
}
