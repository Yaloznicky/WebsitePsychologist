namespace WebsitePsychologist.Services
{
    public interface IUserService
    {
        public string CurrentUser {  get; }
    }

    public class UserService : IUserService
    {
        public string CurrentUser => GetUser();

        public string GetUser()
        {
            return "";
        }
    }

    public static class ServiceProviderUsersExtentions
    {
        public static void AddUsersService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
