using AssetsStore.Models;
using AssetsStore_InterView.ViewModel;
using AutoMapper;
using Attribute = AssetsStore.Models.Attribute;
namespace AssetsStore_InterView.BussinessLayer.Logic
{
    public class Mapping :Profile 
    {
        public Mapping()
        {

            CreateMap<Asset, AssetViewModel>().ReverseMap();
            CreateMap<Asset, AssetDetailViewModel>().ReverseMap();
            CreateMap<Attribute, AttributeViewModel>().ReverseMap();
            
        }
    }
}
