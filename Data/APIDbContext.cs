using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APICatalogo.Data;

public class APIDbContext : DbContext
{
    public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        //Categoria
        mb.Entity<Categoria>().
            HasKey(c => c.CategoriaId);

        mb.Entity<Categoria>().
            Property(c => c.Nome).
            HasMaxLength(100).
            IsRequired();

        mb.Entity<Categoria>().
            Property(c=>c.ImagemUrl).
            HasMaxLength(300).
            IsRequired();

        //Produto
        mb.Entity<Produto>().
           Property(c => c.Nome).
           HasMaxLength(100).
           IsRequired();

        mb.Entity<Produto>().
           Property(c => c.Descricao).
           HasMaxLength(300).
           IsRequired();

        mb.Entity<Produto>().
           Property(c => c.ImagemUrl).
           HasMaxLength(300).
           IsRequired();

        mb.Entity<Produto>().
           Property(c => c.Preco).
           HasPrecision(12,2).
           IsRequired();

        mb.Entity<Categoria>()
            .HasMany(c=>c.Produtos)
            .WithOne(c=>c.Categoria)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
          
    }

}