using System.ComponentModel.DataAnnotations;

namespace AspNetServer.Data.Classes;

internal sealed class CatheterClass
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Time { get; set; } = string.Empty;
}