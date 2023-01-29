using Microsoft.EntityFrameworkCore;

namespace AssetsStore.Models
{
    [Index(nameof(Name))]
    public class Asset
    {
        public int ID { get; set; }
        [Required]
        public string  Name { get; set; }
        public IEnumerable<Attribute> Attributes { get; set; }
    }
}
