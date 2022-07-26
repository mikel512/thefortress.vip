﻿using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Artist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public string? Tour { get; set; }
        public string? Picture { get; set; }
        public string? PlaylistEmbed { get; set; }
    }
}
