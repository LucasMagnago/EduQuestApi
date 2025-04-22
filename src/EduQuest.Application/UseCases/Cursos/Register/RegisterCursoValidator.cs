using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Cursos.Register
{
    public class RegisterCursoValidator : AbstractValidator<RequestRegisterCursoJson>
    {
        public RegisterCursoValidator()
        {
            RuleFor(curso => curso.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(curso => curso.Descricao)
                .NotEmpty()
                .WithMessage("Descrição é obrigatória");
        }
    }
}
