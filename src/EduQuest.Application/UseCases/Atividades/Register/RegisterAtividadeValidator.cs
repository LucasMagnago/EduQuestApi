using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Atividades.Register
{
    internal class RegisterAtividadeValidator : AbstractValidator<RequestRegisterAtividadeJson>
    {
        public RegisterAtividadeValidator()
        {
            RuleFor(atividade => atividade.Titulo)
                .NotEmpty()
                .WithMessage("Titulo é obrigatório");

            RuleFor(atividade => atividade.Descricao)
                .NotEmpty()
                .WithMessage("Descricao é obrigatória");

            RuleFor(atividade => atividade.Valor)
                .NotEmpty()
                .WithMessage("Valor obrigatório");

            RuleFor(atividade => atividade.TempoLimiteSegundos)
                .NotEmpty()
                .WithMessage("Tempo limite é obrigatório");

            RuleFor(atividade => atividade.ProfessorId)
                .NotEmpty()
                .WithMessage("Professor é obrigatório");
        }
    }
}
