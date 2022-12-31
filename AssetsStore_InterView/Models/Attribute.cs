using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetsStore.Models
{
    public class Attribute
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string  Name { get; set; }
        public string Description { get; set; }
        public int AssetId { get; set; }
        [ForeignKey(nameof(AssetId))]
        public Asset Asset { get; set; }
    }
}
