using WebsitePsychologist.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsitePsychologist.Models;

namespace WebsitePsychologist.Pages
{
    [IgnoreAntiforgeryToken]
    public class ReviewsModel(IDbService db, IUserService user) : PageModel
    {
        public List<Review> reviews = db.GetReviews();
        public List<User> users = db.GetUsers();
        
        public void OnGet()
        {
            reviews.Reverse();
            ViewData["Login"] = user.CurrentUser;
        }

        public IActionResult OnPost(string review)
        {
            Review newReview = new();
            newReview.DateTimeReview = DateTime.Now;
            newReview.Text = review;
            newReview.Users = db.GetUser(user.CurrentUser);
            db.SetReview(newReview);
            return RedirectToPage();
        }

        public IActionResult OnGetDelete(int id)
        {
            db.DeleteReviews(id);
            return RedirectToPage();
        }
    }
}
