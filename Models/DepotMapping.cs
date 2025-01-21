using System.ComponentModel.DataAnnotations;

namespace SelfServicePortal.Models;

public class DepotMapping
{
    public int Id { get; set; }
    public int ADGroup { get; set; }
    public string? Depot { get; set; }

}