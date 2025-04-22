using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Turmas.AddAluno
{
    public class AddAlunoToTurmaValidator : AbstractValidator<RequestAddAlunoToTurmaJson>
    {
        public AddAlunoToTurmaValidator()
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
