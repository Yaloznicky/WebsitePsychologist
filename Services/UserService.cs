using WebsitePsychologist.Models;

namespace WebsitePsychologist.Services
{
    public interface IUserService
    {
        public string CurrentUser { get; }
        public string Admin { get; }
    }

    public class UserService(IDbService db) : IUserService
    {
        public string Admin => "Admin";
        
        public string CurrentUser { 
            //get => db.GetUser("Admin").Login!;
            get => "";
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
