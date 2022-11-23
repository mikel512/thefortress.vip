using System.ComponentModel.DataAnnotations;

namespace Api.Forms
{
    public class CityFormModel
    {
        [Required]
        [MaxLength(100)]
        public string? CityName { get; set; }

        [FileExtensions(Extensions ="jpg,jpeg,png")]
        [Required]
        public IFormFile? Image { get; set; }
    }
}
