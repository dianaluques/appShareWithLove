using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Reflection.PortableExecutable;
using appShareWithLove.Models.Data;

namespace appShareWithLove.Models.Data;

public partial class ShareWithLoveDbContext : DbContext
{
    public ShareWithLoveDbContext()
    {
    }

    public ShareWithLoveDbContext(DbContextOptions<ShareWithLoveDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Constant> Constants { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Publication> Publications { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=CadenaSQL");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Access>(entity =>
        {
            entity.HasKey(e => e.IdAccess);

            entity.ToTable("Access");

            entity.Property(e => e.IdAccess).HasColumnName("Id_Access");
            entity.Property(e => e.Email)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdRole).HasColumnName("Id_Role");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Password)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Accesses)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Access_Role");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Accesses)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Access_User");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("PK_Addresss");

            entity.ToTable("Address");

            entity.Property(e => e.IdAddress).HasColumnName("Id_Address");
            entity.Property(e => e.Address1)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_User");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.IdComment);

            entity.ToTable("Comment");

            entity.Property(e => e.IdComment).HasColumnName("Id_Comment");
            entity.Property(e => e.Comment1)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.IdPublication).HasColumnName("Id_Publication");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.PublicationDate)
                .HasColumnType("datetime")
                .HasColumnName("publicationDate");

            entity.HasOne(d => d.IdPublicationNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdPublication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Publication");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_User");
        });

        modelBuilder.Entity<Constant>(entity =>
        {
            entity.HasKey(e => e.IdConst);

            entity.ToTable("Constant");

            entity.Property(e => e.IdConst).HasColumnName("Id_Const");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.IdPhone);

            entity.ToTable("Phone");

            entity.Property(e => e.IdPhone).HasColumnName("Id_Phone");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Phone1).HasColumnName("Phone");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Phones)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Phone_User");
        });

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.HasKey(e => e.IdPublication);

            entity.ToTable("Publication");

            entity.Property(e => e.IdPublication).HasColumnName("Id_Publication");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Image)
                .HasColumnType("image")
                .HasColumnName("image");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Publications)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Publication_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("Id_Role");
            entity.Property(e => e.RoleType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("roleType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.State).HasColumnName("state");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

