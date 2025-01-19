using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsitePsychologist.Models;
using WebsitePsychologist.Services;

namespace WebsitePsychologist.Pages
{
    [IgnoreAntiforgeryToken]
    public class EditReviewModel(IDbService db, IUserService user) : PageModel
    {
        public Review editReview = new();

        public void OnGet(int id)
        {
            editReview = db.GetReview(id);
            ViewData["Login"] = db.GetUser(user.CurrentUser).Login;
        }

        public RedirectToPageResult OnPost(string id, string text, string key)
        {
            if(key == "1")
                db.EditReviews(Convert.ToInt32(id), text);
            return RedirectToPage("Reviews");
        }
    }
}
