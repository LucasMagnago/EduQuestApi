using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.AtividadeRespostas.Answer
{
    internal class AlunoAnswerQuestaoFromAtividadeValidator : AbstractValidator<RequestAlunoAnswerQuestaoFromAtividadeJson>
    {
        public AlunoAnswerQuestaoFromAtividadeValidator()
        {
            RuleFor(AlunoAnswerQuestao => AlunoAnswerQuestao.AlunoId)
                .NotEmpty()
                .WithMessage("Aluno é obrigatório");

            RuleFor(AlunoAnswerQuestao => AlunoAnswerQuestao.AtividadeId)
                .NotEmpty()
                .WithMessage("Atividade é obrigatória");

            RuleFor(AlunoAnswerQuestao => AlunoAnswerQuestao.QuestaoId)
                .NotEmpty()
                .WithMessage("Questão é obrigatória");

            RuleFor(AlunoAnswerQuestao => AlunoAnswerQuestao.AlternativaEscolhaId)
                .NotEmpty()
                .WithMessage("Alternativa escolhida é obrigatória");
        }
    }
}
