using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Turmas.RemoveAluno
{
    public class RemoveAlunoFromTurmaValidator : AbstractValidator<RequestRemoveAlunoFromTurmaJson>
    {
        public RemoveAlunoFromTurmaValidator()
        {
            RuleFor(alunoToTurma => alunoToTurma.AlunoId)
                .NotEmpty()
                .WithMessage("Aluno é obrigatório");

            RuleFor(alunoToTurma => alunoToTurma.TurmaId)
                .NotEmpty()
                .WithMessage("Turma é obrigatório");
        }
    }
}
