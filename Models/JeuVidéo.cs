namespace SiteWebTransactionnel.Models;

public class JeuVidéo : Produit
{
	public string? Développeur { get; set; }
	public string? Éditeur { get; set; }
	public string[] Genres { get; set; } = [];
	public Plateforme[] Plateformes { get; set; } = [];
}
