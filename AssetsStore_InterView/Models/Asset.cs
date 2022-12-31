using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace AssetsStore.Models
{
    public class Asset
    {
        public int ID { get; set; }
        [Required]
        
        public string  Name { get; set; }
        public IEnumerable<Attribute> Attributes { get; set; }
    }
}
