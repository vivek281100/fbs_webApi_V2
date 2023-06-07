using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.UserDtos;

namespace fbs_webApi_v2.services.Authservice
{
    public interface IAuthRepository
    {
        Task<serviceResponce<int>> Register(User user, string password);

        Task<serviceResponce<loginresponce>> Login(string username, string password);


        Task<serviceResponce<string>> changepassword(changepasswordDto passwordform);

        Task<bool> UserExists(User user);
    }
}
