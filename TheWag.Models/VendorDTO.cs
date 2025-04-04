﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWag.Models
{
    public record VendorDTO
    {
        public int? Id { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
    }
}
