using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsitePsychologist.Models;
using WebsitePsychologist.Services;

namespace WebsitePsychologist.Pages
{
    [IgnoreAntiforgeryToken]
    public class ThemeFormModel(IDbService db) : PageModel
    {
        public Theme editTheme = new();
        public string? key;

        public void OnGet(int id)
        {
            if (id == 0) 
            {
                key = "newTheme";
            }
            else
            {
                key = "editTheme";
                editTheme = db.GetTheme(id);
            }

            if (Request.Cookies["Login"] == null)
                ViewData["Login"] = "";
            else
                ViewData["Login"] = User.Identity!.Name;
        }

        public RedirectToPageResult OnPost(string id, string themeName, string text, string key)
        {
            if(key == "editTheme")
                db.EditThemes(Convert.ToInt32(id), themeName, text);
            else if(key == "newTheme")
            {
                Theme newTheme = new();
                newTheme.PathImage = "img/service.jpg";
                newTheme.ThemeName = themeName;
                newTheme.Text = text;
                db.SetTheme(newTheme);
            }
            return RedirectToPage("Themes");
        }
    }
}
