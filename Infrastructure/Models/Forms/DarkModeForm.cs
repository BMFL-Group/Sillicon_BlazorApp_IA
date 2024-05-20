
using Business.Utilities;

namespace Infrastructure.Models.Forms
{
    public class DarkModeForm
    {
        [CheckboxRequired]
        public bool DarkMode { get; set; } = false;
    }
}
