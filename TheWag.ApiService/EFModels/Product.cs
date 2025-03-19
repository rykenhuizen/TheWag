

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheWag.Api.WagDB.EFModels
{
    public record Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public required string URL { get; init; }
        public required decimal Price { get; init; }
        public required int Stock { get; init; }
        public required string Description { get; init; }
        public required ICollection<Product_Tag> Tags { get; init; } 
    }
}
