using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationRules
{
    public class HospitalValidation : AbstractValidator<Hospital>
    {

        public HospitalValidation()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Hastane adı boş olamaz!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Hastane adı maksimum 30 karakterden oluşabilir!");


        }


    }
}
