namespace appShareWithLove.Models.Data
{
    public class Role
    {
        public int IdRole { get; set; }

        public string RoleType { get; set; } = null!;

        public virtual ICollection<Access> Accesses { get; set; } = new List<Access>();
    }
}
