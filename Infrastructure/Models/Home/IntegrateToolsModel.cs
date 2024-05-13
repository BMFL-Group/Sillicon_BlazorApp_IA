namespace Infrastructure.Models.Home;

public class IntegrateToolsModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string SubHeading { get; set; } = null!;
    public List<ToolBoxModel> Boxes { get; set; } = null!;
}

public class ToolBoxModel
{
    public ImageModel Image { get; set; } = null!;
    public string Text { get; set; } = null!;
}
