using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Batalhas.Register
{
    internal class RegisterBatalhaValidator : AbstractValidator<RequestRegisterBatalhaJson>
    {
        public RegisterBatalhaValidator()
        {
            RuleFor(batalha => batalha.TempoLimiteSegundos)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("O tempo limite é obrigatório e deve ser maior que zero");
        }
    }
}
