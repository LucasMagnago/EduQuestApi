using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.Unassign
{
    public interface IUnassignUserToSchoolWithRoleUseCase
    {
        Task<ResponseUnassignedUsuarioJson> Execute(RequestUnassignUsuarioJson request);
    }
}
