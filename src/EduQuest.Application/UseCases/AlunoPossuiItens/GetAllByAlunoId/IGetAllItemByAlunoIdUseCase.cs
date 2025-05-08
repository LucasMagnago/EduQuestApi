using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AlunoPossuiItens.GetAllByAlunoId
{
    public interface IGetAllItemByAlunoIdUseCase
    {
        Task<List<ResponseShortAlunoPossuiItemJson>> Execute(int alunoId);
    }
}
