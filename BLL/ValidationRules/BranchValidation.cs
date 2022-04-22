using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationRules
{
    public class BranchValidation : AbstractValidator<Branch>
    {

        public BranchValidation()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Branş adı boş olamaz!");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Branş adı maksimum 20 karakterden oluşabilir!");



        }

    }
}
