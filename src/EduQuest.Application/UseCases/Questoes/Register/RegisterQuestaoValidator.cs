using EduQuest.Communication.Requests;
using FluentValidation;

namespace EduQuest.Application.UseCases.Questoes.Register
{
    public class RegisterQuestaoValidator : AbstractValidator<RequestRegisterQuestaoJson>
    {
        public RegisterQuestaoValidator()
        {
            RuleFor(questao => questao.Enunciado)
                .NotEmpty()
                .WithMessage("Enunciado é obrigatório");

            RuleFor(questao => questao.Resposta)
                .NotEmpty()
                .WithMessage("Resposta é obrigatória");

            RuleFor(questao => questao.NivelEscola)
                .NotEmpty()
                .WithMessage("Nível escolar é obrigatório");

            RuleFor(questao => questao.DisciplinaId)
                .NotEmpty()
                .WithMessage("Disciplina é obrigatório");
        }
    }
}
