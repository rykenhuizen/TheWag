using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWag.Models
{
    public record Vendor
    {
        public required string Name { get; init; }
        public required bool Reseller { get; init; }
    }
}
