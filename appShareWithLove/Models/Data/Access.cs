using System.Data;

namespace appShareWithLove.Models.Data
{
    public class Access
    {
        public int IdAccess { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int IdUser { get; set; }

        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
