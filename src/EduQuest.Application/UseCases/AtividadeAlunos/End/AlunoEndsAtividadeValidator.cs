using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.AtividadeAlunos.End
{
    internal class AlunoEndsAtividadeValidator : AbstractValidator<RequestAlunoEndsAtividadeJson>
    {
        public AlunoEndsAtividadeValidator()
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
