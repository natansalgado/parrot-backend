using Parrot.Model;

namespace Parrot.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> UpdateUser(int id, UserModel user);
        Task<bool> DeleteUser(int id);
    }
}
