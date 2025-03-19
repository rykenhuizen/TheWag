

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheWag.Api.WagDB.EFModels
{
    public class Product_Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Tag { get; init; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
