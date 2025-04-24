using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.AtividadeTurmas.Assign
{
    public class AssignAtividadeToTurmaValidator : AbstractValidator<RequestAssignAtividadeToTurmaJson>
    {
        public AssignAtividadeToTurmaValidator()
        {
            RuleFor(atividadeToTurma => atividadeToTurma.AtividadeId)
                .NotEmpty()
                .WithMessage("Atividade é obrigatória");

            RuleFor(atividadeToTurma => atividadeToTurma.TurmaId)
                .NotEmpty()
                .WithMessage("Turma é obrigatória");

            RuleFor(atividadeToTurma => atividadeToTurma.DisciplinaId)
                .NotEmpty()
                .WithMessage("Disciplina é obrigatória");

            RuleFor(atividadeToTurma => atividadeToTurma.DataAtribuicao)
                .NotEmpty()
                .WithMessage("Data de atribuicao é obrigatória");

            RuleFor(atividadeToTurma => atividadeToTurma.DataEntrega)
                .NotEmpty()
                .WithMessage("Data de entrega é obrigatória");
        }
    }
}
