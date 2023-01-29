namespace AssetsStore_InterView.ViewModel
{
    public class AssetDetailViewModel
    {
        
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<AttributeViewModel> Attributes { get; set; }
        public AssetDetailViewModel()
        {
            Attributes =  new List<AttributeViewModel>();
        }
    }
}
