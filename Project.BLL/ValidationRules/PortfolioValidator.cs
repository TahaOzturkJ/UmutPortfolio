using FluentValidation;
using Project.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class PortfolioValidator: AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş geçilemez")
                                .MinimumLength(5).WithMessage("Proje adı en az 5 karakterden oluşmak zorundadır")
                                .MaximumLength(100).WithMessage("Proje adı en fazla 100 karakterden oluşmak zorundadır");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat değeri boş geçilemez");
            RuleFor(x => x.Condition).NotEmpty().WithMessage("Tamamlanma oranı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez");

        }
    }
}
