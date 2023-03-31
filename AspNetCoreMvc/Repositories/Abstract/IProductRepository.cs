using AspNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMvc.Repositories.Abstract
{
    public interface IProductRepository
    {
        List<ProductDetailDto> GetProductDetails();
        List<SelectListItem> SelectCategoryItems();
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        Product GetProductById(int id);
    }
}
