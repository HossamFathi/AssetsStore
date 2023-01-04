using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Attribute = AssetsStore.Models.Attribute;
namespace AssetsStore_InterView.BussinessLayer.Helper
{
    public interface IAttributeHelper
    {
        bool RemoveRange(IEnumerable<int> ids);
        bool InsertRange(IEnumerable<Attribute> attribute);
        IEnumerable<Attribute> GetAll(Expression<Func<Attribute, bool>> predicate = null,
            Func<IQueryable<Attribute>, IOrderedQueryable<Attribute>> orderBy = null,
            Func<IQueryable<Attribute>, IIncludableQueryable<Attribute, object>> include = null,
            bool enableTracking = true);
    }
}
