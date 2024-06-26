﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using admin_panel.Data;

#nullable disable

namespace adminpanel.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240329132342_createdNewTableSchema")]
    partial class createdNewTableSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("admin_panel.Entity.Kategori", b =>
                {
                    b.Property<int>("kategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("kategoriId"));

                    b.Property<string>("kategoriName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kategoriId");

                    b.ToTable("kategoriler");
                });

            modelBuilder.Entity("admin_panel.Entity.Tablo", b =>
                {
                    b.Property<int>("tabloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tabloId"));

                    b.Property<string>("tabloName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tabloId");

                    b.ToTable("tablolar");
                });

            modelBuilder.Entity("admin_panel.Entity.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("kategoriId")
                        .HasColumnType("int");

                    b.Property<int>("tabloId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kategoriId");

                    b.HasIndex("tabloId");

                    b.ToTable("urunler");
                });

            modelBuilder.Entity("admin_panel.Entity.Urun", b =>
                {
                    b.HasOne("admin_panel.Entity.Kategori", "Kategori")
                        .WithMany()
                        .HasForeignKey("kategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("admin_panel.Entity.Tablo", "Tablo")
                        .WithMany()
                        .HasForeignKey("tabloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("Tablo");
                });
#pragma warning restore 612, 618
        }
    }
}
