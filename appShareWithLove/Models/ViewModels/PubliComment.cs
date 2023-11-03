using appShareWithLove.Models.Data;

namespace appShareWithLove.Models.ViewModels
{
    public class PubliComment
    {
        public List<Comment> Comment = new();
        public List<Publication> publi = new();
        public int id = new int();
        public PubliComment(List<Publication> publications, List<Comment> comments)
        {
            Comment = comments;
            publi = publications;
        }
    }
}
