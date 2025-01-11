using System.Collections.Generic;
using WebsitePsychologist.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebsitePsychologist.Pages
{
    public class IndexModel(ILogger<IndexModel> logger, IUserService user) : PageModel
    {
        private readonly ILogger<IndexModel> _logger = logger;

        public void OnGet()
        {
            ViewData["Login"] = user.CurrentUser;
        }
    }
}
