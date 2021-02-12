﻿// <auto-generated />
using System;
using HargaSaham.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HargaSaham.Migrations
{
    [DbContext(typeof(SahamContext))]
    [Migration("20210210085331_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("HargaSaham.Models.Saham", b =>
                {
                    b.Property<int>("SahamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Harga")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("NamaSaham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SektorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SahamID");

                    b.HasIndex("SektorId");

                    b.ToTable("Sahams");

                    b.HasData(
                        new
                        {
                            SahamID = 1,
                            Harga = 1900,
                            NamaSaham = "WIKA",
                            SektorId = "I"
                        },
                        new
                        {
                            SahamID = 2,
                            Harga = 2000,
                            NamaSaham = "BRIS",
                            SektorId = "B"
                        });
                });

            modelBuilder.Entity("HargaSaham.Models.Sektor", b =>
                {
                    b.Property<string>("SektorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nama")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SektorId");

                    b.ToTable("Sektors");

                    b.HasData(
                        new
                        {
                            SektorId = "I",
                            Nama = "Infra"
                        },
                        new
                        {
                            SektorId = "B",
                            Nama = "Banking"
                        },
                        new
                        {
                            SektorId = "M",
                            Nama = "Mining"
                        });
                });

            modelBuilder.Entity("HargaSaham.Models.Saham", b =>
                {
                    b.HasOne("HargaSaham.Models.Sektor", "Sektor")
                        .WithMany()
                        .HasForeignKey("SektorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sektor");
                });
#pragma warning restore 612, 618
        }
    }
}
