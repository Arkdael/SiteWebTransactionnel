using SiteWebTransactionnel.Models;

namespace SiteWebTransactionnel.Data;

public class Seed
{
	public static readonly Produit[] SeedProduits = [
		new Produit(pId: 1, pNom: "Crayon à mine", pDescription: "Pour écrire et/ou dessiner (mais pas colorier).", pPrix: 10m),
		new Produit(pId: 2, pNom: "Chapeau", pDescription: "Protège très bien du soleil.", pPrix: 20m),
		new Produit(pId: 3, pNom: "Tournevis", pDescription: "Parfais pour clouer des clous.", pPrix: 30m),
	];
}
