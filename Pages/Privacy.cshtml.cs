using WebsitePsychologist.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebsitePsychologist.Pages
{
    public class PrivacyModel(IDbService db, IUserService user) : PageModel
    {
        public void OnGet()
        {
            ViewData["Login"] = user.CurrentUser;

        }
    }

}
