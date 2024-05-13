using Infrastructure.Models.Account;

namespace Infrastructure.Models.Home;

public class DownloadAppModel
{
    public string Id { get; set; } = null!;
    public ImageModel Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public List<AppDisplayModel> AppDisplays { get; set; } = [];
}

public class AppDisplayModel
{
    public string Title { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Rating { get; set; } = null!;
    public LinkModel Link { get; set; } = new LinkModel();
    public ImageModel Image { get; set; } = new ImageModel();
}
