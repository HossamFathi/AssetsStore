using AssetsStore.Models.DataAcces.Helper;
using AssetsStore_InterView.BussinessLayer.Helper;
using Attribute = AssetsStore.Models.Attribute;
namespace AssetsStore_InterView.BussinessLayer.Logic
{
    public class AttributeLogic : IAttributeHelper
    {
        private readonly IRepositoryHelper<Attribute> _Repository;
        public AttributeLogic(IRepositoryHelper<Attribute> repository)
        {
            _Repository = repository;
        }
        public bool InsertRange(IEnumerable<Attribute> attribute)
        {

            return _Repository.InsertRange(attribute);            
        }

        public bool Remove(int ID)
        {
            return _Repository.delete(ID);
        }
    }
}
