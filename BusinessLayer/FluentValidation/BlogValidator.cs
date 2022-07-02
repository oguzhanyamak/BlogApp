using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik Girmeniz Gerekmektedir.");

        }
    }
}
