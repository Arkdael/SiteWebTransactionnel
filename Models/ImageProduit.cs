using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SiteWebTransactionnel.Models;

public class ImageProduit
{
	[Key]
	public int Id { get; set; }
	public int ProduitId { get; set; }
	public required byte[] Image { get; set; }
	public required string Nom { get; set; }
	public string TypeMédia { get; set; } = "image/jpg";

	[ForeignKey(nameof(ProduitId))]
	public virtual Produit Produit { get; init; } = null!;

	public ImageProduit() {}

	[SetsRequiredMembers]
	public ImageProduit(IFormFile fichier, int produitId, string nom)
	{			
		Image = ExtraireOctetsFichier(fichier);
		ProduitId = produitId;
		Nom = nom;
		TypeMédia = fichier.ContentType;
	}

	private static byte[] ExtraireOctetsFichier(IFormFile fichier)
	{
		MemoryStream flux = new();
		fichier.CopyTo(flux);
		byte[] octets = flux.ToArray();
		return octets;
	}
}
