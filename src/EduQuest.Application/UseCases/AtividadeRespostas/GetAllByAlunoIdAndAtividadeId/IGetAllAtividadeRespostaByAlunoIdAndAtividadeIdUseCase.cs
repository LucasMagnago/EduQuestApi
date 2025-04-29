using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AtividadeRespostas.GetAllByAlunoIdAndAtividadeId
{
    public interface IGetAllAtividadeRespostaByAlunoIdAndAtividadeIdUseCase
    {
        Task<IEnumerable<ResponseAtividadeRespostaJson>> Execute(int alunoId, int atividadeId);
    }
}
