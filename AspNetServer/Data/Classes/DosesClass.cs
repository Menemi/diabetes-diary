using System.ComponentModel.DataAnnotations;

namespace AspNetServer.Data.Classes;

internal sealed class DosesClass
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double Dose { get; set; }
    
    [Required]
    public string StartTime { get; set; } = string.Empty;
    
    [Required]
    public string EndTime { get; set; } = string.Empty;
}