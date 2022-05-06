using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationRules
{
    public class AboutValidation : AbstractValidator<About>
    { 

        public AboutValidation()
        {

            RuleFor(x => x.topWriting).NotEmpty().WithMessage("Üst yazı boş olamaz!");
            RuleFor(x => x.rightWriting).NotEmpty().WithMessage("Sağ yazı boş olamaz!");
            RuleFor(x => x.topWriting).MaximumLength(120).WithMessage("Üst yazı maksimum 120 karakterden oluşabilir!");
            RuleFor(x => x.rightWriting).MaximumLength(300).WithMessage("Sağ yazı maksimum 300 karakterden oluşabilir!");



        }

    }
}
