using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.BatalhaRespostas.Answer
{
    internal class AlunoAnswerQuestaoFromBatalhaValidator : AbstractValidator<RequestAlunoAnswerQuestaoFromBatalhaJson>
    {
        public AlunoAnswerQuestaoFromBatalhaValidator()
        {
            RuleFor(answer => answer.AlunoId)
                .NotEmpty()
                .WithMessage("Aluno é obrigatório");

            RuleFor(answer => answer.BatalhaId)
                .NotEmpty()
                .WithMessage("Batalha é obrigatória");

            RuleFor(answer => answer.QuestaoId)
                .NotEmpty()
                .WithMessage("Questão obrigatória");

            RuleFor(answer => answer.AlternativaEscolhaId)
                .NotEmpty()
                .WithMessage("Alternativa é obrigatória");
        }
    }
}
