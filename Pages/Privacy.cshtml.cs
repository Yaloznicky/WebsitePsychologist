using WebsitePsychologist.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebsitePsychologist.Pages
{
    public class PrivacyModel(IDbService db) : PageModel
    {
        public void OnGet()
        {
            if (Request.Cookies["Login"] == null)
                ViewData["Login"] = "";
            else
                ViewData["Login"] = User.Identity!.Name;
        }
    }

}
