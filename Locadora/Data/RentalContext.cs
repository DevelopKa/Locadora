using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rental.Models;

namespace Rental.Data
{
    public partial class RentalContext : DbContext
    {
        public RentalContext()
        {
        }

        public RentalContext(DbContextOptions<RentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Filme> Filmes { get; set; } = null!;
        public virtual DbSet<Locacao> Locacaos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.HasIndex(e => e.Cpf, "IDX_CPF");

                entity.HasIndex(e => e.Nome, "IDX_NOME");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Nome).HasMaxLength(200);
            });

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.ToTable("filme");

                entity.HasIndex(e => e.Lancamento, "IDX_LANCAMENTO");

                entity.HasIndex(e => e.Titulo, "IDX_TITULO");

                entity.Property(e => e.Titulo).HasMaxLength(100);
            });

            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.ToTable("locacao");

                entity.HasIndex(e => e.IdCliente, "fk_Cliente");

                entity.HasIndex(e => e.IdFilme, "fk_Filme");

                entity.Property(e => e.DataDevolucao).HasColumnType("datetime");

                entity.Property(e => e.DataLocacao).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.IdFilme).HasColumnName("Id_Filme");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_Cliente");

                entity.HasOne(d => d.Filme)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("fk_Filme");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
