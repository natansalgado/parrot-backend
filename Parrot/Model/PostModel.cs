
namespace Parrot.Model
{
    public class PostModel
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? UserId { get; set; }
        public UserModel? User { get; set; }

        public static implicit operator PostModel(List<PostModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
