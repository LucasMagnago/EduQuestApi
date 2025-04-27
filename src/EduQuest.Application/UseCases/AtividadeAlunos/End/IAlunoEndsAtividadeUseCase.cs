using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AtividadeAlunos.End
{
    public interface IAlunoEndsAtividadeUseCase
    {
        Task<ResponseAtividadeAlunoJson> Execute(RequestAlunoEndsAtividadeJson request);
    }
}
