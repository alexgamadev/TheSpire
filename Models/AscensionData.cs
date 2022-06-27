using System.ComponentModel.DataAnnotations;

namespace TheSpire.Models;

public class AscensionData
{
    [Required]
    [Key]
    public int id;

    [Required]
    public float ascensionDuration;
}