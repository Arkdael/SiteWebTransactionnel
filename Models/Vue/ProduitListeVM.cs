using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SiteWebTransactionnel.Models.Vue;

public class ProduitListeVM
{
	[Display(Name="ChampId")]
	public int Id { get; set; }

	[Display(Name="ChampNom")]
	public required string Nom { get; set; }

	[Display(Name="ChampDescription")]
	public string Description { get; set; } = "";

	[Display(Name="ChampPrix")]
	public decimal Prix { get; set; }

	[Display(Name="ChampImages")]
	public string[] Images { get; set; } = []; // Images représentées en string.
	
	public ProduitListeVM() {}

	[SetsRequiredMembers]
	public ProduitListeVM(int pId, string pNom, string pDescription, decimal pPrix)
	{
		Id = pId;
		Nom = pNom;
		Description = pDescription;
		Prix = pPrix;
	}

	[SetsRequiredMembers]
	public ProduitListeVM(Produit produit)
	{
		try
		{
			Id = produit.Id;
			Nom = produit.Nom;
			Description = produit.Description;
			Prix = produit.Prix;
			Images = produit.Images.Count() > 0 ? ConvertirPhotos(produit.Images) : [];
		}
		catch(Exception exception)
		{
			Console.WriteLine(exception);
			Id = produit.Id;
			Nom = produit.Nom;
			Description = produit.Description;
			Prix = produit.Prix;
			Images = [];
		}
	}
		private static string[] ConvertirPhotos(ICollection<ImageProduit> photos)
	{
		string[] chaines = [];
		foreach(ImageProduit photo in photos)
		{
			string chaine = $"data:{photo.TypeMédia};base64, {Convert.ToBase64String(photo.Image)}";
			chaines = [.. chaines, chaine];
		}
		return chaines;
	}
}
