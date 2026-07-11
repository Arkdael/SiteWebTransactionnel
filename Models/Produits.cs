using System.Diagnostics.CodeAnalysis;

namespace SiteWebTransactionnel.Models;

public class Produit
{
	public int Id { get; set; }
	public required string Nom { get; set; }
	public string Description { get; set; } = "";
	public decimal Prix { get; set; }

	public Produit() {}

	[SetsRequiredMembers]
	public Produit(int pId, string pNom, string pDescription, decimal pPrix)
	{
		this.Id = pId;
		this.Nom = pNom;
		this.Description = pDescription;
		this.Prix = pPrix;
	}
}
