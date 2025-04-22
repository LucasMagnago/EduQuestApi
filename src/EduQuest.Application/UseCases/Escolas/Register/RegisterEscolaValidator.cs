using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Escolas.Register
{
    public class RegisterEscolaValidator : AbstractValidator<RequestRegisterEscolaJson>
    {
        public RegisterEscolaValidator()
        {
            RuleFor(escola => escola.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(escola => escola.Sigla)
                .NotEmpty()
                .WithMessage("Sigla é obrigatória");

            RuleFor(escola => escola.Inep)
                .NotEmpty()
                .WithMessage("Código inep obrigatório");

            RuleFor(escola => escola.Telefone)
                .NotEmpty()
                .WithMessage("Telefone é obrigatório");

            RuleFor(escola => escola.TipoUnidadeId)
                .NotEmpty()
                .WithMessage("O tipo de escola é obrigatório");
        }
    }
}
