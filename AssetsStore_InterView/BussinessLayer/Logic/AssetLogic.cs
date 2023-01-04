using AssetsStore.Models;
using AssetsStore.Models.DataAcces.Helper;
using AssetsStore_InterView.BussinessLayer.Helper;
using AssetsStore_InterView.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Attribute = AssetsStore.Models.Attribute;

namespace AssetsStore_InterView.BussinessLayer.Logic
{
    public class AssetLogic : IAssetHelper
    {
        private readonly IRepositoryHelper<Asset> _repository;
        private readonly IMapper _Mapper;
        private readonly IAttributeHelper _Attrubite;
        public AssetLogic(IRepositoryHelper<Asset> repository, IAttributeHelper attribute, IMapper mapper)
        {
            _repository = repository;
            _Mapper = mapper;
            _Attrubite = attribute;

        }
        public AssetViewModel Create(AssetDetailViewModel assetDetail)
        {
            Asset asset = AssetDetailViewModel_MapTo_Asset(assetDetail);

            var AssetInserted = _repository.Insert(asset);
            if (AssetInserted is null)
                return null;

            if (_repository.SaveChange())
            {
                return Asset_MapTo_AssetViewModel(AssetInserted);
            }
            return null;

        }

        public bool Delete(int id)
        {
            if (_repository.delete(id))
                return _repository.SaveChange();
            return false;
        }


        public IEnumerable<AssetViewModel> GetAllAssets()
        {
            return _repository.GetAll().Select(a => Asset_MapTo_AssetViewModel(a));
        }

        public AssetDetailViewModel GetAssetDetail(int Id)
        {
            var assetDetail = _repository.SingleOrDefault(a => a.ID == Id, include: a => a.Include(asset => asset.Attributes));
            return Asset_MapTo_AssetDetailViewModdel(assetDetail);
        }

        public IEnumerable<AssetViewModel> SearchAsset(string Name)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
                return GetAllAssets();
            var assetDetail = _repository.Search(a => a.Name.Contains(Name.Trim()));
            return assetDetail.Select(a => Asset_MapTo_AssetViewModel(a));
        }

        public bool Update(AssetDetailViewModel assetdetail)
        {
            Asset NewAsset = AssetDetailViewModel_MapTo_Asset(assetdetail);

           var AttributeDeleted = _Attrubite.GetAll(ass => ass.AssetId == assetdetail.ID && !assetdetail.Attributes.Select(a => a.ID).Contains(ass.ID));

            AttributeDeleted.Select(AttDelted => NewAsset.Attributes.ToList().RemoveAll(a => a.ID == AttDelted.ID));
            if (AttributeDeleted.Count() == 0 || _Attrubite.RemoveRange(AttributeDeleted.Select(att => att.ID)))
            {
                
                if (_repository.update(NewAsset))
                    return _repository.SaveChange();
            }
            return false;
        }

       
        private AssetViewModel Asset_MapTo_AssetViewModel(Asset asset)
        {
            if (asset == null) return null;
            return _Mapper.Map<AssetViewModel>(asset);

        }
        private Asset AssetDetailViewModel_MapTo_Asset(AssetDetailViewModel assetDetail)
        {
            if (assetDetail == null) return null;
            return _Mapper.Map<Asset>(assetDetail);
        }
      
      


        private AssetDetailViewModel Asset_MapTo_AssetDetailViewModdel(Asset asset)
        {

            return _Mapper.Map<AssetDetailViewModel>(asset);
        }

       

    }
}
