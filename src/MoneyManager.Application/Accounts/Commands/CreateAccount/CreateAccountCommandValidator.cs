using FluentValidation;

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
                .GreaterThanOrEqualTo(0);
        }
    }
}
