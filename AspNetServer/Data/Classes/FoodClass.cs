using System.ComponentModel.DataAnnotations;

namespace AspNetServer.Data.Classes;

internal sealed class FoodClass
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double Dose { get; set; }

    [Required]
    public string Time { get; set; } = string.Empty;

    [Required]
    public double BreadUnits { get; set; }
    
    [Required]
    public double InsulinPinned { get; set; }

    [Required]
    public string FoodName { get; set; } = string.Empty;
}