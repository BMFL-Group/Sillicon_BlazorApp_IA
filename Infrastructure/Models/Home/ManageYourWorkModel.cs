using Infrastructure.Models.Account;

namespace Infrastructure.Models.Home;

public class ManageYourWorkModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public ImageModel Image { get; set; } = null!;
    public List<CheckListModel> Checklist { get; set; } = null!;
    public LinkModel Link { get; set; } = new LinkModel();

}

public class CheckListModel
{
    public string Icon { get; set; } = "fa - regular fa-circle-check";
    public string Text { get; set; } = null!;
}