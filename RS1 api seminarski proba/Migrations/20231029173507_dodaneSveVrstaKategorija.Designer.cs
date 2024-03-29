﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RS1_api_seminarski_proba.Data;

#nullable disable

namespace RS1_api_seminarski_proba.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231029173507_dodaneSveVrstaKategorija")]
    partial class dodaneSveVrstaKategorija
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Brend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brend");
                });

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Kategorije.GlavnaKategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GlavnaKategorija");
                });

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Kategorije.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Kategorije.KategorijaGlavnaKategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GlavnaKategorijaID")
                        .HasColumnType("int");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GlavnaKategorijaID");

                    b.HasIndex("KategorijaID");

                    b.ToTable("KategorijaGlavnaKategorija");
                });

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Kategorije.KategorijaPotkategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<int>("PotkategorijaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("PotkategorijaID");

                    b.ToTable("KategorijaPotkategorija");
                });

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Kategorije.Potkategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Potkategorija");
                });

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrendID")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PocetnaCijena")
                        .HasColumnType("real");

                    b.Property<int>("PotkategorijaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrendID");

                    b.HasIndex("PotkategorijaID");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Kategorije.KategorijaGlavnaKategorija", b =>
                {
                    b.HasOne("RS1_api_seminarski_proba.Modul1.Models.Kategorije.GlavnaKategorija", "GlavnaKategorija")
                        .WithMany()
                        .HasForeignKey("GlavnaKategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_api_seminarski_proba.Modul1.Models.Kategorije.GlavnaKategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GlavnaKategorija");

                    b.Navigation("Kategorija");
                });

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Kategorije.KategorijaPotkategorija", b =>
                {
                    b.HasOne("RS1_api_seminarski_proba.Modul1.Models.Kategorije.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_api_seminarski_proba.Modul1.Models.Kategorije.Potkategorija", "Potkategorija")
                        .WithMany()
                        .HasForeignKey("PotkategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorija");

                    b.Navigation("Potkategorija");
                });

            modelBuilder.Entity("RS1_api_seminarski_proba.Modul1.Models.Proizvod", b =>
                {
                    b.HasOne("RS1_api_seminarski_proba.Modul1.Models.Brend", "Brend")
                        .WithMany()
                        .HasForeignKey("BrendID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_api_seminarski_proba.Modul1.Models.Kategorije.Potkategorija", "Potkategorija")
                        .WithMany()
                        .HasForeignKey("PotkategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brend");

                    b.Navigation("Potkategorija");
                });
#pragma warning restore 612, 618
        }
    }
}
