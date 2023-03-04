using FluentValidation;
using Hair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Application.Validators
{
    internal class AddressValidator : AbstractValidator<AddressEntity>
    {
        public AddressValidator()
        {
            RuleFor(x => x.CEP).NotEmpty().NotNull().Length(8).WithName("CEP");

            RuleFor(x => x.Number).NotNull().NotEmpty().WithName("Número de endereço");

            RuleFor(x => x.City).NotNull().NotEmpty().WithName("Cidade");

            RuleFor(x => x.State).NotEmpty().NotNull().Length(2).WithName("Estado");
        }
    }
}