
using Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api.Forms
{
    [FormGenerate]
    public class EventConcert
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string? FlyerUrl { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? PriceAmount { get; set; }
        public string? Time { get; set; }
    }
}
