using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.AtividadeQuestoes.Register
{
    public class AddQuestaoToAtividadeValidator : AbstractValidator<RequestAddQuestaoToAtividadeJson>
    {
        public AddQuestaoToAtividadeValidator()
        {
            RuleFor(questaoToAtividade => questaoToAtividade.QuestaoId)
                .NotEmpty()
                .WithMessage("Questão é obrigatória");

            RuleFor(questaoToAtividade => questaoToAtividade.QuestaoId)
                .GreaterThan(0)
                .WithMessage("QuestãoId deve ser maior que zero");

            RuleFor(questaoToAtividade => questaoToAtividade.AtividadeId)
                .NotEmpty()
                .WithMessage("Atividade é obrigatória");

            RuleFor(questaoToAtividade => questaoToAtividade.AtividadeId)
                .GreaterThan(0)
                .WithMessage("AtividadeId deve ser maior que zero");
        }
    }
}
