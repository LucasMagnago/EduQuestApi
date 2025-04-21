using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Domain.Security.Cryptography;
using EduQuest.Domain.Security.Tokens;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Auth.Login
{
    internal class LoginUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IUsuarioEscolaPerfilRepository _usuarioEscolaPerfilRepository;
        private readonly IAccessTokenGenerator _tokenGenerator;

        public LoginUsuarioUseCase(IMapper mapper,
            IPasswordEncripter passwordEncripter,
            IUsuarioRepository usuarioRepository,
            //IMatriculaRepository matriculaRepository,
            //IUsuarioEscolaPerfilRepository usuarioEscolaPerfilRepository,
            IAccessTokenGenerator tokenGenerator)
        {
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _usuarioRepository = usuarioRepository;
            //_matriculaRepository = matriculaRepository;
            //_usuarioEscolaPerfilRepository = usuarioEscolaPerfilRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResponseLoggedUsuarioJson> Execute(RequestLoginUsuarioJson request)
        {
            var usuario = await _usuarioRepository.GetByEmail(request.Email);
            if (usuario is null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncripter.Verify(request.Senha, usuario.SenhaHash);
            if (passwordMatch == false)
            {
                throw new InvalidLoginException();
            }

            var response = new ResponseLoggedUsuarioJson
            {
                Nome = string.Empty,
                Token = string.Empty
            };

            var matricula = await _matriculaRepository.GetMatriculaAtivaByUsuarioId(usuario.Id);
            var perfis = await _usuarioEscolaPerfilRepository.GetAllByUsuarioIdAsync(usuario.Id);

            return new ResponseLoggedUsuarioJson
            {
                Nome = usuario.Nome,
                Token = _tokenGenerator.Generate(usuario, matricula, perfis)
            };
        }
    }
}
