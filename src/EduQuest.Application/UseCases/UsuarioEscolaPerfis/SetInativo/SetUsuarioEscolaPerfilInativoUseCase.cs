using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.SetInativo
{
    internal class SetUsuarioEscolaPerfilInativoUseCase : ISetUsuarioEscolaPerfilInativoUseCase
    {
        private readonly IUsuarioEscolaPerfilRepository _usuarioEscolaPerfilRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SetUsuarioEscolaPerfilInativoUseCase(IUsuarioEscolaPerfilRepository usuarioEscolaPerfilRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _usuarioEscolaPerfilRepository = usuarioEscolaPerfilRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(RequestAssignUsuarioJson request)
        {
            var usuarioEscolaPerfil = await _usuarioEscolaPerfilRepository.GetByUsuarioIdAndEscolaIdAndPerfilIdAsync(request.UsuarioId, request.EscolaId, request.PerfilId);
            if (usuarioEscolaPerfil is null)
                throw new NotFoundException("Não foi encontrado nenhum vínculo ativo deste usuário nesta escola com este perfil.");

            usuarioEscolaPerfil.Ativo = false;

            await _usuarioEscolaPerfilRepository.UpdateAsync(usuarioEscolaPerfil);
            await _unitOfWork.Commit();
        }
    }
}
