using Parrot.Model;

namespace Parrot.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<List<PostModel>> GetAllPosts();
        Task<PostModel> GetPostById(int id);
        Task<PostModel> CreatePost(PostModel post);
        Task<bool> DeletePost(int id);
    }
}
