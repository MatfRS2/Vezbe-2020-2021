﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prodavnica.Models;

namespace Prodavnica.Migrations
{
    [DbContext(typeof(ApplicationDbContex))]
    partial class ApplicationDbContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prodavnica.Models.KorpaElement", b =>
                {
                    b.Property<int>("KorpaElementId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kolicina");

                    b.Property<int?>("PorudzbinaId");

                    b.Property<int?>("ProizvodId");

                    b.HasKey("KorpaElementId");

                    b.HasIndex("PorudzbinaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("KorpaElement");
                });

            modelBuilder.Entity("Prodavnica.Models.Porudzbina", b =>
                {
                    b.Property<int>("PorudzbinaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa1")
                        .IsRequired();

                    b.Property<string>("Adresa2");

                    b.Property<string>("Drzava")
                        .IsRequired();

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<string>("ImeGrada")
                        .IsRequired();

                    b.Property<bool>("Poklon");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired();

                    b.HasKey("PorudzbinaId");

                    b.ToTable("Porudzbine");
                });

            modelBuilder.Entity("Prodavnica.Models.Proizvod", b =>
                {
                    b.Property<int>("ProizvodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cena");

                    b.Property<string>("Ime");

                    b.Property<string>("Kategorija");

                    b.Property<string>("Opis");

                    b.Property<string>("SlikaPutanja");

                    b.HasKey("ProizvodId");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("Prodavnica.Models.KorpaElement", b =>
                {
                    b.HasOne("Prodavnica.Models.Porudzbina")
                        .WithMany("ListaProizvodaUKorpi")
                        .HasForeignKey("PorudzbinaId");

                    b.HasOne("Prodavnica.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId");
                });
#pragma warning restore 612, 618
        }
    }
}
