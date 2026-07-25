using System.Diagnostics.CodeAnalysis;

namespace SiteWebTransactionnel.Models.Vue;

public class ProduitDetailsVM
{
	public int Id { get; set; }
	public required string Nom { get; set; }
	public string Description { get; set; } = "";
	public decimal Prix { get; set; }
	public string[] Images { get; set; } = []; // Images représentées en string.
	public ProduitDetailsVM() {}

	[SetsRequiredMembers]
	public ProduitDetailsVM(int pId, string pNom, string pDescription, decimal pPrix)
	{
		Id = pId;
		Nom = pNom;
		Description = pDescription;
		Prix = pPrix;
	}

	[SetsRequiredMembers]
	public ProduitDetailsVM(Produit produit)
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
