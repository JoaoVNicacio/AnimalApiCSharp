﻿// <auto-generated />
using System;
using AnimalApiCSharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimalApiCSharp.Migrations
{
    [DbContext(typeof(AnimalContext))]
    [Migration("20230224141201_UpdateDB")]
    partial class UpdateDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AnimalApiCSharp.Models.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CommonName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("common_name");

                    b.Property<string>("GenericName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("generic_name");

                    b.Property<string>("SpeciesName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("species_name");

                    b.HasKey("Id");

                    b.ToTable("animals", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
