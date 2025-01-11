using WebsitePsychologist.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebsitePsychologist.Pages
{
    public class ReviewsModel(IUserService user) : PageModel
    {
        public DateTime? dateTime = DateTime.Now;

        public void OnGet()
        {
            ViewData["Login"] = user.CurrentUser;

        }
    }
}
