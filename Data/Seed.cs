using SiteWebTransactionnel.Models;

namespace SiteWebTransactionnel.Data;

public class Seed
{
	public static readonly Produit[] SeedProduits = [
		new Produit(pId: 1, pNom: "nom", pDescription: "description", pPrix: 10m),
		new Produit(pId: 2, pNom: "Lorem", pDescription: "Ipsum", pPrix: 20m),
		new Produit(pId: 3, pNom: "Ipsum", pDescription: "Lorem", pPrix: 30m),
	];
}