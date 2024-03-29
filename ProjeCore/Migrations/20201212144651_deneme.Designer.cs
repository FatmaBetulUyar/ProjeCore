﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjeCore.Models;

namespace ProjeCore.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201212144651_deneme")]
    partial class deneme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ProjeCore.Models.Birim", b =>
                {
                    b.Property<int>("BirimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BirimAd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BirimID");

                    b.ToTable("birims");
                });

            modelBuilder.Entity("ProjeCore.Models.Personel", b =>
                {
                    b.Property<int>("PersonelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BirimID")
                        .HasColumnType("int");

                    b.Property<string>("Sehir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonelID");

                    b.HasIndex("BirimID");

                    b.ToTable("personels");
                });

            modelBuilder.Entity("ProjeCore.Models.Personel", b =>
                {
                    b.HasOne("ProjeCore.Models.Birim", "birim")
                        .WithMany("personels")
                        .HasForeignKey("BirimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("birim");
                });

            modelBuilder.Entity("ProjeCore.Models.Birim", b =>
                {
                    b.Navigation("personels");
                });
#pragma warning restore 612, 618
        }
    }
}
