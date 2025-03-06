﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using driveCom;

#nullable disable

namespace driveCom.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20250221170009_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.13");

            modelBuilder.Entity("driveCom.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageSource")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mileage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
