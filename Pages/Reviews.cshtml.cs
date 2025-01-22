using WebsitePsychologist.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsitePsychologist.Models;

namespace WebsitePsychologist.Pages
{
    [IgnoreAntiforgeryToken]
    public class ReviewsModel(IDbService db) : PageModel
    {
        public List<Review> reviews = db.GetReviews();
        public List<User> users = db.GetUsers();
        
        public void OnGet()
        {
            reviews.Reverse();
            if (Request.Cookies["Login"] == null)
                ViewData["Login"] = "";
            else
                ViewData["Login"] = User.Identity!.Name;
        }

        public IActionResult OnPost(string review)
        {
            Review newReview = new();
            newReview.DateTimeReview = DateTime.Now;
            newReview.Text = review;
            newReview.Users = db.GetUser(User.Identity!.Name!);
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
