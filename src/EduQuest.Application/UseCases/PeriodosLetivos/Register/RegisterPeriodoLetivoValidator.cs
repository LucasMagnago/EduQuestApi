using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.PeriodosLetivos.Register
{
    public class RegisterPeriodoLetivoValidator : AbstractValidator<RequestRegisterPeriodoLetivoJson>
    {
        public RegisterPeriodoLetivoValidator()
        {
            RuleFor(periodoLetivo => periodoLetivo.Ano)
                .NotEmpty()
                .WithMessage("Ano é obrigatório");

            RuleFor(periodoLetivo => periodoLetivo.DataInicio)
                .NotEmpty()
                .WithMessage("Data inicial é obrigatória");

            RuleFor(periodoLetivo => periodoLetivo.DataFim)
                .NotEmpty()
                .WithMessage("Data final é obrigatória");

            RuleFor(periodoLetivo => periodoLetivo.Ativo)
                .NotEmpty()
                .WithMessage("É necessário informar se deseja ativar o periodo letivo");

            RuleFor(periodoLetivo => periodoLetivo.EscolaId)
                .NotEmpty()
                .WithMessage("Escola é obrigatória");
        }
    }
}
