using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProviderSystem.Models;

public partial class ProviderDbContext : DbContext
{
    public ProviderDbContext()
    {
    }

    public ProviderDbContext(DbContextOptions<ProviderDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<FieldWork> FieldWorks { get; set; }

    public virtual DbSet<Journal> Journals { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<StatusMessage> StatusMessages { get; set; }

    public virtual DbSet<TariffPlan> TariffPlans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRating> UserRatings { get; set; }

    public virtual DbSet<UserTraffic> UserTraffics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = ProviderDb; Integrated Security = true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.IdBill);

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bills_User");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IdCity);

            entity.ToTable("CIty");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("PK_Eevnt");

            entity.ToTable("Event");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<FieldWork>(entity =>
        {
            entity.HasKey(e => e.IdFieldWork);

            entity.ToTable("FieldWork");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.FieldWorks)
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FieldWork_Service");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.FieldWorkIdUserNavigations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FieldWork_User");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.FieldWorkIdWorkerNavigations)
                .HasForeignKey(d => d.IdWorker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FieldWork_User1");
        });

        modelBuilder.Entity<Journal>(entity =>
        {
            entity.HasKey(e => e.IdJournal);

            entity.ToTable("Journal");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Journals)
                .HasForeignKey(d => d.IdEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Journal_Event");

            entity.HasOne(d => d.IdTariffPlanNavigation).WithMany(p => p.Journals)
                .HasForeignKey(d => d.IdTariffPlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Journal_TariffPlan");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Journals)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Journal_User");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.IdMessage);

            entity.ToTable("Message");

            entity.Property(e => e.IdMessage).ValueGeneratedNever();

            entity.HasOne(d => d.IdStatusMessageNavigation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.IdStatusMessage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_StatusMessage");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.MessageIdUserNavigations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_User");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.MessageIdWorkerNavigations)
                .HasForeignKey(d => d.IdWorker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_User1");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdPayment);

            entity.ToTable("Payment");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition);

            entity.ToTable("Position");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService);

            entity.ToTable("Service");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusMessage>(entity =>
        {
            entity.HasKey(e => e.IdStatusMessage);

            entity.ToTable("StatusMessage");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TariffPlan>(entity =>
        {
            entity.HasKey(e => e.IdTariffPlan);

            entity.ToTable("TariffPlan");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.BlockStatus).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fio).HasColumnName("FIO");
            entity.Property(e => e.IdCity).HasColumnName("IdCIty");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdCity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_CIty");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Position");

            entity.HasOne(d => d.IdTariffPlanNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdTariffPlan)
                .HasConstraintName("FK_User_TariffPlan");
        });

        modelBuilder.Entity<UserRating>(entity =>
        {
            entity.HasKey(e => e.IdUserRating);

            entity.ToTable("UserRating");

            entity.HasOne(d => d.IdTariffPlanNavigation).WithMany(p => p.UserRatings)
                .HasForeignKey(d => d.IdTariffPlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRating_TariffPlan");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserRatings)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRating_User");
        });

        modelBuilder.Entity<UserTraffic>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserTraffic");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTraffic_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
