using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.AtividadeAlunos.Start
{
    internal class AlunoStartsAtividadeValidator : AbstractValidator<RequestAlunoStartsAtividadeJson>
    {
        public AlunoStartsAtividadeValidator()
        {
            RuleFor(AlunoStartsAtividade => AlunoStartsAtividade.AtividadeId)
                .NotEmpty()
                .WithMessage("Atividade é obrigatória");

            RuleFor(AlunoStartsAtividade => AlunoStartsAtividade.AlunoId)
                .NotEmpty()
                .WithMessage("Aluno é obrigatório");
        }
    }
}
