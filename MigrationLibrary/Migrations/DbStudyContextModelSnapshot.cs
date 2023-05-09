﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MigrationLibrary;

#nullable disable

namespace MigrationLibrary.Migrations
{
    [DbContext(typeof(DbStudyContext))]
    partial class DbStudyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MigrationLibrary.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiaSemana")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HoraFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("MateriaId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("NotificationStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("MigrationLibrary.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MateriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeMateria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("MigrationLibrary.Models.Agenda", b =>
                {
                    b.HasOne("MigrationLibrary.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("MigrationLibrary.Models.Materia", b =>
                {
                    b.HasOne("MigrationLibrary.Models.Materia", null)
                        .WithMany("Materias")
                        .HasForeignKey("MateriaId");
                });

            modelBuilder.Entity("MigrationLibrary.Models.Materia", b =>
                {
                    b.Navigation("Materias");
                });
#pragma warning restore 612, 618
        }
    }
}
