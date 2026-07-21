using System.Diagnostics.CodeAnalysis;

namespace SiteWebTransactionnel.Models;

public class CréerProduit // Pourrait être une interface.
{
	public required string Nom { get; set; }
	public string Description { get; set; } = "";
	public decimal Prix { get; set; }

	public CréerProduit() {}
}
