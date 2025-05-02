using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.Unassign
{
    internal class UnassignUserToSchoolWithRoleUseCase : IUnassignUserToSchoolWithRoleUseCase
    {
        private readonly IUsuarioEscolaPerfilRepository _usuarioEscolaPerfilRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UnassignUserToSchoolWithRoleUseCase(IUsuarioEscolaPerfilRepository usuarioEscolaPerfilRepository,
            IUnitOfWork unitOfWork)
        {
            _usuarioEscolaPerfilRepository = usuarioEscolaPerfilRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseUnassignedUsuarioJson> Execute(RequestUnassignUsuarioJson request)
        {
            bool existVinculo = await _usuarioEscolaPerfilRepository.DoesUsuarioHavePerfilInEscolaAsync(request.UsuarioId, request.EscolaId, request.PerfilId);
            if (!existVinculo)
                throw new NotFoundException("Nenhum vínculo encontrado para este usuário nesta escola com este perfil"); // Alterar exception

            var usuarioEscolaPerfil = new UsuarioEscolaPerfil
            {
                UsuarioId = request.UsuarioId,
                EscolaId = request.EscolaId,
                PerfilId = request.PerfilId
            };

            await _usuarioEscolaPerfilRepository.DeleteAsync(usuarioEscolaPerfil);
            await _unitOfWork.Commit();

            return new ResponseUnassignedUsuarioJson
            {
                UsuarioId = request.UsuarioId,
                EscolaId = request.EscolaId,
                PerfilId = request.PerfilId,
                DeletedAt = DateTime.Now
            };
        }
    }
}
