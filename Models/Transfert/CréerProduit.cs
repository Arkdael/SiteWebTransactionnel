namespace SiteWebTransactionnel.Models.Transfert;

public class CréerProduit // Pourrait être une interface.
{
	public required string Nom { get; set; }
	public string Description { get; set; } = "";
	public decimal Prix { get; set; }
	public IFormFile[]? Photos { get; set; } = [];
	public CréerProduit() {}
}
