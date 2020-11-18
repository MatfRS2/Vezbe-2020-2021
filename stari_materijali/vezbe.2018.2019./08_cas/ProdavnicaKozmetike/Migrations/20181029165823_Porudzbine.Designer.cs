﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProdavnicaKozmetike.Models;

namespace ProdavnicaKozmetike.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181029165823_Porudzbine")]
    partial class Porudzbine
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProdavnicaKozmetike.Models.KorpaElement", b =>
                {
                    b.Property<int>("KorpaElementID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kolicina");

                    b.Property<int?>("PorudzbinaID");

                    b.Property<int?>("ProizvodID");

                    b.HasKey("KorpaElementID");

                    b.HasIndex("PorudzbinaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("KorpaElement");
                });

            modelBuilder.Entity("ProdavnicaKozmetike.Models.Porudzbina", b =>
                {
                    b.Property<int>("PorudzbinaID")
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

                    b.HasKey("PorudzbinaID");

                    b.ToTable("Porudzbine");
                });

            modelBuilder.Entity("ProdavnicaKozmetike.Models.Proizvod", b =>
                {
                    b.Property<int>("ProizvodID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cena");

                    b.Property<string>("Ime");

                    b.Property<string>("Kategorija");

                    b.Property<string>("Opis");

                    b.HasKey("ProizvodID");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("ProdavnicaKozmetike.Models.KorpaElement", b =>
                {
                    b.HasOne("ProdavnicaKozmetike.Models.Porudzbina")
                        .WithMany("listaProizvodaUKorpi")
                        .HasForeignKey("PorudzbinaID");

                    b.HasOne("ProdavnicaKozmetike.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID");
                });
#pragma warning restore 612, 618
        }
    }
}