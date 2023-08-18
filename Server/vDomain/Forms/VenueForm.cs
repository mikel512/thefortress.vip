using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using vDomain.Attributes;

namespace vDomain.Forms;

[FormGenerate]
public class VenueFormModel
{
    [Required]
    [MaxLength(100)]
    [MinLength(1)]
    public string VenueName { get; set; } = null!;

    [FileExtensions(Extensions = "jpg,jpeg,png")]
    [Required]
    public IFormFile? Picture { get; set; }

    [Required]
    public string Address { get; set; } = "";
    [Required]
    public string Description { get; set; } = "";
    public string? Location { get; set; }
    public string? TicketsLink { get; set; }
    public string? MenuLink { get; set; }
    public string? Hours { get; set; }


    [FieldIgnore]
    public int CityFk { get; set; }

}
