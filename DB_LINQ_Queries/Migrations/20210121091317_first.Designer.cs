﻿// <auto-generated />
using DB_LINQ_Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB_LINQ_Queries.Migrations
{
    [DbContext(typeof(CarShowroom))]
    [Migration("20210121091317_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DB_LINQ_Queries.Car", b =>
                {
                    b.Property<int>("carId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("carColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("carYear")
                        .HasColumnType("int");

                    b.HasKey("carId");

                    b.ToTable("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
