using Microsoft.EntityFrameworkCore;
using Parrot.Data;
using Parrot.Model;
using Parrot.Repositories.Interfaces;

namespace Parrot.Repositories
{
    public class PostRepository: IPostRepository
    {
        private readonly ParrotDBContext _dbContext;

        public PostRepository(ParrotDBContext parrotDBContext)
        { 
            _dbContext = parrotDBContext;
        }

        public async Task<List<PostModel>> GetAllPosts()
        {
            return await _dbContext.Posts.Include(x => x.User).ToListAsync();
        }

        public async Task<PostModel> GetPostById(int id)
        {
            PostModel postById = await _dbContext.Posts.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

            if (postById == null)
            {
                throw new Exception($"Post with ID: {id} was not found.");
            }

            return postById;
        }

        public async Task<PostModel> CreatePost(PostModel postModel)
        {
            await _dbContext.Posts.AddAsync(postModel);
            await _dbContext.SaveChangesAsync();
            return postModel;
        }

        public async Task<bool> DeletePost(int id)
        {
            PostModel postById = await GetPostById(id);
            
            _dbContext.Remove(postById);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
