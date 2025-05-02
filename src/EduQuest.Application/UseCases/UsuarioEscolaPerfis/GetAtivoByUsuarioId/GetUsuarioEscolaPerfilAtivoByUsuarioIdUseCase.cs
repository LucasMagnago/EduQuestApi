using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.GetAtivoByUsuarioId
{
    internal class GetUsuarioEscolaPerfilAtivoByUsuarioIdUseCase : IGetUsuarioEscolaPerfilAtivoByUsuarioIdUseCase
    {
        private readonly IUsuarioEscolaPerfilRepository _usuarioEscolaPerfilRepository;
        private readonly IMapper _mapper;

        public GetUsuarioEscolaPerfilAtivoByUsuarioIdUseCase(IUsuarioEscolaPerfilRepository usuarioEscolaPerfilRepository,
            IMapper mapper)
        {
            _usuarioEscolaPerfilRepository = usuarioEscolaPerfilRepository;
            _mapper = mapper;
        }

        public async Task<ResponseShortUsuarioEscolaPerfilJson> Execute(int usuarioId)
        {
            var usuarioEscolaPerfil = await _usuarioEscolaPerfilRepository.GetActiveWithRelationsByUsuarioIdAsync(usuarioId);
            if (usuarioEscolaPerfil is null)
                throw new NotFoundException("Não foi encontrado nenhum vínculo ativo deste usuário nesta escola com este perfil.");

            return new ResponseShortUsuarioEscolaPerfilJson
            {
                Usuario = _mapper.Map<ResponseShortUsuarioJson>(usuarioEscolaPerfil.Usuario),
                Escola = _mapper.Map<ResponseShortEscolaJson>(usuarioEscolaPerfil.Escola),
                Perfil = _mapper.Map<ResponseShortPerfilJson>(usuarioEscolaPerfil.Perfil)
            };
        }
    }
}
