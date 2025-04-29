using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Batalhas.AddAluno
{
    internal class AddAlunoToBatalhaValidator : AbstractValidator<RequestAddAlunoToBatalhaJson>
    {
        public AddAlunoToBatalhaValidator()
        {
            RuleFor(alunoToBatalha => alunoToBatalha.AlunoId)
                .NotEmpty()
                .WithMessage("Aluno é obrigatório");

            RuleFor(alunoToBatalha => alunoToBatalha.BatalhaId)
                .NotEmpty()
                .WithMessage("Batalha é obrigatória");
        }
    }
}