using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Usuarios.GetAllByEscolaAndPerfilId
{
    internal class GetAllUsuarioByEscolaIdAndPerfilIdUseCase : IGetAllUsuarioByEscolaIdAndPerfilIdUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public GetAllUsuarioByEscolaIdAndPerfilIdUseCase(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseUsuarioJson>> Execute(int escolaId, int perfilId)
        {
            var usuarios = await _usuarioRepository.GetAllByPerfilIdAndEscolaId(perfilId, escolaId);
            if (usuarios is null || !usuarios.Any())
                throw new NotFoundException("Usuários não encontrados");

            return usuarios.Select(u => _mapper.Map<ResponseUsuarioJson>(u)).ToList();
        }
    }
}
