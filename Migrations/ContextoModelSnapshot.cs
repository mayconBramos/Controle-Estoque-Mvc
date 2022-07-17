﻿// <auto-generated />
using System;
using GestaoEstoque.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleEstoque.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ControleEstoque.Models.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Lote");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome/Marca");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<DateTime>("Recebimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Recebimento");

                    b.Property<DateTime>("Retirada")
                        .HasColumnType("datetime2")
                        .HasColumnName("Retirada");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2")
                        .HasColumnName("Validade");

                    b.HasKey("Id");

                    b.ToTable("Entrada-Estoque");
                });

            modelBuilder.Entity("ControleEstoque.Models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Lote");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome/Marca");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<DateTime>("Recebimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Recebimento");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2")
                        .HasColumnName("Validade");

                    b.HasKey("Id");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("ControleEstoque.Models.Saida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Lote");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome/Marca");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<DateTime>("Retirada")
                        .HasColumnType("datetime2")
                        .HasColumnName("Retirada");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2")
                        .HasColumnName("Validade");

                    b.HasKey("Id");

                    b.ToTable("Saida");
                });
#pragma warning restore 612, 618
        }
    }
}
