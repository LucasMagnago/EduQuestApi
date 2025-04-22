using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Matriculas.Matricular
{
    internal class RegisterMatriculaValidator : AbstractValidator<RequestRegisterMatriculaJson>
    {
        public RegisterMatriculaValidator()
        {
            RuleFor(Matricula => Matricula.AlunoId)
                .NotEmpty()
                .WithMessage("Aluno é obrigatório");

            RuleFor(Matricula => Matricula.TurmaId)
                .NotEmpty()
                .WithMessage("Turma é obrigatória");
        }
    }
}
