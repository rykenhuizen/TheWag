using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWag.Models
{
    public record Cart
    {
        public required IList<CartItem> Items { get; init; }
        public required Customer Customer { get; init; }
        public required Promo[]? Promo { get; init; }
    }
}
