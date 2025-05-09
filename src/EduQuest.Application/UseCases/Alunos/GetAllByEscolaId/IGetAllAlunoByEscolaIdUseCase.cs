using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Alunos.GetAllByEscolaId
{
    public interface IGetAllAlunoByEscolaIdUseCase
    {
        Task<List<ResponseShortAlunoJson>> Execute(int escolaId);
    }
}
