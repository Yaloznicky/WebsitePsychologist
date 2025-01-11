namespace WebsitePsychologist.Services
{
    public interface IThemeService
    {
        public List<Theme> Themes {  get; }
    }

    public class ThemeService : IThemeService
    {
        public List<Theme> Themes => GetThemes();

        public List<Theme> GetThemes()
        {
            List<Theme> themes = new();
            Theme s1 = new("Услуга 1", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nobis doloremque voluptatum repellat maxime libero quia inventore, magnam, aspernatur incidunt unde iste officia earum porro id et quasi dolorem! Quibusdam quod quas hic quos optio reiciendis impedit eum explicabo tenetur pariatur. Culpa, adipisci quasi! Quaerat excepturi, ullam nobis vitae delectus magni.");
            Theme s2 = new("Услуга 2", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nobis doloremque voluptatum repellat maxime libero quia inventore, magnam, aspernatur incidunt unde iste officia earum porro id et quasi dolorem! Quibusdam quod quas hic quos optio reiciendis impedit eum explicabo tenetur pariatur. Culpa, adipisci quasi! Quaerat excepturi, ullam nobis vitae delectus magni.");
            themes.Add(s1);
            themes.Add(s2);

            return themes;
        }
    }

    public static class ServiceProviderThemesExtentions
    {
        public static void AddThemesService(this IServiceCollection services)
        {
            services.AddScoped<IThemeService, ThemeService>();
        }
    }
}
