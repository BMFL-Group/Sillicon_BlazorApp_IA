using Blazored.LocalStorage;
using Microsoft.JSInterop;

namespace Infrastructure.Services;

public record Preferences
{
    public bool IsDarkMode { get; init; }
}
public class SiteSettings(IJSRuntime iJSRuntime, ILocalStorageService localStorageService)
{
    private readonly IJSRuntime _IJSRuntime = iJSRuntime;
    private readonly ILocalStorageService _localStorageService = localStorageService;

    public event Action<Preferences> OnChange;

    public async Task<bool> ToggleDarkMode()
    {
        var preferences = await GetPreferences();
        var newPreferences = preferences
        with
        { IsDarkMode = !preferences.IsDarkMode };

        await _localStorageService.SetItemAsync("preferences", newPreferences);
        //await _localStorageService.SetItemAsync("preferences", newPreferences.IsDarkMode ? "dark" : "light");

        //await _IJSRuntime.InvokeVoidAsync("localStorage.setItem", "preferences", newPreferences.IsDarkMode ? "dark" : "light");

        OnChange?.Invoke(newPreferences);
        return newPreferences.IsDarkMode;
    }

    public async Task<Preferences> GetPreferences()
    {
        return await _localStorageService.GetItemAsync<Preferences>("preferences")
        ?? new Preferences() { IsDarkMode = false };

        //string? theme = await _localStorageService.GetItemAsync<string>("preferences");
        ////string theme = await _IJSRuntime.InvokeAsync<string>("localStorage.getItem", "preferences");
        //if (String.IsNullOrEmpty(theme) || theme == "light")
        //{
        //    return new Preferences { IsDarkMode = true };
        //}
        //else
        //{
        //    return new Preferences { IsDarkMode = false };
        //}
    }
}
