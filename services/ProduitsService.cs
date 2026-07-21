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

	public async Task<Produit> Créer(CréerProduit créerProduit)
	{
		Produit nouveauProduit = new(créerProduit);
		_contexte.Produits.Add(nouveauProduit);
		await _contexte.SaveChangesAsync();

		return nouveauProduit;
	}

	public async Task<Produit> Modifier(Produit produit)
	{
		_contexte.Produits.Update(produit);
		await _contexte.SaveChangesAsync();

		return produit;
	}

	public async Task<bool> Supprimer(int id)
	{
		Produit produit = _contexte.Produits.Where(p => p.Id == id).Single() ?? throw new KeyNotFoundException();
		_contexte.Produits.Remove(produit);
		await _contexte.SaveChangesAsync();
		return true;
	}
}
