﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Winecellar.Infrastructure.Context;

#nullable disable

namespace Winecellar.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241221143522_AddRefreshTokens")]
    partial class AddRefreshTokens
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Winecellar.Domain.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("SetAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("set_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("token");

                    b.Property<Guid>("UserId")
                        .HasColumnType("UUID")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("refresh_tokens");
                });

            modelBuilder.Entity("Winecellar.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80967cc2-9bef-4620-8a7d-15e55a1d2231"),
                            Email = "user1@mail.com",
                            Password = "123",
                            Username = "User1"
                        },
                        new
                        {
                            Id = new Guid("34cc7e90-39de-41f3-b5db-a86b0c4e9008"),
                            Email = "user2@mail.com",
                            Password = "123",
                            Username = "User2"
                        });
                });

            modelBuilder.Entity("Winecellar.Domain.Models.Wine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(36)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("wines");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5b3313d-5336-4663-82a3-dd2287ab6930"),
                            Name = "Wine 1"
                        },
                        new
                        {
                            Id = new Guid("9ac1e64a-417f-4a3e-ab83-82478d2331e7"),
                            Name = "Wine 2"
                        });
                });

            modelBuilder.Entity("Winecellar.Domain.Models.RefreshToken", b =>
                {
                    b.HasOne("Winecellar.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}