using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SiteWebTransactionnel.Models;
using SiteWebTransactionnel.Models.Transfert;
using SiteWebTransactionnel.Models.Vue;
using SiteWebTransactionnel.Services;

namespace SiteWebTransactionnel.Controllers;

public class ProduitsController(ProduitsService produitsService, IStringLocalizer<ProduitsController> localizer) : Controller
{
	private readonly IStringLocalizer<ProduitsController> _localizer = localizer;
	private readonly ProduitsService _produitsService = produitsService;

	[Route("[controller]/[action]/{id:int}")]
	[Route("[controller]/Details/{id:int}")]
	[HttpGet]
	public IActionResult Détails(int id)
	{
		try
		{
			Produit produit = _produitsService.Récupérer(id);
			ProduitDétailsVM produitDétailsVM = new(produit);

			return View(produitDétailsVM);
		}
		catch(KeyNotFoundException introuvable)
		{
			return NotFound(introuvable);
		}
	}

	[HttpGet]
	public IActionResult Liste()
	{
		try
		{
			Produit[] produits = _produitsService.RécupérerTout();
			List<ProduitListeVM> produitListeVMs = new();
			foreach(Produit produit in produits)
			{
				produitListeVMs.Add(new ProduitListeVM(produit));
			}
			return View(produitListeVMs.ToArray());
		}
		catch(ArgumentNullException nullException)
		{
			Console.WriteLine(nullException);
			return NotFound();
		}
	}

	[HttpGet]
	[Route("[controller]/[action]")]
	[Route("[controller]/Creer")]
	public IActionResult Créer()
	{
		try
		{
			return View();
		}
		catch(Exception introuvable)
		{
			return NotFound(introuvable);
		}
	}

	[HttpPost]
	[Route("[controller]/Creer")]
	public async Task<IActionResult> Créer(CréerProduit créerProduit)
	{
		try
		{
			Produit produit = await _produitsService.Créer(créerProduit);
			return RedirectToAction(nameof(Liste));
		}
		catch(KeyNotFoundException introuvable)
		{
			return NotFound(introuvable);
		}
		catch(Exception erreur)
		{
			Console.WriteLine(erreur);
			return View(); // TODO Afficher l'erreur.
		}
	}

	[HttpGet]
	public IActionResult Modifier(int id)
	{
		try
		{
			Produit produit = _produitsService.Récupérer(id);
			return View(produit);
		}
		catch(KeyNotFoundException introuvable)
		{
			return NotFound(introuvable);
		}
	}

	[HttpPost]
	public async Task<IActionResult> Modifier(int id, Produit nouveauProduit)
	{
		try
		{
			Produit produit = await _produitsService.Modifier(nouveauProduit);
			return RedirectToAction(nameof(Liste));
		}
		catch(KeyNotFoundException introuvable)
		{
			return NotFound(introuvable);
		}
	}

	[HttpGet]
	public IActionResult Supprimer(int id)
	{
		try
		{
			Produit produit = _produitsService.Récupérer(id);
			return View(produit);
		}
		catch(KeyNotFoundException introuvable)
		{
			return NotFound(introuvable);
		}
	}

	[HttpPost]
	public async Task<IActionResult> Supprimer(int id, Produit produit)
	{
		try 
		{
			bool succès = await _produitsService.Supprimer(id);
			return RedirectToAction(nameof(Liste));
		}
		catch(Exception erreur)
		{
			Console.WriteLine(erreur);
			return View(); // TODO Afficher l'erreur.
		}
	}
}
