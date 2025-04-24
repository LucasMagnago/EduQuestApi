using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Atividades.GetAllAvailableByAlunoId
{
    public interface IGetAllAvailableAtividadeByAlunoIdUseCase
    {
        Task<List<ResponseAtividadeJson>> Execute(int alunoId);
    }
}
