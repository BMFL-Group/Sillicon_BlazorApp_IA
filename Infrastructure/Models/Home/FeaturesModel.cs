using Infrastructure.Models.Account;

namespace Infrastructure.Models.Home;

public class FeaturesModel
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    public List<FeaturesBoxModel> FeaturesBoxes { get; set; } = [];
}
public class FeaturesBoxModel
{
    public LinkModel Link { get; set; } = new();

    public ImageModel Image { get; set; } = new();

    public string SubHeading { get; set; } = null!;

    public string Text { get; set; } = null!;
}