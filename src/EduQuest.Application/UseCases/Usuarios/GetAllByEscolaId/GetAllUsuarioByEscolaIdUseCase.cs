using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Usuarios.GetAllByEscolaId
{
    internal class GetAllUsuarioByEscolaIdUseCase : IGetAllUsuarioByEscolaIdUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public GetAllUsuarioByEscolaIdUseCase(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<List<ResponseUsuarioJson>> Execute(int escolaId)
        {
            var usuarios = await _usuarioRepository.GetAllByEscolaId(escolaId);
            if (usuarios is null || !usuarios.Any())
                throw new NotFoundException("Usuários não encontrados");

            return usuarios.Select(u => _mapper.Map<ResponseUsuarioJson>(u)).ToList();
        }
    }
}
