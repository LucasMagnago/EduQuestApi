using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AlunoPossuiItens.Acquire
{
    public interface IAlunoAcquireItemUseCase
    {
        Task<ResponseShortAlunoPossuiItemJson> Execute(RequestAlunoAcquireItemJson request);
    }
}
