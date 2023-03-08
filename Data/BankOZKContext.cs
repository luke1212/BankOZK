using System;
using System.Collections.Generic;
using BankOZK.Models;
using Microsoft.EntityFrameworkCore;

namespace BankOZK.Data;

public partial class BankOZKContext : DbContext
{
    public BankOZKContext(DbContextOptions<BankOZKContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bankaccount> Bankaccounts { get; set; }

    public virtual DbSet<Bankuser> Bankusers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Bankaccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bankaccount");

            entity.HasIndex(e => e.BankUserId, "BankUserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.BankUser).WithMany(p => p.Bankaccounts)
                .HasForeignKey(d => d.BankUserId)
                .HasConstraintName("bankaccount_ibfk_1");
        });

        modelBuilder.Entity<Bankuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bankusers");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AddressAddress1)
                .HasMaxLength(300)
                .HasColumnName("Address_Address1")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AddressAddress2)
                .HasMaxLength(300)
                .HasColumnName("Address_Address2")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AddressCity)
                .HasMaxLength(50)
                .HasColumnName("Address_City")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AddressCountry)
                .HasMaxLength(50)
                .HasColumnName("Address_Country")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AddressState)
                .HasMaxLength(50)
                .HasColumnName("Address_State")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AddressZipCode)
                .HasMaxLength(5)
                .HasColumnName("Address_ZipCode")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
