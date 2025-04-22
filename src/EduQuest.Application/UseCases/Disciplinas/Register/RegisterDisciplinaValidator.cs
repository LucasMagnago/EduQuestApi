using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Disciplinas.Register
{
    public class RegisterDisciplinaValidator : AbstractValidator<RequestRegisterDisciplinaJson>
    {
        public RegisterDisciplinaValidator()
        {
            RuleFor(disciplina => disciplina.Descricao)
                .NotEmpty()
                .WithMessage("Descrição é obrigatória");

            RuleFor(disciplina => disciplina.Sigla)
                .NotEmpty()
                .WithMessage("Sigla é obrigatória");
        }
    }
}
