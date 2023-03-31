using AspNetCoreMvc.Logging;
using AspNetCoreMvc.Models;
using AspNetCoreMvc.Repositories.Abstract;
using AspNetCoreMvc.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<Category> _validator;
        public CategoryController(ICategoryRepository categoryRepository, IValidator<Category> validator)
        {
            _categoryRepository = categoryRepository;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _categoryRepository.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCategory(Category category)
        {
            var validationResult = _validator.Validate(category);

            if (validationResult.IsValid)
            {
                _categoryRepository.Add(category);
                TempData["notification"] = Notification.BasicNotification("Kateqoriya uğurla əlavə olundu", NotificationType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ViewData["ValidationResults"] = item.ErrorMessage;
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            return PartialView("_DeleteCategoryPartial", category);
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            try
            {
                _categoryRepository.Delete(category);
                TempData["notification"] = Notification.BasicNotification("Kateqoriya uğurla silindi", NotificationType.Success);
                FileLogger.Log("DeleteCategory", "Kateqoriya silindi. CategoryId = " + category.CategoryId);
            }
            catch (Exception ex)
            {
                TempData["notification"] = Notification.BasicNotification("Xəta baş verdi: " + ex.Message, NotificationType.Error);
                FileLogger.Log("DeleteCategory", "Xəta baş verdi: " + ex.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return View("GetCategoryById", category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            var updatedCategory = _categoryRepository.GetCategoryById(category.CategoryId);
            updatedCategory.CategoryName = category.CategoryName;

            var validationResult = _validator.Validate(category);

            if (validationResult.IsValid)
            {
                _categoryRepository.Update(updatedCategory);
                TempData["notification"] = Notification.BasicNotification("Kateqoriya uğurla redaktə edildi", NotificationType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ViewData["ValidationResults"] = item.ErrorMessage;
                }
            }

            return View("GetCategoryById");
        }

        [HttpGet]
        public IActionResult GetDetails(int id)
        {
            var values = _categoryRepository.GetDetails(id);    
            return View(values);
        }
    }
}
