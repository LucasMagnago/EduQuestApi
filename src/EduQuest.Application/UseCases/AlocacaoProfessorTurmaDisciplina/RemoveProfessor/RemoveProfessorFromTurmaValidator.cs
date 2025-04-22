using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.RemoveProfessor
{
    public class RemoveProfessorFromTurmaValidator : AbstractValidator<RequestRemoveProfessorFromTurmaJson>
    {
        public RemoveProfessorFromTurmaValidator()
        {
            RuleFor(professorFromTurma => professorFromTurma.ProfessorId)
                .NotEmpty()
                .WithMessage("Professor é obrigatório");

            RuleFor(professorFromTurma => professorFromTurma.TurmaId)
                .NotEmpty()
                .WithMessage("Turma é obrigatória");

            RuleFor(professorFromTurma => professorFromTurma.DisciplinaId)
                .NotEmpty()
                .WithMessage("Disciplina é obrigatória");
        }
    }
}
