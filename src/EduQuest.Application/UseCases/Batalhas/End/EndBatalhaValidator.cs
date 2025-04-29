using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Batalhas.End
{
    internal class EndBatalhaValidator : AbstractValidator<RequestEndBatalhaJson>
    {
        public EndBatalhaValidator()
        {
            RuleFor(endBatalha => endBatalha.BatalhaId)
                .NotEmpty()
                .WithMessage("A batalha é obrigatória");
        }
    }
}
