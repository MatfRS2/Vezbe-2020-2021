﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prodavnica2.Models;

namespace Prodavnica2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prodavnica2.Models.KorpaElement", b =>
                {
                    b.Property<int>("KorpaElementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int?>("PorudzbinaID")
                        .HasColumnType("int");

                    b.Property<int?>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("KorpaElementID");

                    b.HasIndex("PorudzbinaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("KorpaElement");
                });

            modelBuilder.Entity("Prodavnica2.Models.Porudzbina", b =>
                {
                    b.Property<int>("PorudzbinaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adresa2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Drzava")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeGrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Poklon")
                        .HasColumnType("bit");

                    b.Property<bool>("Poslato")
                        .HasColumnType("bit");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PorudzbinaID");

                    b.ToTable("Porudzbine");
                });

            modelBuilder.Entity("Prodavnica2.Models.Proizvod", b =>
                {
                    b.Property<int>("ProizvodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kategorija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaPutanja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProizvodID");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("Prodavnica2.Models.KorpaElement", b =>
                {
                    b.HasOne("Prodavnica2.Models.Porudzbina", null)
                        .WithMany("listaProizvodaUKorpi")
                        .HasForeignKey("PorudzbinaID");

                    b.HasOne("Prodavnica2.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID");
                });
#pragma warning restore 612, 618
        }
    }
}
