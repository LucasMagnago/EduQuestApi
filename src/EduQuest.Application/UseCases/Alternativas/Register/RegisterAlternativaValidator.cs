using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Alternativas.Register
{
    internal class RegisterAlternativaValidator : AbstractValidator<RequestRegisterAlternativaJson>
    {
        public RegisterAlternativaValidator()
        {
            RuleFor(alternativa => alternativa.Texto)
                .NotEmpty()
                .WithMessage("Texto é obrigatório");

            RuleFor(alternativa => alternativa.Ordem)
                .NotEmpty()
                .WithMessage("Ordem é obrigatória");

            RuleFor(alternativa => alternativa.QuestaoId)
                .NotEmpty()
                .WithMessage("Questão é obrigatória");
        }
    }
}
