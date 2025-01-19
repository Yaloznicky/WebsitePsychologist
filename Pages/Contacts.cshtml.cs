using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsitePsychologist.Services;

namespace WebsitePsychologist.Pages
{
    public class ContactsModel(IDbService db, IUserService user) : PageModel
    {
        public void OnGet()
        {
            ViewData["Login"] = user.CurrentUser;

        }
    }
}
