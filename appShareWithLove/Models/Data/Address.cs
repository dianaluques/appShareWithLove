namespace appShareWithLove.Models.Data
{
    public class Address
    {
        public int IdAddress { get; set; }

        public string? Address1 { get; set; }

        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
