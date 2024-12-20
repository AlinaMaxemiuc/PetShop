using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using exp.Template.Infrastructure.Entities;

namespace exp.Template.Infrastructure.Context;

public partial class AnimalsFoodContext : DbContext
{
    public AnimalsFoodContext()
    {
    }

    public AnimalsFoodContext(DbContextOptions<AnimalsFoodContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonament> Abonaments { get; set; }

    public virtual DbSet<Animale> Animales { get; set; }

    public virtual DbSet<Comanda> Comandas { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Hrana> Hranas { get; set; }

    public virtual DbSet<Livrari> Livraris { get; set; }

    public virtual DbSet<Utilizator> Utilizators { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AnimalsFood;Encrypt=false;Persist Security Info=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abonament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Abonamen__3213E83F221F1095");

            entity.ToTable("Abonament");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataIncepere).HasColumnName("data_incepere");
            entity.Property(e => e.DataSfarsit).HasColumnName("data_sfarsit");
            entity.Property(e => e.Frecventa).HasColumnName("frecventa");
            entity.Property(e => e.IdHrana).HasColumnName("id_hrana");
            entity.Property(e => e.IdUtilizator).HasColumnName("id_utilizator");

            entity.HasOne(d => d.IdHranaNavigation).WithMany(p => p.Abonaments)
                .HasForeignKey(d => d.IdHrana)
                .HasConstraintName("FK_Abonament_id_hrana");
        });

        modelBuilder.Entity<Animale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnimaleT__3214EC07FDB812FD");

            entity.ToTable("Animale");

            entity.Property(e => e.Gen).HasMaxLength(50);
            entity.Property(e => e.Greutate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Specie).HasMaxLength(50);
        });

        modelBuilder.Entity<Comanda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ComandaN__3213E83F4D4539E7");

            entity.ToTable("Comanda");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataComenzii).HasColumnName("data_comenzii");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.IdAbonament).HasColumnName("id_abonament");
            entity.Property(e => e.IdUtilizator).HasColumnName("id_utilizator");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdAbonamentNavigation).WithMany(p => p.Comandas)
                .HasForeignKey(d => d.IdAbonament)
                .HasConstraintName("FK_Comanda_id_abonament");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3213E83FF46FB6AC");

            entity.ToTable("Discount");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NumarComenzi).HasColumnName("numar_comenzi");
            entity.Property(e => e.ProcentDiscount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("procent_discount");
        });

        modelBuilder.Entity<Hrana>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HranaNou__3213E83F72F6E950");

            entity.ToTable("Hrana");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descriere)
                .HasMaxLength(250)
                .HasColumnName("descriere");
            entity.Property(e => e.Nume)
                .HasMaxLength(50)
                .HasColumnName("nume");
            entity.Property(e => e.Pret)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("pret");
            entity.Property(e => e.Stoc).HasColumnName("stoc");
        });

        modelBuilder.Entity<Livrari>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LivrariN__3213E83FDD5A79CF");

            entity.ToTable("Livrari");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdresaLivrare)
                .HasMaxLength(250)
                .HasColumnName("adresa_livrare");
            entity.Property(e => e.DataLivrare).HasColumnName("data_livrare");
            entity.Property(e => e.IdComanda).HasColumnName("id_comanda");

            entity.HasOne(d => d.IdComandaNavigation).WithMany(p => p.Livraris)
                .HasForeignKey(d => d.IdComanda)
                .HasConstraintName("FK_Livrari_id_comanda");
        });

        modelBuilder.Entity<Utilizator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Utilizat__3213E83F8C5D410B");

            entity.ToTable("Utilizator");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Nume)
                .HasMaxLength(50)
                .HasColumnName("nume");
            entity.Property(e => e.Parola)
                .HasMaxLength(250)
                .HasColumnName("parola");
            entity.Property(e => e.Prenume)
                .HasMaxLength(50)
                .HasColumnName("prenume");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
