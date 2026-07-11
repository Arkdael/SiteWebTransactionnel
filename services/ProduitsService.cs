using SiteWebTransactionnel.Data;
using SiteWebTransactionnel.Models;

namespace SiteWebTransactionnel.Controllers;

public class ProduitsService(BdContexte contexte)
{
	private readonly BdContexte _contexte = contexte;

	public Produit Récupérer(int id)
	{
		Produit produit = _contexte.Produits.ToArray().First(p => p.Id == id) ?? throw new KeyNotFoundException();
		return produit;
	}

	public Produit[] RécupérerTout()
	{
		Produit[] produits = _contexte.Produits.ToArray();
		return produits;
	}

	public Produit Créer()
	{
		throw new NotImplementedException();
	}

	public Produit Modifier()
	{
		Produit produit = _contexte.Produits.Where(p => p.Id == -1).First() ?? throw new KeyNotFoundException();
		throw new NotImplementedException();
	}

	public bool Supprimer(int id)
	{
		Produit produit = _contexte.Produits.Where(p => p.Id == id).Single() ?? throw new KeyNotFoundException();
		_contexte.Produits.Remove(produit);
		return true;
	}
}
