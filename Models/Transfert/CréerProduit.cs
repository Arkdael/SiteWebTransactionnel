using System.ComponentModel.DataAnnotations;

namespace SiteWebTransactionnel.Models.Transfert;

public class CréerProduit
{
	[Display(Name="ChampNom")]
	public required string Nom { get; set; }

	[Display(Name="ChampDescription")]
	public string Description { get; set; } = "";

	[Display(Name="ChampPrix")]
	public decimal Prix { get; set; }

	[Display(Name="ChampImages")]
	public IFormFile[]? Photos { get; set; } = [];
	public CréerProduit() {}
}
