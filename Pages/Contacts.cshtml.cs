using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsitePsychologist.Services;

namespace WebsitePsychologist.Pages
{
    public class ContactsModel(IDbService db) : PageModel
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
