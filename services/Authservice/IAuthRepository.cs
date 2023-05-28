using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;

namespace fbs_webApi_v2.services.Authservice
{
    public interface IAuthRepository
    {
        Task<serviceResponce<int>> Register(User user, string password);

        Task<serviceResponce<loginresponce>> Login(string username, string password);

        Task<bool> UserExists(User user);
    }
}
