using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Batalhas.Start
{
    internal class StartBatalhaValidator : AbstractValidator<RequestStartBatalhaJson>
    {
        public StartBatalhaValidator()
        {
            RuleFor(startBatalha => startBatalha.BatalhaId)
                .NotEmpty()
                .WithMessage("A batalha é obrigatória");
        }
    }
}
