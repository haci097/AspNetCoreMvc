using AspNetCoreMvc.Models;
using FluentValidation;

namespace AspNetCoreMvc.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c=>c.CategoryName).NotEmpty().WithMessage("Kateqoriya adı boş ola bilməz!");
            RuleFor(c=>c.CategoryName).MinimumLength(2).WithMessage("Kateqoriya adı ən azı 2 simvoldan ibarət olmalıdır!");
            RuleFor(c=>c.CategoryName).MaximumLength(50).WithMessage("Kateqoriya adı ən çoxu 50 simvoldan ibarət ola bilər!");
        }
    }
}
