using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Usuarios.Register
{
    public class RegisterUsuarioValidator : AbstractValidator<RequestRegisterUsuarioJson>
    {
        public RegisterUsuarioValidator()
        {
            RuleFor(user => user.Nome)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
                .WithMessage("Email is invalid");

            RuleFor(user => user.Senha)
                .SetValidator(new PasswordValidator<RequestRegisterUsuarioJson>());
        }
    }
}
