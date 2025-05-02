using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.GetAllByUsuarioId
{
    internal class GetAllUsuarioEscolaPerfilByUsuarioIdUseCase : IGetAllUsuarioEscolaPerfilByUsuarioIdUseCase
    {
        private readonly IUsuarioEscolaPerfilRepository _usuarioEscolaPerfilRepository;
        private readonly IMapper _mapper;

        public GetAllUsuarioEscolaPerfilByUsuarioIdUseCase(IUsuarioEscolaPerfilRepository usuarioEscolaPerfilRepository,
            IMapper mapper)
        {
            _usuarioEscolaPerfilRepository = usuarioEscolaPerfilRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseShortUsuarioEscolaPerfilJson>> Execute(int usuarioId)
        {
            var usuarioEscolaPerfis = await _usuarioEscolaPerfilRepository.GetAllWithRelationsByUsuarioIdAsync(usuarioId);
            if (usuarioEscolaPerfis is null)
                return new List<ResponseShortUsuarioEscolaPerfilJson>();

            return _mapper.Map<List<ResponseShortUsuarioEscolaPerfilJson>>(usuarioEscolaPerfis);
        }
    }
}

