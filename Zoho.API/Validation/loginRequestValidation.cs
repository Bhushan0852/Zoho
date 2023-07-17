using FluentValidation;
using Zoho.DTOs;

namespace Zoho.API.Validation
{
    public class loginRequestValidation : AbstractValidator<LoginRequestDTO>
    {
        public loginRequestValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Please enter a valid Name");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Please enter a valid Password");
        }
    }
}
