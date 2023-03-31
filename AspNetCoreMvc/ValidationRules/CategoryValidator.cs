using AspNetCoreMvc.Models;
using FluentValidation;

namespace AspNetCoreMvc.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c=>c.CategoryName).NotEmpty().WithMessage("Kateqoriya adı boş ola bilməz!");
            RuleFor(c=>c.CategoryName).MinimumLength(2);
            RuleFor(c=>c.CategoryName).MaximumLength(50);
        }
    }
}
