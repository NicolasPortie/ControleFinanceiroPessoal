﻿// <auto-generated />
using System;
using ControleFinanceiroPessoal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleFinanceiroPessoal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241208033820_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.CategoriaInvestimento", b =>
                {
                    b.Property<int>("IdCategoriaInvestimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoriaInvestimento"));

                    b.Property<decimal?>("JurosAnual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NomeInvestimento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("TaxaJuros")
                        .HasColumnType("bit");

                    b.Property<string>("TipoCategoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdCategoriaInvestimento");

                    b.ToTable("CategoriaInvestimento");
                });

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.ContaFinanceira", b =>
                {
                    b.Property<int>("IdContaFinanceira")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContaFinanceira"));

                    b.Property<string>("NomeInstituicao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SaldoAtual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoConta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContaFinanceira");

                    b.ToTable("ContasFinanceiras");
                });

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.Despesa", b =>
                {
                    b.Property<int>("IdDespesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDespesa"));

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdContaFinanceira")
                        .HasColumnType("int");

                    b.Property<string>("Intervalo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroParcelas")
                        .HasColumnType("int");

                    b.Property<bool>("PagamentoRealizado")
                        .HasColumnType("bit");

                    b.Property<int>("ParcelasRestantes")
                        .HasColumnType("int");

                    b.Property<bool>("Recorrente")
                        .HasColumnType("bit");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDespesa");

                    b.HasIndex("IdContaFinanceira");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.Investimento", b =>
                {
                    b.Property<int>("IdInvestimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInvestimento"));

                    b.Property<DateTime>("DataInvestimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoriaInvestimento")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValorFuturo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorInvestido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdInvestimento");

                    b.HasIndex("IdCategoriaInvestimento");

                    b.ToTable("Investimentos");
                });

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.Receita", b =>
                {
                    b.Property<int>("IdReceita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReceita"));

                    b.Property<DateTime?>("DataFinalRecebimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRecebimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormaRecebimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdContaFinanceira")
                        .HasColumnType("int");

                    b.Property<string>("Intervalo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Recorrente")
                        .HasColumnType("bit");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdReceita");

                    b.HasIndex("IdContaFinanceira");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.Despesa", b =>
                {
                    b.HasOne("ControleFinanceiroPessoal.Models.ContaFinanceira", "ContaFinanceira")
                        .WithMany("Despesas")
                        .HasForeignKey("IdContaFinanceira")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContaFinanceira");
                });

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.Investimento", b =>
                {
                    b.HasOne("ControleFinanceiroPessoal.Models.CategoriaInvestimento", "CategoriaInvestimento")
                        .WithMany("Investimentos")
                        .HasForeignKey("IdCategoriaInvestimento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaInvestimento");
                });

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.Receita", b =>
                {
                    b.HasOne("ControleFinanceiroPessoal.Models.ContaFinanceira", "ContaFinanceira")
                        .WithMany("Receitas")
                        .HasForeignKey("IdContaFinanceira")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContaFinanceira");
                });

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.CategoriaInvestimento", b =>
                {
                    b.Navigation("Investimentos");
                });

            modelBuilder.Entity("ControleFinanceiroPessoal.Models.ContaFinanceira", b =>
                {
                    b.Navigation("Despesas");

                    b.Navigation("Receitas");
                });
#pragma warning restore 612, 618
        }
    }
}