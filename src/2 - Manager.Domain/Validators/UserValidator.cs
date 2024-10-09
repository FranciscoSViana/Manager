using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade n�o pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade n�o pode ser nula.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome n�o pode ser vazio")

                .NotNull()
                .WithMessage("O nome n�o pode ser nulo")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no m�nimo 3 caracteres")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no m�ximo 80 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail n�o pode ser vazio")

                .NotNull()
                .WithMessage("O e-mail n�o pode ser nulo")

                .MinimumLength(10)
                .WithMessage("O e-mail deve ter no m�nimo 10 caracteres")

                .MaximumLength(180)
                .WithMessage("O e-mail deve ter no m�ximo 180 caracteres")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O e-mail informado n�o � v�lido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha n�o pode ser vazio")

                .NotNull()
                .WithMessage("A senha n�o pode ser nulo")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no m�nimo 6 caracteres")

                .MaximumLength(80)
                .WithMessage("A senha deve ter no m�ximo 80 caracteres");
        }
    }
}