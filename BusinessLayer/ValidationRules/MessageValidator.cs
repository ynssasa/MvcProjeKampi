using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresi boş geçilemez.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adı boş geçilemez.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj boş geçilemez.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
        }
    }
}
