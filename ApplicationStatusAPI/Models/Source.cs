﻿using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace ApplicationStatusAPI.Models
{
    public class Source
    {
        public int SourceId { get; set; }
        [Required]
        public string SourceName { get; set; }       
    }
}
