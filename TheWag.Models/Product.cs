using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWag.Models
{
    public record Product
    {
        public required int Id { get; init; }
        public required string URL { get; init; }
        public required decimal Price { get; init; }
        public required int Stock { get; init; }
        public required string Description { get; init; }
        public IList<string> Tags { get; init; } = []; 
    }
}
