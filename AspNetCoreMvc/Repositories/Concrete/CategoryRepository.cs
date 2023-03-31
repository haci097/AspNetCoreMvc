using AspNetCoreMvc.Models;
using AspNetCoreMvc.Repositories.Abstract;

namespace AspNetCoreMvc.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Add(Category category)
        {
            using (Context context = new Context())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void Delete(Category category)
        {
            using (Context context = new Context())
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            using (Context context = new Context())
            {
                var result = context.Categories.OrderBy(c=>c.CategoryId).ToList();
                return result;
            }
        }

        public Category GetCategoryById(int id)
        {
            using (Context context = new Context())
            {
                return context.Categories.Find(id);
            }
        }

        public List<Product> GetDetails(int id)
        {
            using (Context context = new Context())
            {
                return context.Products.Where(p => p.CategoryId == id).ToList();
            }
        }

        public void Update(Category category)
        {
            using (Context context = new Context())
            {
                context.Categories.Update(category);
                context.SaveChanges();  
            }
        }
    }
}
