using System.Linq.Expressions;
using System.Security.Principal;
using TgWorkshop.WebAPI.Models;

namespace TgWorkshop.WebAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> filter = null);
        Task<Product> Get(Expression<Func<Product, bool>> filter);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task Delete(Product product);
    }
}
