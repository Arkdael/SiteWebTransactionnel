using Microsoft.EntityFrameworkCore;
using SiteWebTransactionnel.Models;

namespace SiteWebTransactionnel.Data;

public class BdContexte(DbContextOptions<BdContexte> options) : DbContext(options)
{
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<Produit>().HasData(Seed.SeedProduits);
	}

	public DbSet<Produit> Produits { get; set; }
	public DbSet<ImageProduit> Images { get; set; }
	public DbSet<JeuVidéo> JeuVidéo { get; set; } = default!;
}
