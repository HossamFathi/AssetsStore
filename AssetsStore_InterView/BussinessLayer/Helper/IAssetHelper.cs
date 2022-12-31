using AssetsStore.Models;
using AssetsStore_InterView.ViewModel;

namespace AssetsStore_InterView.BussinessLayer.Helper
{
    public interface IAssetHelper 
    {
        IEnumerable<AssetViewModel> GetAllAssets();
        AssetDetailViewModel GetAssetDetail(int Id);
        IEnumerable<AssetViewModel> SearchAsset(string Name);
        bool Delete(int id);
        
        AssetViewModel Create(AssetDetailViewModel asset);
        bool Update(AssetDetailViewModel asset);

    }
}
