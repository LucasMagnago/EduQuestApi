using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Atividades.GetAllByAlunoId
{
    public interface IGetAllAtividadeByAlunoIdUseCase
    {
        Task<List<ResponseAtividadeJson>> Execute(int alunoId);
    }
}
