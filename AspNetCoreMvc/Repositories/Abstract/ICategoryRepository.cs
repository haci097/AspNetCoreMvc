using AspNetCoreMvc.Models;

namespace AspNetCoreMvc.Repositories.Abstract
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        void Add(Category category);
        void Delete(Category category);
        Category GetCategoryById(int id);   
        void Update(Category category);
        List<Product> GetDetails(int id);   
    }
}
