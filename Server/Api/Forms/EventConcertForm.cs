
using Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api.Forms
{
    [FormGenerate]
    public class EventConcertFormModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string EventName { get; set; } = null!;

        [FileExtensions(Extensions ="jpg,jpeg,png")]
        [Required]
        public IFormFile? Flyer { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public string? Details { get; set; }
        public string? Price { get; set; }
        public string? EventTime { get; set; }
        public bool IsApproved { get; set; }

    }
}
