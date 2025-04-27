using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Questoes.SetCorrectAlternativa
{
    public class SetQuestaoCorrectAlternativaValidator : AbstractValidator<RequestSetQuestaoCorrectAlternativaJson>
    {
        public SetQuestaoCorrectAlternativaValidator()
        {
            RuleFor(questao => questao.AlternativaId)
                .NotEmpty()
                .WithMessage("Alternativa é obrigatória");

            RuleFor(questao => questao.AlternativaId)
                .GreaterThan(0)
                .WithMessage("AlternativaId deve ser maior que zero");
        }
    }
}
