using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AtividadeAlunos.Start
{
    public interface IAlunoStartsAtividadeUseCase
    {
        public Task<ResponseAtividadeAlunoJson> Execute(RequestAlunoStartsAtividadeJson request);
    }
}
