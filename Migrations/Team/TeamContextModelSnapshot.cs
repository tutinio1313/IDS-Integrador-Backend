﻿// <auto-generated />
using System;
using IDS_Integrador.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IDS_Integrador.Migrations.Team
{
    [DbContext(typeof(TeamContext))]
    partial class TeamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("IDS_Integrador.Model.Entity.Team.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdCategory");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("IDS_Integrador.Model.Entity.Team.Match", b =>
                {
                    b.Property<int>("IDMatch")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LocalTeamGoals")
                        .HasColumnType("int");

                    b.Property<int>("LocalTeamID")
                        .HasColumnType("int");

                    b.Property<int>("VisitTeamGoals")
                        .HasColumnType("int");

                    b.Property<int>("VisitorTeamID")
                        .HasColumnType("int");

                    b.HasKey("IDMatch");

                    b.HasIndex("CategoryID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("IDS_Integrador.Model.Entity.Team.Player", b =>
                {
                    b.Property<int>("IDPlayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Dorsal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("IDPlayer");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("IDS_Integrador.Model.Entity.Team.Team", b =>
                {
                    b.Property<int>("IDTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IDTeam");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("IDS_Integrador.Model.Entity.Team.Match", b =>
                {
                    b.HasOne("IDS_Integrador.Model.Entity.Team.Category", "category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}
