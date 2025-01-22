using WebsitePsychologist.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebsitePsychologist.Pages
{
    public class IndexModel(ILogger<IndexModel> logger, IDbService db) : PageModel
    {
        private readonly ILogger<IndexModel> _logger = logger;

        public void OnGet()
        {
            if (Request.Cookies["Login"] == null)
                ViewData["Login"] = "";
            else
                ViewData["Login"] = User.Identity!.Name;
        }
    }
}
