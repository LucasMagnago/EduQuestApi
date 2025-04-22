using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.AddProfessor
{
    public class AddProfessorToTurmaValidator : AbstractValidator<RequestAddProfessorToTurmaJson>
    {
        public AddProfessorToTurmaValidator()
        {
            RuleFor(professorToTurma => professorToTurma.ProfessorId)
                   .NotEmpty()
                   .WithMessage("Professor é obrigatório");

            RuleFor(professorToTurma => professorToTurma.TurmaId)
                    .NotEmpty()
                    .WithMessage("Turma é obrigatória");

            RuleFor(professorToTurma => professorToTurma.DisciplinaId)
                    .NotEmpty()
                    .WithMessage("Disciplina é obrigatória");
        }
    }
}
