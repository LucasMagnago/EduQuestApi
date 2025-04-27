using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AtividadeRespostas.Answer
{
    public interface IAlunoAnswerQuestaoFromAtividadeUseCase
    {
        Task<ResponseAtividadeRespostaJson> Execute(RequestAlunoAnswerQuestaoFromAtividadeJson request);
    }
}
