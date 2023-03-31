using AspNetCoreMvc.Models;
using FluentValidation;

namespace AspNetCoreMvc.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=>p.ProductName).NotEmpty().WithMessage("Məhsul adı boş ola bilməz!");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Məhsul adı ən azı 2 simvoldan ibarət olmalıdır!");
            RuleFor(p => p.ProductName).MaximumLength(50).WithMessage("Məhsul adı ən çoxu 50 simvoldan ibarət ola bilər!");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kateqoriya seçin!");
        }
    }
}
