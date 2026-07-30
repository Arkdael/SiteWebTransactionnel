using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using SiteWebTransactionnel.Models.Transfert;

namespace SiteWebTransactionnel.Models;

public class Produit
{
	[Key]
	public int Id { get; set; }
	public required string Nom { get; set; }
	public string Description { get; set; } = "";
	public decimal Prix { get; set; }

	public virtual ICollection<ImageProduit> Images { get; set; } = [];

	public Produit() {}

	[SetsRequiredMembers]
	public Produit(int pId, string pNom, string pDescription, decimal pPrix)
	{
		Id = pId;
		Nom = pNom;
		Description = pDescription;
		Prix = pPrix;
	}

	[SetsRequiredMembers]
	public Produit(CréerProduit créerProduit)
	{
		Nom = créerProduit.Nom;
		Description = créerProduit.Description;
		Prix = créerProduit.Prix;
	}
}
