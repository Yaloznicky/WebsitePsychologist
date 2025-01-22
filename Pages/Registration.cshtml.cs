using WebsitePsychologist.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebsitePsychologist.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace WebsitePsychologist.Pages
{
    public record class LoginUser
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }


    [IgnoreAntiforgeryToken]
    public class RegistrationModel(IDbService db) : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Не указан логин")]
        public string? Login { get; set; }

        [BindProperty]
        [Required]
        public string? Gender { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "Не введен пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }


        public void OnGet()
        {
            if (Request.Cookies["Login"] == null)
                ViewData["Login"] = "";
            else
                ViewData["Login"] = User.Identity!.Name;
        }

        public async Task<IActionResult> OnPost()
        {
            if(Password == null) ModelState.AddModelError("ConfirmPassword", "Проверьте правильность ввода паролей");

            if (ModelState.IsValid)
            {
                User newUser = new (Login, Gender, Password);
                if (db.GetUser(Login!) is null)
                {
                    db.SetUser(newUser);
                }
                else
                {
                    ModelState.AddModelError("Login", "Такой пользователь уже есть. Придумайте другой логин.");
                    return Page();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, newUser.Login!)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }


        public async Task<IActionResult> OnPostLogIn(LoginUser loginUser)
        {
            if (loginUser.Login == null
                || loginUser.Password == null)
                return RedirectToPage("Registration");

            User user = db.GetUser(loginUser.Login);

            if (user is null)
            {
                return RedirectToPage("Registration");
            }

            PasswordHasher<User> hasher = new();
            PasswordVerificationResult result = hasher.VerifyHashedPassword(user, user.Password!, loginUser.Password);

            if(result == 0)
            {
                return RedirectToPage("Registration");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login!)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("Index");
        }


        public async Task<IActionResult> OnPostLogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("Index");
        }
    }
}
