using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThucHanh.Models;

public partial class NewContext : DbContext
{
    public NewContext()
    {
    }

    public NewContext(DbContextOptions<NewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Catalog> Catalogs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-GGATRPH\\SQLEXPRESS;Initial Catalog=New;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC0757EA3A03");

            entity.ToTable("Account");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Catalog__3214EC07D6061F5E");

            entity.ToTable("Catalog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CatalogCode).HasMaxLength(50);
            entity.Property(e => e.CatalogName).HasMaxLength(250);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC079A25B3ED");

            entity.ToTable("Product");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(250);

            entity.HasOne(d => d.Catalog).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatalogId)
                .HasConstraintName("FK__Product__Catalog__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
