using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.Assign
{
    public interface IAssingUserToSchoolWithRoleUseCase
    {
        Task<ResponseAssignedUsuarioJson> Execute(RequestAssignUsuarioJson request);
    }
}
