using AssetsStore.Models;
using Microsoft.EntityFrameworkCore;
using Attribute = AssetsStore.Models.Attribute;
using AssetsStore_InterView.ViewModel;

namespace AssetsStore_InterView.Models.DataAcces
{
    public class AssetContext : DbContext
    {
        IConfiguration _configuration;
        public AssetContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Asset> Assets { get; set; }
      public DbSet<Attribute> Attributes { get; set; }
     
    
    }
}
