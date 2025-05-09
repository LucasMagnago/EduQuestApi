using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Usuarios.GetById
{
    internal class GetUsuarioByIdUseCase : IGetUsuarioByIdUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public GetUsuarioByIdUseCase(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<ResponseUsuarioJson> Execute(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario is null)
                throw new NotFoundException("Usuário não encontrado");

            return _mapper.Map<ResponseUsuarioJson>(usuario);
        }
    }
}
