 using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brand.Commands.CreateBrand
{
    public class CreateBrandValidator:AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Name).MinimumLength(3);
        }
    }
}
