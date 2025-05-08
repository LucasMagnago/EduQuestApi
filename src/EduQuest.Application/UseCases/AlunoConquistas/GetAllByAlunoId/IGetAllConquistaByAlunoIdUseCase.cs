using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AlunoConquistas.GetAllByAlunoId
{
    public interface IGetAllConquistaByAlunoIdUseCase
    {
        Task<List<ResponseAlunoConquistaJson>> Execute(int alunoId);
    }
}
