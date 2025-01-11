using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsitePsychologist.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebsitePsychologist.Pages
{
    public class ThemesModel(IThemeService list, IUserService user) : PageModel
    {
        public List<Theme> themes = list.Themes;
        

        public void OnGet() 
        {
            ViewData["Login"] = user.CurrentUser;
        }
    }
}
