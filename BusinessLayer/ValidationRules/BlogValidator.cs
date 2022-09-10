using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz!");
        }
    }
}
