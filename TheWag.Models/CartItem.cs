using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWag.Models
{
    public record CartItem
    {
        public required Product Product { get; init; }
        public required int Quantity { get; init; }
    }
}
