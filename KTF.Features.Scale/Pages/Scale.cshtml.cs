using KTF.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace KTF.Features.Scale.Pages
{
    public class ScaleModel : PageModel
    {
        [BindProperty]
        public Setting Setting { get; set; }

        public ScaleModel(IOptions<Setting> setting)
        {
            Setting = setting.Value;
        }
        public void OnGet()
        {
        }
    }
}
