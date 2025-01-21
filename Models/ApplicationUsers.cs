using System.ComponentModel.DataAnnotations;

namespace SelfServicePortal.Models;

public class ApplicationUsers
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    public string? Appgroup { get; set; }
    public string? AdGroup { get; set; }
}