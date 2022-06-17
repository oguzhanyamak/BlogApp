using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("İsim Zorunludur");
            RuleFor(x => x.AuthorMail).EmailAddress().WithMessage("Mail Zorunludur");
            RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Şifre Zorunludur");
            RuleFor(x => x.AuthorPassword).Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.");
            RuleFor(x => x.AuthorPassword).Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.");
        }
    }
}
