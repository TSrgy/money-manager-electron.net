using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.InitialBalance)
                .GreaterThanOrEqualTo(10); // TODO Check and replace to 0
        }
    }
}
