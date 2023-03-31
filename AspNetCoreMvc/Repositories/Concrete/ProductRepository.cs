using AspNetCoreMvc.Models;
using AspNetCoreMvc.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMvc.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            using (Context context = new Context())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using(Context context = new Context())
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();  
            }
        }

        public Product GetProductById(int id)
        {
            using (Context context = new Context())
            {
                return context.Products.Find(id);
            }
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            using (Context context = new Context())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock,
                                 UnitPrice = p.UnitPrice,
                             };
                return result.ToList();
            }
        }

        public List<SelectListItem> SelectCategoryItems()
        {
            using (Context context = new Context())
            {
                var values = (from c in context.Categories.OrderBy(c => c.CategoryId).ToList()
                              select new SelectListItem
                              {
                                  Text = c.CategoryName,
                                  Value = c.CategoryId.ToString(),
                              }).ToList();

                return values;
            }
        }

        public void Update(Product product)
        {
            using (Context context = new Context())
            {
                context.Products.Update(product);
                context.SaveChanges();  
            }
        }
    }
}
