using Infrastructure.Models.Account;

namespace Infrastructure.Models.Home;

public class ShowcaseModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string SubHeading { get; set; } = null!;
    public LinkModel Link { get; set; } = new();
    public string BrandsText { get; set; } = null!;
    public List<ImageModel> Brands { get; set; } = [];
    public ImageModel ShowcaseImage { get; set; } = new();
}
