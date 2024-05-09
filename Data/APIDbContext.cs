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
}