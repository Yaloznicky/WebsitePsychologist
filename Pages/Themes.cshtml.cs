using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsitePsychologist.Models;
using WebsitePsychologist.Services;

namespace WebsitePsychologist.Pages
{
    public class ThemesModel(IDbService db, IUserService user) : PageModel
    {
        public List<Theme> themes = db.GetThemes();
        public string? admin;

        public void OnGet() 
        {
            ViewData["Login"] = user.CurrentUser;
            admin = user.Admin;
        }

        public IActionResult OnGetDelete(int id)
        {
            db.DeleteThemes(id);
            return RedirectToPage();
        }

    }
}
