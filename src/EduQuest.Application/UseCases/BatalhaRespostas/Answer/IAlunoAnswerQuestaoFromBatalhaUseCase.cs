using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.BatalhaRespostas.Answer
{
    public interface IAlunoAnswerQuestaoFromBatalhaUseCase
    {
        Task<ResponseBatalhaRespostaJson> Execute(RequestAlunoAnswerQuestaoFromBatalhaJson request);
    }
}
