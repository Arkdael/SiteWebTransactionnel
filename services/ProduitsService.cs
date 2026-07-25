using Microsoft.EntityFrameworkCore;
using SiteWebTransactionnel.Data;
using SiteWebTransactionnel.Models;
using SiteWebTransactionnel.Models.Transfert;

namespace SiteWebTransactionnel.Services;

public class ProduitsService(BdContexte contexte)
{
	private readonly BdContexte _contexte = contexte;

	public Produit Récupérer(int id)
	{
		Produit produit = _contexte.Produits.Include(p => p.Images).First(p => p.Id == id) ?? throw new KeyNotFoundException();
		return produit;
	}

	public Produit[] RécupérerTout()
	{
		Produit[] produits = _contexte.Produits.Include(p => p.Images).ToArray();
		return produits;
	}

	public async Task<Produit> Créer(CréerProduit créerProduit)
	{
		Produit nouveauProduit = new(créerProduit);
		_contexte.Produits.Add(nouveauProduit);
		await _contexte.SaveChangesAsync();

		if(créerProduit.Photos != null)
		{
			foreach(IFormFile photo in créerProduit.Photos)
			{
				ImageProduit image = new(photo, nouveauProduit.Id, photo.FileName);
				_contexte.Images.Add(image);
			}
		}

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
