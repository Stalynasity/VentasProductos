using BOOT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BOOT.Infrastructura.Persistences.Contexts;

public partial class BootContext : DbContext
{
    public BootContext()
    {
    }

    public BootContext(DbContextOptions<BootContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<InvoiceDetaild> InvoiceDetailds { get; set; }

    public virtual DbSet<InvoiceHead> InvoiceHeads { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InvoiceDetaild>(entity =>
        {
            entity.HasKey(e => e.InvoiceDetailId);

            entity.ToTable("InvoiceDetaild");

            entity.Property(e => e.InvoiceDetailId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.InvoiceDetail).WithOne(p => p.InvoiceDetaild)
                .HasForeignKey<InvoiceDetaild>(d => d.InvoiceDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetaild_InvoiceHead");

            entity.HasOne(d => d.Product).WithMany(p => p.InvoiceDetailds)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_InvoiceDetaild_Product");
        });

        modelBuilder.Entity<InvoiceHead>(entity =>
        {
            entity.ToTable("InvoiceHead");

            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.InvoiceHeads)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceHead_Users");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ImagUrl)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Categorys).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdentityCard)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        // modifica para manera globalmente
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
