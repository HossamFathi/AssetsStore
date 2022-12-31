using Attribute = AssetsStore.Models.Attribute;
namespace AssetsStore_InterView.BussinessLayer.Helper
{
    public interface IAttributeHelper
    {
        bool Remove(int id);
        bool InsertRange(IEnumerable<Attribute> attribute);
    }
}
