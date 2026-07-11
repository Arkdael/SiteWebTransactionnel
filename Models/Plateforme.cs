namespace SiteWebTransactionnel.Models;

/** */
public class Plateforme
{
    public int Id { get; set; }
    public required string Nom { get; set; }
    public string Manufacturier { get; set; } = "";
}
