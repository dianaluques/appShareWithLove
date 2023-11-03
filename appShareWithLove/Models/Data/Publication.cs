namespace appShareWithLove.Models.Data
{
    public class Publication
    {
        public int IdPublication { get; set; }

        public DateTime? Date { get; set; }

        public byte[]? Image { get; set; }

        public int? IdUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual User? IdUserNavigation { get; set; }
    }
}
