using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace vApplication.Forms;

public class CityFormModel
{
    [Required]
    [MaxLength(100)]
    public string? CityName { get; set; }

    [FileExtensions(Extensions = "jpg,jpeg,png")]
    [Required]
    public IFormFile? Image { get; set; }
}
