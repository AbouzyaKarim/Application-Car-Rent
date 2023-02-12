﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rent.Service.VoitureAPI.DbContexts;

#nullable disable

namespace Rent.Service.VoitureAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230211234552_VoitureAPIDB")]
    partial class VoitureAPIDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Rent.Service.VoitureAPI.Models.Voiture", b =>
                {
                    b.Property<int>("VoitureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoitureId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriceByDay")
                        .HasColumnType("float");

                    b.Property<string>("marque")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("VoitureId");

                    b.ToTable("Voitures");

                    b.HasData(
                        new
                        {
                            VoitureId = 1,
                            CategoryName = "Citadine",
                            ImageURL = "https://artisanaka.blob.core.windows.net/artisana/v3.png",
                            PriceByDay = 540.0,
                            marque = "Peugeot 208"
                        },
                        new
                        {
                            VoitureId = 2,
                            CategoryName = "Citadine",
                            ImageURL = "https://artisanaka.blob.core.windows.net/artisana/v2.png",
                            PriceByDay = 400.0,
                            marque = "Dacia Sandero"
                        },
                        new
                        {
                            VoitureId = 3,
                            CategoryName = "Citadine",
                            ImageURL = "https://artisanaka.blob.core.windows.net/artisana/v1.png",
                            PriceByDay = 650.0,
                            marque = "Renault Clio 4"
                        },
                        new
                        {
                            VoitureId = 4,
                            CategoryName = "Citadine",
                            ImageURL = "https://artisanaka.blob.core.windows.net/artisana/v4.png",
                            PriceByDay = 450.0,
                            marque = "Citroën C3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
