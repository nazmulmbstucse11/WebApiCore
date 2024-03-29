﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApiFirst.Repositories;

namespace WebApiFirst.Migrations
{
    [DbContext(typeof(MainDBContext))]
    partial class MainDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebApiFirst.Models.ExceptionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ExceptionType")
                        .HasColumnType("text");

                    b.Property<string>("Logtime")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExceptionTable");
                });

            modelBuilder.Entity("WebApiFirst.Models.Person", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("PersonTable");
                });

            modelBuilder.Entity("WebApiFirst.Models.RequestLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Logtime")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RequestTable");
                });

            modelBuilder.Entity("WebApiFirst.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.Property<string>("ExecutorAddress")
                        .HasColumnType("text");

                    b.Property<string>("ExecutorMobile")
                        .HasColumnType("text");

                    b.Property<string>("ExecutorName")
                        .HasColumnType("text");

                    b.Property<string>("RequesterAddress")
                        .HasColumnType("text");

                    b.Property<string>("RequesterMobile")
                        .HasColumnType("text");

                    b.Property<string>("RequesterName")
                        .HasColumnType("text");

                    b.Property<string>("TaskName")
                        .HasColumnType("text");

                    b.Property<bool>("isComplete")
                        .HasColumnType("boolean");

                    b.HasKey("TaskId");

                    b.ToTable("TaskTable");
                });
#pragma warning restore 612, 618
        }
    }
}
