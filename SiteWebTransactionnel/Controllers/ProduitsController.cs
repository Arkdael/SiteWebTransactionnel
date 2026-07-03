using Microsoft.AspNetCore.Mvc;
using SiteWebTransactionnel.Models;

namespace SiteWebTransactionnel.Controllers;

public class ProduitsController(ProduitsService produitsService) : Controller
{
	private readonly ProduitsService _produitsService = produitsService;

	[Route("[controller]/[action]/{id:int}")]
	[HttpGet]
	public IActionResult Details(int id)
	{
		try
		{
			Produit produit = _produitsService.Récupérer(id);
			return View("Details", produit);
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
			return View(produits);
		}
		catch(Exception exception)
		{
			Console.WriteLine(exception);
			return View(); // TODO Afficher l'erreur.
		}
	}

	[HttpPost]
	public IActionResult Créer()
	{
		throw new NotImplementedException();
	}

	[HttpPut]
	public IActionResult Modifier()
	{
		throw new NotImplementedException();
	}

	[HttpPost]
	public IActionResult Supprimer()
	{
		throw new NotImplementedException();
	}
}
