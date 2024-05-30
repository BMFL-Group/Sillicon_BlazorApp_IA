using Microsoft.JSInterop;

namespace Sillicon_BlazorApp_IA.Client.Components
{
    public class AppTheme
    {
        private readonly IJSRuntime _js;

        public AppTheme(IJSRuntime js)
        {
            _js = js;
        }

        private bool isDarkMode = false;

        public bool IsDarkMode
        {
            get => isDarkMode;
            set
            {
                isDarkMode = value;
                _js.InvokeVoidAsync("setDarkMode", value);
            }
        }



    }
}
