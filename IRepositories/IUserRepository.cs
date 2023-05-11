using System;
using fbs_webApi_v2.DataModels;

namespace fbs_webApi_v2.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();


        Task<User> GetUserByUser_IdAsync(int userId);

        Task<User?> GetUserByUser_NameAsync(string name);

        Task<User> GetUserByUser_EmailAsync(string email);

        Task<User> GetUserByPhonenumberAsync(string phonenumber);
        Task<bool> CreateUserAsync(User user);

        Task<bool> UpdateUserAsync(User user);

        Task<bool> DeleteUserAsync(int userId);

    }
}
