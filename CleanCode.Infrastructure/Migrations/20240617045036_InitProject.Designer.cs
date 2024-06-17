﻿// <auto-generated />
using System;
using CleanCode.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanCode.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240617045036_InitProject")]
    partial class InitProject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanCode.Domain.Entities.Data", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("created_by");

                    b.Property<int?>("Index")
                        .HasColumnType("int")
                        .HasColumnName("index");

                    b.Property<string>("Model")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("model");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2")
                        .HasColumnName("time");

                    b.Property<string>("TimeLine")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("timeline");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("data");
                });
#pragma warning restore 612, 618
        }
    }
}
