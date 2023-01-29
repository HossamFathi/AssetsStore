namespace AssetsStore_InterView.ViewModel
{
    public class AttributeViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int AssetId { get; set; }
    }
}
