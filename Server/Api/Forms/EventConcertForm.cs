﻿
using Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api.Forms
{
    [FormGenerate]
    public class EventConcert
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string EventName { get; set; } = null!;
        [Required]
        public string? Flyer { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public string? Details { get; set; }
        public string? Price { get; set; }
        public string? EventTime { get; set; }
        public bool IsApproved { get; set; }

    }
}