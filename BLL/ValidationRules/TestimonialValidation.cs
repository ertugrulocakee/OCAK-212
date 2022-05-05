using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationRules
{
    public class TestimonialValidation : AbstractValidator<Testimonial>
    {
        public TestimonialValidation() {
            RuleFor(x => x.description).NotEmpty().WithMessage("Açıklamanız boş olamaz!");
            RuleFor(x => x.description).MaximumLength(120).WithMessage("Açıklamanız maksimum 120 karakterden oluşabilir!");
        }

    }
}
