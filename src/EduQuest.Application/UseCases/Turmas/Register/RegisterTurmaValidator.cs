using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Turmas.Register
{
    public class RegisterTurmaValidator : AbstractValidator<RequestRegisterTurmaJson>
    {
        public RegisterTurmaValidator()
        {
            RuleFor(turma => turma.Descricao)
                .NotEmpty()
                .WithMessage("Descrição é obrigatória");

            RuleFor(turma => turma.Turno)
                .NotEmpty()
                .WithMessage("Turno é obrigatório");

            RuleFor(turma => turma.NivelEscolar)
                .NotEmpty()
                .WithMessage("Nível escolar é obrigatório");

            RuleFor(turma => turma.Ano)
                .NotEmpty()
                .WithMessage("Ano é obrigatório");

            RuleFor(turma => turma.EscolaId)
                .NotEmpty()
                .WithMessage("Escola é obrigatória");
        }
    }
}
