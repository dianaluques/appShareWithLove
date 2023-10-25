namespace appShareWithLove.Models.Data
{
    public class Comment
    {
        public int IdComment { get; set; }

        public string? Comment1 { get; set; }

        public DateTime? PublicationDate { get; set; }

        public int IdUser { get; set; }

        public int IdPublication { get; set; }

        public virtual Publication? IdPublicationNavigation { get; set; } = null!;

        public virtual User? IdUserNavigation { get; set; } = null!;
    }
}
