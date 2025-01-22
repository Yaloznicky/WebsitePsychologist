using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsitePsychologist.Models;
using WebsitePsychologist.Services;

namespace WebsitePsychologist.Pages
{
    public class ThemesModel(IDbService db) : PageModel
    {
        public List<Theme> themes = db.GetThemes();

        public void OnGet() 
        {
            if (Request.Cookies["Login"] == null)
                ViewData["Login"] = "";
            else
                ViewData["Login"] = User.Identity!.Name;
        }

        public IActionResult OnGetDelete(int id)
        {
            db.DeleteThemes(id);
            return RedirectToPage();
        }

    }
}
