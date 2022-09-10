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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail kısmı boş geçilemez!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez!");
            RuleFor(x => x.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifre en az bir adet büyük karakter içermelidir!");
            RuleFor(x => x.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifre en az bir adet küçük karakter içermelidir!");
            RuleFor(x => x.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifre en az bir adet sayı içermelidir!");
            RuleFor(x => x.WriterPassword).Matches(@"[\!\?\*\.]+").WithMessage("Şifre en az bir adet özel karakter içermelidir!(!? *.).");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az iki karakter girmelisiniz!");
        }
    }
}
