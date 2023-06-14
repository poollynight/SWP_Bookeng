using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SWP_template.Models;

public partial class SwpContext : DbContext
{
    public SwpContext()
    {
    }

    public SwpContext(DbContextOptions<SwpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountRole> AccountRoles { get; set; }

    public virtual DbSet<Accountss> Accountsses { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<InfoAccount> InfoAccounts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=SWP;User ID=sa;Password=123456;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("AccountRole");

            entity.HasIndex(e => e.Role, "role").IsUnique();

            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("roleID");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Accountss>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("Accountss");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.AccountId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Accountsses)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accountss_AccountRole");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.ToTable("Hotel");

            entity.HasIndex(e => e.HotelId, "HotelID").IsUnique();

            entity.Property(e => e.HotelId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HotelID");
            entity.Property(e => e.AccountId)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.Avartar)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HotelAddress)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HotelInfo)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HotelName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StartPrice)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Account).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hotel_Accountss");
        });

        modelBuilder.Entity<InfoAccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("InfoAccount");

            entity.HasIndex(e => e.AccountId, "AccountID").IsUnique();

            entity.HasIndex(e => e.Identitycard, "identitycard").IsUnique();

            entity.Property(e => e.AccountId)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.Age)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("age");
            entity.Property(e => e.Birthday)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("birthday");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Identitycard)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("identitycard");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Nation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nation");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.Account).WithOne()
                .HasForeignKey<InfoAccount>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InfoAccount_Accountss");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Order");

            entity.Property(e => e.AccountId)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.CheckIn)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CheckOut)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoomId)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RoomID");
            entity.Property(e => e.RoomName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Accountss");

            entity.HasOne(d => d.Room).WithMany()
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Room");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.RoomId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RoomID");
            entity.Property(e => e.BedQuantity)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HotelId)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HotelID");
            entity.Property(e => e.RoomImage)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoomInfo)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoomName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoomPrice)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Smoking)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Wifi)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Window)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_Hotel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
