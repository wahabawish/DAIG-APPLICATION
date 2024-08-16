using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DaigApplication.Models;

public partial class DaigAppContext : DbContext
{
    public DaigAppContext()
    {
    }

    public DaigAppContext(DbContextOptions<DaigAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthAdmin> AuthAdmins { get; set; }

    public virtual DbSet<DaigTable> DaigTables { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3IKAFCF\\SQLEXPRESS;Database=DaigApp;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuthAdmi__3214EC07C9AEB234");

            entity.ToTable("AuthAdmin");

            entity.Property(e => e.Emailis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emailis");
            entity.Property(e => e.Passwordis)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Usernameis)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DaigTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DaigTabl__3214EC07B1187FBB");

            entity.ToTable("DaigTable");

            entity.Property(e => e.DaigAvailability)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DaigStatus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DaigType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC071274981B");

            entity.ToTable("Table");

            entity.Property(e => e.DaigAvailability)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DaigStatus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DaigType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
