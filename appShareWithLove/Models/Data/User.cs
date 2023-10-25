using System.Net;

namespace appShareWithLove.Models.Data
{
    public class User
    {
        public int IdUser { get; set; }

        public string? Name { get; set; }

        public bool? State { get; set; } = true;

        public virtual ICollection<Access>? Accesses { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }

        public virtual ICollection<Phone>? Phones { get; set; } = null;
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Publication>? Publications { get; set; }
    }
}
