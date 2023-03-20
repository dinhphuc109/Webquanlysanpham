﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webquanlysanpham.Data;

#nullable disable

namespace Webquanlysanpham.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Webquanlysanpham.Models.DonViTinh", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("DVTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaDVT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("donViTinhs");
                });

            modelBuilder.Entity("Webquanlysanpham.Models.NhaCungCap", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNCC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("nhaCungCaps");
                });

            modelBuilder.Entity("Webquanlysanpham.Models.SanPham", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<long?>("DvtID")
                        .HasColumnType("bigint");

                    b.Property<double>("GiaSP")
                        .HasColumnType("float");

                    b.Property<string>("LoaiSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongSP")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("sanPhams");
                });

            modelBuilder.Entity("Webquanlysanpham.Models.SanPham_NhaCungCap", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<long?>("NCCID")
                        .HasColumnType("bigint");

                    b.Property<long?>("SanPhamID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("sanPham_NhaCungCaps");
                });
#pragma warning restore 612, 618
        }
    }
}