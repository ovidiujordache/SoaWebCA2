using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApiCA2.Repository.Models;

namespace WebApiCA2.Repository;

public partial class UserDbContext : DbContext
{
    public UserDbContext()
    {
    }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FinancialTransaction> FinancialTransactions { get; set; }

    public virtual DbSet<HospitalityServiceProvider> HospitalityServiceProviders { get; set; }

    public virtual DbSet<HspandRestaurant> HspandRestaurants { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<User> User { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FinancialTransaction>(entity =>
        {
            entity.HasKey(e => e.FinancialTransactionId).HasName("PK_FTra");

            entity.HasOne(d => d.User).WithMany(p => p.FinancialTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FTransaction_User");
        });

/*        modelBuilder.Entity<HospitalityServiceProvider>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });*/

        modelBuilder.Entity<HspandRestaurant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FTransaction");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.HspandRestaurants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restaurant");

            entity.HasOne(d => d.User).WithMany(p => p.HspandRestaurants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HSP");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.Property(e => e.RestaurantId).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
