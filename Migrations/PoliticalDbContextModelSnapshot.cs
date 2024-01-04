﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Feladat_2023._01._04.Migrations
{
    [DbContext(typeof(PoliticalDbContext))]
    partial class PoliticalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PoliticalParty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("LastVoteCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TimeFounded")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UploadedToDb")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("PoliticalParties");
                });

            modelBuilder.Entity("Politician", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid>("PoliticalPartyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UploadedToDb")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PoliticalPartyId");

                    b.ToTable("Politicians");
                });

            modelBuilder.Entity("Politician", b =>
                {
                    b.HasOne("PoliticalParty", "PoliticalParty")
                        .WithMany("Politicians")
                        .HasForeignKey("PoliticalPartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PoliticalParty");
                });

            modelBuilder.Entity("PoliticalParty", b =>
                {
                    b.Navigation("Politicians");
                });
#pragma warning restore 612, 618
        }
    }
}
