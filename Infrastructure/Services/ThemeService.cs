namespace Infrastructure.Services;

public class ThemeService
{
    public event Action<string> OnChange;

    public void NotifyThemeChanged(string newState) => OnChange?.Invoke(newState);


    private string _theme = "light";
    public string Theme
    {
        get => _theme;
        set
        {
            _theme = value;
            NotifyThemeChanged(_theme);
        }
    }
}
