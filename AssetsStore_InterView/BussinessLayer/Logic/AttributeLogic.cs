using AssetsStore.Models.DataAcces.Helper;
using AssetsStore_InterView.BussinessLayer.Helper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
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

        public IEnumerable<Attribute> GetAll(Expression<Func<Attribute, bool>> predicate = null, Func<IQueryable<Attribute>, IOrderedQueryable<Attribute>> orderBy = null, Func<IQueryable<Attribute>, IIncludableQueryable<Attribute, object>> include = null, bool enableTracking = true)
        {
           return _Repository.Search(predicate, orderBy, include, enableTracking);
        }

        public bool InsertRange(IEnumerable<Attribute> attribute)
        {

            return _Repository.InsertRange(attribute);            
        }

        public bool RemoveRange(IEnumerable<int> IDs)
        {

          var IsDeleted =  IDs.Select(id => _Repository.delete(id)).ToList();
            return _Repository.SaveChange();
        }
    }
}
