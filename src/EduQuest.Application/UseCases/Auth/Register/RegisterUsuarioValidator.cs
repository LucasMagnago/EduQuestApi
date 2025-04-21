using EduQuest.Application.UseCases.Usuarios;
using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Auth.Register
{
    public class RegisterUsuarioValidator : AbstractValidator<RequestRegisterUsuarioJson>
    {
        public RegisterUsuarioValidator()
        {
            RuleFor(usuario => usuario.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(usuario => usuario.DataNascimento)
                .NotEmpty()
                .WithMessage("Data de nascimento é obrigatória");

            RuleFor(usuario => usuario.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório")
                .EmailAddress()
                .When(usuario => string.IsNullOrWhiteSpace(usuario.Email) == false, ApplyConditionTo.CurrentValidator)
                .WithMessage("Email é invalido");

            RuleFor(usuario => usuario.Senha)
                .SetValidator(new PasswordValidator<RequestRegisterUsuarioJson>());

            RuleFor(usuario => usuario.IsAluno)
                .NotEmpty()
                .WithMessage("Deve ser informado se a conta é para aluno ou servidor");
        }
    }
}
