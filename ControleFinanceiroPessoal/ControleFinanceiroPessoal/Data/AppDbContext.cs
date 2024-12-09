using Microsoft.EntityFrameworkCore;
using ControleFinanceiroPessoal.Models;

namespace ControleFinanceiroPessoal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definição das tabelas
        public DbSet<ContaFinanceira> ContasFinanceiras { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }
        public DbSet<CategoriaInvestimento> CategoriaInvestimentos { get; set; }

        // Configuração das tabelas e relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de CategoriaInvestimento
            modelBuilder.Entity<CategoriaInvestimento>()
                .HasKey(ci => ci.IdCategoriaInvestimento);

            modelBuilder.Entity<CategoriaInvestimento>()
                .Property(ci => ci.NomeInvestimento)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<CategoriaInvestimento>()
                .Property(ci => ci.TipoCategoria)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<CategoriaInvestimento>()
                .Property(ci => ci.JurosAnual)
                .HasColumnType("decimal(18,2)");

            // Configuração de Investimento
            modelBuilder.Entity<Investimento>()
                .HasKey(i => i.IdInvestimento);

            modelBuilder.Entity<Investimento>()
                .Property(i => i.ValorInvestido)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Investimento>()
                .Property(i => i.ValorFuturo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Investimento>()
                .HasOne(i => i.CategoriaInvestimento)
                .WithMany(ci => ci.Investimentos)
                .HasForeignKey(i => i.IdCategoriaInvestimento)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração de ContaFinanceira
            modelBuilder.Entity<ContaFinanceira>()
                .HasKey(cf => cf.IdContaFinanceira);

            modelBuilder.Entity<ContaFinanceira>()
                .Property(cf => cf.SaldoAtual)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Configuração de Despesa
            modelBuilder.Entity<Despesa>()
                .HasKey(d => d.IdDespesa);

            modelBuilder.Entity<Despesa>()
                .Property(d => d.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Despesa>()
                .HasOne(d => d.ContaFinanceira)
                .WithMany(cf => cf.Despesas)
                .HasForeignKey(d => d.IdContaFinanceira)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração de Receita
            modelBuilder.Entity<Receita>()
                .HasKey(r => r.IdReceita);

            modelBuilder.Entity<Receita>()
                .Property(r => r.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Receita>()
                .HasOne(r => r.ContaFinanceira)
                .WithMany(cf => cf.Receitas)
                .HasForeignKey(r => r.IdContaFinanceira)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
