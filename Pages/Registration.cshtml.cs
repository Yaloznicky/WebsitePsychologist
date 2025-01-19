using WebsitePsychologist.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebsitePsychologist.Pages
{
    public class RegistrationModel(IDbService db, IUserService user) : PageModel
    {
        public void OnGet()
        {
            ViewData["Login"] = user.CurrentUser;
        }
    }
}
