using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Lanche> Lanches { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().Property(p => p.CategotiaId).HasDefaultValueSql("uuid_generate_v4 ()");
        modelBuilder.Entity<Lanche>().Property(p => p.LancheId).HasDefaultValueSql("uuid_generate_v4 ()");
        modelBuilder.Entity<CarrinhoCompraItem>().Property(p => p.CarrinhoCompraItemId)
            .HasDefaultValueSql("uuid_generate_v4 ()");
    }
}