using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Batalhas.GetById
{
    public interface IGetBatalhaByIdUseCase
    {
        Task<ResponseBatalhaJson> Execute(int id);
    }
}
