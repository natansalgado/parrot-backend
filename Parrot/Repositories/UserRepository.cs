using Microsoft.EntityFrameworkCore;
using Parrot.Data;
using Parrot.Model;
using Parrot.Repositories.Interfaces;

namespace Parrot.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ParrotDBContext _dbContext;

        public UserRepository(ParrotDBContext parrotDBContext)
        {
            _dbContext = parrotDBContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            UserModel user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new Exception($"User with ID: {id} was not found.");
            }

            return user;
        }

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            await _dbContext.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserModel> UpdateUser(int id, UserModel userModel)
        {
            UserModel userById = await GetUserById(id);

            userModel.Id = id;
            userById.Id = id;
            userById.Name = userModel.Name;
            userById.Username = userModel.Username;
            userById.Email = userModel.Email;
            userById.Password = userModel.Password;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
