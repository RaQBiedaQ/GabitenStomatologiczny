using System;
using System.Collections.Generic;
using GabitenStomatologiczny.Models;
using Microsoft.EntityFrameworkCore;

namespace GabitenStomatologiczny.Context;

public partial class GabinetStomatologicznyContext : DbContext
{
    public GabinetStomatologicznyContext()
    {
    }

    public GabinetStomatologicznyContext(DbContextOptions<GabinetStomatologicznyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Klient> Klients { get; set; }

    public virtual DbSet<Pomieszczenium> Pomieszczenia { get; set; }

    public virtual DbSet<Pracownicy> Pracownicies { get; set; }

    public virtual DbSet<Stanowiska> Stanowiskas { get; set; }

    public virtual DbSet<Uslugi> Uslugis { get; set; }

    public virtual DbSet<Wizyty> Wizyties { get; set; }

    public virtual DbSet<Wizytyuslugi> Wizytyuslugis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Klient>(entity =>
        {
            entity.HasKey(e => e.IdKlienta).HasName("klient_pkey");

            entity.ToTable("klient");

            entity.Property(e => e.IdKlienta).HasColumnName("id_klienta");
            entity.Property(e => e.AdresZamieszkania)
                .HasMaxLength(100)
                .HasColumnName("adres_zamieszkania");
            entity.Property(e => e.DataUrodzenia).HasColumnName("data_urodzenia");
            entity.Property(e => e.Imie)
                .HasMaxLength(30)
                .HasColumnName("imie");
            entity.Property(e => e.MailKlienta)
                .HasMaxLength(100)
                .HasColumnName("mail_klienta");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(60)
                .HasColumnName("nazwisko");
            entity.Property(e => e.NumerTelefonu).HasColumnName("numer_telefonu");
        });

        modelBuilder.Entity<Pomieszczenium>(entity =>
        {
            entity.HasKey(e => e.IdPomieszczenia).HasName("pomieszczenia_pkey");

            entity.ToTable("pomieszczenia");

            entity.Property(e => e.IdPomieszczenia).HasColumnName("id_pomieszczenia");
            entity.Property(e => e.NazwaPomieszczenia)
                .HasMaxLength(60)
                .HasColumnName("nazwa_pomieszczenia");
            entity.Property(e => e.NumerPomieszczenia).HasColumnName("numer_pomieszczenia");
        });

        modelBuilder.Entity<Pracownicy>(entity =>
        {
            entity.HasKey(e => e.IdPracownika).HasName("pracownicy_pkey");

            entity.ToTable("pracownicy");

            entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");
            entity.Property(e => e.AdresZamieszkania)
                .HasMaxLength(100)
                .HasColumnName("adres_zamieszkania");
            entity.Property(e => e.DataUrodzenia).HasColumnName("data_urodzenia");
            entity.Property(e => e.IdStanowiska).HasColumnName("id_stanowiska");
            entity.Property(e => e.Imie)
                .HasMaxLength(30)
                .HasColumnName("imie");
            entity.Property(e => e.MailPracownika)
                .HasMaxLength(100)
                .HasColumnName("mail_pracownika");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(60)
                .HasColumnName("nazwisko");
            entity.Property(e => e.NumerTelefonu).HasColumnName("numer_telefonu");

            entity.HasOne(d => d.IdStanowiskaNavigation).WithMany(p => p.Pracownicies)
                .HasForeignKey(d => d.IdStanowiska)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_stanowiska");
        });

        modelBuilder.Entity<Stanowiska>(entity =>
        {
            entity.HasKey(e => e.IdStanowiska).HasName("stanowiska_pkey");

            entity.ToTable("stanowiska");

            entity.Property(e => e.IdStanowiska).HasColumnName("id_stanowiska");
            entity.Property(e => e.NazwaStanowiska)
                .HasMaxLength(60)
                .HasColumnName("nazwa_stanowiska");
        });

        modelBuilder.Entity<Uslugi>(entity =>
        {
            entity.HasKey(e => e.IdUslugi).HasName("uslugi_pkey");

            entity.ToTable("uslugi");

            entity.Property(e => e.IdUslugi).HasColumnName("id_uslugi");
            entity.Property(e => e.CenaUslugi).HasColumnName("cena_uslugi");
            entity.Property(e => e.NazwaUslugi)
                .HasMaxLength(100)
                .HasColumnName("nazwa_uslugi");
        });

        modelBuilder.Entity<Wizyty>(entity =>
        {
            entity.HasKey(e => e.IdWizyty).HasName("wizyty_pkey");

            entity.ToTable("wizyty");

            entity.Property(e => e.IdWizyty).HasColumnName("id_wizyty");
            entity.Property(e => e.DataWizyty).HasColumnName("data_wizyty");
            entity.Property(e => e.IdKlienta).HasColumnName("id_klienta");
            entity.Property(e => e.IdPomieszczenia).HasColumnName("id_pomieszczenia");
            entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");

            entity.HasOne(d => d.IdKlientaNavigation).WithMany(p => p.Wizyties)
                .HasForeignKey(d => d.IdKlienta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_klienta");

            entity.HasOne(d => d.IdPomieszczeniaNavigation).WithMany(p => p.Wizyties)
                .HasForeignKey(d => d.IdPomieszczenia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pomieszczenia");

            entity.HasOne(d => d.IdPracownikaNavigation).WithMany(p => p.Wizyties)
                .HasForeignKey(d => d.IdPracownika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pracownika");
        });

        modelBuilder.Entity<Wizytyuslugi>(entity =>
        {
            entity.HasKey(e => e.IdWizytyuslugi).HasName("wizytyuslugi_pkey");

            entity.ToTable("wizytyuslugi");

            entity.Property(e => e.IdWizytyuslugi).HasColumnName("id_wizytyuslugi");
            entity.Property(e => e.IdUslugi).HasColumnName("id_uslugi");
            entity.Property(e => e.IdWizyty).HasColumnName("id_wizyty");

            entity.HasOne(d => d.IdUslugiNavigation).WithMany(p => p.Wizytyuslugis)
                .HasForeignKey(d => d.IdUslugi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_uslugi");

            entity.HasOne(d => d.IdWizytyNavigation).WithMany(p => p.Wizytyuslugis)
                .HasForeignKey(d => d.IdWizyty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_wizyty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
