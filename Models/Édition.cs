namespace SiteWebTransactionnel.Models;

public class Édition
{
	public int Id { get; set; }
	public required JeuVidéo Jeu { get; set; }
	public required Plateforme Plateforme { get; set; }
	public SupportMédia Support { get; set; }
	public DateTime DateSortie { get; set; }
}

public enum SupportMédia { CARTOUCHE, CASSETTE, DISQUE, TÉLÉCHARGEMENT_NUMÉRIQUE }