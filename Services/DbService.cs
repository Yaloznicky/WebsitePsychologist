using WebsitePsychologist.Models;

namespace WebsitePsychologist.Services
{
    public interface IDbService
    {
        public User GetUser(string login);
        public List<User> GetUsers();
        public List<Theme> GetThemes();
        public List<Review> GetReviews();
        public Review GetReview(int id);
        public Theme GetTheme(int id);

        public void SetUser(User user);
        public void SetTheme(Theme theme);
        public void SetReview(Review review);

        public void EditReviews(int id, string text);
        public void DeleteReviews(int id);
        public void EditThemes(int id, string themeName, string text);
        public void DeleteThemes(int id);
    }

    public class DbService(ApplicationContext context) : IDbService
    {
        public List<Review> GetReviews()
        {
            return context.Reviews!.ToList();
        }

        public Review GetReview(int id)
        {
            return context.Reviews!.FirstOrDefault(review => review.Id == id)!;
        }

        public List<Theme> GetThemes()
        {
            return context.Themes!.ToList();
        }

        public Theme GetTheme(int id)
        {
            return context.Themes!.FirstOrDefault(theme => theme.Id == id)!;
        }

        public User GetUser(string login)
        {
            return context.Users!.FirstOrDefault(user => user.Login == login)!;
        }
        List<User> IDbService.GetUsers()
        {
            return context.Users!.ToList();
        }

        public void SetReview(Review review)
        {
            context.Reviews!.Add(review);
            context.SaveChanges();
        }

        public void SetTheme(Theme theme)
        {
            context.Themes!.Add(theme);
            context.SaveChanges();
        }

        public void SetUser(User user)
        {
            context.Users!.Add(user);
            context.SaveChanges();
        }

        public void EditReviews(int id, string text)
        {
            Review review = context.Reviews!.FirstOrDefault(review => review.Id == id)!;
            if(review != null)
            {
                review.Text = text;
                context.Update(review);
                context.SaveChanges();
            }
        }

        public void DeleteReviews(int id)
        {
            context.Reviews!.Remove(context.Reviews.FirstOrDefault(review => review.Id == id)!);
            context.SaveChanges();
        }

        public void EditThemes(int id, string themeName, string text)
        {
            Theme theme = context.Themes!.FirstOrDefault(theme => theme.Id == id)!;
            if (theme != null)
            {
                theme.ThemeName = themeName;
                theme.Text = text;
                context.Update(theme);
                context.SaveChanges();
            }
        }

        public void DeleteThemes(int id)
        {
            context.Themes!.Remove(context.Themes.FirstOrDefault(theme => theme.Id == id)!);
            context.SaveChanges();
        }
    }

    public static class ServiceProviderDataBaseExtentions
    {
        public static void AddDataBaseService(this IServiceCollection services)
        {
            services.AddScoped<IDbService, DbService>();
        }
    }
}
