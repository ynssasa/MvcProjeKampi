using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soy adı boş geçilemez.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda boş geçilemez.");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapınız.");
            RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Hakkında kısmında en az bir a harfi bulunmalıdır.");
        }

        private bool IsAboutValid(string arg)
        {
            var IsTrue = arg.Contains("a");
            if(IsTrue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
