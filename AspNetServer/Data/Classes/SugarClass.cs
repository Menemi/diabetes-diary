using System.ComponentModel.DataAnnotations;

namespace AspNetServer.Data.Classes;

internal sealed class SugarClass
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double Sugar { get; set; }
    
    [Required]
    public string Time { get; set; } = string.Empty;
    
    [Required]
    public double InsulinIncreased { get; set; } = 0;
}